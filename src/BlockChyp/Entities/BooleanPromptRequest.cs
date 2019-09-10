using Newtonsoft.Json;

namespace BlockChyp
{
    public class BooleanPromptRequest
    {
        /// <summary>
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The text to be displayed on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// The preferred caption for the 'yes' button.
        /// </summary>
        [JsonProperty(PropertyName = "yesCaption")]
        public string YesCaption { get; set; }

        /// <summary>
        /// The preferred caption for the 'no' button.
        /// </summary>
        [JsonProperty(PropertyName = "noCaption")]
        public string NoCaption { get; set; }
    }
}
