using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SignatureFormat
    {
        /// <summary>No format specified.</summary>
        [EnumMember(Value = "")]
        None,

        /// <summary>PNG image format.</summary>
        [EnumMember(Value = "png")]
        PNG,

        /// <summary>JPG image format.</summary>
        [EnumMember(Value = "jpg")]
        JPG,

        /// <summary>GIF image format.</summary>
        [EnumMember(Value = "gif")]
        GIF,
    }
}
