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
        public string Amount { get; set; }

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

        /// <summary>
        /// The amount of cash back requested.
        /// </summary>
        [JsonProperty(PropertyName = "cashBackAmount")]
        public string CashBackAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an FSA
        /// card. This amount may be less than the transaction total, in
        /// which case only this amount will be charged if an FSA card is
        /// presented. If the FSA amount is paid on an FSA card, then
        /// <see cref="ApprovalResponseWithAmounts.FsaAuth"/> will be set.
        /// </summary>
        [JsonProperty(PropertyName = "fsaAmount")]
        public string FsaAmount { get; set; }

        /// <summary>
        /// Whether or not the request is tax exempt.
        /// Only required for tax exempt level 2 processing.
        /// </summary>
        [JsonProperty(PropertyName = "taxExempt")]
        public bool TaxExempt { get; set; }
    }
}
