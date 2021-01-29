using BorgunRpgClient.Exceptions;
using BorgunRpgClient.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BorgunRpgClient.API
{
    public class TokenSingleAPI : ITokenSingleAPI
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public TokenSingleAPI(HttpClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<TokenSingleResponse> CreateAsync(TokenSingleRequest req)
        {
            var tokenRes = new TokenSingleResponse();
            var resp = await _client.PostAsJsonAsync("token/single", req)
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            tokenRes.Token = await resp.Content.ReadAsAsync<TokenSingleInfo>()
                .ConfigureAwait(false);
            if (resp.Headers.Location != null)
            {
                tokenRes.Uri = resp.Headers.Location.AbsoluteUri;
            }

            return tokenRes;
        }

        public async Task<TokenSingleInfo> GetAsync(string token)
        {
            var resp = await _client.GetAsync("token/single/" + token)
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);

            return await resp.Content.ReadAsAsync<TokenSingleInfo>()
                    .ConfigureAwait(false);
        }

        public async Task DisableAsync(string token)
        {
            var resp = await _client.PutAsync("token/single/" + token + "/disable", null)
                .ConfigureAwait(false);

            await HandleErrorResponseAsync(resp).ConfigureAwait(false);
        }

        private async Task HandleErrorResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                _logger.LogError($"StatusCode: {response.StatusCode} - {errorResponse}");

                throw new BorgunSingleTokenApiException
                {
                    Response = response
                };
            }
        }

    }
}
