/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Net.Http.Headers;

namespace ZenOfBeer.BreweryDb.Pcl.HttpCore
{
    internal interface IApiRequest
    {
        /// <summary>
        /// Base request address
        /// </summary>
        string BaseAddress { get; }

        /// <summary>
        /// default request headers
        /// </summary>
        MediaTypeWithQualityHeaderValue DefaultRequestHeaders { get; }

        /// <summary>
        /// constructed query string
        /// </summary>
        string QueryString { get; }

        /// <summary>
        /// private api key
        /// </summary>
        string ApiKey { get; }
    }
}