using Newtonsoft.Json;

namespace BlockChyp
{
    public class AuthResponse : ApprovalResponseWithPaymentMethod
    {
        [JsonProperty(PropertyName = "storeAndForward")]
        public bool StoreAndForward { get; set; }
    }
}