using PunkApiNet.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PunkApiNet.Exceptions;

namespace PunkApiNet
{
    public class PunkApiClient : IPunkApiClient
    {
        private readonly HttpClient _httpClient;

        public PunkApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync(int maxResults = 25)
        {
            return await GetAsync<IEnumerable<Beer>>("beers", null, maxResults);
        }

        public async Task<IEnumerable<Beer>> GetAllBeersByPageAsync(int pageIndex, int maxResults = 25)
        {
            return await GetAsync<IEnumerable<Beer>>($"beers?page={pageIndex}", null, maxResults);
        }

        public async Task<IEnumerable<Beer>> GetAllBeersWithFilterAsync(PunkApiRequestParams punkAPiRequestParams, int maxResults = 25)
        {
            return await GetAsync<IEnumerable<Beer>>("beers", punkAPiRequestParams, maxResults);
        }

        public async Task<IEnumerable<Beer>> GetAllBeersWithFilterByPageAsync(PunkApiRequestParams punkAPiRequestParams, int pageIndex, int maxResults = 25)
        {
            return await GetAsync<IEnumerable<Beer>>($"beers?page={pageIndex}", punkAPiRequestParams, maxResults);
        }

        public async Task<Beer> GetBeerAsync(int id)
        {
            return await GetAsync<Beer>($"beers/{id}");
        }

        public async Task<Beer> GetRandomBeerAsync()
        {
            return await GetAsync<Beer>("beers/random");
        }

        private async Task<T> GetAsync<T>(string relativePath, PunkApiRequestParams punkAPiRequestParams = null, int? maxResults = 25)
        {
            try
            {
                var relativePathAndQuery = relativePath;
                if (maxResults.HasValue)
                {
                    relativePathAndQuery += "?per_page=" + maxResults.Value;
                }

                relativePathAndQuery += PunkQueryParamCreator.BuildQueryParamsString(punkAPiRequestParams);

                using var request = new HttpRequestMessage(HttpMethod.Get, relativePathAndQuery);

                var beersResponse = await _httpClient.SendAsync(request);

                if (beersResponse.IsSuccessStatusCode)
                    return await beersResponse.Content.ReadFromJsonAsync<T>();

                throw new PunkApiServiceException(beersResponse.StatusCode, "Request did not receive successful status code.");
            }
            catch (HttpRequestException httpEx)
            {
                throw httpEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
