using Newtonsoft.Json;

namespace BlockChyp
{
    public class RefundRequest : PaymentRequest
    {
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }
    }
}