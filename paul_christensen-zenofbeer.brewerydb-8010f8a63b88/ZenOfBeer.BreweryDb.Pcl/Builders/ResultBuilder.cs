/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using Newtonsoft.Json.Linq;
using ZenOfBeer.BreweryDb.Pcl.Public;
using ZenOfBeer.BreweryDb.Pcl.Utils;

namespace ZenOfBeer.BreweryDb.Pcl.Builders
{
    internal class ResultBuilder : IResultBuilder
    {
        private string _id;
        private string _name;
        private string _description;
        private string _categoryId;
        private JToken _category;
        private string _ibuMin;
        private string _ibuMax;
        private string _abvMin;
        private string _abvMax;
        private string _srmMin;
        private string _srmMax;
        private string _ogMin;
        private string _ogMax;
        private string _fgMin;
        private string _fgMax;
        private string _foodPairings;
        private string _originalGravity;
        private string _abv;
        private string _ibu;
        private string _glasswareId;
        private JToken _glass;
        private string _styleId;
        private JToken _style;
        private bool? _isOrganic;
        private JToken _labels;
        private string _servingTemperature;
        private string _servingTemperatureDisplay;
        private string _status;
        private string _statusDisplay;
        private string _availableId;
        private JToken _available;
        private string _beerVariationId;
        private JToken _beerVariation;
        private string _year;
        private string _icon;
        private string _medium;
        private string _large;
        private string _website;
        private string _established;
        private string _mailinglistUrl;
        private JToken _images;

        public ResultBuilder()
        {            
        }

        public IBdoBase Build()
        {
            return new BeerDataObject
                       {
                           Id = _id,
                           Name = _name,
                           Description = _description,
                           CategoryId = _categoryId,
                           Category = (ICategory)BreweryDbFactory<ICategory>.GetObject(_category),
                           IbuMin = _ibuMin,
                           IbuMax = _ibuMax,
                           AbvMin = _abvMin,
                           AbvMax = _abvMax,
                           SrmMin = _srmMin,
                           SrmMax = _srmMax,
                           OgMin = _ogMin,
                           OgMax = _ogMax,
                           FgMin = _fgMin,
                           FgMax = _fgMax,
                           FoodPairings = _foodPairings,
                           OriginalGravity = _originalGravity,
                           Abv = _abv,
                           Ibu = _ibu,
                           GlasswareId = _glasswareId,
                           Glass = (IGlass)BreweryDbFactory<IGlass>.GetObject(_glass),
                           StyleId = _styleId,
                           Style = (IStyle)BreweryDbFactory<IStyle>.GetObject(_style),
                           IsOrganic = _isOrganic,
                           Labels = (ILabels)BreweryDbFactory<ILabels>.GetObject(_labels),
                           ServingTemperature = _servingTemperature,
                           ServingTemperatureDisplay = _servingTemperatureDisplay,
                           Status = _status,
                           StatusDisplay = _statusDisplay,
                           AvailableId = _availableId,
                           Available = (IBeerAvailability)BreweryDbFactory<IBeerAvailability>.GetObject(_available),
                           BeerVariationId = _beerVariationId,
                           BeerVariation = (IBeer)BreweryDbFactory<IBeer>.GetObject(_beerVariation),
                           Year = _year,
                           Icon = _icon,
                           Medium = _medium,
                           Large = _large,
                           Website = _website,
                           Established = _established,
                           MailingListUrl = _mailinglistUrl,
                           Images = (IImages)BreweryDbFactory<IImages>.GetObject(_images)
                       };
        }

        public void Init()
        {
            _id = null;
            _name = null;
            _description = null;
            _categoryId = null;
            _category = null;
            _ibuMin = null;
            _ibuMax = null;
            _abvMin = null;
            _abvMax = null;
            _srmMin = null;
            _srmMax = null;
            _ogMin = null;
            _ogMax = null;
            _fgMin = null;
            _fgMax = null;
            _icon = null;
            _foodPairings = null;
            _originalGravity = null;
            _abv = null;
            _ibu = null;
            _glasswareId = null;
            _glass = null;
            _styleId = null;
            _style = null;
            _isOrganic = null;
            _labels = null;
            _servingTemperature = null;
            _servingTemperatureDisplay = null;
            _status = null;
            _statusDisplay = null;
            _availableId = null;
            _available = null;
            _beerVariationId = null;
            _beerVariation = null;
            _year = null;
        }

        public void SetResultData(JToken jToken)
        {
            _id = StringHelpers.ParseJTokenString(jToken["id"]);
            _name = StringHelpers.ParseJTokenString(jToken["name"]);
            _description = StringHelpers.ParseJTokenString(jToken["description"]);
            _categoryId = StringHelpers.ParseJTokenString(jToken["categoryId"]);
            _category = jToken["category"];
            _ibuMin = StringHelpers.ParseJTokenString(jToken["ibuMin"]);
            _ibuMax = StringHelpers.ParseJTokenString(jToken["ibuMax"]);
            _abvMin = StringHelpers.ParseJTokenString(jToken["abvMin"]);
            _abvMax = StringHelpers.ParseJTokenString(jToken["abvMax"]);
            _srmMin = StringHelpers.ParseJTokenString(jToken["srmMin"]);
            _srmMax = StringHelpers.ParseJTokenString(jToken["srmMax"]);
            _ogMin = StringHelpers.ParseJTokenString(jToken["ogMin"]);
            _ogMax = StringHelpers.ParseJTokenString(jToken["ogMax"]);
            _fgMin = StringHelpers.ParseJTokenString(jToken["fgMin"]);
            _fgMax = StringHelpers.ParseJTokenString(jToken["fgMax"]);
            _foodPairings = StringHelpers.ParseJTokenString(jToken["foodPairings"]);
            _originalGravity = StringHelpers.ParseJTokenString(jToken["originalGravity"]);
            _abv = StringHelpers.ParseJTokenString(jToken["abv"]);
            _ibu = StringHelpers.ParseJTokenString(jToken["ibu"]);
            _glasswareId = StringHelpers.ParseJTokenString(jToken["glasswareId"]);
            _glass = jToken["glass"];
            _styleId = StringHelpers.ParseJTokenString(jToken["styleId"]);
            _style = jToken["style"];
            _isOrganic = StringHelpers.ParseJTokenNullableBool(jToken["isOrganic"]);
            _labels = jToken["labels"];
            _servingTemperature = StringHelpers.ParseJTokenString(jToken["servingTemperature"]);
            _servingTemperatureDisplay = StringHelpers.ParseJTokenString(jToken["servingTemperatureDisplay"]);
            _status = StringHelpers.ParseJTokenString(jToken["status"]);
            _statusDisplay = StringHelpers.ParseJTokenString(jToken["statusDisplay"]);
            _availableId = StringHelpers.ParseJTokenString(jToken["availableId"]);
            _available = jToken["available"];
            _beerVariationId = StringHelpers.ParseJTokenString(jToken["beerVariationId"]);
            _beerVariation = jToken["beerVariation"];
            _year = StringHelpers.ParseJTokenString(jToken["year"]);
            _icon = StringHelpers.ParseJTokenString(jToken["icon"]);
            _medium = StringHelpers.ParseJTokenString(jToken["medium"]);
            _large = StringHelpers.ParseJTokenString(jToken["large"]);
            _website = StringHelpers.ParseJTokenString(jToken["website"]);
            _established = StringHelpers.ParseJTokenString(jToken["established"]);
            _mailinglistUrl = StringHelpers.ParseJTokenString(jToken["mailingListUrl"]);
            _images = jToken["images"];
        }
    }
}