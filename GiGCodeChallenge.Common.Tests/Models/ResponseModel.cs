using Newtonsoft.Json;

namespace GiGCodeChallenge.Common.Tests.Models
{
    public class ResponseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
