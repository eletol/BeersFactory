/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Net.Http;
using Newtonsoft.Json.Linq;
using ZenOfBeer.BreweryDb.Pcl.HttpCore;
using ZenOfBeer.BreweryDb.Pcl.Utils;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal class ApiResponseBuilder : IApiResponseBuilder
    {
        private HttpResponseMessage _responseMessage;

        public IApiResponse Build()
        {
            Guard.IsNotNull(_responseMessage);

            var response = new ApiCall
                               {
                                   StatusSuccess = _responseMessage.IsSuccessStatusCode,
                                   HttpStatusCode = _responseMessage.StatusCode,
                                   RawResult = _responseMessage.Content.ReadAsStringAsync().Result
                               };
            // ToDo: implement logging and fix this to check for an exception. 

            if (response.StatusSuccess)
            {
                response.JsonResponse = JObject.Parse(response.RawResult);
            }
            return response;
        }

        public void SetApiResponse(HttpResponseMessage httpResponseMessage)
        {
            _responseMessage = httpResponseMessage;
        }
    }
}