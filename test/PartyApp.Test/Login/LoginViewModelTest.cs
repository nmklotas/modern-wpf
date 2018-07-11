using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using FluentAssertions;
using SampleApp.Application;
using SampleApp.Login;
using SampleApp.TesonetApi;
using Xunit;

namespace SampleApp.Test.Login
{
    public class LoginViewModelTest
    {
        [Fact]
        public void ShowsErrorsOnTesonetApiException()
        {
            var sut = new LoginViewModel(
                new FakeTesonetApi(),
                new EventAggregator())
            {
                UserName = "test",
                Password = "testPassword"
            };

            sut.Login();
            sut.Error.Should().Be("testError");
        }

        private class FakeTesonetApi : ITesonetApi
        {
            public Task<IServers> Login(Credentials credentials, CancellationToken cancellationToken) 
                => throw new AppException("testError");
        }
    }
}
