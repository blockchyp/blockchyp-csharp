using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PromptType
    {
        /// <summery>Prompt for email address.</summery>
        [EnumMember(Value = "email")]
        Email,

        /// <summery>Prompt for phone number.</summery>
        [EnumMember(Value = "phone")]
        PhoneNumber,

        /// <summery>Prompt for customer number.</summery>
        [EnumMember(Value = "customer-number")]
        CustomerNumber,

        /// <summery>Prompt for rewards number.</summery>
        [EnumMember(Value = "rewards-number")]
        RewardsNumber,
    }
}
