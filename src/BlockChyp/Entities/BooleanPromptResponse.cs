using Newtonsoft.Json;

namespace BlockChyp
{
    public class BooleanPromptResponse : Acknowledgement
    {
        [JsonProperty(PropertyName = "response")]
        public bool Response { get; set; }
    }
}