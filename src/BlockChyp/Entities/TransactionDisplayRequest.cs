using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class TransactionDisplayRequest
    {
        /// <summary>
        /// The target terminal name.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The <see cref="TransactionDisplayTransaction"/> to be displayed on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "transaction")]
        public TransactionDisplayTransaction Transaction { get; set; }
    }
}
