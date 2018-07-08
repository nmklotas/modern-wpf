using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using PartyApp.Application;
using PartyApp.TesonetApi;
using Xunit;

namespace PartyApp.Test.TesonetApi
{
	public class HttpTesonetApiTest
	{
	    [Fact]
	    public async Task ValidCredentialsReturnsServers()
	    {
	        var sut = new HttpTesonetApi();
	        var servers = await sut.Login(new Credentials("tesonet", "partyanimal"), new CancellationToken());
	        servers.Should().NotBeNull();
	    }

	    [Fact]
	    public void InvalidCredentialThrows()
	    {
	        var sut = new HttpTesonetApi();
	        Func<Task<IServers>> servers = () => sut.Login(new Credentials("test", "test"), new CancellationToken());
	        servers.Should().Throw<AppException>().WithMessage("Invalid user name or password");
	    }
    }
}
