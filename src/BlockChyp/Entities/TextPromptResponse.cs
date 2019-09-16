using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class TextPromptResponse : Acknowledgement
    {
        /// <summary>
        /// The text prompt response.
        /// </summary>
        [JsonProperty(PropertyName = "response")]
        public string Response { get; set; }
    }
}
