using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BlockChyp.Client;
using BlockChyp.Entities;
using FsCheck;
using FsCheck.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace BlockChypTest.Client
{
    public class CryptoTest
    {
        private readonly ITestOutputHelper output;

        public CryptoTest(ITestOutputHelper output)
        {
            this.output = output;

            // Register Arbitrary instances
            Arb.Register<CryptoArbitrary>();
        }

        [Fact]
        public void CryptoTest_GenerateAuthHeaders()
        {
            var creds = new ApiCredentials(
                "SGLATIFZD7PIMLAQJ2744MOEGI",
                "FI2SWNNJHJVO6DBZEF26YEHHMY",
                "c3a8214c318dd470b0107d6c111f086b60ad695aaeb598bf7d1032eee95339a0");

            var result = Crypto.GenerateAuthHeaders(creds);
            foreach (KeyValuePair<string, string> header in result)
            {
                output.WriteLine($"{header.Key}: {header.Value}");
            }

            Assert.Equal(3, result.Count);

            Assert.NotNull(result["Nonce"]);
            Assert.NotNull(result["Timestamp"]);
            Assert.NotNull(result["Authorization"]);
        }

        /// <summary>
        /// Test that the <c>Crypto.Encrypt</c> and <c>Crypto.Decrypt</c> methods round-trip.
        /// </summary>
        [Property(MaxTest = 10000)]
        public bool prop_EncryptDecrypt_RoundTrip(NonNull<string> plaintext, AesKey aesKey)
        {
            string ciphertext = Crypto.Encrypt(plaintext.Get, aesKey.Get);
            string roundTripPlaintext = Crypto.Decrypt(ciphertext, aesKey.Get);
            return plaintext.Get == roundTripPlaintext;
        }

        /// <summary>
        /// Property: A nonce, <c>GenerateNonce(len)</c>, should be of length, <c>len</c>
        /// </summary>
        [Property(MaxTest = 10000)]
        public bool prop_NonceLength_Correct(NonceLength nonceLength)
        {
            int hexEncodedNonceLength = nonceLength.Get * 2;  // 2 hex chars == 1 byte
            return Crypto.GenerateNonce(nonceLength.Get).Length == hexEncodedNonceLength;
        }

        /// <summary>
        /// Property: A nonce, <c>GenerateNonce(len)</c>, should only contain base-16 characters.
        /// i.e. The nonce should be a hexadecimal-encoded <c>string</c>.
        /// </summary>
        [Property(MaxTest = 10000)]
        public bool prop_Nonce_IsHexEncoded(NonceLength nonceLength)
        {
            string nonce = Crypto.GenerateNonce(nonceLength.Get);
            return Regex.IsMatch(nonce, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        /// <summary>
        /// Property: <c>ba.SequenceEqual(FromHex(ToHex(ba)))</c>
        /// </summary>
        [Property(MaxTest = 10000)]
        public bool prop_ToHexFromHex_RoundTrip(byte[] ba)
        {
            return ba.SequenceEqual(Crypto.FromHex(Crypto.ToHex(ba)));
        }
    }
}
