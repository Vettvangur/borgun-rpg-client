using System.Threading.Tasks;

namespace BorgunRpgClient.Model
{
    public interface IPaymentAPI
    {
        Task<CancelAuthorizationResponse> CancelAsync(string transactionId);

        Task<CaptureAuthorizationResponse> CaptureAsync(string transactionId);

        Task<PaymentTransactionResponse> CreateAsync(PaymentRequest req);

        Task<TransactionInfo> GetTransactionAsync(string transactionId);

        Task<RefundAuthorizationResponse> RefundAsync(string transactionId);
    }
}
