/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Net;
using Newtonsoft.Json.Linq;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal interface IResultsBuilder<T>
    {
        IResultsContainer<T> Build();

        void Init();

        void SetResults(JObject jObject, HttpStatusCode httpStatusCode);
    }
}