/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using ZenOfBeer.BreweryDb.Pcl.HttpCore;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal interface IApiCallerBuilder
    {
        IApiCaller Build();

        void Init();

        void SetRequest(IApiRequest apiRequest);
    }
}