using Newtonsoft.Json;

namespace BlockChyp
{
    public class TransactionDisplayRequest
    {
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        [JsonProperty(PropertyName = "transaction")]
        public TransactionDisplayTransaction Transaction { get; set; }
    }
}