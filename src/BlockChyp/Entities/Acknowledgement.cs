using Newtonsoft.Json;

namespace BlockChyp
{
    public class Acknowledgement
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}