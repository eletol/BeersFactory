/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using ZenOfBeer.BreweryDb.Pcl.Public;

namespace ZenOfBeer.BreweryDb.Pcl
{
    public class BeerDataObject : BdoBase, IStyle, ICategory, IGlass, ILabels, IBeerAvailability, IBeer, IImages, IBrewery
    {
        public string CategoryId { get; set; }
        public ICategory Category { get; set; }
        public string IbuMin { get; set; }
        public string IbuMax { get; set; }
        public string AbvMin { get; set; }
        public string AbvMax { get; set; }
        public string SrmMin { get; set; }
        public string SrmMax { get; set; }
        public string OgMin { get; set; }
        public string OgMax { get; set; }
        public string FgMin { get; set; }
        public string FgMax { get; set; }
        public string FoodPairings { get; set; }
        public string OriginalGravity { get; set; }
        public string Abv { get; set; }
        public string Ibu { get; set; }
        public string GlasswareId { get; set; }
        public IGlass Glass { get; set; }
        public string StyleId { get; set; }
        public IStyle Style { get; set; }
        public string Website { get; set; }
        public string Established { get; set; }
        public string MailingListUrl { get; set; }
        public IImages Images { get; set; }
        public bool? IsOrganic { get; set; }
        public ILabels Labels { get; set; }
        public string ServingTemperature { get; set; }
        public string ServingTemperatureDisplay { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string AvailableId { get; set; }
        public IBeerAvailability Available { get; set; }
        public string BeerVariationId { get; set; }
        public IBeer BeerVariation { get; set; }
        public string Year { get; set; }
        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}