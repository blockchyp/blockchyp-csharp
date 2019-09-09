using Newtonsoft.Json;

namespace BlockChyp
{
    public class BooleanPromptRequest
    {
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        [JsonProperty(PropertyName = "prompt")]
        public string Prompt { get; set; }

        [JsonProperty(PropertyName = "yesCaption")]
        public string YesCaption { get; set; }

        [JsonProperty(PropertyName = "noCaption")]
        public string NoCaption { get; set; }
    }
}