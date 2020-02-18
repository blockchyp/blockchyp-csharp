using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AvsResponse
    {
        /// <summary>Address verification is not applicable.</summary>
        [EnumMember(Value = "")]
        NotApplicable,

        /// <summary>Address verification is not supported.</summary>
        [EnumMember(Value = "not_supported")]
        NotSupported,

        /// <summary>System failed, address verification can be retried.</summary>
        [EnumMember(Value = "retry")]
        Retry,

        /// <summary>No provided AVS data matched.</summary>
        [EnumMember(Value = "no_match")]
        NoMatch,

        /// <summary>Address matched, but postal code did not.</summary>
        [EnumMember(Value = "address_match")]
        AddressMatch,

        /// <summary>Postal code matched, but address did not.</summary>
        [EnumMember(Value = "zip_match")]
        PostalCodeMatch,

        /// <summary>Address and postal code matched.</summary>
        [EnumMember(Value = "match")]
        AddressAndPostalCodeMatch,
    }
}
