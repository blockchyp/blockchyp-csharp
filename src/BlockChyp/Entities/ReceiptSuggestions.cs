using BlockChyp.Json;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    public class ReceiptSuggestions
    {
        /// <summary>
        /// EMV application identifier.
        /// </summary>
        [JsonProperty(PropertyName = "aid")]
        public string Aid { get; set; }

        /// <summary>
        /// The application request cryptogram. This is a digital signature
        /// typically used for offline authorization.
        /// </summary>
        [JsonProperty(PropertyName = "arqc")]
        public string Arqc { get; set; }

        /// <summary>
        /// EMV issuer application data. This is a proprietary data field sent
        /// by the card issuer.
        /// </summary>
        [JsonProperty(PropertyName = "iad")]
        public string Iad { get; set; }

        /// <summary>
        /// EMV authorization response code (Tag 8A).
        /// </summary>
        [JsonProperty(PropertyName = "arc")]
        public string Arc { get; set; }

        /// <summary>
        /// EMV transaction certificate. Another kind of digital signature
        /// used for offline authorization.
        /// </summary>
        [JsonProperty(PropertyName = "tc")]
        public string Tc { get; set; }

        /// <summary>
        /// EMV transaction status information (Tag 9B). A bit field indicating
        /// what type of risk management checks the terminal performed
        /// during the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "tsi")]
        public string Tsi { get; set; }

        /// <summary>
        /// The ID of the payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

        /// <summary>
        /// The name of the merchant's business.
        /// </summary>
        [JsonProperty(PropertyName = "merchantName")]
        public string MerchantName { get; set; }

        /// <summary>
        /// The partially masked merchant key required on EMV receipts.
        /// </summary>
        [JsonProperty(PropertyName = "merchantKey")]
        public string MerchantKey { get; set; }

        /// <summary>
        /// The description of the selected AID.
        /// </summary>
        [JsonProperty(PropertyName = "applicationLabel")]
        public string ApplicationLabel { get; set; }

        /// <summary>
        /// Whether or not the receipt should contain a signature line.
        /// </summary>
        [JsonProperty(PropertyName = "requestSignature")]
        public bool RequestSignature { get; set; }

        /// <summary>
        /// The masked primary account number of the payment card, as required
        /// on EMV receipts.
        /// </summary>
        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// The amount authorized by the payment network. Could be less than
        /// the requested amount for partial auth.
        /// </summary>
        [JsonProperty(PropertyName = "authorizedAmount")]
        [JsonConverter(typeof(CurrencyJsonConverter))]
        public decimal AuthorizedAmount { get; set; }

        /// <summary>
        /// The type of transaction performed (CHARGE, PREAUTH, REFUND, etc).
        /// </summary>
        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// The method by which the payment card was entered
        /// (MSR, CHIP, KEYED, etc.)
        /// </summary>
        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }
    }
}
