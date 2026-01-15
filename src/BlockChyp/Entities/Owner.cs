// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models an individual with 25% or more ownership interest in a company.
    /// </summary>
    public class Owner : BaseEntity
    {
        /// <summary>
        /// The first name of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// The job title of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "jobTitle")]
        public string JobTitle { get; set; }

        /// <summary>
        /// The tax identification number (SSN) of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "taxIdNumber")]
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// The phone number of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The date of birth of the owner in mm/dd/yyyy format.
        /// </summary>
        [JsonProperty(PropertyName = "dob")]
        public string Dob { get; set; }

        /// <summary>
        /// The percentage of ownership.
        /// </summary>
        [JsonProperty(PropertyName = "ownership")]
        public string Ownership { get; set; }

        /// <summary>
        /// The address of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        /// <summary>
        /// The email address of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// A single line representation of the owner's address.
        /// </summary>
        [JsonProperty(PropertyName = "singleLineAddress")]
        public string SingleLineAddress { get; set; }

        /// <summary>
        /// The type of entity this owner represents.
        /// </summary>
        [JsonProperty(PropertyName = "entityType")]
        public string EntityType { get; set; }

        /// <summary>
        /// The driver's license number of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "dlNumber")]
        public string DlNumber { get; set; }

        /// <summary>
        /// The state that issued the owner's driver's license.
        /// </summary>
        [JsonProperty(PropertyName = "dlStateOrProvince")]
        public string DlStateOrProvince { get; set; }

        /// <summary>
        /// The expiration date of the owner's driver's license.
        /// </summary>
        [JsonProperty(PropertyName = "dlExpiration")]
        public string DlExpiration { get; set; }
    }
}
