using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup;
using System.Globalization;

namespace DALT.Controls.Converters
{
    public class StringToIntConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // convert from string to int
            string s = parameter as string;
            int result = 0;
            if(!string.IsNullOrEmpty(s))
            {
                if (int.TryParse(s, out result))
                {
                    return result; // sloppy
                }

            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // convert from int to string
            int i = (int)parameter;
            return i;
        }

    }

}
