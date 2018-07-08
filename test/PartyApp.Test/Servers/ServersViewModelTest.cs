using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using FluentAssertions;
using PartyApp.Servers;
using PartyApp.TesonetApi;
using Xunit;

namespace PartyApp.Test.Servers
{
    public class ServersViewModelTest
    {
        [Fact]
        public void ShowsServersOnActivate()
        {
            var sut = new ServersViewModel(new FakeServers(), new EventAggregator());
            sut.As<IActivate>().Activate();
            var server = sut.Servers.Single();
            server.Name.Should().Be("testName");
            server.Distance.Should().Be("100 km");
        }

        private class FakeServers : IServers
        {
            public async Task<IList<Server>> Fetch(CancellationToken cancellationToken)
            {
                return new List<Server>
                {
                    new Server("testName", 100)
                };
            }
        }
    }
}
