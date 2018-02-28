using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Xml;
using System.Windows.Markup;

namespace DALT.Utility.Extensions
{
    public static class ExportControlTemplateExtension
    {
        // return control template as a string
        public static string ExportControlTemplate(this Control ctrl)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, settings);
            XamlWriter.Save(ctrl.Template, writer);
            return sb.ToString();
        }
        
        // save control template to a file
        public static void ExportControlTemplateToFile(this Control ctrl, string path)
        {
            File.WriteAllText(path, ctrl.ExportControlTemplate());
        }

    }
}
