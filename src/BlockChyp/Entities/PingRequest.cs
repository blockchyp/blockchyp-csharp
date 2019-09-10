using Newtonsoft.Json;

namespace BlockChyp
{
    public class PingRequest
    {
        /// <summary>
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }
    }
}
