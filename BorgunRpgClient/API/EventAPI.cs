using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BorgunRpgClient.API
{
    public class EventAPI
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public EventAPI(HttpClient client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

    }
}
