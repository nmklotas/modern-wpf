using FluentAssertions;
using SampleApp.Servers;
using Xunit;

namespace SampleApp.Test.Servers
{
    public class ServerViewModelTest
    {
        [Fact]
        public void FormatsDistance()
        {
            new ServerViewModel("test", 100).
                FormatDistance().
                Distance.
                Should().Be("100 km");
        }
    }
}
