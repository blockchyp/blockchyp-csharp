using System;
using Newtonsoft.Json;

namespace BlockChyp
{
    public class TerminalRouteResponse : ICloneable
    {
        [JsonProperty(PropertyName = "exists")]
        public bool Exists { get; set; }

        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "cloudRelayEnabled")]
        public bool CloudRelayEnabled { get; set; }

        [JsonProperty(PropertyName = "transientCredentials")]
        public ApiCredentials TransientCredentials { get; set; }

        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}