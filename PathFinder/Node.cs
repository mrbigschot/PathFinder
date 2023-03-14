namespace PathFinder
{
    public class Node
    {
        // ========== Constructors ========== //
        public Node(string nodeId)
        {
            Id = nodeId;
        }

        // ========== Properties ========== //
        public string Id
        { get; private set; }


        // ========== Methods ========== //
        public override string ToString()
        {
            return this.Id;
        }
    }
}
