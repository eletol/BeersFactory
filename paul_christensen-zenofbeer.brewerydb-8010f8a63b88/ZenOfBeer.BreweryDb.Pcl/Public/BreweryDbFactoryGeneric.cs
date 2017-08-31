/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZenOfBeer.BreweryDb.Pcl.Builders;
using ZenOfBeer.BreweryDb.Pcl.HttpCore;
using ZenOfBeer.BreweryDb.Pcl.Utils;

namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class BreweryDbFactory<T>
    {
        private static IApiRequestBuilder _requestBuilder = new ApiRequestBuilder();
        private static IApiCallerBuilder _callerBuilder = new ApiCallerBuilder();
        private static readonly EndpointsMap Endpoints = new EndpointsMap();

        /// <summary>
        /// public interface to the API wrapper. 
        /// </summary>
        /// <param name="apiKey">api key</param>
        /// <param name="parameters">key value pair representing BreweryDb query parameters. </param>
        /// <returns></returns>
        public async static Task<IResultsContainer<T>> GetData(string apiKey, params KeyValuePair<string, string>[] parameters)
        {
            Guard.IsNullOrEmpty(apiKey);

            var endpoint = Endpoints.Map[typeof(T)];

            var apiRequest = BuildRequest(apiKey, endpoint, parameters);
            var apiCaller = BuildCaller(apiRequest);

            var apiResponse = await apiCaller.GetResponse();

            return  GetQueryResponse(apiResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="breweryId"></param>
        /// <returns></returns>
        internal async static Task<IResultsContainer<T>> GetBeersByBrewery(string apiKey, string breweryId) 
        {
            Guard.IsNotNull(apiKey);
            Guard.IsNotNull(breweryId);

            var endpoint = Endpoints.Map[typeof (T)];

            _requestBuilder.Init();
            _requestBuilder.SetForBeersByBrewery(apiKey, "brewery", endpoint, breweryId);
            var apiRequest = _requestBuilder.Build();
            var apiCaller = BuildCaller(apiRequest);
            var apiResponse = await apiCaller.GetResponse();
            return GetQueryResponse(apiResponse);
        }

        internal static IBdoBase GetObject(JToken jToken)
        {            
            if (null == jToken)
            {
                return null;
            }
            var builder = GetBuilder();
            builder.Init();
            builder.SetResultData(jToken);
            return builder.Build();
        }

        private static IResultsContainer<T> GetQueryResponse(IApiResponse apiResponse)
        {
            var builder = new ResultsBuilder<T>(GetBuilder());
            builder.Init();
            var jsonResponse = (JObject)JsonConvert.DeserializeObject(apiResponse.RawResult);
            builder.SetResults(jsonResponse, apiResponse.HttpStatusCode);
            var responseContainer = builder.Build();
            if (responseContainer.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(responseContainer.ErrorMessage);
            }
            return responseContainer;
        }

        private static IApiRequest BuildRequest(string apiKey, string endpoint,
                                                KeyValuePair<string, string>[] parameters)
        {
            _requestBuilder.Init();
            _requestBuilder.SetRequest(apiKey, endpoint, parameters);
            return _requestBuilder.Build();
        }

        private static IApiCaller BuildCaller(IApiRequest request)
        {
            _callerBuilder.Init();
            _callerBuilder.SetRequest(request);
            return _callerBuilder.Build();
        }

        /// <summary>
        /// maps interfaces to styles to set up endpoint queries.
        /// </summary>
        private class EndpointsMap
        {
            public EndpointsMap()
            {
                Map = new Dictionary<Type, string>();
                Map.Add(typeof (IStyle), "styles");
                Map.Add(typeof (IBeer), "beers");
                Map.Add(typeof(IAdjunct), "adjuncts");
                Map.Add(typeof (IImages), "images");
                Map.Add(typeof (IBrewery), "breweries");
                Map.Add(typeof(BeerDataObject), "beers");

            }

            public Dictionary<Type, string> Map { get; private set; }
        }

        private static IResultBuilder GetBuilder()
        {
            if (typeof (IAdjunct) == typeof (T))
            {
                return new AdjunctBuilder();
            }
            else
            {
                return new ResultBuilder();
            }
        }
    }
}