using BlockChyp.Json;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class ApprovalResponseWithAmounts : ApprovalResponse
    {
        /// <summary>
        /// Indicates whether or not the transaction was approved for a partial amount.
        /// </summary>
        [JsonProperty(PropertyName = "partialAuth")]
        public bool PartialAuth { get; set; }

        /// <summary>
        /// Indicates whether or not an alternate currency was used.
        /// </summary>
        [JsonProperty(PropertyName = "altCurrency")]
        public bool AltCurrency { get; set; }

        /// <summary>
        /// The currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The requested amount.
        /// </summary>
        [JsonProperty(PropertyName = "requestedAmount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal RequestedAmount { get; set; }

        /// <summary>
        /// The authorized amount. May not match the requested amount in the
        /// event of a partial auth.
        /// </summary>
        [JsonProperty(PropertyName = "authorizedAmount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal AuthorizedAmount { get; set; }

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
    }
}
