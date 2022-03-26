using PunkApiNet.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunkApiNet
{
    public interface IPunkApiClient
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync(int maxResults = 25);
        Task<IEnumerable<Beer>> GetAllBeersByPageAsync(int pageIndex, int maxResults = 25);
        Task<IEnumerable<Beer>> GetAllBeersWithFilterAsync(PunkApiRequestParams punkApiRequestParams);
        Task<Beer> GetBeerAsync(int id);
        Task<Beer> GetRandomBeerAsync();
    }
}
