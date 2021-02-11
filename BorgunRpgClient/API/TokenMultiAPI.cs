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
    public class TokenMultiAPI : ITokenMultiAPI
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public TokenMultiAPI(HttpClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<TokenMultiResponse> CreateAsync(TokenMultiRequest req)
        {
            // See notes in PaymentAPI
            if (req.VerifyCard != null && req.VerifyCard.Currency != Currency.JPY.ToString())
            {
                req.VerifyCard.CheckAmount *= 100;
            }

            var tokenRes = new TokenMultiResponse();
            var resp = await DefaultPolly.Policy()
                .ExecuteAsync(() => _client.PostAsJsonAsync("token/multi", req))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            tokenRes.Token = await resp.Content.ReadAsAsync<TokenMultiInfo>().ConfigureAwait(false);
            if (resp.Headers.Location != null)
            {
                tokenRes.Uri = resp.Headers.Location.AbsoluteUri;
            }

            return tokenRes;
        }

        public async Task<TokenMultiInfo> GetAsync(string token)
        {
            var resp = await DefaultPolly.Policy()
                .ExecuteAsync(() => _client.GetAsync("token/multi/" + token))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<TokenMultiInfo>().ConfigureAwait(false);
        }

        public async Task DisableAsync(string token)
        {
            var resp = await DefaultPolly.Policy()
                .ExecuteAsync(() => _client.PutAsync("token/multi/" + token + "/disable", null))
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);
        }

        private async Task HandleErrorResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                _logger.LogError($"StatusCode: {response.StatusCode} - {errorResponse}");

                throw new BorgunMultiTokenApiException
                {
                    Response = response
                };
            }
        }
    }
}
