using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class CoreRequest
    {
        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The transaction reference value. This is an arbitrary string
        /// intended for your own use. Can be used for subsequent reversal
        /// requests.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements
        /// enabled (not common).
        /// </summary>
        [JsonProperty(PropertyName = "destinationAccount")]
        public string DestinationAccount { get; set; }

        /// <summary>
        /// The request timeout in milliseconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}
