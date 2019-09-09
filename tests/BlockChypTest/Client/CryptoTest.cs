using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlockChyp;
using BlockChyp.Client;
using Xunit;

namespace BlockChypTest.Client
{
    public class CryptoTest
    {
        [Fact]
        public void BlockChypClientTest_GenerateAuthHeaders()
        {
            var creds = new ApiCredentials(
                "SGLATIFZD7PIMLAQJ2744MOEGI",
                "FI2SWNNJHJVO6DBZEF26YEHHMY",
                "c3a8214c318dd470b0107d6c111f086b60ad695aaeb598bf7d1032eee95339a0");

            var result = Crypto.GenerateAuthHeaders(creds);
            foreach (KeyValuePair<string, string> header in result)
            {
                Console.WriteLine(header);
            }

            Assert.Equal(3, result.Count);

            Assert.NotNull(result["Nonce"]);
            Assert.NotNull(result["Timestamp"]);
            Assert.NotNull(result["Authorization"]);
        }
    }
}