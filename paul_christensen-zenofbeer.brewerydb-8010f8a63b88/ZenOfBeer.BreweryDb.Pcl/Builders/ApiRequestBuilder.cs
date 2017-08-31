/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using ZenOfBeer.BreweryDb.Pcl.HttpCore;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal class ApiRequestBuilder : IApiRequestBuilder
    {
        private readonly string _baseAddress = "http://api.brewerydb.com/v2/";

        private readonly MediaTypeWithQualityHeaderValue _mediaHeaderValue =
            new MediaTypeWithQualityHeaderValue("application/json");

        private string _endpoint;
        private string _apiKey;
        private string _parameters;

        public IApiRequest Build()
        {
            return new ApiCall
                       {
                           BaseAddress = _baseAddress,
                           DefaultRequestHeaders = _mediaHeaderValue,
                           QueryString = string.Format("{0}?key={1}{2}", _endpoint, _apiKey, _parameters)
                       };
        }

        public void Init()
        {
            _endpoint = null;
            _apiKey = null;
            _parameters = null;
        }

        public void SetRequest(string apiKey, string endpoint, KeyValuePair<string, string>[] parameters)
        {
            _endpoint = endpoint;
            _apiKey = apiKey;
            _parameters = BuildParametersList(parameters);
        }

        public void SetForBeersByBrewery(string apiKey, string extendBaseAddress, string endpoint, string breweryId)
        {
            _endpoint = string.Format("{0}/{1}/{2}", extendBaseAddress, breweryId, endpoint);
            _apiKey = apiKey;
            _parameters = null;
        }

        private string BuildParametersList(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var stringBuilder = new StringBuilder();

            foreach (var parameter in parameters)
            {
                if (parameter.Value.Length!=0)
                {
                    stringBuilder.Append(string.Concat("&", parameter.Key, "=", parameter.Value));

                }
            }

            return stringBuilder.ToString();
        }
    }
}