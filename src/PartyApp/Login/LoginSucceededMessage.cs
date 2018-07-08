using PartyApp.TesonetApi;

namespace PartyApp.Login
{
    public class LoginSucceededMessage
    {
        public LoginSucceededMessage(IServers servers) 
            => Servers = servers;

        public IServers Servers { get; }
    }
}