using BorgunRpgClient.Exceptions;
using BorgunRpgClient.Model.Mpi;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BorgunRpgClient.API
{
    public class MpiAPI : IMpiAPI
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public MpiAPI(HttpClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<EnrollmentResponse> EnrollAsync(EnrollmentRequest req)
        {
            return await Policy<EnrollmentResponse>
                .HandleResult(r => IsRetryableMdStatus(r.MdStatus))
                .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAsync(async () =>
                {
                    var resp = await DefaultPolly.Policy()
                        .ExecuteAsync(() => _client.PostAsJsonAsync("mpi/v2/enrollment", req))
                        .ConfigureAwait(false);

                    await HandleErrorResponseAsync(resp).ConfigureAwait(false);

                    return await resp.Content.ReadAsAsync<EnrollmentResponse>()
                            .ConfigureAwait(false);
                })
                .ConfigureAwait(false);
        }

        public async Task<ValidationResponse> PaResValidationAsync(string PARes)
        {
            var resp = await DefaultPolly.Policy()
                .ExecuteAsync(() =>_client.PostAsJsonAsync("mpi/v2/validation", new { PARes }))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<ValidationResponse>().ConfigureAwait(false);
        }

        private async Task HandleErrorResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                _logger.LogError($"StatusCode: {response.StatusCode} - {errorResponse}");

                throw new BorgunMpiApiException
                {
                    Response = response
                };
            }
        }

        public static bool IsSuccessMdStatus(string mdStatus)
        {
            switch (mdStatus)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsRetryableMdStatus(string mdStatus)
        {
            switch (mdStatus)
            {
                case "5":
                case "91":
                case "92":
                case "93":
                case "94":
                case "99":
                    return true;

                default:
                    return false;
            }
        }  
    }
}
