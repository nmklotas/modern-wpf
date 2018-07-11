namespace SampleApp.TesonetApi
{
    public class Server
    {
        public Server(string name, double distance)
        {
            Name = name;
            Distance = distance;
        }

        public string Name { get; }

        public double Distance { get; }
    }
}