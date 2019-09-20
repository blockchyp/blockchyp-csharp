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
        public string RequestedAmount { get; set; }

        /// <summary>
        /// The authorized amount. May not match the requested amount in the
        /// event of a partial auth.
        /// </summary>
        [JsonProperty(PropertyName = "authorizedAmount")]
        public string AuthorizedAmount { get; set; }

        /// <summary>
        /// Cash back amount the customer requested on PIN entry.
        /// </summary>
        [JsonProperty(PropertyName = "requestedCashBackAmount")]
        public string RequestedCashBackAmount { get; set; }

        /// <summary>
        /// The amount of cash back authorized by the gateway. This amount
        /// Will be the entire amount requested, or zero.
        /// </summary>
        [JsonProperty(PropertyName = "authorizedCashBackAmount")]
        public string AuthorizedCashBackAmount { get; set; }

        /// <summary>
        /// The tip amount.
        /// </summary>
        [JsonProperty(PropertyName = "tipAmount")]
        public string TipAmount { get; set; }

        /// <summary>
        /// The tax amount.
        /// </summary>
        [JsonProperty(PropertyName = "taxAmount")]
        public string TaxAmount { get; set; }
    }
}
