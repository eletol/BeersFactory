/*
 * Copyright (c) 2013 Paul Christensen
 * See the file license.txt for copying permission.
 */

using Newtonsoft.Json.Linq;

namespace ZenOfBeer.BreweryDb.Pcl.Utils
{
    internal static class StringHelpers
    {
         public static string ParseJTokenString(JToken jToken)
         {
             return (null != jToken) ? jToken.ToString() : null;
         }

        public static bool? ParseJTokenNullableBool(JToken jToken)
        {
            bool? result = null;
            if (null != jToken)
            {
                bool parseBool;
                result = bool.TryParse(jToken.ToString(), out parseBool);
                if ((bool) result)
                {
                    result = parseBool;
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
    }
}