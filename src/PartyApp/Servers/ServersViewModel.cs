using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using PartyApp.Application;
using PartyApp.TesonetApi;
using static System.TimeSpan;

namespace PartyApp.Servers
{
    public class ServersViewModel : Screen
    {
        private readonly IServers _tesonetServers;
        private readonly IEventAggregator _eventAggregator;
        private BindableCollection<ServerViewModel> _servers = new BindableCollection<ServerViewModel>();

        public ServersViewModel(IServers servers, IEventAggregator eventAggregator)
        {
            _tesonetServers = servers;
            _eventAggregator = eventAggregator;
        }

        public BindableCollection<ServerViewModel> Servers
        {
            get => _servers;
            private set => Set(ref _servers, value);
        }

        public async void Logout()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new LogoutRequestedMessage());
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            try
            {
                Servers = await FetchServers();
            }
            catch (AppException)
            {
            }
        }

        private async Task<BindableCollection<ServerViewModel>> FetchServers()
        {
            using (var cancellationTokenSource = new CancellationTokenSource(FromSeconds(30)))
            {
                var servers = await _tesonetServers.Fetch(cancellationTokenSource.Token);
                return new BindableCollection<ServerViewModel>(
                    servers.Select(s => new ServerViewModel(s).FormatDistance()).OrderBy(s => s.Name));
            }
        }
    }
}