using System.Text.Json.Serialization;

namespace BlockChypTest
{
    public class IntegrationTestSettings
    {
        [JsonPropertyName("gatewayHost")]
        public string GatewayUrl { get; set; }

        [JsonPropertyName("testGatewayHost")]
        public string GatewayTestUrl { get; set; }

        [JsonPropertyName("defaultTerminalName")]
        public string DefaultTerminalName { get; set; }

        [JsonPropertyName("defaultTerminalAddress")]
        public string DefaultTerminalAddress { get; set; }

        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }

        [JsonPropertyName("bearerToken")]
        public string BearerToken { get; set; }

        [JsonPropertyName("signingKey")]
        public string SigningKey { get; set; }
    }
}