using Newtonsoft.Json;

namespace BlockChyp.Entities
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

        /// <summary>
        /// The API key.
        /// </summary>
        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; protected set; }

        /// <summary>
        /// The bearer token.
        /// </summary>
        [JsonProperty(PropertyName = "bearerToken")]
        public string BearerToken { get; protected set; }

        /// <summary>
        /// The signing key.
        /// </summary>
        [JsonProperty(PropertyName = "signingKey")]
        public string SigningKey { get; protected set; }
    }
}
