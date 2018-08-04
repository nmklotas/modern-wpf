using FluentAssertions;
using SampleApp.Servers;
using SampleApp.TesonetApi;
using Xunit;

namespace SampleApp.Test.Servers
{
    public class ServerViewModelTest
    {
        [Fact]
        public void Formats()
        {
            var sut = new ServerViewModel(
                new Server("test", 100)).Format();

            sut.Name.Should().Be("test");
            sut.Distance.Should().Be("100 km");
        }
    }
}
