using Newtonsoft.Json;

namespace BlockChyp
{
    public class MessageRequest
    {
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}