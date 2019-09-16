using System;
using System.Net;

namespace BlockChyp.Client
{
    public class BlockChypException : Exception
    {
        public BlockChypException()
        {
        }

        public BlockChypException(string message) : base(message)
        {
        }

        public BlockChypException(string message, Exception err) : base(message, err)
        {
        }

        public BlockChypException(string message, HttpStatusCode statusCode, string body) : base(message)
        {
            HttpStatusCode = statusCode;
            ResponseBody = body;
        }

        public HttpStatusCode HttpStatusCode { get; }

        public string ResponseBody { get; }
    }
}
