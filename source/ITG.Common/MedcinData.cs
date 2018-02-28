using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml;


namespace ITG.Common
{
    // TODO
    // * figure out how to query for active/available terms

    public static class MedcinData
    {
        // PATH TO DEFAULT DICTIONARY (maybe make this an application setting so user can configure?)
        private static string pathToTerms = Path.Combine(Environment.CurrentDirectory, "Resources", "MedcinStarterPack.xml");

        // CONSTRUCTOR
        static MedcinData()
        {
            terms = new ObservableCollection<MedcinTerm>();

            // attempt to load default data
            if (File.Exists(pathToTerms))
            {
                Console.WriteLine("Default dictionary located at {0}.", pathToTerms);
                Console.WriteLine("Attempting to load file ...");
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (XmlReader reader = XmlReader.Create(pathToTerms, settings))
                {
                    MedcinData.ReadXml(reader);
                }
                Console.WriteLine("Loading finished.");
            }
            else Console.WriteLine("File not found");
        }


        // MASTER LIST OF TERMS
        private static ObservableCollection<MedcinTerm> terms;
        public static ObservableCollection<MedcinTerm> Terms
        {
            get { return terms; }
        }


        #region LIST OPERATIONS

        public static IEnumerable<MedcinTerm> ExtractBy(Common.Category cat)
        {
            IEnumerable<MedcinTerm> query = Terms.Where(term => term.Category == cat);
            return query;
        }

        public static IEnumerable<MedcinTerm> ExtractBy(Common.Category cat, IEnumerable<MedcinTerm> list)
        {
            IEnumerable<MedcinTerm> query = list.Where(term => term.Category == cat);
            return query;
        }

        public static void Reset()
        {
            Terms.Clear();
        }

        public static bool IsEmpty()
        {
            if (!Terms.Any()) return true;
            else return false;
        }

        public static bool ContainsKey(string key)
        {
            foreach (MedcinTerm term in terms)
            {
                if (term.Key == key) return true;
            }
            return false; // did not find a match
        }

        public static bool ContainsTerm(MedcinTerm term)
        {
            return terms.Contains(term);
        }

        #endregion


        #region SERIALIZATION

        public static void ReadXml(XmlReader r)
        {
            // watch out for empty elements
            bool isEmpty = r.IsEmptyElement;
            r.ReadStartElement();
            if (isEmpty) return;

            // make sure the node retrieved is an element
            while (r.NodeType == XmlNodeType.Element)
            {
                // verify the element is a MedcinTerm
                if (r.Name == MedcinTerm.XmlName)
                {
                    if (terms == null) terms = new ObservableCollection<MedcinTerm>();
                    terms.Add(new MedcinTerm(r));
                }
                else
                    throw new XmlException("Unexpected node: " + r.Name);
            }
            r.ReadEndElement();
        }

        public static void WriteXml(XmlWriter w)
        {
            foreach (MedcinTerm term in terms)
            {
                w.WriteStartElement(MedcinTerm.XmlName);
                term.WriteXml(w);
                w.WriteEndElement();
            }
        }

        #endregion
    }
}
