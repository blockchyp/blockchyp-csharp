// Copyright 2019-2023 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a customer record.
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// BlockChyp assigned customer id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Optional customer ref that can be used for the client's system's customer id.
        /// </summary>
        [JsonProperty(PropertyName = "customerRef")]
        public string CustomerRef { get; set; }

        /// <summary>
        /// Customer's first name.
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last name.
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Customer's company name.
        /// </summary>
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Customer's email address.
        /// </summary>
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Customer's SMS or mobile number.
        /// </summary>
        [JsonProperty(PropertyName = "smsNumber")]
        public string SmsNumber { get; set; }

        /// <summary>
        /// Model saved payment methods associated with a customer.
        /// </summary>
        [JsonProperty(PropertyName = "paymentMethods")]
        public List<CustomerToken> PaymentMethods { get; set; }
    }
}
