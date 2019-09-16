using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class TransactionDisplayTransaction
    {
        /// <summary>
        /// The pre-tax subtotal for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "subtotal")]
        public string Subtotal { get; set; }

        /// <summary>
        /// Tax for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "tax")]
        public string Tax { get; set; }

        /// <summary>
        /// Grand total for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }

        /// <summary>
        /// Array of <see cref="TransactionDisplayItem"/> for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public TransactionDisplayItem[] Items { get; set; }
    }
}
