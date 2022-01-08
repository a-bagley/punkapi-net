using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PunkApiNet.Tests.TestHelpers
{
    internal class FakeHttpMessageHandler : HttpMessageHandler
    {
        private Queue<HttpResponseMessage> _responseQueue = new Queue<HttpResponseMessage>();
        private HttpRequestMessage _lastRequest;

        internal void EnqueuResponse(HttpResponseMessage httpResponseMessage)
        {
            _responseQueue.Enqueue(httpResponseMessage);
        }

        internal void EnqueueStringJsonResponse(string json)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json);
            _responseQueue.Enqueue(response);
        }

        internal void EnqueuErrorResponse(HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            _responseQueue.Enqueue(new HttpResponseMessage(httpStatusCode));
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _lastRequest = request;
            return Task.FromResult(_responseQueue.Dequeue());
        }
    }
}
