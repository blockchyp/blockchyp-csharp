using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Day of week constants used by the for BlockChyp SDK.
    /// </summary>
    public enum Weekday
    {
        /// <summary>
        /// Sunday (0)
        /// </summary>
        SUNDAY,

        /// <summary>
        /// Monday (1)
        /// </summary>
        MONDAY,

        /// <summary>
        /// Tuesday (2)
        /// </summary>
        TUESDAY,

        /// <summary>
        /// Wednesday (3)
        /// </summary>
        WEDNESDAY,

        /// <summary>
        /// Thursday (4)
        /// </summary>
        THURSDAY,

        /// <summary>
        /// Friday (5)
        /// </summary>
        FRIDAY,

        /// <summary>
        /// Saturday (6)
        /// </summary>
        SATURDAY,
    }
}
