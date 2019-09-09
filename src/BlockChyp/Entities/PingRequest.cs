using Newtonsoft.Json;

namespace BlockChyp
{
    public class PingRequest
    {
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }
    }
}