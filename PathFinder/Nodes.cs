namespace PathFinder
{
    public class Nodes : List<Node>
    {
        public void Add(string nodeId)
        {
            if (this.GetNodeById(nodeId) == null)
            {
                this.Add(new Node(nodeId));
            }
            else
            {
                // TODO: should probably throw an exception
            }
        }
        public Node? GetNodeById(string? nodeId)
        {
            if (nodeId != null)
            {
                foreach (Node node in this)
                {
                    if (node.Id.Equals(nodeId)) return node;
                }
            }
            return null;
        }

        public Nodes Copy()
        {
            Nodes result = new Nodes();
            foreach (Node node in this)
            {
                result.Add(node);
            }
            return result;
        }
    }
}
