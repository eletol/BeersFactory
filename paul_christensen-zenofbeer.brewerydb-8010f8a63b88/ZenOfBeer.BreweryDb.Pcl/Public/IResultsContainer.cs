/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
using System.Collections.Generic;
using System.Net;

namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    public interface IResultsContainer<T> : ICollection<T>
    {
        string Message { get; }
        string Status { get; }

        /// <summary>
        /// the error message returned from the api
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// the http status message
        /// </summary>
        HttpStatusCode HttpStatusCode { get; }

        /// <summary>
        /// the current result page
        /// </summary>
        string CurrentPage { get; }

        /// <summary>
        /// the total number of pages
        /// </summary>
        string NumberOfPages { get; }

        /// <summary>
        /// the total number of results
        /// </summary>
        string TotalResults { get; }
    }
}