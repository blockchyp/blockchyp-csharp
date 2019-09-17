using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class CaptureRequest : AmountRequest
    {
        /// <summary>
        /// The ID of the transaction being captured.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }
    }
}
