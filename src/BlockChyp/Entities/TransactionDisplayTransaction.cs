using Newtonsoft.Json;

namespace BlockChyp
{
    public class TransactionDisplayTransaction
    {
        [JsonProperty(PropertyName = "subtotal")]
        public string Subtotal { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public string Tax { get; set; }

        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }

        [JsonProperty(PropertyName = "items")]
        public TransactionDisplayItem[] Items { get; set; }
    }
}