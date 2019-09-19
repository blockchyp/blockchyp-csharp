using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PromptType
    {
        /// <summary>Prompt for email address.</summary>
        [EnumMember(Value = "email")]
        Email,

        /// <summary>Prompt for phone number.</summary>
        [EnumMember(Value = "phone")]
        PhoneNumber,

        /// <summary>Prompt for customer number.</summary>
        [EnumMember(Value = "customer-number")]
        CustomerNumber,

        /// <summary>Prompt for rewards number.</summary>
        [EnumMember(Value = "rewards-number")]
        RewardsNumber,
    }
}
