using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinder
{
    public class Path
    {
        // ========== Fields ========== //
        private Node startingNode;
        private Node destinationNode;

        // ========== Constructors ========== //
        public Path(Node startNode, Node endNode)
        {
            this.startingNode = startNode;
            this.destinationNode = endNode;
            this.Connections = new Connections();
        }
        public Path(Connection connection) : this(connection.StartNode, connection.EndNode)
        {
            this.Connections.Add(connection);
            this.Value = connection.Value;
        }

        // ========== Properties ========== //
        public int Value
        { get; private set; }
        public Connections Connections
        { get; private set; }

        // ========== Methods ========== //
        public void FindOptimalPath(Connections network, Nodes? visited = null)
        {
            Connections branches = network.GetConnections(this.startingNode, visited);
            if (branches.Count == 0)
            {
                this.Value = -1;
            }
            else
            {
                Path? bestPath = null;
                foreach (Connection connection in branches)
                {
                    if (connection.ConnectsTo(this.destinationNode))
                    {
                        Path candidatePath = new Path(connection);
                        if (IsBetterPath(candidatePath, bestPath)) bestPath = candidatePath;
                    }
                    else
                    {
                        Nodes subVisited = new();
                        if (visited != null) subVisited = visited.Copy();
                        subVisited.Add(this.startingNode);

                        Path candidatePath = new Path(connection.EndNode, this.destinationNode);
                        candidatePath.FindOptimalPath(network, subVisited);
                        if (candidatePath.Value > 0)
                        {
                            candidatePath.Prepend(connection);
                            if (IsBetterPath(candidatePath, bestPath)) bestPath = candidatePath;
                        }
                    }
                }

                if (bestPath != null) this.Append(bestPath);
            }
        }

        public void Prepend(Connection connection)
        {
            this.Connections.Insert(0, connection);
            this.Value += connection.Value;
        }
        public void Append(Connection connection)
        {
            this.Connections.Add(connection);
            this.Value += connection.Value;
        }
        public void Append(Path pathToAppend)
        {
            this.Connections.AddRange(pathToAppend.Connections);
            this.Value += pathToAppend.Value;
        }

        private static bool IsBetterPath(Path candidate, Path? pathToBeat)
        {
            return candidate.Value > 0 && (pathToBeat == null || candidate.Value > pathToBeat.Value);
        }

        public string Trace()
        {
            return String.Join(" -> ", this.Connections);
        }

        public override string ToString()
        {
            return $"Path {this.startingNode} -[{this.Value}]-> {this.destinationNode} ";
        }
    }
}
