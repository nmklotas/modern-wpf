using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using FluentAssertions;
using SampleApp.Servers;
using SampleApp.TesonetApi;
using Xunit;

namespace SampleApp.Test.Servers
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
                => new[] { new Server("testName", 100) };
        }
    }
}
