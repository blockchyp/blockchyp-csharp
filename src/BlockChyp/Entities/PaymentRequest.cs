using Newtonsoft.Json;

namespace BlockChyp
{
    public class PaymentRequest : AmountRequest
    {
        /// <summary>
        /// The name of the payment terminal to which the transaction will be
        /// routed.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The payment token to be used for this transaction. This should be
        /// used for recurring transactions.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Track 1 magnetic stripe data.
        /// </summary>
        [JsonProperty(PropertyName = "track1")]
        public string Track1 { get; set; }

        /// <summary>
        /// Track 2 magnetic stripe data.
        /// </summary>
        [JsonProperty(PropertyName = "track2")]
        public string Track2 { get; set; }

        /// <summary>
        /// Primary account number. We recommend using the terminal or
        /// e-commerce tokenization libraries instead of passing
        /// account numbers in directly, as this would put your application
        /// in PCI scope.
        /// </summary>
        [JsonProperty(PropertyName = "pan")]
        public string Pan { get; set; }

        /// <summary>
        /// The ACH routing number for ACH transactions.
        /// </summary>
        [JsonProperty(PropertyName = "routingNumber")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// The cardholder name. Only required if the request includes a
        /// primary account number or track data.
        /// </summary>
        [JsonProperty(PropertyName = "cardholderName")]
        public string CardholderName { get; set; }

        /// <summary>
        /// The card expiration month for use with PAN based transactions.
        /// </summary>
        [JsonProperty(PropertyName = "expMonth")]
        public string ExpirationMonth { get; set; }

        /// <summary>
        /// The card expiration year for use with PAN based transactions.
        /// </summary>
        [JsonProperty(PropertyName = "expYear")]
        public string ExpirationYear { get; set; }

        /// <summary>
        /// The card CVV for use with PAN based transactions.
        /// </summary>
        [JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }

        /// <summary>
        /// Cardholder address for use with address verification.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Cardholder postal code for use with address verification.
        /// </summary>
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Whether or not the terminal should allow keying in a card number
        /// manually instead of reading it from a card.
        /// </summary>
        [JsonProperty(PropertyName = "manualEntry")]
        public bool ManualEntry { get; set; }

        /// <summary>
        /// The preferred signature image output format. Supports:
        /// PNG, JPEG (case insensitive).
        /// </summary>
        [JsonProperty(PropertyName = "sigFormat")]
        public string SignatureFormat { get; set; }

        /// <summary>
        /// Maximum width of the signature image in pixels.
        /// </summary>
        [JsonProperty(PropertyName = "sigWidth")]
        public int SignatureWidth { get; set; }

        /// <summary>
        /// The desired output location for the signature file on the local
        /// filesystem.
        /// </summary>
        [JsonIgnore]
        public string SignatureFile { get; set; }

        /// <summary>
        /// Key serial number for use with DUKPT PIN encryption.
        /// </summary>
        [JsonProperty(PropertyName = "ksn")]
        public string Ksn { get; set; }

        /// <summary>
        /// PIN encoded in ANSI X9.8 format.
        /// </summary>
        [JsonProperty(PropertyName = "pinblock")]
        public string Pinblock { get; set; }

        /// <summary>
        /// Identifier for the type of card being used
        /// (credit, EBT, debit, gift card).
        /// </summary>
        [JsonProperty(PropertyName = "cardType")]
        public int CardType { get; set; }

        /// <summary>
        /// The card brand (VISA, MC, AMEX, etc).
        /// </summary>
        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }
    }
}
