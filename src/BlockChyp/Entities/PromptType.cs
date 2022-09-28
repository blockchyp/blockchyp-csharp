using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PromptType
    {
        /// <summary>Prompt for a monetary amount.</summary>
        [EnumMember(Value = "amount")]
        Amount,

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

        /// <summary>Prompt for first name.</summary>
        [EnumMember(Value = "first-name")]
        FirstName,

        /// <summary>Prompt for last name.</summary>
        [EnumMember(Value = "last-name")]
        LastName,
    }
}
