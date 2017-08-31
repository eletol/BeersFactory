/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
namespace ZenOfBeer.BreweryDb.Pcl.Public
{
    /// <summary>
    /// Gets a list of all adjuncts. Results are paginated.
    /// <remarks>
    /// possible query parameters:
    /// p : Page Number
    /// adjunctId : get a singe adjunct by Id
    /// </remarks>
    /// </summary>
    public interface IAdjunct : IBdoBase
    {
        /// <summary>
        /// This value will always be set to "misc"
        /// </summary>
        string Category { get; }

        /// <summary>
        /// This value will always be set to "Miscellaneous"
        /// </summary>
        string CategoryDisplay { get; }
    }
}