/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace ZenOfBeer.BreweryDb.Pcl.HttpCore
{
    internal class ApiCall : IApiRequest, IApiResponse
    {
        public string BaseAddress { get; set; }
        public MediaTypeWithQualityHeaderValue DefaultRequestHeaders { get; set; }
        public string QueryString { get; set; }
        public string ApiKey { get; set; }
        public bool StatusSuccess { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string RawResult { get; set; }
        public JObject JsonResponse { get; set; }
    }
}