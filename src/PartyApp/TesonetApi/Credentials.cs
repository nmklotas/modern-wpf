using Newtonsoft.Json;

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

        public void ToJSON(JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("username");
            writer.WriteValue(_username);
            writer.WritePropertyName("password");
            writer.WriteValue(_password);
            writer.WriteEndObject();
        }
    }
}