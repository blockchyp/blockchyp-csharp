using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class ApprovalResponse : CoreResponse
    {
        /// <summary>
        /// Indicates whether or not the transaction was approved.
        /// </summary>
        [JsonProperty(PropertyName = "approved")]
        public bool Approved { get; set; }

        /// <summary>
        /// The auth code from the payment network.
        /// </summary>
        [JsonProperty(PropertyName = "authCode")]
        public string AuthCode { get; set; }

        /// <summary>
        /// Hex encoded signature data.
        /// </summary>
        [JsonProperty(PropertyName = "sigFile")]
        public string SignatureFile { get; set; }
    }
}
