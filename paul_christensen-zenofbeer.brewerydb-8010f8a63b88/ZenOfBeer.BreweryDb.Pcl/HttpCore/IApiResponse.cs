/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Net;
using Newtonsoft.Json.Linq;

namespace ZenOfBeer.BreweryDb.Pcl.HttpCore
{
    internal interface IApiResponse
    {
        /// <summary>
        /// returns the status of the call
        /// </summary>
        bool StatusSuccess { get; }

        HttpStatusCode HttpStatusCode { get; }

        string RawResult { get; }

        JObject JsonResponse { get; }
    }
}