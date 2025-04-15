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
    /// Details about a merchant user.
    /// </summary>
    public class MerchantUser : BaseEntity
    {
        /// <summary>
        /// Whether or not these results are for test or live merchants.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The user's primary key.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The user account status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The type of user account.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The role codes assigned to this user.
        /// </summary>
        [JsonProperty(PropertyName = "roles")]
        public List<string> Roles { get; set; }

        /// <summary>
        /// Whether or not this user account is locked.
        /// </summary>
        [JsonProperty(PropertyName = "locked")]
        public bool Locked { get; set; }
    }
}
