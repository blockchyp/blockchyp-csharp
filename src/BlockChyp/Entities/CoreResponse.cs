using System;
using Newtonsoft.Json;

namespace BlockChyp
{
    public class CoreResponse
    {
        /// <summary>
        /// Contains extra details about the transaction in the event that
        /// it is not approved.
        /// </summary>
        [JsonProperty(PropertyName = "responseDescription")]
        public string ResponseDescription { get; set; }

        /// <summary>
        /// The ID assigned to the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The ID assigned to the batch.
        /// </summary>
        [JsonProperty(PropertyName = "batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// The transaction reference string assigned to the transaction
        /// request. If no transaction ref was assiged on the request,
        /// then the gateway will randomly generate one.
        /// </summary>
        [JsonProperty(PropertyName = "transactionRef")]
        public string TransactionRef { get; set; }

        /// <summary>
        /// The type of transaction.
        /// </summary>
        [JsonProperty(PropertyName = "transactionType")]
        public string TransactionType { get; set; }

        /// <summary>
        /// The timestamp of the transaction in RFC 3339 format.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// The hash of the last tick block.
        /// </summary>
        [JsonProperty(PropertyName = "tickBlock")]
        public string TickBlock { get; set; }

        /// <summary>
        /// Whether or not the transaction was processed on the test gateway.
        /// </summary>
        [JsonProperty(PropertyName = "test")]
        public bool Test { get; set; }

        /// <summary>
        /// The ECC signature of the response. Can be used to ensure that it
        /// was signed by the terminal and detect man-in-the middle attacks.
        /// </summary>
        [JsonProperty(PropertyName = "sig")]
        public string Signature { get; set; }

    }
}
