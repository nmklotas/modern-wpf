using System;
using System.Threading.Tasks;
using FluentAssertions;
using SampleApp.Application;
using SampleApp.TesonetApi;
using Xunit;

namespace SampleApp.Test.TesonetApi
{
	public class HttpTesonetApiTest
	{
	    [Fact]
	    public async Task ValidCredentialsReturnsServers()
	    {
	        var sut = new HttpTesonetApi();
	        var servers = await sut.Login(new Credentials("tesonet", "partyanimal"), default);
	        servers.Should().NotBeNull();
	    }

	    [Fact]
	    public void InvalidCredentialThrows()
	    {
	        var sut = new HttpTesonetApi();
	        Func<Task<IServers>> servers = () => sut.Login(new Credentials("test", "test"), default);
	        servers.Should().Throw<AppException>().WithMessage("Invalid user name or password");
	    }
    }
}
