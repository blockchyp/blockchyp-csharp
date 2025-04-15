// Copyright 2019-2025 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models a physical address.
    /// </summary>
    public class Address : BaseEntity
    {
        /// <summary>
        /// The first line of the street address.
        /// </summary>
        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }

        /// <summary>
        /// The second line of the street address.
        /// </summary>
        [JsonProperty(PropertyName = "address2")]
        public string Address2 { get; set; }

        /// <summary>
        /// The city associated with the street address.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// The state or province associated with the street address.
        /// </summary>
        [JsonProperty(PropertyName = "stateOrProvince")]
        public string StateOrProvince { get; set; }

        /// <summary>
        /// The postal code associated with the street address.
        /// </summary>
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The ISO country code associated with the street address.
        /// </summary>
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The latitude component of the address's GPS coordinates.
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; set; }

        /// <summary>
        /// The longitude component of the address's GPS coordinates.
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; set; }
    }
}
