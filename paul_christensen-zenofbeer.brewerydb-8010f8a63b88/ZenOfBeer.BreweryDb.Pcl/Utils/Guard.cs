/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */
using System;

namespace ZenOfBeer.BreweryDb.Pcl.Utils
{
    internal static class Guard
    {
         public static void IsNotNull(object source)
         {
             if (null == source)
             {
                 throw new ArgumentException("object is null and should not be");
             }
         }

        public static void IsNullOrEmpty(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("string is null or empty and should not be");
            }
        }
    }
}