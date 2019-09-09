using Newtonsoft.Json;

namespace BlockChyp
{
    public class ReceiptSuggestions
    {
        [JsonProperty(PropertyName = "aid")]
        public string Aid { get; set; }

        [JsonProperty(PropertyName = "arqc")]
        public string Arqc { get; set; }

        [JsonProperty(PropertyName = "iad")]
        public string Iad { get; set; }

        [JsonProperty(PropertyName = "arc")]
        public string Arc { get; set; }

        [JsonProperty(PropertyName = "tc")]
        public string Tc { get; set; }

        [JsonProperty(PropertyName = "tsi")]
        public string Tsi { get; set; }

        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        [JsonProperty(PropertyName = "merchantName")]
        public string MerchantName { get; set; }

        [JsonProperty(PropertyName = "merchantKey")]
        public string MerchantKey { get; set; }

        [JsonProperty(PropertyName = "applicationLabel")]
        public string ApplicationLabel { get; set; }

        [JsonProperty(PropertyName = "requestSignature")]
        public bool RequestSignature { get; set; }

        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        [JsonProperty(PropertyName = "authorizedAmount")]
        public string AuthorizedAmount { get; set; }

        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }
    }
}