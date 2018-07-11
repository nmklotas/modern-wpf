using System.Threading.Tasks;
using FluentAssertions;
using SampleApp.TesonetApi;
using Xunit;

namespace SampleApp.Test.TesonetApi
{
    public class HttpServersTest
    {
        [Fact]
        public async Task FetchesServers()
        {
            var servers = await CreateSut();
            (await servers.Fetch(default)).Should().NotBeEmpty();
        }

        private static async Task<IServers> CreateSut()
        {
            var servers = await new HttpTesonetApi().Login(
                new Credentials("tesonet", "partyanimal"),
                default);

            return servers;
        }
    }
}
