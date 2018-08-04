using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using SampleApp.Application;

namespace SampleApp.TesonetApi
{
    public class HttpTesonetApi : ITesonetApi
    {
        [LoggingAspect]
        public async Task<IServers> Login(Credentials credentials, CancellationToken cancellationToken)
        {
            try
            {
                var authenticationToken = await "http://playground.tesonet.lt/v1/tokens".
                    WithHeader("Content-Type", "application/json").
                    PostJsonAsync(credentials.ToJObject(), cancellationToken).
                    ReceiveJson<AuthenticationToken>();

                return new HttpServers(authenticationToken.Token);
            }
            catch (FlurlHttpException ex)
            {
                throw new AppException(ResolveError(ex), ex);
            }
        }

        private static string ResolveError(FlurlHttpException ex)
        {
            return ex.Call.Response.StatusCode == HttpStatusCode.Unauthorized
                ? "Invalid user name or password"
                : "Failed to authenticate";
        }

        private class AuthenticationToken
        {
            public string Token { get; set; }
        }
    }
}