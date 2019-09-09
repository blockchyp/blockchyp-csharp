using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp
{
    public class CloseBatchResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "capturedTotals")]
        public string CapturedTotals { get; set; }

        [JsonProperty(PropertyName = "cardBrands")]
        public Dictionary<string, string> CardBrands { get; set; }
    }
}