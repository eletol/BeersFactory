using System.Threading.Tasks;
using ZenOfBeer.BreweryDb.Pcl.Utils;

namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    /// <summary>
    /// Non-Generic IBeer version of the factory so that we don't have to specify the type in this call.
    /// </summary>
    public static class BreweryDbFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="breweryId"></param>
        /// <returns></returns>
        public async static Task<IResultsContainer<IBeer>> GetBeersByBrewery(string apiKey, string breweryId)
        {
            Guard.IsNotNull(apiKey);
            Guard.IsNotNull(breweryId);

            return await BreweryDbFactory<IBeer>.GetBeersByBrewery(apiKey, breweryId);
        }
    }
}