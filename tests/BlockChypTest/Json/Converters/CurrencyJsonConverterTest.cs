using System.Collections.Generic;
using System.Linq;
using BlockChyp.Json;
using Newtonsoft.Json;
using FsCheck;
using FsCheck.Xunit;

namespace BlockChypTest.Json
{
    internal static class Helpers
    {
        public static IEnumerable<(K, V)> flattenDictionary<K, V>(Dictionary<K, V> d)
        {
            return d.Keys.Zip(d.Values, (k, v) => (k, v));
        }

        public static string flattenDictionaryToString<K, V>(Dictionary<K, V> d)
        {
            string s = string.Join(",", Helpers.flattenDictionary(d));
            return $"[{s}]";
        }
    }

    public class CurrencyJsonConverterTest
    {
        /// <summary>
        /// Test that successively serializing and deserializing a <c>decimal</c> value using <c>CurrencyJsonConverter</c>
        /// yields the same initial <c>decimal</c> value (formatted appropriately by rounding to 2 decimal places).
        /// </summary>
        [Property(MaxTest = 10000, Arbitrary = new[] { typeof(CurrencyJsonConverterArbitrary) })]
        public bool prop_CurrencyJsonConverter_RoundTrip(decimal x)
        {
            string json = JsonConvert.SerializeObject(x, new CurrencyJsonConverter());
            decimal roundTripX = JsonConvert.DeserializeObject<decimal>(json, new CurrencyJsonConverter());
            return x == roundTripX;
        }

        /// <summary>
        /// Test that successively serializing and deserializing a <c>decimal</c> value using <c>CurrencyJsonConverter</c>
        /// yields the same initial <c>decimal</c> value (formatted appropriately by rounding to 2 decimal places).
        /// </summary>
        [Property(MaxTest = 10000, Arbitrary = new[] { typeof(CurrencyJsonConverterArbitrary) })]
        public Property prop_CurrencyJsonConverter_Dictionary_RoundTrip(Dictionary<string, decimal> dict)
        {
            string json = JsonConvert.SerializeObject(dict, new CurrencyJsonConverter());
            Dictionary<string, decimal> roundTripDict = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(
                json,
                new CurrencyJsonConverter()
            );
            // TODO: Need a proper `Dictionary` equality check.
            return (
                dict.Count == roundTripDict.Count
                && !dict.Except(roundTripDict).Any()
            ).Label($"{Helpers.flattenDictionaryToString(dict)} != {Helpers.flattenDictionaryToString(roundTripDict)}");
        }
    }
}
