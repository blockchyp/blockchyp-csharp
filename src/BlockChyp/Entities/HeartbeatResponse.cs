using System;
using Newtonsoft.Json;

namespace BlockChyp
{
    public class HeartbeatResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty(PropertyName = "clockchain")]
        public string Clockchain { get; set; }

        [JsonProperty(PropertyName = "latestTick")]
        public string LatestTick { get; set; }

        [JsonProperty(PropertyName = "merchantPk")]
        public string MerchantPublicKey { get; set; }
    }
}