// Copyright 2019-2024 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a bank account associated with an application.
    /// </summary>
    public class ApplicationAccount : BaseEntity
    {
        /// <summary>
        /// The name of the bank account.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The name of the bank.
        /// </summary>
        [JsonProperty(PropertyName = "bank")]
        public string Bank { get; set; }

        /// <summary>
        /// The name of the account holder.
        /// </summary>
        [JsonProperty(PropertyName = "accountHolderName")]
        public string AccountHolderName { get; set; }

        /// <summary>
        /// The routing number of the bank.
        /// </summary>
        [JsonProperty(PropertyName = "routingNumber")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// The account number.
        /// </summary>
        [JsonProperty(PropertyName = "accountNumber")]
        public string AccountNumber { get; set; }
    }
}
