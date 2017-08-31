/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    /// <summary>
    /// A set of images (icon, medium, and large)
    /// </summary>
    public interface IImages : IBdoBase
    {
        /// <summary>
        /// The icon version of the image.
        /// </summary>
        string Icon { get; }

        /// <summary>
        /// The medium version of the image.
        /// </summary>
        string Medium { get; }

        /// <summary>
        /// The large version of the image.
        /// </summary>
        string Large { get; }
    }
}