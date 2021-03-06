﻿
namespace BorgunRpgClient.Model
{
    public class CaptureAuthorizationResponse
    {
        /// <summary>
        /// TransactionId of transaction in request.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Action code result of operation.
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// Message if form error occurs.
        /// </summary>
        public string Message { get; set; }
    }
}
