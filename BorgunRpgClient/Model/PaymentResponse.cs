using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgunRpgClient.Model
{
    public class PaymentTransactionResponse
    {
        /// <summary>
        /// Transaction object received by the response.
        /// </summary>
        public TransactionInfo Transaction { get; set; }

        /// <summary>
        /// ContentLocation header if provided by response.
        /// </summary>
        public string Uri { get; set; }
    }
}
