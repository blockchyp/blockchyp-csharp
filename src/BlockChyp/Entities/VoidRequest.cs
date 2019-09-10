using Newtonsoft.Json;

namespace BlockChyp
{
    public class VoidRequest : CoreRequest
    {
        /// <summary>
        /// The ID of the transaction to void.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }
    }
}
