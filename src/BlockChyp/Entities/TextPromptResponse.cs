using Newtonsoft.Json;

namespace BlockChyp
{
    public class TextPromptResponse : Acknowledgement
    {
        [JsonProperty(PropertyName = "response")]
        public string Response { get; set; }
    }
}