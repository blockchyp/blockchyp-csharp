using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class AuthResponse : ApprovalResponseWithPaymentMethod
    {
        /// <summary>
        /// Indicates that the transaction was flagged for store and
        /// forward due to network problems.
        /// </summary>
        [JsonProperty(PropertyName = "storeAndForward")]
        public bool StoreAndForward { get; set; }

        /// <summary>
        /// Data about the card. Null unless the card's BIN range has been
        /// specifically whitelisted.
        /// </summary>
        [JsonProperty(PropertyName = "whiteListedCard")]
        public WhiteListedCard WhiteListedCard { get; set; }
    }
}
