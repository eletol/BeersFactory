/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
using ZenOfBeer.BreweryDb.Pcl.HttpCore;
using ZenOfBeer.BreweryDb.Pcl.Utils;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal class ApiCallerBuilder : IApiCallerBuilder
    {
        private IApiRequest _apiRequest;

        public IApiCaller Build()
        {
            Guard.IsNotNull(_apiRequest);
            return new ApiCaller
                       {
                           Request = _apiRequest
                       };
        }

        public void Init()
        {
            _apiRequest = null;
        }

        public void SetRequest(IApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }
    }
}