using System;
using System.IO;
using System.Threading.Tasks;
using BlockChyp;
using BlockChyp.Client;
using Xunit;

namespace BlockChypTest.Client
{
    public class PaymentTest
    {
        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_BatchClose()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="123.45",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat="png",
                SignatureWidth=200,
            };

            var response = blockchyp.Charge(request);
            
            Assert.True(response.Approved);

            var closeBatchRequest = new CloseBatchRequest();

            var closeBatchResponse = blockchyp.CloseBatch(closeBatchRequest);

            Assert.True(closeBatchResponse.Success);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_Charge()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat="png",
                SignatureWidth=200,
                SignatureFile="sig.png",
            };

            var response = blockchyp.Charge(request);
            
            Assert.True(response.Approved);
            Assert.True(File.Exists("sig.png"));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_ManualCharge()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="12.13",
                Test=true,
                ManualEntry=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = blockchyp.Charge(request);
            
            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_Enroll()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = blockchyp.Enroll(request);
            
            Assert.True(response.Approved);
            Assert.False(String.IsNullOrEmpty(response.Token));
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_FreeRangeRefund()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new RefundRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat="png",
                SignatureWidth=200,
            };

            var response = blockchyp.Refund(request);
            
            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_Preauth()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var preauthRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat="png",
                SignatureWidth=200,
            };

            var preauthResponse = blockchyp.Preauth(preauthRequest);
            
            Assert.True(preauthResponse.Approved);

            var captureRequest = new CaptureRequest{
                TransactionId=preauthResponse.TransactionId,
                Test=preauthResponse.Test,
            };

            var captureResponse = blockchyp.Capture(captureRequest);

            Assert.True(captureResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_PreauthWithTip()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var preauthRequest = new AuthRequest{
                Amount="25.00",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat="png",
                SignatureWidth=200,
            };

            var preauthResponse = blockchyp.Preauth(preauthRequest);
            
            Assert.True(preauthResponse.Approved);

            var captureRequest = new CaptureRequest{
                TransactionId=preauthResponse.TransactionId,
                Test=preauthResponse.Test,
                TipAmount="5.00",
                Amount="30.00",
            };

            var captureResponse = blockchyp.Capture(captureRequest);

            Assert.True(captureResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_Refund()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                SignatureFormat="png",
                SignatureWidth=200,
            };

            var chargeResponse = blockchyp.Charge(chargeRequest);
            
            Assert.True(chargeResponse.Approved);

            var refundRequest = new RefundRequest{
                TransactionId=chargeResponse.TransactionId,
                Test=chargeResponse.Test,
            };

            var refundResponse = blockchyp.Refund(refundRequest);

            Assert.True(refundResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_Reverse()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef=Crypto.GenerateNonce(),
            };

            var chargeResponse = blockchyp.Charge(chargeRequest);
            
            Assert.True(chargeResponse.Approved);

            var reversalRequest = new AuthRequest{
                TransactionRef=chargeRequest.TransactionRef,
                Test=chargeResponse.Test,
            };

            var reversalResponse = blockchyp.Reverse(reversalRequest);

            Assert.True(reversalResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_TaxExemptCharge()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="55.55",
                Test=true,
                TaxExempt=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = blockchyp.Charge(request);
            
            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_TaxableLevel2()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var request = new AuthRequest{
                Amount="15.00",
                TaxAmount="2.00",
                Test=true,
                TaxExempt=false,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var response = blockchyp.Charge(request);
            
            Assert.True(response.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_TaxableLevel2Capture()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var preauthRequest = new AuthRequest{
                Amount="15.00",
                Test=true,
                TaxExempt=false,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
            };

            var preauthResponse = blockchyp.Preauth(preauthRequest);
            
            Assert.True(preauthResponse.Approved);

            var captureRequest = new CaptureRequest{
                Amount="24.00",
                TaxAmount="3.00",
                TaxExempt=false,
                TransactionId=preauthResponse.TransactionId,
                Test=preauthResponse.Test,
            };

            var captureResponse = blockchyp.Capture(captureRequest);

            Assert.True(captureResponse.Approved);
        }

        [Trait("Category", "Integration")]
        [Fact]
        public void PaymentTest_Void()
        {
            var blockchyp = IntegrationTestConfiguration.Instance.GetTestClient();

            var chargeRequest = new AuthRequest{
                Amount="55.55",
                Test=true,
                TerminalName=IntegrationTestConfiguration.Instance.Settings.DefaultTerminalName,
                TransactionRef=Crypto.GenerateNonce(),
            };

            var chargeResponse = blockchyp.Charge(chargeRequest);
            
            Assert.True(chargeResponse.Approved);

            var voidRequest = new VoidRequest{
                TransactionId=chargeResponse.TransactionId,
                Test=chargeResponse.Test,
            };

            var voidResponse = blockchyp.Void(voidRequest);

            Assert.True(voidResponse.Approved);
        }
    }
}