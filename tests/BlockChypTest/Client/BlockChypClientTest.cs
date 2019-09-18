using System;
using BlockChyp.Client;
using BlockChyp.Entities;
using Xunit;

namespace BlockChypTest.Client
{
    public class BlockChypClientTest
    {
        [Trait("Category", "Integration")]
        [Fact]
        public async void BlockChypClientTest_Heartbeat()
        {
            var blockchyp = new BlockChypClient();
            blockchyp.GatewayRequestTimeout = TimeSpan.FromSeconds(30);
            var result = await blockchyp.HeartbeatAsync(false);

            Assert.True(result.Success);
            Assert.NotEqual(default(DateTime), result.Timestamp);
            Assert.NotNull(result.LatestTick);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void BlockChypClientTest_AuthenticatedHeartbeat()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();
            var result = await blockchyp.HeartbeatAsync(true);

            Assert.True(result.Success);
            Assert.NotEqual(default(DateTime), result.Timestamp);
            Assert.False(String.IsNullOrEmpty(result.LatestTick));
            Assert.False(String.IsNullOrEmpty(result.MerchantPublicKey));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void BlockChypClientTest_Ping()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();
            blockchyp.GatewayRequestTimeout = TimeSpan.FromSeconds(30);
            blockchyp.TerminalRequestTimeout = TimeSpan.FromSeconds(30);

            var terminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName;
            var request = new PingRequest{TerminalName=terminalName};

            var result = await blockchyp.PingAsync(request);

            Assert.True(result.Success);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void BlockChypClientTest_PingHttps()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            blockchyp.TerminalHttps = true;

            var terminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName;
            var request = new PingRequest{TerminalName=terminalName};

            var result = await blockchyp.PingAsync(request);

            Assert.True(result.Success);
        }
    }
}
