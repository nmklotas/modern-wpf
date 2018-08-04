using SampleApp.TesonetApi;

namespace SampleApp.Servers
{
    public class ServerViewModel
    {
        private readonly Server _server;

        public ServerViewModel(Server server) : this(server, "", "")
        {
            
        }

        private ServerViewModel(Server server, string name, string distance)
        {
            _server = server;
            Name = name;
            Distance = distance;
        }

        public string Name { get; }

        public string Distance { get; }

        public ServerViewModel Format()
        {
            return new ServerViewModel(
                _server, 
                Name, 
                $"{_server.Distance} km");
        }
    }
}