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

        public const string HeaderNonce = "Nonce";
        public const string HeaderTimestamp = "Timestamp";
        public const string HeaderAuthorization = "Authorization";
        public const string AuthSchemeDual = "Dual";
        public const char CipherTextFieldSep = '|';

        public const int AesKeySizeBytes = 16;
        public const int NonceSizeBytes = 32;

        private static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

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

        public static string GenerateNonce()
        {
            byte[] nonceBytes = new byte[NonceSizeBytes];
            rand.GetBytes(nonceBytes);

            return BitConverter.ToString(nonceBytes).Replace("-", string.Empty);
        }

        public static string GetTimestamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }

        public static string ToHex(byte[] input)
        {
            return BitConverter.ToString(input).Replace("-", string.Empty).ToLower();
        }

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