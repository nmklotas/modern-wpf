using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using PartyApp.Application;

namespace PartyApp.TesonetApi
{
    public class HttpTesonetApi : ITesonetApi
    {
        [LoggingAspect]
        public async Task<IServers> Login(Credentials credentials, CancellationToken cancellationToken)
        {
            try
            {
                using (var loginResponse = await "http://playground.tesonet.lt/v1/tokens".
                    WithHeader("Content-Type", "application/json").
                    PostStringAsync(SerializeCredentials(credentials), cancellationToken))
                {
                    var authenticationToken = JsonConvert.DeserializeAnonymousType(
                        await loginResponse.Content.ReadAsStringAsync(),
                        new {Token = ""}).Token;

                    return new HttpServers(authenticationToken);
                }
            }
            catch (FlurlHttpException ex)
            {
                throw new AppException(ResolveError(ex), ex);
            }
        }

        private static string SerializeCredentials(Credentials credentials)
        {
            var stringWritter = new StringWriter();
            credentials.ToJSON(new JsonTextWriter(stringWritter));
            return stringWritter.ToString();
        }

        private static string ResolveError(FlurlHttpException ex)
        {
            return ex.Call.Response.StatusCode == HttpStatusCode.Unauthorized
                ? "Invalid user name or password"
                : "Failed to authenticate";
        }
    }
}