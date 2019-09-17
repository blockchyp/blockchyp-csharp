using System;
using System.Threading;
using BlockChyp.Entities;
using Xunit;

namespace BlockChypTest.Client
{
    public class UtilityTest
    {
        [Trait("Category", "Integration")]
        [Fact]
        public async void UtilityTest_BooleanPrompt()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new BooleanPromptRequest
            {
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                Prompt="Is OpenEdge slower than Christmass?",
                YesCaption="ALWAYS",
                NoCaption="MMM...",
            };

            var response = await blockchyp.BooleanPromptAsync(request);

            Assert.True(response.Success);
            Assert.True(response.Response);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void UtilityTest_ClearTerminal()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new ClearRequest
            {
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = await blockchyp.ClearAsync(request);

            Assert.True(response.Success);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void UtilityTest_LineItemDisplay()
        {
            var testData = new TransactionDisplayTransaction[]
            {
                new TransactionDisplayTransaction
                {
                    Items=new TransactionDisplayItem[]
                    {
                        new TransactionDisplayItem
                        {
                            Description="Schlurm",
                            Price="150.00",
                            Quantity=1f,
                            Extended="145.00",
                            Discounts=new TransactionDisplayDiscount[]
                            {
                                new TransactionDisplayDiscount
                                {
                                    Amount="5.00",
                                    Description="Member Discount",
                                },
                            },
                        },
                    },
                    Subtotal="145.00",
                    Tax="2.00",
                    Total="147.00",
                },
                new TransactionDisplayTransaction
                {
                    Items=new TransactionDisplayItem[]
                    {
                        new TransactionDisplayItem
                        {
                            Description="Shleem",
                            Price="199.00",
                            Quantity=1f,
                            Extended="199.00",
                        },
                    },
                    Subtotal="344.00",
                    Tax="4.50",
                    Total="348.50",
                },
            };

            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var clearRequest = new ClearRequest
            {
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var clearResponse = await blockchyp.ClearAsync(clearRequest);

            Assert.True(clearResponse.Success);

            for (var i = 0; i < testData.Length; i++)
            {
                var txDisplayRequest = new TransactionDisplayRequest
                {
                    TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                    Transaction=testData[i],
                };

                Acknowledgement result;

                if (i == 0)
                {
                    result = await blockchyp.NewTransactionDisplayAsync(txDisplayRequest);
                } else {
                    result = await blockchyp.UpdateTransactionDisplayAsync(txDisplayRequest);
                }

                Assert.True(result.Success);

                Thread.Sleep(1000);
            }
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void UtilityTest_Message()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new MessageRequest
            {
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                Message="Cayan is for bozos.",
            };

            var response = await blockchyp.MessageAsync(request);

            Assert.True(response.Success);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void UtilityTest_PhonePrompt()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new TextPromptRequest
            {
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                PromptType=PromptType.PhoneNumber,
            };

            var response = await blockchyp.TextPromptAsync(request);

            Assert.True(response.Success);
            Assert.False(String.IsNullOrEmpty(response.Response));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void UtilityTest_TextPrompt()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new TextPromptRequest
            {
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                PromptType=PromptType.Email,
            };

            var response = await blockchyp.TextPromptAsync(request);

            Assert.True(response.Success);
            Assert.False(String.IsNullOrEmpty(response.Response));
        }
    }
}
