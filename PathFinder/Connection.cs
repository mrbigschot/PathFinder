namespace PathFinder
{
    public class Connection
    {
        // ========== Constructors ========== //
        public Connection(Node node1, Node node2, int value)
        {
            StartNode = node1;
            EndNode = node2;
            Value = value;
        }

        // ========== Properties ========== //
        public Node StartNode
        { get; private set; }

        public Node EndNode
        { get; private set; }

        public int Value
        { private set; get; }

        // ========== Methods ========== //

        public bool ConnectsFrom(Node node)
        {
            if (node == null) return false;
            return this.StartNode.Id.Equals(node.Id);
        }
        public bool ConnectsTo(Node node)
        {
            if (node == null) return false;
            return this.EndNode.Id.Equals(node.Id);
        }
        public bool ConnectsTo(Nodes? nodes)
        {
            if (nodes == null || nodes.Count == 0) return false;
            foreach (Node node in nodes)
            {
                if (this.ConnectsTo(node)) return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[{this.StartNode} --{this.Value}--> {this.EndNode}]";
        }

    }
}
