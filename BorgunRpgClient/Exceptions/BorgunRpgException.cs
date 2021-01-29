using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;

namespace BorgunRpgClient.Exceptions
{
    public class BorgunRpgException : Exception
    {
        public HttpResponseMessage Response { get; set; }

        public BorgunRpgException()
        {
        }

        public BorgunRpgException(string message) : base(message)
        {
        }

        public BorgunRpgException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BorgunRpgException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
