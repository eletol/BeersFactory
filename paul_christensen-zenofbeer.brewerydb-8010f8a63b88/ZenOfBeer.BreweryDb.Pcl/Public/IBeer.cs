/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    public interface IBeer : IBdoBase
    {
        /// <summary>
        /// A free text field containing any food pairing information for the beer
        /// </summary>
        string FoodPairings { get; }

        /// <summary>
        /// the original gravity of the beer
        /// </summary>
        string OriginalGravity { get; }

        /// <summary>
        /// the alcohol by volumn of the beer (expressed as a percentage).
        /// </summary>
        string Abv { get; }

        /// <summary>
        /// the IBU (International bittering unit) value is a measure of how bitter the beer is. The higher the number, the more bitter the beer.
        /// </summary>
        string Ibu { get; }

        /// <summary>
        /// The id corresponding to the glass object that is assigned to this beer. If this exists, then so will the glass object. See the glass object for more information.
        /// </summary>
        string GlasswareId { get; }

        /// <summary>
        /// Contains the details about the assigned glass (id, name). the name of the glass is the type of glass in which the beer is best served.
        /// </summary>
        IGlass Glass { get; }

        /// <summary>
        /// the id corresponding to the style object that is assigned to teh beer. See the style object for more information
        /// </summary>
        string StyleId { get; }

        /// <summary>
        /// the style object contains details about the assigned style.
        /// </summary>
        IStyle Style { get; }

        /// <summary>
        /// whether or not the beer is certified organic
        /// </summary>
        bool? IsOrganic { get; }

        /// <summary>
        /// If this object is set then labels exist and it will contain items icon, medium and large that are urls to the images
        /// </summary>
        ILabels Labels { get; }

        /// <summary>
        /// the key that corresponds to the serving temperature information. See the servingTemperatureDisplay field for the full details. 
        /// </summary>
        string ServingTemperature { get; }

        /// <summary>
        /// the serving temperature information. If the servingTemperature was "cool" then this field would be like "Cool - (8-12c/45-54F)"
        /// </summary>
        string ServingTemperatureDisplay { get; }

        /// <summary>
        /// the status key for the object
        /// </summary>
        string Status { get; }

        /// <summary>
        /// The display string corresponding to the status
        /// </summary>
        string StatusDisplay { get; }

        /// <summary>
        /// the id corresponding to the assigned availability object
        /// </summary>
        string AvailableId { get; }

        /// <summary>
        /// the object that provides details for the assigned availability. It contains id, name and description
        /// </summary>
        IBeerAvailability Available { get; }

        /// <summary>
        /// if this beer is a variation of another beer, then the id will be set to the id of the source beer.
        /// </summary>
        string BeerVariationId { get; }

        /// <summary>
        /// the beer to which the variationId is pointing
        /// </summary>
        IBeer BeerVariation { get; }

        /// <summary>
        /// The year field is for vintages of a beer
        /// </summary>
        string Year { get; }
    }
}