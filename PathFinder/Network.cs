using System;

namespace PathFinder
{
    public class Network
    {

        // ========== Constructors ========== //
        public Network()
        {
            Nodes = new();
            Connections = new();
        }

        // ========== Properties ========== //
        public Nodes Nodes
        { get; set; }

        public Connections Connections
        { get; set; }

        // ========== Methods ========== //
        public void AddNode(string name)
        { this.Nodes.Add(name); }

        public void ConnectNodes(string startingNodeId, string endingNodeId, int value)
        {
            Node? startingNode = this.Nodes.GetNodeById(startingNodeId);
            Node? endingNode = this.Nodes.GetNodeById(endingNodeId);
            this.Connections.Connect(startingNode, endingNode, value);
        }
    }
}
