using System;
using Newtonsoft.Json;

namespace BlockChyp
{
    public class CoreResponse
    {
        [JsonProperty(PropertyName = "responseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty(PropertyName = "batchId")]
        public string BatchId { get; set; }

        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty(PropertyName = "tickBlock")]
        public string TickBlock { get; set; }

        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        [JsonProperty(PropertyName = "sig")]
        public string Signature { get; set; }

    }
}