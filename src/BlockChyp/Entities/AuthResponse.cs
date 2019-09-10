using Newtonsoft.Json;

namespace BlockChyp
{
    public class AuthResponse : ApprovalResponseWithPaymentMethod
    {
        /// <summary>
        /// Indicates that the transaction was flagged for store and
        /// forward due to network problems.
        /// </summary>
        [JsonProperty(PropertyName = "storeAndForward")]
        public bool StoreAndForward { get; set; }
    }
}
