using Newtonsoft.Json;

namespace BlockChypTest
{
    public class IntegrationTestSettings
    {
        [JsonProperty("gateway")]
        public string GatewayUrl { get; set; }

        [JsonProperty("testGateway")]
        public string GatewayTestUrl { get; set; }

        [JsonProperty("defaultTerminalName")]
        public string DefaultTerminalName { get; set; }

        [JsonProperty("defaultTerminalAddress")]
        public string DefaultTerminalAddress { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("bearerToken")]
        public string BearerToken { get; set; }

        [JsonProperty("signingKey")]
        public string SigningKey { get; set; }
    }
}
