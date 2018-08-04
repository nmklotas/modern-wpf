using Newtonsoft.Json.Linq;

namespace SampleApp.TesonetApi
{
    public class Credentials
    {
        private readonly string _password;
        private readonly string _username;

        public Credentials(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public bool IsValid(out string error)
        {
            if (!string.IsNullOrWhiteSpace(_username) &&
                !string.IsNullOrWhiteSpace(_password))
            {
                error = "";
                return true;
            }

            error = "Invalid credentials";
            return false;
        }

        public JObject ToJObject()
        {
            return new JObject(
                new JProperty("username", _username),
                new JProperty("password", _password));
        }
    }
}