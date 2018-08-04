using FluentAssertions;
using SampleApp.Servers;
using SampleApp.TesonetApi;
using Xunit;

namespace SampleApp.Test.Servers
{
    public class ServerViewModelTest
    {
        [Fact]
        public void FormatsDistance()
        {
            new ServerViewModel(new Server("test", 100)).
                Format().
                Distance.
                Should().Be("100 km");
        }

        [Fact]
        public void FormatsName()
        {
            new ServerViewModel(new Server("test", 100)).
                Format().
                Name.
                Should().Be("test");
        }
    }
}
