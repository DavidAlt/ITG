using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup;
using System.Globalization;

namespace DALT.Controls.Converters
{
    public class StringToFontFamilyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // convert from string to FontFamily
            string font = parameter as string;
            //System.Console.WriteLine("Reached StringToFontFamilyConverter: {0}", font);
            if (!string.IsNullOrEmpty(font))
            {
                return new FontFamily(font);
            }
                
            else return null;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // convert from FontFamily to String
            FontFamily font = parameter as FontFamily;
            return font.ToString().Split('#')[font.ToString().Split('#').Count() - 1];

        }

        private FontFamily GetLocalizedFontFamily(FontFamily font)
        {
            string localizedName = font.FamilyNames[XmlLanguage.GetLanguage(CultureInfo.CurrentUICulture.Name)];
            if (!String.IsNullOrEmpty(localizedName))
                return new FontFamily(localizedName);

            return font;
        }
    }
}
