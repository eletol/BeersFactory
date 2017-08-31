/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    public class ResultsContainer<T> : List<T>, IResultsContainer<T>
    {
        public ResultsContainer() : base()
        {
            
        }

        public string Message { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// the error message returned from the api
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// the http status message
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// the current result page
        /// </summary>
        public string CurrentPage { get; set; }

        /// <summary>
        /// the total number of pages
        /// </summary>
        public string NumberOfPages { get; set; }

        /// <summary>
        /// the total number of results
        /// </summary>
        public string TotalResults { get; set; }
    }
}