// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Creates a payment link.
    /// </summary>
    public class PaymentLinkRequest : BaseEntity, ICoreRequest, IRequestAmount, ITerminalReference
    {
        /// <summary>
        /// The transaction reference string assigned to the transaction request. If no
        /// transaction ref was assiged on the request, then the gateway will randomly
        /// generate one.
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
        /// The name of the target payment terminal.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// Automatically send the link via an email.
        /// </summary>
        [JsonProperty(PropertyName = "autoSend")]
        public bool AutoSend { get; set; }

        /// <summary>
        /// That the payment method should be added to the token vault alongside the
        /// authorization.
        /// </summary>
        [JsonProperty(PropertyName = "enroll")]
        public bool Enroll { get; set; }

        /// <summary>
        /// Flags the payment link as cashier facing.
        /// </summary>
        [JsonProperty(PropertyName = "cashier")]
        public bool Cashier { get; set; }

        /// <summary>
        /// Description explaining the transaction for display to the user.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Subject of the payment email.
        /// </summary>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Transaction details for display on the payment email.
        /// </summary>
        [JsonProperty(PropertyName = "transaction")]
        public TransactionDisplayTransaction Transaction { get; set; }

        /// <summary>
        /// Customer information.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Optional callback url to which transaction responses for this link will be
        /// posted.
        /// </summary>
        [JsonProperty(PropertyName = "callbackUrl")]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// An alias for a Terms and Conditions template configured in the BlockChyp
        /// dashboard.
        /// </summary>
        [JsonProperty(PropertyName = "tcAlias")]
        public string TcAlias { get; set; }

        /// <summary>
        /// The name of the Terms and Conditions the user is accepting.
        /// </summary>
        [JsonProperty(PropertyName = "tcName")]
        public string TcName { get; set; }

        /// <summary>
        /// The content of the terms and conditions that will be presented to the user.
        /// </summary>
        [JsonProperty(PropertyName = "tcContent")]
        public string TcContent { get; set; }
    }
}
