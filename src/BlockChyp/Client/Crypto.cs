using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BlockChyp.Client
{
    public static class Crypto
    {

        /// <summary>The BlockChyp terminal root certificate authority certificate.</summary>
        public static Lazy<X509Certificate2> BlockChypRootCertificate = new Lazy<X509Certificate2>(GetBlockChypRootCertificate);

        private const string HeaderNonce = "Nonce";

        private const string HeaderTimestamp = "Timestamp";

        private const string HeaderAuthorization = "Authorization";

        private const string AuthSchemeDual = "Dual";

        private const string TerminalCommonName = "blockchyp-terminal";

        private const char CipherTextFieldSep = '|';

        private const int AesKeySizeBytes = 16;

        private const int NonceSizeBytes = 32;

        private static RNGCryptoServiceProvider _rand = new RNGCryptoServiceProvider();

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
            _rand.GetBytes(nonceBytes);

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

        /// <summary>
        /// Validates that terminal webservers are using a certificate that was signed
        /// by the BlockChyp root CA.
        /// </summary>
        public static bool ValidateTerminalCertificate(
            object request,
            X509Certificate2 cert,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            if (sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateNotAvailable))
            {
                // Terminals should always serve a certificate.
                return false;
            }

            if (sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateChainErrors))
            {
                // First, ignore that the root CA is unknown. We'll check that
                // the root of the chain matches our root CA at the end.
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                chain.ChainPolicy.ExtraStore.Add(BlockChypRootCertificate.Value);

                // Validate that the chain can be built.
                if (!chain.Build(cert) || chain.ChainElements.Count == 0)
                {
                    return false;
                }

                // Now we know that the chain is valid, so we only have to
                // prove that the root of the chain is our root CA.
                if (chain.ChainElements[chain.ChainElements.Count-1].Certificate.Thumbprint != BlockChypRootCertificate.Value.Thumbprint)
                {
                    return false;
                }
            }

            // Terminals on the local network use a static common name.
            if (sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateNameMismatch))
            {
                return cert.GetNameInfo(X509NameType.SimpleName, false) == TerminalCommonName;
            }

            return false;
        }

        /// <summary>
        /// Overload for net45 support.
        /// </summary>
        public static bool ValidateTerminalCertificate(
            object request,
            X509Certificate cert,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return ValidateTerminalCertificate(request, new X509Certificate2(cert), chain, sslPolicyErrors);
        }

        private static X509Certificate2 GetBlockChypRootCertificate()
        {
            var certData = new MemoryStream();
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("BlockChyp.Assets.BlockChyp.crt"))
            {
                if (stream == null)
                {
                    throw new BlockChypException("BlockChyp CA Certificate not found");
                }
                stream.CopyTo(certData);
            }

            var cert = new X509Certificate2(certData.ToArray());

            return cert;
        }
    }
}
