using System;
using BlockChyp;
using BlockChyp.Client;
using Xunit;

namespace BlockChypTest.Client
{
    public class BlockChypClientTest
    {
        [Trait("Category", "Integration")]
        [Fact]
        public void BlockChypClientTest_Heartbeat()
        {
            var blockchyp = new BlockChypClient();
            blockchyp.RequestTimeout = TimeSpan.FromSeconds(30);
            var result = blockchyp.Heartbeat(false);

            Assert.True(result.Success);
            Assert.NotEqual(default(DateTime), result.Timestamp);
            Assert.NotNull(result.LatestTick);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void BlockChypClientTest_AuthenticatedHeartbeat()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();
            var result = blockchyp.Heartbeat(true);

            Assert.True(result.Success);
            Assert.NotEqual(default(DateTime), result.Timestamp);
            Assert.False(String.IsNullOrEmpty(result.LatestTick));
            Assert.False(String.IsNullOrEmpty(result.MerchantPublicKey));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void BlockChypClientTest_Ping()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();
            blockchyp.RequestTimeout = TimeSpan.FromSeconds(30);

            var terminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName;
            var request = new PingRequest{TerminalName=terminalName};

            var result = blockchyp.Ping(request);

            Assert.True(result.Success);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void BlockChypClientTest_PingHttps()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            blockchyp.TerminalHttps = true;

            var terminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName;
            var request = new PingRequest{TerminalName=terminalName};

            var result = blockchyp.Ping(request);

            Assert.True(result.Success);
        }
    }
}
