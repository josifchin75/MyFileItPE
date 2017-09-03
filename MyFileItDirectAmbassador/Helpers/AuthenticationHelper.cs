using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyFileItDirectAmbassador.Helpers
{
    public static class AuthenticationHelper
    {
        public const string Delimiter = "~";
        public static string CreateAuthCookie(string emailAddress, bool admin)
        {
            var result = emailAddress + Delimiter + admin;
            return result;
        }

        public static string UserName(string cookie)
        {
            string result = null;
            var results = Regex.Split(cookie, Delimiter);
            if (results.Length == 2)
            {
                result = results[0];
            }
            return result;
        }
        public static bool Admin(string cookie)
        {
            bool result = false;
            var results = Regex.Split(cookie, Delimiter);
            if (results.Length == 2)
            {
                result = bool.Parse(results[1].ToLower());
            }
            return result;
        }


    }
}
