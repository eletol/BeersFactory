/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Threading.Tasks;

namespace ZenOfBeer.BreweryDb.Pcl.HttpCore
{
    internal interface IApiCaller
    {
        IApiRequest Request { get; }
        Task<IApiResponse> GetResponse();
    }
}