using System;
using System.Net;

namespace PunkApiNet.Exceptions
{
    public class PunkApiServiceException : Exception
    {
        public HttpStatusCode HttpResponseCode { get; private set; }

        public PunkApiServiceException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpResponseCode = httpStatusCode;
        }

        public PunkApiServiceException(HttpStatusCode httpStatusCode, string message, Exception exception) : base(message, exception)
        {
            HttpResponseCode = httpStatusCode;
        }
    }
}
