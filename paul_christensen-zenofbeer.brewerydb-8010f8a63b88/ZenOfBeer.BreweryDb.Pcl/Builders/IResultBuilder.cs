/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using Newtonsoft.Json.Linq;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal interface IResultBuilder
    {
        IBdoBase Build();

        void Init();

        void SetResultData(JToken jToken);
    }
}