using System;
using System.Threading;
using BlockChyp.Client;
using BlockChyp.Entities;

namespace BlockChypTest.Integration
{
    public class IntegrationTest : IDisposable
    {
        public IntegrationTest()
        {
            blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            string delayEnv = Environment.GetEnvironmentVariable("BC_TEST_DELAY");
            if (!string.IsNullOrEmpty(delayEnv))
            {
                var delayInt = int.Parse(Environment.GetEnvironmentVariable("BC_TEST_DELAY"));
                delay = TimeSpan.FromSeconds(delayInt);
            }
        }

        protected BlockChypClient blockchyp;

        protected TimeSpan delay;

        public void Dispose()
        {
        }

        protected void UseProfile(string profile) {

            blockchyp = IntegrationTestConfiguration.Instance.GetTestClient(profile);
        }

        protected void ShowTestOnTerminal(string test)
        {
            if (delay <= TimeSpan.Zero)
            {
                return;
            }
            MessageRequest request = new MessageRequest
            {
                TerminalName = IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                Test = true,
                Message = $"Running {test} in {delay.Seconds}s",
            };

            blockchyp.Message(request);

            Thread.Sleep(delay);
        }
    }
}
