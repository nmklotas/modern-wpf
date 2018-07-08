using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using PartyApp.TesonetApi;
using Xunit;

namespace PartyApp.Test.TesonetApi
{
	public class HttpServersTest
	{
		[Fact]
		public async Task FetchesServers()
		{
		    var servers = await CreateSut();
		    (await servers.Fetch(new CancellationToken())).Should().NotBeEmpty();
		}

	    private static async Task<IServers> CreateSut()
	    {
	        var servers = await new HttpTesonetApi().Login(
	            new Credentials("tesonet", "partyanimal"),
	            new CancellationToken());

	        return servers;
	    }
	}
}
