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
        /// Transaction amount <br />
        /// Library handles adding 00 to amount where Borgun requires
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
        /// Retrieval Reference Number – Reference number for transaction. Must be exactly 12 characters. Recommended format is a fixed value followed by a sequence, for example ACME00012345. The last six letters must contain a numeric value.
        /// See https://docs.borgun.is/paymentgateways/bgateway/ RRN
        /// Optionally use Helpers.CreateRrnFromLong to format
        /// </summary>
        public string OrderId { get; set; }

        public Metadata Metadata { get; set; }
    }
}
