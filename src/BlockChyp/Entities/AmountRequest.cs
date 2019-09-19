using BlockChyp.Json;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class AmountRequest : CoreRequest
    {
        /// <summary>
        /// The currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The transaction amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal Amount { get; set; }

        /// <summary>
        /// The tip amount.
        /// </summary>
        [JsonProperty(PropertyName = "tipAmount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal TipAmount { get; set; }

        /// <summary>
        /// The tax amount.
        /// </summary>
        [JsonProperty(PropertyName = "taxAmount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// The amount of cash back requested.
        /// </summary>
        [JsonProperty(PropertyName = "cashBackAmount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal CashBackAmount { get; set; }

        /// <summary>
        /// Whether or not the request is tax exempt.
        /// Only required for tax exempt level 2 processing.
        /// </summary>
        [JsonProperty(PropertyName = "taxExempt")]
        public bool TaxExempt { get; set; }
    }
}
