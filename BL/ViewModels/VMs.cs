using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class PagingInfo
    {
        
        public string Page { get; set; }
        public string Sort { get; set; }
        public string Order { get; set; }
        public  List<KeyValuePair<string, string>> filters { get; set; }

    }
    public class BaseBeers
    {
        public List<BeerDataObjectListVM> BeerDataObjectListVM { get; set; }
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
    public class BeerDataObjectVM
    {

            /// <summary>
            /// A free text field containing any food pairing information for the beer
            /// </summary>
           public string FoodPairings { get; set; }

        /// <summary>
        /// the original gravity of the beer
        /// </summary>
        public string OriginalGravity { get; set; }

        /// <summary>
        /// the alcohol by volumn of the beer (expressed as a percentage).
        /// </summary>
        public string Abv { get; set; }

        /// <summary>
        /// the IBU (International bittering unit) value is a measure of how bitter the beer is. The higher the number, the more bitter the beer.
        /// </summary>
        public string Ibu { get; set; }

        /// <summary>
        /// The id corresponding to the glass object that is assigned to this beer. If this exists, then so will the glass object. See the glass object for more information.
        /// </summary>
        public string GlasswareId { get; set; }

        /// <summary>
        /// Contains the details about the assigned glass (id, name). the name of the glass is the type of glass in which the beer is best served.
        /// </summary>

        /// <summary>
        /// the id corresponding to the style object that is assigned to teh beer. See the style object for more information
        /// </summary>
        public string StyleId { get; set; }

        /// <summary>
        /// the style object contains details about the assigned style.
        /// </summary>

        /// <summary>
        /// whether or not the beer is certified organic
        /// </summary>
        public bool? IsOrganic { get; set; }

        /// <summary>
        /// If this object is set then labels exist and it will contain items icon, medium and large that are urls to the images
        /// </summary>

        /// <summary>
        /// the key that corresponds to the serving temperature information. See the servingTemperatureDisplay field for the full details. 
        /// </summary>
        public string ServingTemperature { get; set; }

        /// <summary>
        /// the serving temperature information. If the servingTemperature was "cool" then this field would be like "Cool - (8-12c/45-54F)"
        /// </summary>
        public string ServingTemperatureDisplay { get; set; }

        /// <summary>
        /// the status key for the object
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The display string corresponding to the status
        /// </summary>
        public string StatusDisplay { get; set; }

        /// <summary>
        /// the id corresponding to the assigned availability object
        /// </summary>
        public string AvailableId { get; set; }

        /// <summary>
        /// the object that provides details for the assigned availability. It contains id, name and description
        /// </summary>

        /// <summary>
        /// if this beer is a variation of another beer, then the id will be set to the id of the source beer.
        /// </summary>
        public string BeerVariationId { get; set; }

        /// <summary>
        /// the beer to which the variationId is pointing
        /// </summary>

        /// <summary>
        /// The year field is for vintages of a beer
        /// </summary>
        public string Year { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class BeerDataObjectListVM
    {

       
        /// <summary>
        /// the status key for the object
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The display string corresponding to the status
        /// </summary>
        public string StatusDisplay { get; set; }
        
        public string Id { get; set; }
        public string Name { get; set; }

    }

}
