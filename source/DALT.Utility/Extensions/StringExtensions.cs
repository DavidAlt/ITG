using System;

namespace DALT.Utility.Extensions
{
    public static class StringExtensions
    {
        public static string QuoteWrap(this string source)
        {
            return "\"" + source + "\"";
        }

        public static string QuoteUnwrap(this string source)
        {
            return source.Trim('"');
        }
    }
}
