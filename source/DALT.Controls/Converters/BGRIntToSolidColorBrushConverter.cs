using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup;
using System.Globalization;
using DALT.Utility;

namespace DALT.Controls.Converters
{
    public class BGRIntToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int BGRInt = (int)value;
            return BGRInt.BGRToSolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = (SolidColorBrush)value;
            return brush.ToIntBGR();      
        }
    }
}

