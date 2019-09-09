using Newtonsoft.Json;

namespace BlockChyp
{
    public class ApprovalResponseWithAmounts : ApprovalResponse
    {
        [JsonProperty(PropertyName = "partialAuth")]
        public bool PartialAuth { get; set; }

        [JsonProperty(PropertyName = "altCurrency")]
        public bool AltCurrency { get; set; }

        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "requestedAmount")]
        public string RequestedAmount { get; set; }

        [JsonProperty(PropertyName = "authorizedAmount")]
        public string AuthorizedAmount { get; set; }

        [JsonProperty(PropertyName = "tipAmount")]
        public string TipAmount { get; set; }

        [JsonProperty(PropertyName = "taxAmount")]
        public string TaxAmount { get; set; }
    }
}