using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BlockChyp.Client
{
    public static class Crypto
    {

        private const string HeaderNonce = "Nonce";

        private const string HeaderTimestamp = "Timestamp";

        private const string HeaderAuthorization = "Authorization";

        private const string AuthSchemeDual = "Dual";

        private const char CipherTextFieldSep = '|';

        private const int AesKeySizeBytes = 16;

        private const int NonceSizeBytes = 32;

        private static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

        /// <summary>Generates request headers for authorization to the BlockChyp gateway.</summary>
        /// <param name="credentials">API credentials used to generate request headers.</param>
        public static Dictionary<string, string> GenerateAuthHeaders(ApiCredentials credentials)
        {
            var nonce = GenerateNonce();
            var timestamp = GetTimestamp();

            var toSign = credentials.ApiKey + credentials.BearerToken + timestamp + nonce;
            byte[] key = FromHex(credentials.SigningKey);
            byte[] payload = Encoding.ASCII.GetBytes(toSign);

            string signature;
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hashed = hmac.ComputeHash(payload);
                signature = ToHex(hashed);
            }

            return new Dictionary<string, string>
            {
                [HeaderNonce] = nonce,
                [HeaderTimestamp] = timestamp,
                [HeaderAuthorization] = $"{AuthSchemeDual} {credentials.BearerToken}:{credentials.ApiKey}:{signature}",
            };
        }

        /// <summary>Generates a random nonce for use in requests.</summary>
        public static string GenerateNonce()
        {
            byte[] nonceBytes = new byte[NonceSizeBytes];
            rand.GetBytes(nonceBytes);

            return BitConverter.ToString(nonceBytes).Replace("-", string.Empty);
        }

        /// <summary>Returns the current timestamp in RFS 3339 format.</summary>
        public static string GetTimestamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }

        /// <summary>Converts a byte array to a hexadecimal string.</summary>
        /// <param name="input">The byte array to convert.</param>
        public static string ToHex(byte[] input)
        {
            return BitConverter.ToString(input).Replace("-", string.Empty).ToLower();
        }

        /// <summary>Converts a hexadecimal string to a byte array.</summary>
        /// <param name="input">The hexadecimal string to convert.</param>
        public static byte[] FromHex(string input)
        {
            var ln = input.Length / 2;
            var result = new byte[ln];

            for (int i = 0; i < ln; i++)
            {
                result[i] = Convert.ToByte(input.Substring(i * 2, 2), 16);
            }

            return result;
        }

        /// <summary>Decrypts ciphertext to a byte array.</summary>
        /// <param name="cipherText">The ciphertext to decrypt.</param>
        /// <param name="key">The cryptographic key used to decrypt the payload.</param>
        public static string Decrypt(string cipherText, byte[] key)
        {
            if (String.IsNullOrEmpty(cipherText))
            {
                return null;
            }

            string[] tokens = cipherText.Split(CipherTextFieldSep);

            var iv = FromHex(tokens[0]);
            var payload = FromHex(tokens[1]);

            string output = null;

            using (var aes = Aes.Create())
            {
                aes.Key = payload;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var mem = new MemoryStream(payload))
                using (var crypto = new CryptoStream(mem, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(crypto))
                {
                    output = reader.ReadToEnd();
                }
            }

            return output;
        }

        /// <summary>Encrypts the string payload to a byte array.</summary>
        /// <param name="plainText">The plaintext payload to encrypt.</param>
        /// <param name="key">The cryptographic key used to encrypt the payload.</param>
        public static string Encrypt(string plainText, byte[] key)
        {
            string output = null;

            using (var aes = Aes.Create())
            {
                aes.Key = key;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var mem = new MemoryStream())
                using (var crypto = new CryptoStream(mem, encryptor, CryptoStreamMode.Write))
                {

                    using (var writer = new StreamWriter(crypto))
                    {
                        writer.Write(plainText);
                    }

                    output = ToHex(aes.IV) + CipherTextFieldSep + ToHex(mem.ToArray());
                }
            }

            return output;
        }
    }
}
