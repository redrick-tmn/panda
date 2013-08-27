using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine
{
    public static class Extensions
    {
        #region Boolean 

        public static int Int(this Boolean b)
        {
            return b ? 1 : 0;
        }

        #endregion

        #region String

        public static string Shorten(this string src, int newLength)
        {
            return src.Length > newLength 
                ? src.Substring(0, newLength - 3) + "..."
                : src;
        }

        #endregion
    }
}