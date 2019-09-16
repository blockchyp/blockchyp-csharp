using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class HeartbeatResponse
    {
        /// <summary>
        /// Whether or not the heartbeat request succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The timestamp of the heartbeat in RFC 3339 format.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// The public key of the clockchain. This is blockchain stuff that
        /// you don't really need to worry about. It is a base 58 encoded and
        /// compressed eliptic curve public key.
        ///
        /// For the production clockchain, this will always be:
        /// '3cuhsckVUd9HzMjbdUSW17aY5kCcm1d6YAphJMUwmtXRj7WLyU'
        /// </summary>
        [JsonProperty(PropertyName = "clockchain")]
        public string Clockchain { get; set; }

        /// <summary>
        /// The hash of the last tick block.
        /// </summary>
        [JsonProperty(PropertyName = "latestTick")]
        public string LatestTick { get; set; }

        /// <summary>
        /// The public key for the merchant's blockchain.
        /// </summary>
        [JsonProperty(PropertyName = "merchantPk")]
        public string MerchantPublicKey { get; set; }
    }
}
