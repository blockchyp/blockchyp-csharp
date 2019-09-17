using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class ClearRequest : CoreRequest
    {
        /// <summary>
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }
    }
}
