using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BorgunRpgClient
{
    static class DefaultPolly
    {
        // Handle both exceptions and return values in one policy
        public static HttpStatusCode[] httpStatusCodesWorthRetrying = {
            HttpStatusCode.RequestTimeout, // 408
            HttpStatusCode.InternalServerError, // 500
            HttpStatusCode.BadGateway, // 502
            HttpStatusCode.ServiceUnavailable, // 503
            HttpStatusCode.GatewayTimeout, // 504
            (HttpStatusCode)429, // 429
        };

        public static AsyncRetryPolicy<HttpResponseMessage> Policy()
        {
            return Polly.Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => httpStatusCodesWorthRetrying.Contains(r.StatusCode))
                .WaitAndRetryAsync(2, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                );
        }

        /// <summary>
        /// Intended to be safe from double purchases, according to comments from Microsoft on
        /// <see cref="HttpRequestException"/>, it should throw as such on network errors.
        /// The exceptions to that are calls to EnsureSuccessStatusCode which does not apply here.
        /// https://github.com/dotnet/runtime/issues/911#issuecomment-454446820
        /// </summary>
        /// <returns></returns>
        public static AsyncRetryPolicy PurchaseTransactionPolicy()
            => Polly.Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(2, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                );

    }
}
