using Newtonsoft.Json;

namespace BlockChyp
{
    public class VoidRequest : CoreRequest
    {
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }
    }
}