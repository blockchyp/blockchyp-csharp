using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp
{
    public class AuthRequest : PaymentRequest
    {
        /// <summary>
        /// Whether or not the payment method will be enrolled in the
        /// token vault after authorization.
        /// </summary>
        [JsonProperty(PropertyName = "enroll")]
        public bool Enroll { get; set; }

        /// <summary>
        /// The transaction description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Instructs the terminal to request a tip from the user before
        /// starting the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "promptForTip")]
        public bool PromptForTip { get; set; }

        /// <summary>
        /// A map of alternate currencies and the price in each currency.
        /// </summary>
        [JsonProperty(PropertyName = "altPrices")]
        public Dictionary<string, string> AltPrices { get; set; }
    }
}
