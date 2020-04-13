using Newtonsoft.Json;

namespace GiGCodeChallenge.Common.Tests.Models
{
    public class RegistrationModel
    {
        [JsonProperty("email")] 
        public string Email { get; set; } 

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
