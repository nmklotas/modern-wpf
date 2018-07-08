using System.Threading;
using System.Threading.Tasks;
using PartyApp.Application;

namespace PartyApp.TesonetApi
{
    public interface ITesonetApi
    {
        /// <summary>
        /// Logins to API
        /// </summary>
        /// <exception cref="AppException">Thrown if login fails</exception>
        Task<IServers> Login(Credentials credentials, CancellationToken cancellationToken);
    }
}