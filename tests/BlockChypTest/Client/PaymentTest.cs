using System;
using System.IO;
using BlockChyp.Client;
using BlockChyp.Entities;
using Xunit;

namespace BlockChypTest.Client
{
    public class PaymentTest
    {
        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_BatchClose()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="123.45",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat=SignatureFormat.PNG,
                SignatureWidth=200,
            };

            var response = await blockchyp.ChargeAsync(request);

            Assert.True(response.Approved);

            var closeBatchRequest = new CloseBatchRequest();

            var closeBatchResponse = await blockchyp.CloseBatchAsync(closeBatchRequest);

            Assert.True(closeBatchResponse.Success);
            Assert.False(String.IsNullOrEmpty(closeBatchResponse.CapturedTotal));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_Charge()
        {
            using (var tmpdir = new TempDir())
            {
                var expectedSignature = Path.Combine(tmpdir.Name, "signature.png");

                var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

                var request = new AuthRequest{
                    Amount="55.55",
                    Test=true,
                    TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                    SignatureFormat=SignatureFormat.PNG,
                    SignatureWidth=200,
                    SignatureFile=expectedSignature,
                };

                var response = await blockchyp.ChargeAsync(request);

                Assert.True(response.Approved);
                Assert.True(File.Exists(expectedSignature));
            }
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_ManualCharge()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="12.13",
                Test=true,
                ManualEntry=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = await blockchyp.ChargeAsync(request);

            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_Enroll()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = await blockchyp.EnrollAsync(request);

            Assert.True(response.Approved);
            Assert.False(String.IsNullOrEmpty(response.Token));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_FreeRangeRefund()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new RefundRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat=SignatureFormat.PNG,
                SignatureWidth=200,
            };

            var response = await blockchyp.RefundAsync(request);

            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_Preauth()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var preauthRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat=SignatureFormat.PNG,
                SignatureWidth=200,
            };

            var preauthResponse = await blockchyp.PreauthAsync(preauthRequest);

            Assert.True(preauthResponse.Approved);

            var captureRequest = new CaptureRequest{
                TransactionId=preauthResponse.TransactionId,
                Test=preauthResponse.Test,
            };

            var captureResponse = await blockchyp.CaptureAsync(captureRequest);

            Assert.True(captureResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_PreauthWithTip()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var preauthRequest = new AuthRequest{
                Amount="25.00",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat=SignatureFormat.JPG,
                SignatureWidth=200,
            };

            var preauthResponse = await blockchyp.PreauthAsync(preauthRequest);

            Assert.True(preauthResponse.Approved);

            var captureRequest = new CaptureRequest{
                TransactionId=preauthResponse.TransactionId,
                Test=preauthResponse.Test,
                TipAmount="5.00",
                Amount="30.00",
            };

            var captureResponse = await blockchyp.CaptureAsync(captureRequest);

            Assert.True(captureResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_Refund()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat=SignatureFormat.PNG,
                SignatureWidth=200,
            };

            var chargeResponse = await blockchyp.ChargeAsync(chargeRequest);

            Assert.True(chargeResponse.Approved);

            var refundRequest = new RefundRequest{
                TransactionId=chargeResponse.TransactionId,
                Test=chargeResponse.Test,
            };

            var refundResponse = await blockchyp.RefundAsync(refundRequest);

            Assert.True(refundResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_Reverse()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef=Crypto.GenerateNonce(Crypto.NonceSizeBytes),
            };

            var chargeResponse = await blockchyp.ChargeAsync(chargeRequest);

            Assert.True(chargeResponse.Approved);

            var reversalRequest = new AuthRequest{
                TransactionRef=chargeRequest.TransactionRef,
                Test=chargeResponse.Test,
            };

            var reversalResponse = await blockchyp.ReverseAsync(reversalRequest);

            Assert.True(reversalResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_GatewayTimeout()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            // Time out instantly
            blockchyp.GatewayRequestTimeout = TimeSpan.FromSeconds(0);
            blockchyp.TerminalRequestTimeout = TimeSpan.FromSeconds(30);
            blockchyp.RouteCache.OfflineEnabled = false;

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef=Crypto.GenerateNonce(Crypto.NonceSizeBytes),
            };

            Exception ex = Assert.Throws<TimeoutException>(() => blockchyp.Charge(chargeRequest));

            Assert.Equal("Gateway request timed out", ex.Message);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_TerminalTimeout()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            // Time out instantly
            blockchyp.GatewayRequestTimeout = TimeSpan.FromSeconds(30);
            blockchyp.TerminalRequestTimeout = TimeSpan.FromSeconds(0);
            blockchyp.RouteCache.OfflineEnabled = false;

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef=Crypto.GenerateNonce(Crypto.NonceSizeBytes),
            };

            Exception ex = Assert.Throws<TimeoutException>(() => blockchyp.Charge(chargeRequest));

            Assert.Equal("Terminal request timed out", ex.Message);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_TaxExemptCharge()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="55.55",
                Test=true,
                TaxExempt=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = await blockchyp.ChargeAsync(request);

            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_TaxableLevel2()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="15.00",
                TaxAmount="2.00",
                Test=true,
                TaxExempt=false,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = await blockchyp.ChargeAsync(request);

            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_TaxableLevel2Capture()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var preauthRequest = new AuthRequest{
                Amount="15.00",
                Test=true,
                TaxExempt=false,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var preauthResponse = await blockchyp.PreauthAsync(preauthRequest);

            Assert.True(preauthResponse.Approved);

            var captureRequest = new CaptureRequest{
                Amount="24.00",
                TaxAmount="3.00",
                TaxExempt=false,
                TransactionId=preauthResponse.TransactionId,
                Test=preauthResponse.Test,
            };

            var captureResponse = await blockchyp.CaptureAsync(captureRequest);

            Assert.True(captureResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public async void PaymentTest_Void()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef=Crypto.GenerateNonce(Crypto.NonceSizeBytes),
            };

            var chargeResponse = await blockchyp.ChargeAsync(chargeRequest);

            Assert.True(chargeResponse.Approved);

            var voidRequest = new VoidRequest{
                TransactionId=chargeResponse.TransactionId,
                Test=chargeResponse.Test,
            };

            var voidResponse = await blockchyp.VoidAsync(voidRequest);

            Assert.True(voidResponse.Approved);
        }
    }
}
