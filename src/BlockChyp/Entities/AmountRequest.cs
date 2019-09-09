using Newtonsoft.Json;

namespace BlockChyp
{
    public class AmountRequest : CoreRequest
    {
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        [JsonProperty(PropertyName = "tipAmount")]
        public string TipAmount { get; set; }

        [JsonProperty(PropertyName = "taxAmount")]
        public string TaxAmount { get; set; }

        [JsonProperty(PropertyName = "cashBackAmount")]
        public string CashBackAmount { get; set; }

        [JsonProperty(PropertyName = "taxExempt")]
        public bool TaxExempt { get; set; }
    }
}