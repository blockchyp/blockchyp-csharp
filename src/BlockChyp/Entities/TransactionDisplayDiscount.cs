using BlockChyp.Json;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class TransactionDisplayDiscount
    {
        /// <summary>
        /// The discount description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The amount of the discount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal Amount { get; set; }
    }
}
