/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
using Newtonsoft.Json.Linq;
using ZenOfBeer.BreweryDb.Pcl.Utils;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal class AdjunctBuilder : IResultBuilder
    {
        private string _id;
        private string _name;
        private string _description;
        private string _category;
        private string _categoryDisplay;

        public AdjunctBuilder()
        {            
        }

        public IBdoBase Build()
        {
            return new Adjunct
            {
                Id = _id,
                Name = _name,
                Description = _description,
                Category = _category,
                CategoryDisplay = _categoryDisplay
            };
        }

        public void Init()
        {
            _id = null;
            _name = null;
            _description = null;
            _category = null;
            _categoryDisplay = null;
        }

        public void SetResultData(JToken jToken)
        {
            _id = StringHelpers.ParseJTokenString(jToken["id"]);
            _name = StringHelpers.ParseJTokenString(jToken["name"]);
            _description = StringHelpers.ParseJTokenString(jToken["description"]);
            _category = StringHelpers.ParseJTokenString(jToken["category"]);
            _categoryDisplay = StringHelpers.ParseJTokenString(jToken["categoryDisplay"]);
        }
    }
}