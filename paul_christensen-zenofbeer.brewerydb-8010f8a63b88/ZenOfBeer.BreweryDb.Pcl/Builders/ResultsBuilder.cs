/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using System;
using System.Net;
using Newtonsoft.Json.Linq;
using ZenOfBeer.BreweryDb.Pcl.Public;
using ZenOfBeer.BreweryDb.Pcl.Utils;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal class ResultsBuilder<T> : IResultsBuilder<T>
    {
        private readonly IResultBuilder _builder;
        private string _message;
        private string _errorMessage;
        private string _status;
        private string _currentPage;
        private string _numberOfPages;
        private string _totalResults;
        private HttpStatusCode _httpStatusCode;
        private JToken _data;

        public ResultsBuilder(IResultBuilder builder)
        {
            Guard.IsNotNull(builder);

            _builder = builder;
        }

        public IResultsContainer<T> Build()
        {
            var convertedResults = new ResultsContainer<T>
                                       {
                                           Message = _message,
                                           ErrorMessage = _errorMessage,
                                           Status = _status,
                                           CurrentPage = _currentPage,
                                           NumberOfPages = _numberOfPages,
                                           TotalResults = _totalResults,
                                           HttpStatusCode = _httpStatusCode
                                       };
            if (HttpStatusCode.OK == _httpStatusCode)
            {
                if (_data != null)
                {
                    if (typeof(JArray) == _data.GetType())
                    {
                        foreach (var jToken in _data)
                        {
                            ProcessJData(jToken, ref convertedResults);
                        }
                    }
                    else
                    {
                            ProcessJData(_data, ref convertedResults);

                        
                    }
                }
              
            }
            return convertedResults;
        }

        public void Init()
        {
            _message = null;
            _status = null;
            _data = null;
        }

        public void SetResults(JObject jObject, HttpStatusCode httpStatusCode)
        {
            _message = StringHelpers.ParseJTokenString(jObject["message"]);
            _errorMessage = StringHelpers.ParseJTokenString(jObject["errorMessage"]);
            _status = StringHelpers.ParseJTokenString(jObject["status"]);
            _currentPage = StringHelpers.ParseJTokenString(jObject["currentPage"]);
            _numberOfPages = StringHelpers.ParseJTokenString(jObject["numberOfPages"]);
            _totalResults = StringHelpers.ParseJTokenString(jObject["totalResults"]);
            _httpStatusCode = httpStatusCode;
            
            _data = jObject["data"];
        }

        private void ProcessJData(JToken jToken, ref ResultsContainer<T> convertedResults)
        {
            _builder.Init();
            _builder.SetResultData(jToken);
            convertedResults.Add((T) Convert.ChangeType(_builder.Build(), typeof (T), null));
        }
    }
}