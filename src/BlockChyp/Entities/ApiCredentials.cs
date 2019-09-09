using Newtonsoft.Json;

namespace BlockChyp
{
    public class ApiCredentials
    {
        public ApiCredentials()
        {
        }

        public ApiCredentials(string apiKey, string bearerToken, string signingKey)
        {
            ApiKey = apiKey;
            BearerToken = bearerToken;
            SigningKey = signingKey;
        }

        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; }

        [JsonProperty(PropertyName = "bearerToken")]
        public string BearerToken { get; }

        [JsonProperty(PropertyName = "signingKey")]
        public string SigningKey { get; }
    }
}