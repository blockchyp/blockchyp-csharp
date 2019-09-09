using Newtonsoft.Json;

namespace BlockChyp
{
    public class ApprovalResponseWithPaymentMethod : ApprovalResponseWithAmounts
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }

        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        [JsonProperty(PropertyName = "scopeAlert")]
        public bool ScopeAlert { get; set; }

        [JsonProperty(PropertyName = "cardHolder")]
        public string CardHolder { get; set; }

        [JsonProperty(PropertyName = "receiptSuggestions")]
        public ReceiptSuggestions ReceiptSuggestions { get; set; }
    }
}