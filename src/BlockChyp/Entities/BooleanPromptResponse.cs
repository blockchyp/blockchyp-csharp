using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class BooleanPromptResponse : Acknowledgement
    {
        /// <summary>
        /// The boolean prompt response.
        /// </summary>
        [JsonProperty(PropertyName = "response")]
        public bool Response { get; set; }
    }
}
