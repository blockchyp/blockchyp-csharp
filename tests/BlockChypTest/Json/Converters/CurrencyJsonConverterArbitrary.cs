using System;
using FsCheck;

namespace BlockChypTest.Json
{
    public class CurrencyJsonConverterArbitrary
    {
        /// <summary>
        /// Generates a <c>decimal</c> rounded to 2 decimal places.
        /// </summary>
        /// <remarks>
        /// This generator rounds using <c>MidpointRounding.AwayFromZero</c>.
        /// </remarks>
        public static Arbitrary<decimal> RoundedDecimal2DP() =>
            /*
             * Beware of attempting to use `Arb.Generate<T>` in your implementation of an `Arbitrary<T>`:
             *
             * https://github.com/fscheck/FsCheck/issues/109
             * https://stackoverflow.com/a/44800540
             *
             * Got around this by utilizing an `Arbitrary` from `Arb.Default`.
             */
            Arb.Default.Decimal()
                .Generator
                .Select(x => decimal.Round(x, 2, MidpointRounding.AwayFromZero))
                .ToArbitrary();
    }
}
