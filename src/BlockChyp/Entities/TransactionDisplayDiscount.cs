using Newtonsoft.Json;

namespace BlockChyp
{
    public class TransactionDisplayDiscount
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }
    }
}