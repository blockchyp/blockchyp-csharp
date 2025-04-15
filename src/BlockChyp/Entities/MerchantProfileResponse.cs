// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a response for a single merchant profile.
    /// </summary>
    public class MerchantProfileResponse : BaseEntity, IAbstractAcknowledgement
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
        /// That the response came from the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The merchant id.
        /// </summary>
        [JsonProperty(PropertyName = "merchantId")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The primary bank mid.
        /// </summary>
        [JsonProperty(PropertyName = "bankMid")]
        public string BankMid { get; set; }

        /// <summary>
        /// The merchant's company name.
        /// </summary>
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// The dba name of the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "dbaName")]
        public string DbaName { get; set; }

        /// <summary>
        /// The name the merchant prefers on payment link invoices.
        /// </summary>
        [JsonProperty(PropertyName = "invoiceName")]
        public string InvoiceName { get; set; }

        /// <summary>
        /// The contact name for the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "contactName")]
        public string ContactName { get; set; }

        /// <summary>
        /// The contact number for the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "contactNumber")]
        public string ContactNumber { get; set; }

        /// <summary>
        /// The location name.
        /// </summary>
        [JsonProperty(PropertyName = "locationName")]
        public string LocationName { get; set; }

        /// <summary>
        /// The store number.
        /// </summary>
        [JsonProperty(PropertyName = "storeNumber")]
        public string StoreNumber { get; set; }

        /// <summary>
        /// The partner assigne reference for this merchant.
        /// </summary>
        [JsonProperty(PropertyName = "partnerRef")]
        public string PartnerRef { get; set; }

        /// <summary>
        /// The merchant's local time zone.
        /// </summary>
        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// The batch close time in the merchant's time zone.
        /// </summary>
        [JsonProperty(PropertyName = "batchCloseTime")]
        public string BatchCloseTime { get; set; }

        /// <summary>
        /// The terminal firmware update time.
        /// </summary>
        [JsonProperty(PropertyName = "terminalUpdateTime")]
        public string TerminalUpdateTime { get; set; }

        /// <summary>
        /// Flag indicating whether or not the batch automatically closes.
        /// </summary>
        [JsonProperty(PropertyName = "autoBatchClose")]
        public bool AutoBatchClose { get; set; }

        /// <summary>
        /// Flag indicating whether or not batch closure emails should be automatically
        /// sent.
        /// </summary>
        [JsonProperty(PropertyName = "disableBatchEmails")]
        public bool DisableBatchEmails { get; set; }

        /// <summary>
        /// Flag indicating whether or not pin entry is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "pinEnabled")]
        public bool PinEnabled { get; set; }

        /// <summary>
        /// Flag indicating whether or not cash back is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "cashBackEnabled")]
        public bool CashBackEnabled { get; set; }

        /// <summary>
        /// Flag indicating whether or not store and forward is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "storeAndForwardEnabled")]
        public bool StoreAndForwardEnabled { get; set; }

        /// <summary>
        /// Flag indicating whether or not partial authorizations are supported for this
        /// merchant.
        /// </summary>
        [JsonProperty(PropertyName = "partialAuthEnabled")]
        public bool PartialAuthEnabled { get; set; }

        /// <summary>
        /// Flag indicating whether or not this merchant support split settlement.
        /// </summary>
        [JsonProperty(PropertyName = "splitBankAccountsEnabled")]
        public bool SplitBankAccountsEnabled { get; set; }

        /// <summary>
        /// Floor limit for store and forward transactions.
        /// </summary>
        [JsonProperty(PropertyName = "storeAndForwardFloorLimit")]
        public string StoreAndForwardFloorLimit { get; set; }

        /// <summary>
        /// The blockchyp public key for this merchant.
        /// </summary>
        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        /// <summary>
        /// The underwriting/processing status for the the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Enables cash discount or surcharging.
        /// </summary>
        [JsonProperty(PropertyName = "cashDiscountEnabled")]
        public bool CashDiscountEnabled { get; set; }

        /// <summary>
        /// The post transaction survey timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "surveyTimeout")]
        public int SurveyTimeout { get; set; }

        /// <summary>
        /// Time a transaction result is displayed on a terminal before the terminal is
        /// automatically cleared in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "cooldownTimeout")]
        public int CooldownTimeout { get; set; }

        /// <summary>
        /// That tips are enabled for a merchant account.
        /// </summary>
        [JsonProperty(PropertyName = "tipEnabled")]
        public bool TipEnabled { get; set; }

        /// <summary>
        /// That tips should be automatically prompted for after charge and preauth
        /// transactions.
        /// </summary>
        [JsonProperty(PropertyName = "promptForTip")]
        public bool PromptForTip { get; set; }

        /// <summary>
        /// Three default values for tips. Can be provided as a percentage if a percent sign
        /// is provided. Otherwise the values are assumed to be basis points.
        /// </summary>
        [JsonProperty(PropertyName = "tipDefaults")]
        public List<string> TipDefaults { get; set; }

        /// <summary>
        /// Four default values for cashback prompts.
        /// </summary>
        [JsonProperty(PropertyName = "cashbackPresets")]
        public List<string> CashbackPresets { get; set; }

        /// <summary>
        /// That EBT cards are enabled.
        /// </summary>
        [JsonProperty(PropertyName = "ebtEnabled")]
        public bool EbtEnabled { get; set; }

        /// <summary>
        /// That refunds without transaction references are permitted.
        /// </summary>
        [JsonProperty(PropertyName = "freeRangeRefundsEnabled")]
        public bool FreeRangeRefundsEnabled { get; set; }

        /// <summary>
        /// That pin bypass is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "pinBypassEnabled")]
        public bool PinBypassEnabled { get; set; }

        /// <summary>
        /// That gift cards are disabled.
        /// </summary>
        [JsonProperty(PropertyName = "giftCardsDisabled")]
        public bool GiftCardsDisabled { get; set; }

        /// <summary>
        /// Disables terms and conditions pages in the merchant UI.
        /// </summary>
        [JsonProperty(PropertyName = "tcDisabled")]
        public bool TcDisabled { get; set; }

        /// <summary>
        /// That digital signature capture is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "digitalSignaturesEnabled")]
        public bool DigitalSignaturesEnabled { get; set; }

        /// <summary>
        /// That transactions should auto-reverse when signatures are refused.
        /// </summary>
        [JsonProperty(PropertyName = "digitalSignatureReversal")]
        public bool DigitalSignatureReversal { get; set; }

        /// <summary>
        /// The address to be used for billing correspondence.
        /// </summary>
        [JsonProperty(PropertyName = "billingAddress")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// The address to be used for shipping.
        /// </summary>
        [JsonProperty(PropertyName = "shippingAddress")]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// That Visa cards are supported.
        /// </summary>
        [JsonProperty(PropertyName = "visa")]
        public bool Visa { get; set; }

        /// <summary>
        /// That MasterCard is supported.
        /// </summary>
        [JsonProperty(PropertyName = "masterCard")]
        public bool MasterCard { get; set; }

        /// <summary>
        /// That American Express is supported.
        /// </summary>
        [JsonProperty(PropertyName = "amex")]
        public bool Amex { get; set; }

        /// <summary>
        /// That Discover cards are supported.
        /// </summary>
        [JsonProperty(PropertyName = "discover")]
        public bool Discover { get; set; }

        /// <summary>
        /// That JCB (Japan Card Bureau) cards are supported.
        /// </summary>
        [JsonProperty(PropertyName = "jcb")]
        public bool Jcb { get; set; }

        /// <summary>
        /// That China Union Pay cards are supported.
        /// </summary>
        [JsonProperty(PropertyName = "unionPay")]
        public bool UnionPay { get; set; }

        /// <summary>
        /// That contactless EMV cards are supported.
        /// </summary>
        [JsonProperty(PropertyName = "contactlessEmv")]
        public bool ContactlessEmv { get; set; }

        /// <summary>
        /// That manual card entry is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "manualEntryEnabled")]
        public bool ManualEntryEnabled { get; set; }

        /// <summary>
        /// Requires a zip code to be entered for manually entered transactions.
        /// </summary>
        [JsonProperty(PropertyName = "manualEntryPromptZip")]
        public bool ManualEntryPromptZip { get; set; }

        /// <summary>
        /// Requires a street number to be entered for manually entered transactions.
        /// </summary>
        [JsonProperty(PropertyName = "manualEntryPromptStreetNumber")]
        public bool ManualEntryPromptStreetNumber { get; set; }

        /// <summary>
        /// That this merchant is boarded on BlockChyp in gateway only mode.
        /// </summary>
        [JsonProperty(PropertyName = "gatewayOnly")]
        public bool GatewayOnly { get; set; }

        /// <summary>
        /// Bank accounts for split bank account merchants.
        /// </summary>
        [JsonProperty(PropertyName = "bankAccounts")]
        public List<BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// That a merchant is allowed to send a surcharge amount directly to the gateway.
        /// </summary>
        [JsonProperty(PropertyName = "passthroughSurchargeEnabled")]
        public bool PassthroughSurchargeEnabled { get; set; }
    }
}
