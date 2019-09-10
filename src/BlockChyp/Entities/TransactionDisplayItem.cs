using Newtonsoft.Json;

namespace BlockChyp
{
    public class TransactionDisplayItem
    {
        /// <summary>
        /// The line item ID.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The line item description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The undiscounted price per unit quantity.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        /// <summary>
        /// The line item quantity.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public float Quantity { get; set; }

        /// <summary>
        /// The extended price for a line item.
        /// </summary>
        [JsonProperty(PropertyName = "extended")]
        public string Extended { get; set; }

        /// <summary>
        /// An array of <see cref="TransactionDisplayDiscount"/>
        /// associated with a line item.
        /// </summary>
        [JsonProperty(PropertyName = "discounts")]
        public TransactionDisplayDiscount[] Discounts { get; set; }
    }
}
