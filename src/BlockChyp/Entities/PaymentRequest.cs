using Newtonsoft.Json;

namespace BlockChyp
{
    public class PaymentRequest : AmountRequest
    {
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "track1")]
        public string Track1 { get; set; }

        [JsonProperty(PropertyName = "track2")]
        public string Track2 { get; set; }

        [JsonProperty(PropertyName = "pan")]
        public string Pan { get; set; }

        [JsonProperty(PropertyName = "routingNumber")]
        public string RoutingNumber { get; set; }

        [JsonProperty(PropertyName = "cardholderName")]
        public string CardholderName { get; set; }

        [JsonProperty(PropertyName = "expMonth")]
        public string ExpirationMonth { get; set; }

        [JsonProperty(PropertyName = "expYear")]
        public string ExpirationYear { get; set; }

        [JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "manualEntry")]
        public bool ManualEntry { get; set; }

        [JsonProperty(PropertyName = "sigFormat")]
        public string SignatureFormat { get; set; }

        [JsonProperty(PropertyName = "sigWidth")]
        public int SignatureWidth { get; set; }

        // TODO Omit from JSON
        public string SignatureFile { get; set; }

        [JsonProperty(PropertyName = "ksn")]
        public string Ksn { get; set; }

        [JsonProperty(PropertyName = "pinblock")]
        public string Pinblock { get; set; }

        [JsonProperty(PropertyName = "cardType")]
        public int CardType { get; set; }

        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }
    }
}