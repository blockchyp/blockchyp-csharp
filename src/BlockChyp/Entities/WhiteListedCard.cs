using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Card BIN ranges can be whitelisted so that they are read instead of
    /// being processed directly. This is useful for integration with legacy
    /// gift card systems.
    /// </summary>
    public class WhiteListedCard
    {
        /// <summary>
        /// The card BIN.
        /// </summary>
        [JsonProperty(PropertyName = "bin")]
        public string Bin { get; set; }

        /// <summary>
        /// Track 1 data from the card.
        /// </summary>
        [JsonProperty(PropertyName = "track1")]
        public string Track1 { get; set; }

        /// <summary>
        /// Track2 data from the card.
        /// by the card issuer.
        /// </summary>
        [JsonProperty(PropertyName = "track2")]
        public string Track2 { get; set; }

        /// <summary>
        /// The card primary account number.
        /// </summary>
        [JsonProperty(PropertyName = "pan")]
        public string Pan { get; set; }
    }
}
