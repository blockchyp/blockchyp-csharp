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
    /// Models a merchant application form to add a merchant account.
    /// </summary>
    public class MerchantApplication : BaseEntity
    {
        /// <summary>
        /// The invite code for the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "inviteCode")]
        public string InviteCode { get; set; }

        /// <summary>
        /// The business name your customers know you by (DBA Name).
        /// </summary>
        [JsonProperty(PropertyName = "dbaName")]
        public string DbaName { get; set; }

        /// <summary>
        /// The name of the legal entity you file your taxes under.
        /// </summary>
        [JsonProperty(PropertyName = "corporateName")]
        public string CorporateName { get; set; }

        /// <summary>
        /// The business website.
        /// </summary>
        [JsonProperty(PropertyName = "webSite")]
        public string WebSite { get; set; }

        /// <summary>
        /// The business tax identification number (EIN).
        /// </summary>
        [JsonProperty(PropertyName = "taxIdNumber")]
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// The type of business entity.
        /// </summary>
        [JsonProperty(PropertyName = "entityType")]
        public string EntityType { get; set; }

        /// <summary>
        /// The state where the business is incorporated.
        /// </summary>
        [JsonProperty(PropertyName = "stateOfIncorporation")]
        public string StateOfIncorporation { get; set; }

        /// <summary>
        /// The primary type of business (e.g., Retail, Service, etc.).
        /// </summary>
        [JsonProperty(PropertyName = "merchantType")]
        public string MerchantType { get; set; }

        /// <summary>
        /// A short description of the products and services sold.
        /// </summary>
        [JsonProperty(PropertyName = "businessDescription")]
        public string BusinessDescription { get; set; }

        /// <summary>
        /// The number of years the business has been operating.
        /// </summary>
        [JsonProperty(PropertyName = "yearsInBusiness")]
        public string YearsInBusiness { get; set; }

        /// <summary>
        /// The business telephone number.
        /// </summary>
        [JsonProperty(PropertyName = "businessPhoneNumber")]
        public string BusinessPhoneNumber { get; set; }

        /// <summary>
        /// The physical address of the business.
        /// </summary>
        [JsonProperty(PropertyName = "physicalAddress")]
        public Address PhysicalAddress { get; set; }

        /// <summary>
        /// The mailing address of the business.
        /// </summary>
        [JsonProperty(PropertyName = "mailingAddress")]
        public Address MailingAddress { get; set; }

        /// <summary>
        /// The first name of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactFirstName")]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// The last name of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactLastName")]
        public string ContactLastName { get; set; }

        /// <summary>
        /// The phone number of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactPhoneNumber")]
        public string ContactPhoneNumber { get; set; }

        /// <summary>
        /// The email address of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactEmail")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// The job title of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactTitle")]
        public string ContactTitle { get; set; }

        /// <summary>
        /// The tax identification number (SSN) of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactTaxIdNumber")]
        public string ContactTaxIdNumber { get; set; }

        /// <summary>
        /// The date of birth of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactDOB")]
        public string ContactDob { get; set; }

        /// <summary>
        /// The driver's license number of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactDlNumber")]
        public string ContactDlNumber { get; set; }

        /// <summary>
        /// The state that issued the primary contact's driver's license.
        /// </summary>
        [JsonProperty(PropertyName = "contactDlStateOrProvince")]
        public string ContactDlStateOrProvince { get; set; }

        /// <summary>
        /// The expiration date of the primary contact's driver's license.
        /// </summary>
        [JsonProperty(PropertyName = "contactDlExpiration")]
        public string ContactDlExpiration { get; set; }

        /// <summary>
        /// The home address of the primary contact.
        /// </summary>
        [JsonProperty(PropertyName = "contactHomeAddress")]
        public Address ContactHomeAddress { get; set; }

        /// <summary>
        /// The role of the primary contact in the business.
        /// </summary>
        [JsonProperty(PropertyName = "contactRole")]
        public string ContactRole { get; set; }

        /// <summary>
        /// List of individuals with 25% or more ownership in the company.
        /// </summary>
        [JsonProperty(PropertyName = "owners")]
        public List<Owner> Owners { get; set; }

        /// <summary>
        /// The bank account information for the business.
        /// </summary>
        [JsonProperty(PropertyName = "manualAccount")]
        public ApplicationAccount ManualAccount { get; set; }

        /// <summary>
        /// The average transaction amount.
        /// </summary>
        [JsonProperty(PropertyName = "averageTransaction")]
        public string AverageTransaction { get; set; }

        /// <summary>
        /// The highest expected transaction amount.
        /// </summary>
        [JsonProperty(PropertyName = "highTransaction")]
        public string HighTransaction { get; set; }

        /// <summary>
        /// The average monthly transaction volume.
        /// </summary>
        [JsonProperty(PropertyName = "averageMonth")]
        public string AverageMonth { get; set; }

        /// <summary>
        /// The highest expected monthly transaction volume.
        /// </summary>
        [JsonProperty(PropertyName = "highMonth")]
        public string HighMonth { get; set; }

        /// <summary>
        /// The refund policy of the business.
        /// </summary>
        [JsonProperty(PropertyName = "refundPolicy")]
        public string RefundPolicy { get; set; }

        /// <summary>
        /// The number of days after purchase that refunds can be issued.
        /// </summary>
        [JsonProperty(PropertyName = "refundDays")]
        public string RefundDays { get; set; }

        /// <summary>
        /// The time zone of the business.
        /// </summary>
        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// The time when the daily batch should close.
        /// </summary>
        [JsonProperty(PropertyName = "batchCloseTime")]
        public string BatchCloseTime { get; set; }

        /// <summary>
        /// Indicates if the business has multiple locations.
        /// </summary>
        [JsonProperty(PropertyName = "multipleLocations")]
        public string MultipleLocations { get; set; }

        /// <summary>
        /// The name of this specific business location.
        /// </summary>
        [JsonProperty(PropertyName = "locationName")]
        public string LocationName { get; set; }

        /// <summary>
        /// The store number for this location.
        /// </summary>
        [JsonProperty(PropertyName = "storeNumber")]
        public string StoreNumber { get; set; }

        /// <summary>
        /// Indicates if the business wants to accept EBT cards.
        /// </summary>
        [JsonProperty(PropertyName = "ebtRequested")]
        public string EbtRequested { get; set; }

        /// <summary>
        /// The FNS number issued by the USDA for EBT processing.
        /// </summary>
        [JsonProperty(PropertyName = "fnsNumber")]
        public string FnsNumber { get; set; }

        /// <summary>
        /// Indicates if the business plans to accept payments through a website.
        /// </summary>
        [JsonProperty(PropertyName = "ecommerce")]
        public string Ecommerce { get; set; }

        /// <summary>
        /// Indicates if suppliers ship products directly to customers.
        /// </summary>
        [JsonProperty(PropertyName = "dropShipping")]
        public bool DropShipping { get; set; }

        /// <summary>
        /// The percentage of transactions that will be chip or swipe.
        /// </summary>
        [JsonProperty(PropertyName = "cardPresentPercentage")]
        public string CardPresentPercentage { get; set; }

        /// <summary>
        /// The percentage of transactions that will be phone orders.
        /// </summary>
        [JsonProperty(PropertyName = "phoneOrderPercentage")]
        public string PhoneOrderPercentage { get; set; }

        /// <summary>
        /// The percentage of transactions that will be e-commerce.
        /// </summary>
        [JsonProperty(PropertyName = "ecomPercentage")]
        public string EcomPercentage { get; set; }

        /// <summary>
        /// The number of days before shipment that customers are charged.
        /// </summary>
        [JsonProperty(PropertyName = "billBeforeShipmentDays")]
        public string BillBeforeShipmentDays { get; set; }

        /// <summary>
        /// Indicates if the business plans to process recurring payments.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionsSupported")]
        public string SubscriptionsSupported { get; set; }

        /// <summary>
        /// The frequency of recurring payments (if applicable).
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionFrequency")]
        public string SubscriptionFrequency { get; set; }

        /// <summary>
        /// The full legal name of the person signing the application.
        /// </summary>
        [JsonProperty(PropertyName = "signerName")]
        public string SignerName { get; set; }
    }
}
