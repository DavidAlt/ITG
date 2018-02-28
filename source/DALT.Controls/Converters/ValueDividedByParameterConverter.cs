using System;
using System.Globalization;
using System.Windows.Data;

// USED BY: PopupPanel
// FOR: Popup positioning
namespace DALT.Controls.Converters
{
    public class ValueDividedByParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double n, d;
            if (double.TryParse(value.ToString(), out n)
                && double.TryParse(parameter.ToString(), out d)
                && d != 0)
            {
                return n / d;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
