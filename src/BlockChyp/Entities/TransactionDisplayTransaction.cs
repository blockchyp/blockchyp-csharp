using BlockChyp.Json;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class TransactionDisplayTransaction
    {
        /// <summary>
        /// The pre-tax subtotal for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "subtotal")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Tax for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "tax")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal Tax { get; set; }

        /// <summary>
        /// Grand total for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal Total { get; set; }

        /// <summary>
        /// Array of <see cref="TransactionDisplayItem"/> for the line item display.
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public TransactionDisplayItem[] Items { get; set; }
    }
}
