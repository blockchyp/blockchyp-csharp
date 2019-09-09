using Newtonsoft.Json;

namespace BlockChyp
{
    public class ClearRequest : CoreRequest
    {
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }
    }
}