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
    /// Models a response for details about a single batch.
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
        /// The merchant's company name.
        /// </summary>
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

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
        /// The undwriting/processing status for the the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Bank accounts for split bank account merchants.
        /// </summary>
        [JsonProperty(PropertyName = "bankAccounts")]
        public List<BankAccount> BankAccounts { get; set; }
    }
}
