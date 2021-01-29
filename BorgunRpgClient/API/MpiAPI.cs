using BorgunRpgClient.Exceptions;
using BorgunRpgClient.Model.Mpi;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BorgunRpgClient.API
{
    public class MpiAPI
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
            var resp = await _client.PostAsJsonAsync("mpi/v2/enrollment", req).ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<EnrollmentResponse>().ConfigureAwait(false);
        }

        public async Task<object> PaResValidationAsync(string PARes)
        {
            var resp = await _client.PostAsJsonAsync("mpi/v2/validation", new { PARes })
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<EnrollmentResponse>().ConfigureAwait(false);
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
    }
}
