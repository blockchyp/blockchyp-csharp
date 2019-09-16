using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class RefundRequest : PaymentRequest
    {
        /// <summary>
        /// The ID of the transaction to refund.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }
    }
}
