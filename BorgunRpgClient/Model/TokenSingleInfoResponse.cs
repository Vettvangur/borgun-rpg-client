using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgunRpgClient.Model
{
    public class TokenSingleResponse
    {
        /// <summary>
        /// Token object received by response.
        /// </summary>
        public TokenSingleInfo Token { get; set; }

        /// <summary>
        /// ContentLocation header if provided by response.
        /// </summary>
        public string Uri { get; set; }
    }
}
