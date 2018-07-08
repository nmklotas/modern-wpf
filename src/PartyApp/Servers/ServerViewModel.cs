using Caliburn.Micro;
using PartyApp.TesonetApi;

namespace PartyApp.Servers
{
    public class ServerViewModel : PropertyChangedBase
    {
        private readonly double _distance;

        public ServerViewModel(Server server) : this(server.Name, server.Distance)
        {
        }

        public ServerViewModel(string name, double distance)
        {
            Name = name;
            _distance = distance;
        }

        public string Name { get; }

        public string Distance { get; private set; }

        public ServerViewModel FormatDistance()
        {
            return new ServerViewModel(Name, _distance)
            {
                Distance = $"{_distance} km"
            };
        }
    }
}