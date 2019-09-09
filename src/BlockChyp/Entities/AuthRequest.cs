using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp
{
    public class AuthRequest : PaymentRequest
    {
        [JsonProperty(PropertyName = "enroll")]
        public bool Enroll { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "promptForTip")]
        public bool PromptForTip { get; set; }

        [JsonProperty(PropertyName = "altPrices")]
        public Dictionary<string, string> AltPrices { get; set; }
    }
}