using Newtonsoft.Json;

namespace BlockChyp
{
    public class ApprovalResponse : CoreResponse
    {
        [JsonProperty(PropertyName = "approved")]
        public bool Approved { get; set; }

        [JsonProperty(PropertyName = "authCode")]
        public string AuthCode { get; set; }

        [JsonProperty(PropertyName = "sigFile")]
        public string SignatureFile { get; set; }
    }
}