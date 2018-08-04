using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using SampleApp.Application;
using SampleApp.TesonetApi;
using static System.TimeSpan;

namespace SampleApp.Servers
{
    public class ServersViewModel : Screen
    {
        private readonly IServers _tesonetServers;
        private readonly IEventAggregator _eventAggregator;
        private List<ServerViewModel> _servers = new List<ServerViewModel>();

        public ServersViewModel(IServers servers, IEventAggregator eventAggregator)
        {
            _tesonetServers = servers;
            _eventAggregator = eventAggregator;
        }

        public List<ServerViewModel> Servers
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

        private async Task<List<ServerViewModel>> FetchServers()
        {
            using (var cancellationSource = new CancellationTokenSource(FromSeconds(30)))
            {
                return (await _tesonetServers.Fetch(cancellationSource.Token)).
                    Select(s => new ServerViewModel(s).Format()).
                    OrderBy(s => s.Name).
                    ToList();
            }
        }
    }
}