using BorgunRpgClient.Exceptions;
using BorgunRpgClient.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BorgunRpgClient.API
{
    public class PaymentAPI : IPaymentAPI
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public PaymentAPI(HttpClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<PaymentTransactionResponse> CreateAsync(PaymentRequest req)
        {
            var paymentRes = new PaymentTransactionResponse();

            var resp = await DefaultPolly.PurchaseTransactionPolicy()
                .ExecuteAsync(() =>_client.PostAsJsonAsync("payment", req))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            paymentRes.Transaction = await resp.Content.ReadAsAsync<TransactionInfo>().ConfigureAwait(false);
            if (resp.Headers.Location != null)
            {
                paymentRes.Uri = resp.Headers.Location.AbsoluteUri;
            }

            return paymentRes;
        }

        public async Task<TransactionInfo> GetTransactionAsync(string transactionId)
        {
            var resp = await DefaultPolly.Policy()
                .ExecuteAsync(() => _client.GetAsync("payment/" + transactionId))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<TransactionInfo>().ConfigureAwait(false);
        }

        public async Task<CancelAuthorizationResponse> CancelAsync(string transactionId)
        {
            var resp = await DefaultPolly.Policy()
                .ExecuteAsync(() => _client.PutAsync("payment/" + transactionId + "/cancel", null))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<CancelAuthorizationResponse>().ConfigureAwait(false);
        }

        public async Task<CaptureAuthorizationResponse> CaptureAsync(string transactionId)
        {
            var resp = await DefaultPolly.Policy()
                .ExecuteAsync(() => _client.PutAsync("payment/" + transactionId + "/capture", null))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<CaptureAuthorizationResponse>().ConfigureAwait(false);
        }

        public async Task<RefundAuthorizationResponse> RefundAsync(string transactionId)
        {
            var resp = await DefaultPolly.PurchaseTransactionPolicy()
                .ExecuteAsync(() => _client.PutAsync("payment/" + transactionId + "/refund", null))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<RefundAuthorizationResponse>().ConfigureAwait(false);
        }

        private async Task HandleErrorResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                _logger.LogError($"StatusCode: {response.StatusCode} - {errorResponse}");

                throw new BorgunPaymentApiException
                {
                    Response = response
                };
            }
        }
    }
}
