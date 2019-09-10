using Newtonsoft.Json;

namespace BlockChyp
{
    public class TextPromptRequest
    {
        /// <summary>
        /// The target terminal name.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The prompt type (email, phone, etc).
        /// </summary>
        [JsonProperty(PropertyName = "promptType")]
        public string PromptType { get; set; }
    }
}
