using Newtonsoft.Json;

namespace BlockChyp
{
    public class TerminalRequest
    {
        public TerminalRequest(ApiCredentials credentials, object request)
        {
            ApiKey = credentials.ApiKey;
            BearerToken = credentials.BearerToken;
            SigningKey = credentials.SigningKey;
            Request = request;
        }

        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty(PropertyName = "bearerToken")]
        public string BearerToken { get; set; }

        [JsonProperty(PropertyName = "signingKey")]
        public string SigningKey { get; set; }

        [JsonProperty(PropertyName = "request")]
        public object Request { get; set; }
    }
}