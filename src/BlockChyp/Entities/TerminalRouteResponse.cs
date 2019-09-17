using System;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class TerminalRouteResponse : ICloneable
    {
        /// <summary>
        /// Whether or not the route lookup succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The name of the terminal in the request.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The terminal IP address on the local network.
        /// </summary>
        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Whether or not requests for the terminal should be relayed through
        /// the cloud. This will typically be done when the terminal and the
        /// client application are on different networks.
        /// </summary>
        [JsonProperty(PropertyName = "cloudRelayEnabled")]
        public bool CloudRelayEnabled { get; set; }

        /// <summary>
        /// Transient credentials to be used for requests to the terminal.
        /// Transient credentials are periodically rotated, reducing the
        /// risk of root credentials being compromised in flight.
        /// </summary>
        [JsonProperty(PropertyName = "transientCredentials")]
        public ApiCredentials TransientCredentials { get; set; }

        /// <summary>
        /// The public key of the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        /// <summary>
        /// The timestamp of the route request, used for cache expirey.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Implements the ICloneable interface. Does not perform a deep copy.
        /// </summary>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
