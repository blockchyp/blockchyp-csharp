using Newtonsoft.Json;

namespace BlockChyp
{
    public class CaptureRequest : AmountRequest
    {
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }
    }
}