using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using PartyApp.Application;

namespace PartyApp.TesonetApi
{
    public class HttpServers : IServers
    {
        private readonly string _authenticationToken;

        public HttpServers(string authenticationToken)
        {
            _authenticationToken = authenticationToken;
        }

        [LoggingAspect]
        public async Task<IList<Server>> Fetch(CancellationToken cancellationToken)
        {
            try
            {
                return await "http://playground.tesonet.lt/v1/servers".
                    WithHeader("Authorization", $"Bearer {_authenticationToken}").
                    WithHeader("accept", "application/json").GetAsync(cancellationToken).
                    ReceiveJson<List<Server>>();
            }
            catch (FlurlHttpException ex)
            {
                throw new AppException("Failed to fetch servers", ex);
            }
        }
    }
}