/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Collections.Generic;
using ZenOfBeer.BreweryDb.Pcl.HttpCore;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal interface IApiRequestBuilder
    {
        /// <summary>
        /// prepare the builder for setup and building. 
        /// </summary>
        void Init();

        /// <summary>
        /// build the api request
        /// </summary>
        /// <returns></returns>
        IApiRequest Build();

        /// <summary>
        /// Set the API Request.
        /// </summary>
        /// <remarks>
        /// Some styles require parameters without paid license. See BreweryDb docs for details: http://www.brewerydb.com/developers/docs
        /// </remarks>
        /// <param name="apiKey">private api key</param>
        /// <param name="endpoint">string name of service endpoint</param>
        /// <param name="parameters">query parameters</param>
        void SetRequest(string apiKey, string endpoint, KeyValuePair<string, string>[] parameters);

        /// <summary>
        /// build an api request to get beers by brewery
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="extendBaseAddress"></param>
        /// <param name="endpoint"></param>
        /// <param name="breweryId"></param>
        void SetForBeersByBrewery(string apiKey, string extendBaseAddress, string endpoint, string breweryId);
    }
}