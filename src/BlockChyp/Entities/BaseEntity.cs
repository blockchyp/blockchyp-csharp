using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// The base class for BlockChyp requests and responses.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>Deserializes data from JSON to a specific entity type.</summary>
        /// <typeparam name="T">The type of the entity to return.</typeparam>
        /// <param name="value">The JSON data to deserialize.</param>
        /// <returns>The deserialized entity.</returns>
        public static T FromJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>Creates a string representation of the entity.</summary>
        /// <returns>A string representing the entity.</returns>
        public override string ToString()
        {
            return string.Format(
                "{0}: {1}",
                base.ToString(),
                JsonConvert.SerializeObject(
                    this,
                    Formatting.Indented));
        }

        /// <summary>Serializes the entity to JSON.</summary>
        /// <returns>A JSON serialized representation of the entity.</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
