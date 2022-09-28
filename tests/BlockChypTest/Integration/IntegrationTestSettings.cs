using Newtonsoft.Json;
using BlockChyp.Entities;
using System.Collections.Generic;

namespace BlockChypTest.Integration
{
    public class IntegrationTestSettings
    {
        [JsonProperty("gatewayHost")]
        public string GatewayUrl { get; set; }

        [JsonProperty("testGatewayHost")]
        public string GatewayTestUrl { get; set; }

        [JsonProperty("dashboardHost")]
        public string DashboardUrl { get; set; }

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

        [JsonProperty("profiles")]
        public Dictionary<string, ApiCredentials> profiles { get; set;}
    }
}
