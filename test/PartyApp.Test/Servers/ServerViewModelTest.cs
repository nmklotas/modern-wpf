using FluentAssertions;
using PartyApp.Servers;
using Xunit;

namespace PartyApp.Test.Servers
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
