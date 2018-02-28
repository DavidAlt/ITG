using System;

namespace DALT.ITG.Shared.Utilities
{
    public static class StringUtilities
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
