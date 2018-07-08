using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
using PartyApp.TesonetApi;
using Xunit;

namespace PartyApp.Test.TesonetApi
{
    public class CredentialsTest
    {
        [Fact]
        public void EmptyCredentialsNotValid()
        {
            var sut = new Credentials(" ", "");
            sut.IsValid(out string error).Should().BeFalse();
            error.Should().Be("Invalid credentials");
        }

        [Fact]
        public void ConvertsToJson()
        {
            var sut = new Credentials("testUser", "testPassword");
            var stringWritter = new StringWriter();
            sut.ToJSON(new JsonTextWriter(stringWritter));
            stringWritter.ToString().Should().Be("{\"username\":\"testUser\",\"password\":\"testPassword\"}");
        }
    }
}
