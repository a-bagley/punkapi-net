using NUnit.Framework;
using PunkApiNet.Exceptions;
using PunkApiNet.Tests.TestHelpers;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PunkApiNet.Tests
{
    [TestFixture]
    public class PunkApiClientTests
    {
        private static string BeersTestDataName = "beersTestData.json";
        private static string SingleBeerTestDataName = "singleBeerTestData.json";

        public PunkApiClient CreateSut(HttpMessageHandler httpMessageHandler)
        {
            var client = new HttpClient(httpMessageHandler);
            client.BaseAddress = new Uri("http://test.punkapi.local/v2/");
            return new PunkApiClient(client);
        }

        [Test]
        public async Task GetAllBeersAsync_should_load_all_beers()
        {
            var responseJson = await File.ReadAllTextAsync(GetTestDataPath(BeersTestDataName));
            var fakeHttpMessageHandler = new FakeHttpMessageHandler();
            fakeHttpMessageHandler.EnqueueStringJsonResponse(responseJson);

            var beers = await CreateSut(fakeHttpMessageHandler).GetAllBeersAsync();

            Assert.NotNull(beers);
            Assert.IsNotEmpty(beers);
        }

        [Test]
        public void GetAllBeersAsync_should_throw_on_server_error()
        {
            var fakeHttpMessageHandler = new FakeHttpMessageHandler();
            fakeHttpMessageHandler.EnqueuErrorResponse();

            var exception = Assert.ThrowsAsync<PunkApiServiceException>(() => CreateSut(fakeHttpMessageHandler).GetAllBeersAsync());
            Assert.AreEqual(HttpStatusCode.InternalServerError, exception.HttpResponseCode);
        }

        [Test]
        public async Task GetBeerAsync_should_load_sinlge_beer()
        {
            var responseJson = await File.ReadAllTextAsync(GetTestDataPath(SingleBeerTestDataName));
            var fakeHttpMessageHandler = new FakeHttpMessageHandler();
            fakeHttpMessageHandler.EnqueueStringJsonResponse(responseJson);

            var beers = await CreateSut(fakeHttpMessageHandler).GetBeerAsync(1);

            Assert.NotNull(beers);
        }

        [Test]
        public void GetBeerAsync_should_throw_on_server_error()
        {
            var fakeHttpMessageHandler = new FakeHttpMessageHandler();
            fakeHttpMessageHandler.EnqueuErrorResponse();

            var exception = Assert.ThrowsAsync<PunkApiServiceException>(() => CreateSut(fakeHttpMessageHandler).GetBeerAsync(1));
            Assert.AreEqual(HttpStatusCode.InternalServerError, exception.HttpResponseCode);
        }

        [Test]
        public async Task GetRandomBeerAsync_should_load_sinlge_beer()
        {
            var responseJson = await File.ReadAllTextAsync(GetTestDataPath(SingleBeerTestDataName));
            var fakeHttpMessageHandler = new FakeHttpMessageHandler();
            fakeHttpMessageHandler.EnqueueStringJsonResponse(responseJson);

            var beers = await CreateSut(fakeHttpMessageHandler).GetRandomBeerAsync();

            Assert.NotNull(beers);
        }

        [Test]
        public void GetRandomBeerAsync_should_throw_on_server_error()
        {
            var fakeHttpMessageHandler = new FakeHttpMessageHandler();
            fakeHttpMessageHandler.EnqueuErrorResponse();

            var exception = Assert.ThrowsAsync<PunkApiServiceException>(() => CreateSut(fakeHttpMessageHandler).GetRandomBeerAsync());
            Assert.AreEqual(HttpStatusCode.InternalServerError, exception.HttpResponseCode);
        }

        private static string GetTestDataPath(string testFileName)
        {
            return Path.Combine(Environment.CurrentDirectory, "Data", testFileName);
        }
    }
}
