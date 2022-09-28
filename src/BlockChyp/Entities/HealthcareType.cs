// Copyright 2019 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HealthcareType
    {
        /// <summary>General healthcare.</summary>
        [EnumMember(Value = "healthcare")]
        Healthcare,

        /// <summary>Prescription amount.</summary>
        [EnumMember(Value = "prescription")]
        Prescription,

        /// <summary>Vision/optical services.</summary>
        [EnumMember(Value = "vision")]
        Vision,

        /// <summary>Clinic or other qualified medical expense.</summary>
        [EnumMember(Value = "clinic")]
        Clinic,

        /// <summary>Dental services.</summary>
        [EnumMember(Value = "dental")]
        Dental,
    }
}
