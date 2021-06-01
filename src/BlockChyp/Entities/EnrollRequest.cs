// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The information needed to enroll a new payment method in the token vault.
    /// </summary>
    public class EnrollRequest : BaseEntity, ICoreRequest, IPaymentMethod, ITerminalReference
    {
        /// <summary>
        /// A user-assigned reference that can be used to recall or reverse transactions.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// Defers the response to the transaction and returns immediately. Callers
        /// should retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "async")]
        public bool Async { get; set; }

        /// <summary>
        /// Adds the transaction to the queue and returns immediately. Callers should
        /// retrive the transaction result using the Transaction Status API.
        /// </summary>
        [JsonProperty(PropertyName = "queue")]
        public bool Queue { get; set; }

        /// <summary>
        /// Whether or not the request should block until all cards have been removed from
        /// the card reader.
        /// </summary>
        [JsonProperty(PropertyName = "waitForRemovedCard")]
        public bool WaitForRemovedCard { get; set; }

        /// <summary>
        /// Override any in-progress transactions.
        /// </summary>
        [JsonProperty(PropertyName = "force")]
        public bool Force { get; set; }

        /// <summary>
        /// An identifier from an external point of sale system.
        /// </summary>
        [JsonProperty(PropertyName = "orderRef")]
        public string OrderRef { get; set; }

        /// <summary>
        /// The settlement account for merchants with split settlements.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAccount")]
        public string DestinationAccount { get; set; }

        /// <summary>
        /// Whether or not to route transaction to the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }

        /// <summary>
        /// The payment token to be used for this transaction. This should be used for
        /// recurring transactions.
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
        /// The primary account number. We recommend using the terminal or e-commerce
        /// tokenization libraries instead of passing account numbers in directly, as
        /// this would put your application in PCI scope.
        /// </summary>
        [JsonProperty(PropertyName = "pan")]
        public string Pan { get; set; }

        /// <summary>
        /// The ACH routing number for ACH transactions.
        /// </summary>
        [JsonProperty(PropertyName = "routingNumber")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// The cardholder name. Only required if the request includes a primary account
        /// number or track data.
        /// </summary>
        [JsonProperty(PropertyName = "cardholderName")]
        public string CardholderName { get; set; }

        /// <summary>
        /// The card expiration month for use with PAN based transactions.
        /// </summary>
        [JsonProperty(PropertyName = "expMonth")]
        public string ExpMonth { get; set; }

        /// <summary>
        /// The card expiration year for use with PAN based transactions.
        /// </summary>
        [JsonProperty(PropertyName = "expYear")]
        public string ExpYear { get; set; }

        /// <summary>
        /// The card CVV for use with PAN based transactions.
        /// </summary>
        [JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }

        /// <summary>
        /// The cardholder address for use with address verification.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// The cardholder postal code for use with address verification.
        /// </summary>
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// That the payment entry method is a manual keyed transaction. If this is true, no
        /// other payment method will be accepted.
        /// </summary>
        [JsonProperty(PropertyName = "manualEntry")]
        public bool ManualEntry { get; set; }

        /// <summary>
        /// The key serial number used for DUKPT encryption.
        /// </summary>
        [JsonProperty(PropertyName = "ksn")]
        public string Ksn { get; set; }

        /// <summary>
        /// The encrypted pin block.
        /// </summary>
        [JsonProperty(PropertyName = "pinBlock")]
        public string PinBlock { get; set; }

        /// <summary>
        /// Designates categories of cards: credit, debit, EBT.
        /// </summary>
        [JsonProperty(PropertyName = "cardType")]
        public CardType CardType { get; set; }

        /// <summary>
        /// Designates brands of payment methods: Visa, Discover, etc.
        /// </summary>
        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The method by which the payment card was entered (MSR, CHIP, KEYED, etc.).
        /// </summary>
        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }

        /// <summary>
        /// Customer with which the new token should be associated.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }
    }
}
