namespace PathFinder
{
    public class Connections : List<Connection>
    {
        public void Connect(Node? nodeA, Node? nodeB, int value)
        {
            if (nodeA != null && nodeB != null)
                this.Add(new Connection(nodeA, nodeB, value));
        }

        public Connections GetConnections(Node node, Nodes? exclude)
        {
            Connections result = new Connections();
            foreach (Connection connection in this)
            {
                if (connection.ConnectsFrom(node) && !connection.ConnectsTo(exclude))
                {
                    result.Add(connection);
                }
            }
            return result;
        }
    }
}
