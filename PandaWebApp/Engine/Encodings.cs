using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PandaWebApp.Engine
{
    public class Encodings
    {
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;

        public static string GetString(byte[] bytes)
        {
            return DefaultEncoding.GetString(bytes);
        }

        public static byte[] GetBytes(string str)
        {
            return DefaultEncoding.GetBytes(str);
        }
    }
}