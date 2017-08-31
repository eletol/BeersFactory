/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    /// <summary>
    /// a breweryDb brewery object
    /// </summary>
    public interface IBrewery : IBdoBase
    {
        /// <summary>
        /// The URL to the brewery's website.
        /// </summary>
        string Website { get; }

        /// <summary>
        /// The year that the brewery was established.
        /// </summary>
        string Established { get; }

        /// <summary>
        /// The URL to the brewery's mailing list.
        /// </summary>
        string MailingListUrl { get; }

        /// <summary>
        /// Whether or not the brewery is certified organic.
        /// </summary>
        bool? IsOrganic { get; }

        /// <summary>
        /// The images field will contain the three image sizes for the brewery logos (icon, medium, and large).
        /// </summary>
        IImages Images{get;}
    }
}