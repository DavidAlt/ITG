using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Utilities
{
    public static class TextOps
    {
        public static string QuoteWrap(string source)
        {
            return "\"" + source + "\"";
        }

        public static string ToggleLineReturn(string source)
        {
            string result = "";
            if (source.Contains("~"))
            {
                result = source.Replace("~", Environment.NewLine);
            }
            else
            { 
                result = source.Replace(Environment.NewLine, "~").Replace("\r", "~").Replace("\n", "~");
            }
            return result;
        }

        public static string ExtractCaption(string source)
        {
            return SplitCaptionContent(source)[0];
        }

        public static string ExtractContent(string source)
        {
            return SplitCaptionContent(source)[1];
        }

        public static string[] SplitCaptionContent(string source)
        {
            string [] tokens = source.Split("~".ToCharArray(),2);
            return tokens;
        }
    }
}
