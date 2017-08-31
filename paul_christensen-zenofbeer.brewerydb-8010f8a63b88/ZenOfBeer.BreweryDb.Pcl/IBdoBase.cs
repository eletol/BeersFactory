/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
namespace ZenOfBeer.BreweryDb.Pcl
{
    public interface IBdoBase
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }
    }
}