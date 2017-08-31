/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace ZenOfBeer.BreweryDb.Pcl
{
    internal class Adjunct : BdoBase, IAdjunct
    {
        public string Category { get; set; }
    }
}