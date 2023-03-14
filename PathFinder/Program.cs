namespace PathFinder
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Network network = new Network();
            network.AddNode("A");
            network.AddNode("B");
            network.AddNode("C");
            network.AddNode("D");

            network.ConnectNodes("A", "D", 10);
            network.ConnectNodes("A", "B", 5);
            network.ConnectNodes("B", "C", 6);
            network.ConnectNodes("C", "D", 7);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PathFinderForm(network));
        }
    }
}