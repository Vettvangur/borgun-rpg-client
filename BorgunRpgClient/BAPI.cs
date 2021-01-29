using BorgunRpgClient.API;
using BorgunRpgClient.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BorgunRpgClient
{
    public class RPGClient : IRPGClient
    {
        private readonly HttpClient _client;

        private readonly ITokenSingleAPI _tokenSingle;

        private readonly ITokenMultiAPI _tokenMulti;

        private readonly IPaymentAPI _payment;

        public ITokenSingleAPI TokenSingle { get { return _tokenSingle; } }

        public ITokenMultiAPI TokenMulti { get { return _tokenMulti; } }

        public IPaymentAPI Payment { get { return _payment; } }

        public RPGClient(string merchantKey, string serviceUri, ILogger logger, HttpMessageHandler httpMessageHandler)
        {
            _client = new HttpClient(httpMessageHandler);

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(serviceUri);
            _client.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(merchantKey + ":")));

            _tokenSingle = new TokenSingleAPI(_client, logger);
            _tokenMulti = new TokenMultiAPI(_client, logger);
            _payment = new PaymentAPI(_client, logger);
        }

        public RPGClient(string merchantKey, string serviceUri, ILogger logger) 
            : this(merchantKey, serviceUri, logger, new HttpClientHandler())
        {

        }

        public RPGClient(IPaymentAPI paymentApi, ITokenSingleAPI tokenSingleApi, ITokenMultiAPI tokenMultiApi)
        {
            _payment = paymentApi;
            _tokenSingle = tokenSingleApi;
            _tokenMulti = tokenMultiApi;
        }
    }
}
