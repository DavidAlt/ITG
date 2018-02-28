using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup;
using System.Globalization;

namespace DALT.ITG.Converters
{
    public class TildeToNewLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ToNewLine(parameter as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ToTilde(parameter as string);
        }


        public static string Toggle(string source)
        {
            if (source.Contains("~"))
                return ToNewLine(source);
            else
                return ToTilde(source);
        }

        public static string ToTilde(string source)
        {
            if (!source.Contains(Environment.NewLine) ||
                !source.Contains("\r") ||
                !source.Contains("\n"))
                return source;
            else
                return source.Replace(Environment.NewLine, "~").Replace("\r", "~").Replace("\n", "~");
        }

        public static string ToNewLine(string source)
        {
            if (!source.Contains("~"))
                return source;
            else
                return source.Replace("~", Environment.NewLine);
        }
    }
}
