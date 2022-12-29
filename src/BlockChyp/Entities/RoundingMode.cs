using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoundingMode
    {
        /// <summary>Round fractional pennies up.</summary>
        [EnumMember(Value = "up")]
        Up,

        /// <summary>Round fractional pennies to the nearest whole penny.</summary>
        [EnumMember(Value = "nearest")]
        Nearest,

        /// <summary>Round fractional pennies down.</summary>
        [EnumMember(Value = "down")]
        Down,
    }
}
