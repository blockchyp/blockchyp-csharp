// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// An authorization request for a charge, preauth, or reverse transaction.
    /// </summary>
    public class AuthorizationRequest : BaseEntity, ICoreRequest, IPaymentMethod, IPreviousTransaction, IRequestAmount, ISignatureRequest, ISubtotals, ITerminalReference
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
        /// The ID of the previous transaction being referenced.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The transaction currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The requested amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// That the request is tax exempt. Only required for tax exempt level 2 processing.
        /// </summary>
        [JsonProperty(PropertyName = "taxExempt")]
        public bool TaxExempt { get; set; }

        /// <summary>
        /// A flag to add a surcharge to the transaction to cover credit card fees, if
        /// permitted.
        /// </summary>
        [JsonProperty(PropertyName = "surcharge")]
        public bool Surcharge { get; set; }

        /// <summary>
        /// A flag that applies a discount to negate the surcharge for debit transactions or
        /// other surcharge ineligible payment methods.
        /// </summary>
        [JsonProperty(PropertyName = "cashDiscount")]
        public bool CashDiscount { get; set; }

        /// <summary>
        /// A location on the filesystem which a customer signature should be written to.
        /// </summary>
        [JsonProperty(PropertyName = "sigFile")]
        public string SigFile { get; set; }

        /// <summary>
        /// The image format to be used for returning signatures.
        /// </summary>
        [JsonProperty(PropertyName = "sigFormat")]
        public SignatureFormat SigFormat { get; set; }

        /// <summary>
        /// The width that the signature image should be scaled to, preserving the aspect
        /// ratio. If not provided, the signature is returned in the terminal's max
        /// resolution.
        /// </summary>
        [JsonProperty(PropertyName = "sigWidth")]
        public int SigWidth { get; set; }

        /// <summary>
        /// Whether or not signature prompt should be skipped on the terminal. The terminal
        /// will indicate whether or not a signature is required by the card in the receipt
        /// suggestions response.
        /// </summary>
        [JsonProperty(PropertyName = "disableSignature")]
        public bool DisableSignature { get; set; }

        /// <summary>
        /// The tip amount.
        /// </summary>
        [JsonProperty(PropertyName = "tipAmount")]
        public string TipAmount { get; set; }

        /// <summary>
        /// The tax amount.
        /// </summary>
        [JsonProperty(PropertyName = "taxAmount")]
        public string TaxAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an FSA card. This amount
        /// may be less than the transaction total, in which case only this amount will be
        /// charged if an FSA card is presented. If the FSA amount is paid on an FSA card, then
        /// the FSA amount authorized will be indicated on the response.
        /// </summary>
        [JsonProperty(PropertyName = "fsaEligibleAmount")]
        public string FsaEligibleAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an HSA card.
        /// </summary>
        [JsonProperty(PropertyName = "hsaEligibleAmount")]
        public string HsaEligibleAmount { get; set; }

        /// <summary>
        /// The amount of the transaction that should be charged to an EBT card.
        /// </summary>
        [JsonProperty(PropertyName = "ebtEligibleAmount")]
        public string EbtEligibleAmount { get; set; }

        /// <summary>
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// Used to validate online gift card authorizations.
        /// </summary>
        [JsonProperty(PropertyName = "onlineAuthCode")]
        public string OnlineAuthCode { get; set; }

        /// <summary>
        /// That the payment method should be added to the token vault alongside the
        /// authorization.
        /// </summary>
        [JsonProperty(PropertyName = "enroll")]
        public bool Enroll { get; set; }

        /// <summary>
        /// A narrative description of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// That the terminal should request a tip from the user before starting the
        /// transaction.
        /// </summary>
        [JsonProperty(PropertyName = "promptForTip")]
        public bool PromptForTip { get; set; }

        /// <summary>
        /// That cash back should be enabled for supported cards.
        /// </summary>
        [JsonProperty(PropertyName = "cashBackEnabled")]
        public bool CashBackEnabled { get; set; }

        /// <summary>
        /// A map of alternate currencies and the price in each currency.
        /// </summary>
        [JsonProperty(PropertyName = "altPrices")]
        public Dictionary<string, string> AltPrices { get; set; }

        /// <summary>
        /// Suggested receipt fields.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }
    }
}
