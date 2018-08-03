using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lBook
{
    static class ExtensionForString
    {
        static public bool IsLetter(this string s, char c)
        {
            return c >= 'A' && c <= 'Z';
        }
        static bool IsDigit(this string s, char c)
        {
            return c >= '0' && c <= '9';
        }
        static bool IsSymbol(this string s, char c)
        {
            return c > 32 && c <= 47 || c >= 91 && c < 97 || c >= 123 && c < 127;
        }
        public static bool IsValidPassword(this string password)
        {
            return
                password.Any(x => password.IsLetter(x)) &&
                password.Any(x => password.IsDigit(x)) &&
                password.Any(x => password.IsSymbol(x));
        }
    }
}
