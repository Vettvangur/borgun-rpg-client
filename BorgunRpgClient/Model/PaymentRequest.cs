using System;

namespace BorgunRpgClient.Model
{
    public class PaymentRequest
    {
        /// <summary>
        /// Only allow Authorization or Capture.
        /// </summary>
        public TransactionTypes TransactionType { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        public int? Amount { get; set; }

        /// <summary>
        /// Currency in Digit format (352 for ISK).
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Transaction Date Time.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Payment method for transaction.
        /// </summary>
        public PaymentRequestMethod PaymentMethod { get; set; }

        /// <summary>
        /// 12 Character RRN of transaction.
        /// </summary>
        public string OrderId { get; set; }

        public Metadata Metadata { get; set; }
    }
}
