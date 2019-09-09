using System;
using System.Threading.Tasks;
using BlockChyp;
using BlockChyp.Client;
using Xunit;

namespace BlockChypTest.Client
{
    public class BlockChypClientTest
    {
        [Trait("Category", "Integration")]
        [Fact]
        public async Task BlockChypClientTest_Heartbeat()
        {
            var blockchyp = new BlockChypClient();
            var result = await blockchyp.Heartbeat(false);

            Assert.True(result.Success);
            Assert.NotEqual(default(DateTime), result.Timestamp);
            Assert.NotNull(result.LatestTick);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task BlockChypClientTest_AuthenticatedHeartbeat()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();
            var result = await blockchyp.Heartbeat(true);

            Assert.True(result.Success);
            Assert.NotEqual(default(DateTime), result.Timestamp);
            Assert.False(String.IsNullOrEmpty(result.LatestTick));
            Assert.False(String.IsNullOrEmpty(result.MerchantPublicKey));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task BlockChypClientTest_Ping()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var terminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName;
            var request = new PingRequest{TerminalName=terminalName};

            var result = await blockchyp.Ping(request);

            Assert.True(result.Success);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async Task BlockChypClientTest_PingHttps()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            blockchyp.TerminalHttps = true;

            var terminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName;
            var request = new PingRequest{TerminalName=terminalName};

            var result = await blockchyp.Ping(request);

            Assert.True(result.Success);
        }
    }
}