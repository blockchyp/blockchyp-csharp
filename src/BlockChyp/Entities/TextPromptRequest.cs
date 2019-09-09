using Newtonsoft.Json;

namespace BlockChyp
{
    public class TextPromptRequest
    {
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        [JsonProperty(PropertyName = "promptType")]
        public string PromptType { get; set; }
    }
}