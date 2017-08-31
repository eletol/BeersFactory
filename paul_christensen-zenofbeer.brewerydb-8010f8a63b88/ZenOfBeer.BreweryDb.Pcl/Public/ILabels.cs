/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    public interface ILabels : IBdoBase
    {
        /// <summary>
        /// url to label icon image
        /// </summary>
        string Icon { get; }

        /// <summary>
        /// url to label medium image
        /// </summary>
        string Medium { get; }

        /// <summary>
        /// url to label large image
        /// </summary>
        string Large { get; }
    }
}