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

        public async Task<IEnumerable<Beer>> GetAllBeersAsync(int maxResults = PunkApiRequestParams.DefaultMaxResultCount)
        {
            var requestParams = new PunkApiRequestParams { MaxResultCount = maxResults };
            return await GetAsync<IEnumerable<Beer>>("beers", requestParams);
        }

        public async Task<IEnumerable<Beer>> GetAllBeersByPageAsync(int pageIndex, int maxResults = PunkApiRequestParams.DefaultMaxResultCount)
        {
            var punkApiRequestParams = new PunkApiRequestParams { PageIndex = pageIndex, MaxResultCount = maxResults };
            return await GetAsync<IEnumerable<Beer>>("beers", punkApiRequestParams);
        }

        public async Task<IEnumerable<Beer>> GetAllBeersWithFilterAsync(PunkApiRequestParams punkApiRequestParams)
        {
            if (punkApiRequestParams == null)
                punkApiRequestParams = PunkApiRequestParams.Default();

            return await GetAsync<IEnumerable<Beer>>("beers", punkApiRequestParams);
        }

        public async Task<Beer> GetBeerAsync(int id)
        {
            return await GetAsync<Beer>($"beers/{id}");
        }

        public async Task<Beer> GetRandomBeerAsync()
        {
            return await GetAsync<Beer>("beers/random");
        }

        private async Task<T> GetAsync<T>(string relativePath, PunkApiRequestParams punkApiRequestParams = null)
        {
            try
            {
                var relativePathAndQuery = relativePath;

                 relativePathAndQuery += PunkQueryParamCreator.BuildQueryParamsString(punkApiRequestParams);

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
