// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CvmType
    {
        /// <summary>Customer signature.</summary>
        [EnumMember(Value = "Signature")]
        Signature,

        /// <summary>PIN verified by the terminal.</summary>
        [EnumMember(Value = "Offline PIN")]
        OfflinePin,

        /// <summary>PIN verified by the card issuer.</summary>
        [EnumMember(Value = "Online PIN")]
        OnlinePin,

        /// <summary>Consumer device verification.</summary>
        [EnumMember(Value = "CDCVM")]
        CdCvm,

        /// <summary>Customer verification was not required.</summary>
        [EnumMember(Value = "No CVM")]
        NoCvm,
    }
}
