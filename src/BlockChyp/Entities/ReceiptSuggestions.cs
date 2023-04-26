// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// EMV fields we recommend developers put on their receipts.
    /// </summary>
    public class ReceiptSuggestions : BaseEntity
    {
        /// <summary>
        /// The EMV Application Identifier.
        /// </summary>
        [JsonProperty(PropertyName = "aid")]
        public string Aid { get; set; }

        /// <summary>
        /// The EMV Application Request Cryptogram.
        /// </summary>
        [JsonProperty(PropertyName = "arqc")]
        public string Arqc { get; set; }

        /// <summary>
        /// The EMV Issuer Application Data.
        /// </summary>
        [JsonProperty(PropertyName = "iad")]
        public string Iad { get; set; }

        /// <summary>
        /// The EMV Authorization Response Code.
        /// </summary>
        [JsonProperty(PropertyName = "arc")]
        public string Arc { get; set; }

        /// <summary>
        /// The EMV Transaction Certificate.
        /// </summary>
        [JsonProperty(PropertyName = "tc")]
        public string Tc { get; set; }

        /// <summary>
        /// The EMV Terminal Verification Response.
        /// </summary>
        [JsonProperty(PropertyName = "tvr")]
        public string Tvr { get; set; }

        /// <summary>
        /// The EMV Transaction Status Indicator.
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
        /// The ID of the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The partially masked merchant key required on EMV receipts.
        /// </summary>
        [JsonProperty(PropertyName = "merchantKey")]
        public string MerchantKey { get; set; }

        /// <summary>
        /// A description of the selected AID.
        /// </summary>
        [JsonProperty(PropertyName = "applicationLabel")]
        public string ApplicationLabel { get; set; }

        /// <summary>
        /// That the receipt should contain a signature line.
        /// </summary>
        [JsonProperty(PropertyName = "requestSignature")]
        public bool RequestSignature { get; set; }

        /// <summary>
        /// The masked primary account number of the payment card, as required.
        /// </summary>
        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// The amount authorized by the payment network. Could be less than the requested
        /// amount for partial auth.
        /// </summary>
        [JsonProperty(PropertyName = "authorizedAmount")]
        public string AuthorizedAmount { get; set; }

        /// <summary>
        /// The type of transaction performed (CHARGE, PREAUTH, REFUND, etc).
        /// </summary>
        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// The method by which the payment card was entered (MSR, CHIP, KEYED, etc.).
        /// </summary>
        [JsonProperty(PropertyName = "entryMethod")]
        public string EntryMethod { get; set; }

        /// <summary>
        /// That PIN verification was performed.
        /// </summary>
        [JsonProperty(PropertyName = "pinVerified")]
        public bool PinVerified { get; set; }

        /// <summary>
        /// The customer verification method used for the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "cvmUsed")]
        public CvmType CvmUsed { get; set; }

        /// <summary>
        /// That a chip read failure caused the transaction to fall back to the magstripe.
        /// </summary>
        [JsonProperty(PropertyName = "fallback")]
        public bool Fallback { get; set; }

        /// <summary>
        /// The sequence of the transaction in the batch.
        /// </summary>
        [JsonProperty(PropertyName = "batchSequence")]
        public int BatchSequence { get; set; }

        /// <summary>
        /// The amount of cash back that was approved.
        /// </summary>
        [JsonProperty(PropertyName = "cashBackAmount")]
        public string CashBackAmount { get; set; }

        /// <summary>
        /// The amount added to the transaction to cover eligible credit card fees.
        /// </summary>
        [JsonProperty(PropertyName = "surcharge")]
        public string Surcharge { get; set; }

        /// <summary>
        /// The discount applied to the transaction for payment methods ineligible for
        /// surcharges.
        /// </summary>
        [JsonProperty(PropertyName = "cashDiscount")]
        public string CashDiscount { get; set; }
    }
}
