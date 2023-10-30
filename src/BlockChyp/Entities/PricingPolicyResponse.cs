// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a the response to a pricing policy request.
    /// </summary>
    public class PricingPolicyResponse : BaseEntity, IAbstractAcknowledgement
    {
        /// <summary>
        /// Whether or not the request succeeded.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// The error, if an error occurred.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// A narrative description of the transaction result.
        /// </summary>
        [JsonProperty(PropertyName = "responseDescription")]
        public string ResponseDescription { get; set; }

        /// <summary>
        /// The id owner of the pricing policy.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The id of the partner associated with this pricing policy.
        /// </summary>
        [JsonProperty(PropertyName = "partnerId")]
        public string PartnerId { get; set; }

        /// <summary>
        /// The id of the merchant associated with this pricing policy.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// Whether or not a pricing policy is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The date and time when the pricing policy was created.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The description of the pricing policy.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Type of pricing policy (flat vs interchange).
        /// </summary>
        [JsonProperty(PropertyName = "policyType")]
        public string PolicyType { get; set; }

        /// <summary>
        /// The percentage split of the of buy rate markup with BlockChyp.
        /// </summary>
        [JsonProperty(PropertyName = "partnerMarkupSplit")]
        public string PartnerMarkupSplit { get; set; }

        /// <summary>
        /// The flat rate percentage for standard card present transactions.
        /// </summary>
        [JsonProperty(PropertyName = "standardFlatRate")]
        public PricePoint StandardFlatRate { get; set; }

        /// <summary>
        /// The flat rate percentage for debit card transactions.
        /// </summary>
        [JsonProperty(PropertyName = "debitFlatRate")]
        public PricePoint DebitFlatRate { get; set; }

        /// <summary>
        /// The flat rate percentage for ecommerce transactions.
        /// </summary>
        [JsonProperty(PropertyName = "ecommerceFlatRate")]
        public PricePoint EcommerceFlatRate { get; set; }

        /// <summary>
        /// The flat rate percentage for keyed/manual transactions.
        /// </summary>
        [JsonProperty(PropertyName = "keyedFlatRate")]
        public PricePoint KeyedFlatRate { get; set; }

        /// <summary>
        /// The flat rate percentage for premium (high rewards) card transactions.
        /// </summary>
        [JsonProperty(PropertyName = "premiumFlatRate")]
        public PricePoint PremiumFlatRate { get; set; }

        /// <summary>
        /// The interchange markup percentage for standard card present transactions.
        /// </summary>
        [JsonProperty(PropertyName = "standardInterchangeMarkup")]
        public PricePoint StandardInterchangeMarkup { get; set; }

        /// <summary>
        /// The interchange markup percentage for debit card transactions.
        /// </summary>
        [JsonProperty(PropertyName = "debitInterchangeMarkup")]
        public PricePoint DebitInterchangeMarkup { get; set; }

        /// <summary>
        /// The interchange markup percentage for ecommerce transactions.
        /// </summary>
        [JsonProperty(PropertyName = "ecommerceInterchangeMarkup")]
        public PricePoint EcommerceInterchangeMarkup { get; set; }

        /// <summary>
        /// The interchange markup percentage for keyed/manual transactions.
        /// </summary>
        [JsonProperty(PropertyName = "keyedInterchangeMarkup")]
        public PricePoint KeyedInterchangeMarkup { get; set; }

        /// <summary>
        /// The interchange markup percentage for premium (high rewards) card
        /// transactions.
        /// </summary>
        [JsonProperty(PropertyName = "premiumInterchangeMarkup")]
        public PricePoint PremiumInterchangeMarkup { get; set; }

        /// <summary>
        /// The transaction fee for standard card present transactions.
        /// </summary>
        [JsonProperty(PropertyName = "standardTransactionFee")]
        public PricePoint StandardTransactionFee { get; set; }

        /// <summary>
        /// The transaction fee for debit card transactions.
        /// </summary>
        [JsonProperty(PropertyName = "debitTransactionFee")]
        public PricePoint DebitTransactionFee { get; set; }

        /// <summary>
        /// The transaction fee for ecommerce transactions.
        /// </summary>
        [JsonProperty(PropertyName = "ecommerceTransactionFee")]
        public PricePoint EcommerceTransactionFee { get; set; }

        /// <summary>
        /// The transaction fee for keyed/manual transactions.
        /// </summary>
        [JsonProperty(PropertyName = "keyedTransactionFee")]
        public PricePoint KeyedTransactionFee { get; set; }

        /// <summary>
        /// The transaction fee for premium (high rewards) card transactions.
        /// </summary>
        [JsonProperty(PropertyName = "premiumTransactionFee")]
        public PricePoint PremiumTransactionFee { get; set; }

        /// <summary>
        /// The transaction fee for EBT card transactions.
        /// </summary>
        [JsonProperty(PropertyName = "ebtTransactionFee")]
        public PricePoint EbtTransactionFee { get; set; }

        /// <summary>
        /// A flat fee charged per month.
        /// </summary>
        [JsonProperty(PropertyName = "monthlyFee")]
        public PricePoint MonthlyFee { get; set; }

        /// <summary>
        /// A flat fee charged per year.
        /// </summary>
        [JsonProperty(PropertyName = "annualFee")]
        public PricePoint AnnualFee { get; set; }

        /// <summary>
        /// The fee per dispute or chargeback.
        /// </summary>
        [JsonProperty(PropertyName = "chargebackFee")]
        public PricePoint ChargebackFee { get; set; }

        /// <summary>
        /// The fee per address verification operation.
        /// </summary>
        [JsonProperty(PropertyName = "avsFee")]
        public PricePoint AvsFee { get; set; }

        /// <summary>
        /// The fee per batch.
        /// </summary>
        [JsonProperty(PropertyName = "batchFee")]
        public PricePoint BatchFee { get; set; }

        /// <summary>
        /// The voice authorization fee.
        /// </summary>
        [JsonProperty(PropertyName = "voiceAuthFee")]
        public PricePoint VoiceAuthFee { get; set; }

        /// <summary>
        /// The one time account setup fee.
        /// </summary>
        [JsonProperty(PropertyName = "accountSetupFee")]
        public PricePoint AccountSetupFee { get; set; }
    }
}
