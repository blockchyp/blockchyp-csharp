using System.Collections.Generic;
using BlockChyp.Json;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class CloseBatchResponse
    {
        /// <summary>
        /// Indicates that the operation succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The currency code for this batch.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The total captured amount for this batch. Should be the expected
        /// deposit amount.
        /// </summary>
        [JsonProperty(PropertyName = "capturedTotal")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal CapturedTotal { get; set; }

        /// <summary>
        /// The captured totals by card brand.
        /// </summary>
        [JsonProperty(PropertyName = "cardBrands", ItemConverterType = typeof(CurrencyJsonConverter))]
        public Dictionary<string, decimal> CardBrands { get; set; }

        /// <summary>
        /// The total amount of preauths opened during the batch
        /// that weren't captured.
        /// </summary>
        [JsonProperty(PropertyName = "openPreauths")]
        public string OpenPreauths { get; set; }
    }
}
