using SampleApp.TesonetApi;

namespace SampleApp.Login
{
    public class LoginSucceededMessage
    {
        public LoginSucceededMessage(IServers servers) 
            => Servers = servers;

        public IServers Servers { get; }
    }
}