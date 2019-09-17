using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class TerminalRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalRequest"/> class.
        /// </summary>
        /// <param name="credentials">API credentials used to make requests.</param>
        /// <param name="request">The JSON-serializable request body.</param>
        public TerminalRequest(ApiCredentials credentials, object request)
        {
            ApiKey = credentials.ApiKey;
            BearerToken = credentials.BearerToken;
            SigningKey = credentials.SigningKey;
            Request = request;
        }

        /// <summary>
        /// The API key used to authenticate the request.
        /// </summary>
        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// The bearer token used to authenticate the request.
        /// </summary>
        [JsonProperty(PropertyName = "bearerToken")]
        public string BearerToken { get; set; }

        /// <summary>
        /// The signing key used to authenticate the request.
        /// </summary>
        [JsonProperty(PropertyName = "signingKey")]
        public string SigningKey { get; set; }

        /// <summary>
        /// The JSON-serializable request body.
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public object Request { get; set; }
    }
}
