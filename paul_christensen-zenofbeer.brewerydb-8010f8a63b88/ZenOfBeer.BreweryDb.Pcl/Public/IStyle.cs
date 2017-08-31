/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    /// <summary>
    /// optional parameters
    /// <remarks></remarks>
    /// </summary>
    public interface IStyle : IBdoBase
    {
        /// <summary>
        /// category Id
        /// </summary>
        string CategoryId { get; }

        /// <summary>
        /// Category object associated with category Id
        /// </summary>
        ICategory Category { get; }

        /// <summary>
        /// International Bitterness Unit - max bitterness for this style
        /// </summary>
        string IbuMin { get; }

        /// <summary>
        /// International Bitterness Unit - min bitterness for this style
        /// </summary>
        string IbuMax { get; }

        /// <summary>
        /// Alcohol by volume - max measurement for this style
        /// </summary>
        string AbvMin { get; }

        /// <summary>
        /// Alcohol by volume - min measurement for this style
        /// </summary>
        string AbvMax { get; }

        /// <summary>
        /// Standard Reference Method - min darkness for this style
        /// </summary>
        string SrmMin { get; }

        /// <summary>
        /// Standard Reference Method - max darkness for this style
        /// </summary>
        string SrmMax { get; }

        /// <summary>
        /// Original Gravity - min original gravity for this style
        /// </summary>
        string OgMin { get; }

        /// <summary>
        /// Original Gravity - max original gravity for this style
        /// </summary>
        string OgMax { get; }

        /// <summary>
        /// Final Gravity - min final gravity for this style
        /// </summary>
        string FgMin { get; }

        /// <summary>
        /// Final Gravity - max final gravity for this style
        /// </summary>
        string FgMax { get; }
    }
}