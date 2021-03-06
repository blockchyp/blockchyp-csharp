using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BlockChyp.Entities;

namespace BlockChyp.Client
{
    public static class Crypto
    {
        /// <summary>The length of a nonse in bytes.</summary>
        public const int NonceSizeBytes = 32;

        private const string HeaderNonce = "Nonce";

        private const string HeaderTimestamp = "Timestamp";

        private const string HeaderAuthorization = "Authorization";

        private const string AuthSchemeDual = "Dual";

        private const string TerminalCommonName = "blockchyp-terminal";

        private static Lazy<X509Certificate2> blockChypRootCertificate = new Lazy<X509Certificate2>(GetBlockChypRootCertificate);

        /// <summary>Generates request headers for authorization to the BlockChyp gateway.</summary>
        /// <param name="credentials">API credentials used to generate request headers.</param>
        public static Dictionary<string, string> GenerateAuthHeaders(ApiCredentials credentials)
        {
            var nonce = GenerateNonce(NonceSizeBytes);
            var timestamp = GetRfc3339Timestamp();

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

        /// <summary>
        /// Generate a <paramref name="nonceLengthInBytes"/>-byte long random nonce using
        /// <c>RNGCryptoServiceProvider</c>.
        /// </summary>
        /// <remarks>
        /// Note that the resulting nonce will be represented as a hex <c>string</c> which will therefore have a
        /// length of <c>2 * nonceLengthInBytes</c>.
        /// </remarks>
        /// <param name="nonceLengthInBytes">the desired length of the nonce in bytes.</param>
        public static string GenerateNonce(int nonceLengthInBytes)
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] nonceBytes = new byte[nonceLengthInBytes];
                rng.GetBytes(nonceBytes);
                return BitConverter.ToString(nonceBytes).Replace("-", string.Empty);
            }
        }

        /// <summary>
        /// Returns the current timestamp in RFC 3339 format.
        /// </summary>
        public static string GetRfc3339Timestamp()
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
            if (input.Length % 2 != 0)
            {
                throw new ArgumentException(
                    string.Format("The hex string cannot have an odd number of characters: {0}", input),
                    nameof(input));
            }

            byte[] result = new byte[input.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(input.Substring(i * 2, 2), 16);
            }

            return result;
        }

        /// <summary>Encrypts the string payload to a byte array.</summary>
        /// <param name="plainText">The plaintext payload to encrypt.</param>
        /// <param name="key">The cryptographic key used to encrypt the payload.</param>
        public static string Encrypt(string plainText, byte[] key)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }

            using (var aes = Aes.Create())
            {
                byte[] cipher;

                ICryptoTransform encryptor = aes.CreateEncryptor(key, aes.IV);

                using (var mem = new MemoryStream())
                {
                    using (var crypto = new CryptoStream(mem, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(crypto))
                        {
                            writer.Write(plainText);
                        }

                        cipher = mem.ToArray();
                    }
                }

                var output = new byte[aes.IV.Length + cipher.Length];
                Buffer.BlockCopy(aes.IV, 0, output, 0, aes.IV.Length);
                Buffer.BlockCopy(cipher, 0, output, aes.IV.Length, cipher.Length);

                return Convert.ToBase64String(output);
            }
        }

        /// <summary>Decrypts ciphertext to a byte array.</summary>
        /// <param name="cipherText">The ciphertext to decrypt.</param>
        /// <param name="key">The cryptographic key used to decrypt the payload.</param>
        public static string Decrypt(string cipherText, byte[] key)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return string.Empty;
            }

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            string output;

            using (var aes = Aes.Create())
            {
                var iv = new byte[aes.IV.Length];
                var cipher = new byte[cipherBytes.Length - iv.Length];

                Buffer.BlockCopy(cipherBytes, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(cipherBytes, iv.Length, cipher, 0, cipher.Length);

                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);

                using (var mem = new MemoryStream(cipher))
                {
                    using (var crypto = new CryptoStream(mem, decryptor, CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(crypto))
                        {
                            output = reader.ReadToEnd();
                        }
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Validates that terminal webservers are using a certificate that was signed
        /// by the BlockChyp root CA.
        /// </summary>
        /// <param name="request">The HTTP request.</param>
        /// <param name="cert">The server certificate served with the request.</param>
        /// <param name="chain">The certificate chain served with the request.</param>
        /// <param name="sslPolicyErrors">SSL verification failures.</param>
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
                chain.ChainPolicy.ExtraStore.Add(blockChypRootCertificate.Value);

                // Validate that the chain can be built.
                if (!chain.Build(cert) || chain.ChainElements.Count == 0)
                {
                    return false;
                }

                // Now we know that the chain is valid, so we only have to
                // prove that the root of the chain is our root CA.
                if (chain.ChainElements[chain.ChainElements.Count - 1].Certificate.Thumbprint != blockChypRootCertificate.Value.Thumbprint)
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
        /// <param name="request">The HTTP request.</param>
        /// <param name="cert">The server certificate served with the request.</param>
        /// <param name="chain">The certificate chain served with the request.</param>
        /// <param name="sslPolicyErrors">SSL verification failures.</param>
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
            X509Certificate2 cert;

            using (var certData = new MemoryStream())
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream("BlockChyp.Assets.BlockChyp.crt"))
                {
                    if (stream == null)
                    {
                        throw new BlockChypException("BlockChyp CA Certificate not found");
                    }

                    stream.CopyTo(certData);
                }

                cert = new X509Certificate2(certData.ToArray());
            }

            return cert;
        }
    }
}
