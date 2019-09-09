using Newtonsoft.Json;

namespace BlockChyp
{
    public class CoreRequest
    {
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        [JsonProperty(PropertyName = "destinationAccount")]
        public string DestinationAccount { get; set; }

        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}