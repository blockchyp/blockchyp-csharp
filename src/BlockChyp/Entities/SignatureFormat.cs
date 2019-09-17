using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SignatureFormat
    {
        /// <summery>No format specified.</summery>
        [EnumMember(Value = "")]
        None,

        /// <summery>PNG image format.</summery>
        [EnumMember(Value = "png")]
        PNG,

        /// <summery>JPG image format.</summery>
        [EnumMember(Value = "jpg")]
        JPG,

        /// <summery>GIF image format.</summery>
        [EnumMember(Value = "gif")]
        GIF,
    }
}
