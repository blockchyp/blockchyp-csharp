using Newtonsoft.Json;

namespace BlockChyp
{
    public class TransactionDisplayItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public float Quantity { get; set; }

        [JsonProperty(PropertyName = "extended")]
        public string Extended { get; set; }

        [JsonProperty(PropertyName = "discounts")]
        public TransactionDisplayDiscount[] Discounts { get; set; }
    }
}