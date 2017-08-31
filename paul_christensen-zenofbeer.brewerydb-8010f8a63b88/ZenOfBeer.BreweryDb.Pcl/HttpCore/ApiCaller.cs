/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System;
using System.Net.Http;
using System.Threading.Tasks;
using ZenOfBeer.BreweryDb.Pcl.Builders;

namespace ZenOfBeer.BreweryDb.Pcl.HttpCore
{
    internal class ApiCaller : IApiCaller
    {
        private readonly IApiResponseBuilder _responseBuilder;

        public ApiCaller()
        {
            _responseBuilder = new ApiResponseBuilder();
        }

        public IApiRequest Request { get; set; }

        public async Task<IApiResponse>  GetResponse()
        {
            using (var client = new HttpClient())
            {
                client.MaxResponseContentBufferSize = Int32.MaxValue;
                client.BaseAddress = new Uri(Request.BaseAddress);
                client.DefaultRequestHeaders.Accept.Add(Request.DefaultRequestHeaders);
                client.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
                var response = await client.GetAsync(Request.QueryString);
                _responseBuilder.SetApiResponse(response);
            }
            return _responseBuilder.Build();
        }        

    }
}