// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically. Changes to this file will be lost
// every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Models basic information needed to create a test merchant.
    /// </summary>
    public class CreateTestMerchantRequest : BaseEntity
    {
        /// <summary>
        /// The DBA name for the test merchant.
        /// </summary>
        [JsonProperty(PropertyName = "dbaName")]
        public string DbaName { get; set; }

        /// <summary>
        /// The corporate name for the test merchant.
        /// </summary>
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// The request timeout in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "timeout")]
        public int Timeout { get; set; }
    }
}
