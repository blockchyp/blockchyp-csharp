// Copyright 2019-2026 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a customer token.
    /// </summary>
    public class CustomerToken : BaseEntity
    {
        /// <summary>
        /// BlockChyp assigned customer id.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Masked primary account number.
        /// </summary>
        [JsonProperty(PropertyName = "maskedPan")]
        public string MaskedPan { get; set; }

        /// <summary>
        /// Expiration month.
        /// </summary>
        [JsonProperty(PropertyName = "expiryMonth")]
        public string ExpiryMonth { get; set; }

        /// <summary>
        /// Expiration month.
        /// </summary>
        [JsonProperty(PropertyName = "expiryYear")]
        public string ExpiryYear { get; set; }

        /// <summary>
        /// Payment type.
        /// </summary>
        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }

        /// <summary>
        /// Bank account type (checking, saving).
        /// </summary>
        [JsonProperty(PropertyName = "accountType")]
        public string AccountType { get; set; }

        /// <summary>
        /// Bank account holder type (personal, business).
        /// </summary>
        [JsonProperty(PropertyName = "accountHolderType")]
        public string AccountHolderType { get; set; }

        /// <summary>
        /// Bank name.
        /// </summary>
        [JsonProperty(PropertyName = "bankName")]
        public string BankName { get; set; }

        /// <summary>
        /// Routing number.
        /// </summary>
        [JsonProperty(PropertyName = "routingNumber")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// Token hash (generated with a static salt, Merchant ID, Registration Date and
        /// PAN.
        /// </summary>
        [JsonProperty(PropertyName = "tokenHash")]
        public string TokenHash { get; set; }

        /// <summary>
        /// Card bin.
        /// </summary>
        [JsonProperty(PropertyName = "bin")]
        public string Bin { get; set; }

        /// <summary>
        /// The card postal code.
        /// </summary>
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The card address.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// The card country.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// The card holder name.
        /// </summary>
        [JsonProperty(PropertyName = "cardHolderName")]
        public string CardHolderName { get; set; }

        /// <summary>
        /// Models customer records associated with a payment token.
        /// </summary>
        [JsonProperty(PropertyName = "customers")]
        public List<Customer> Customers { get; set; }
    }
}
