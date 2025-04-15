// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models meta data about a merchant bank account.
    /// </summary>
    public class BankAccount : BaseEntity
    {
        /// <summary>
        /// The account identifier to be used with authorization requests.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the account.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The purpose of the account.
        /// </summary>
        [JsonProperty(PropertyName = "purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// The masked account number.
        /// </summary>
        [JsonProperty(PropertyName = "maskedAccountNumber")]
        public string MaskedAccountNumber { get; set; }
    }
}
