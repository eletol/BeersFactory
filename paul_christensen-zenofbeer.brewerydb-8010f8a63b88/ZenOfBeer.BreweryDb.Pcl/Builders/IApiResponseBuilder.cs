/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Net.Http;
using ZenOfBeer.BreweryDb.Pcl.HttpCore;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal interface IApiResponseBuilder
    {
        IApiResponse Build();
        void SetApiResponse(HttpResponseMessage httpResponseMessage);
    }
}