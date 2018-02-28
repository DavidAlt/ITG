using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Xml;

using DALT.Utility;

namespace ITG.Common
{


    [Serializable]
    public class MedcinTerm : ViewModelBase
    {
        public const string XmlName = "MedcinTerm"; // used by MedcinData for xml reading methods

        public const string KeyToolTip = "Represents a unique key for this term.";
        public const string MedcinCodeToolTip = "Represents the Medcin code associated with a term.";
        public const string PrefixToolTip = "(Optional) Used to differentiate several terms with the same Medcin code.";
        public const string DefaultLabelToolTip = "The term as represented by AHLTA.";
        public const string UserLabelToolTip = "(Optional) Alternate label displayed in the ITG application for when a code is not used for its original intent.";
        public const string CategoryToolTip = "The section of the note the finding will print in.";
        public const string StateOneTextToolTip = "The text displayed when the first state is checked (usually \"positive\" or \"abnormal\") and no custom text is supplied by the user.";
        public const string StateTwoTextToolTip = "The text displayed when the second state is checked (usually \"negative\" or \"normal\") and no custom text is supplied by the user.";
        public const string StateOneIsPositiveFindingToolTip = "(Default behavior) The first state represents the positive/abnormal finding. Uncheck this to invert the behavior.";


        #region Constructors

        // Default constructor
        public MedcinTerm()
        {
            medcinCode = 0;
            prefix = "";
            defaultLabel = "";
            userLabel = "";
            category = Category.CC;
            stateOneText = "";
            stateTwoText = "";
            stateOneIsPositiveFinding = true;
        }

        // Xml deserialization constructor
        public MedcinTerm(XmlReader r)
        {
            ReadXml(r); // populates properties with values from XML file
        }

        #endregion


        #region Properties

        private int medcinCode;
        public int MedcinCode
        {
            get { return medcinCode; }
            set
            {
                if (medcinCode != value)
                {
                    medcinCode = value;
                    NotifyPropertyChanged("MedcinCode");
                    NotifyPropertyChanged("Key");
                }
            }
        }

        private string prefix;
        public string Prefix
        {
            get { return prefix; }
            set
            {
                if (prefix != value)
                {
                    prefix = value;
                    NotifyPropertyChanged("Prefix");
                    NotifyPropertyChanged("Key");
                }
            }
        }

        private string defaultLabel;
        public string DefaultLabel
        {
            get { return defaultLabel; }
            set
            {
                if (defaultLabel != value)
                {
                    defaultLabel = value;
                    NotifyPropertyChanged("DefaultLabel");
                }
            }
        }

        private string userLabel;
        public string UserLabel
        {
            get { return userLabel; }
            set
            {
                if (userLabel != value)
                {
                    userLabel = value;
                    NotifyPropertyChanged("UserLabel");
                }
            }
        }

        private Common.Category category;
        public Common.Category Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    NotifyPropertyChanged("Category");
                }
            }
        }

        private string stateOneText;
        public string StateOneText
        {
            get { return stateOneText; }
            set
            {
                if (stateOneText != value)
                {
                    stateOneText = value;
                    NotifyPropertyChanged("StateOneText");
                }
            }
        }

        private string stateTwoText;
        public string StateTwoText
        {
            get { return stateTwoText; }
            set
            {
                if (stateTwoText != value)
                {
                    stateTwoText = value;
                    NotifyPropertyChanged("StateTwoText");
                }
            }
        }

        private bool stateOneIsPositiveFinding;
        public bool StateOneIsPositiveFinding
        {
            get { return stateOneIsPositiveFinding; }
            set
            {
                if (stateOneIsPositiveFinding != value)
                {
                    stateOneIsPositiveFinding = value;
                    NotifyPropertyChanged("StateOneIsPositiveFinding");
                }
            }
        }

        public string Key
        {
            get { return MedcinCode + Prefix; }
        }

        #endregion


        #region Methods

        // deserializes object from xml; reads the outer element AND inner content
        public void ReadXml(XmlReader r)
        {
            /* XmlReader throws XmlException if any validation fails.
             * XmlExemption has LineNumber and LinePosition properties to indicate 
             * where the error occurred - worth catching and logging?
             */
            r.ReadStartElement();

            MedcinCode = r.ReadElementContentAsInt("MedcinCode", "");
            Prefix = r.ReadElementContentAsString("Prefix", "");
            DefaultLabel = r.ReadElementContentAsString("DefaultLabel", "");
            UserLabel = r.ReadElementContentAsString("UserLabel", "");

            // Parse category from string to enum
            string cat = r.ReadElementContentAsString("Category", "");
            Category = MedcinValidation.ParseToEnum<Common.Category>(cat);

            StateOneText = r.ReadElementContentAsString("StateOneText", "");
            StateTwoText = r.ReadElementContentAsString("StateTwoText", "");

            // XmlReader requires value to be all lowercase for conversion
            StateOneIsPositiveFinding = r.ReadElementContentAsBoolean("StateOneIsPositiveFinding", "");

            r.ReadEndElement();
        }

        // serializes object to xml; writes ONLY the inner content
        public void WriteXml(XmlWriter w)
        {
            w.WriteElementString("MedcinCode", MedcinCode.ToString());
            w.WriteElementString("Prefix", Prefix);
            w.WriteElementString("DefaultLabel", DefaultLabel);
            w.WriteElementString("UserLabel", UserLabel);
            w.WriteElementString("Category", Category.ToString());
            w.WriteElementString("StateOneText", StateOneText);
            w.WriteElementString("StateTwoText", StateTwoText);
            // boolean needs to be all lowercase for xmlreader to parse it correctly
            w.WriteElementString("StateOneIsPositiveFinding", StateOneIsPositiveFinding.ToString().ToLower());
        }


        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(UserLabel))
                return Key + " (" + DefaultLabel + ")";
            else
                return Key + " (" + UserLabel + ")";
        }

        #endregion


        #region BINARY SERIALIZATION
        /*
        // Binary deserialization constructor
        public MedcinTerm(SerializationInfo info, StreamingContext ctxt)
        {
            MedcinCode = (int)info.GetValue("MedcinCode", typeof(int));
            Prefix = (string)info.GetValue("Prefix", typeof(string));
            DefaultLabel = (string)info.GetValue("DefaultLabel", typeof(string));
            UserLabel = (string)info.GetValue("UserLabel", typeof(string));
            //Category = (string)info.GetValue("Category", typeof(string));
            Category = (Category)info.GetValue("Category", typeof(Category)); // no idea if this will work
            StateOneText = (string)info.GetValue("StateOneText", typeof(string));
            StateTwoText = (string)info.GetValue("StateTwoText", typeof(string));
            StateOneIsPositiveFinding = (bool)info.GetValue("StateOneIsPositiveFinding", typeof(bool));
        }
        

        // Binary serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MedcinCode", MedcinCode);
            info.AddValue("Prefix", Prefix);
            info.AddValue("DefaultLabel", DefaultLabel);
            info.AddValue("UserLabel", UserLabel);
            info.AddValue("Category", Category);
            info.AddValue("StateOneText", StateOneText);
            info.AddValue("StateTwoText", StateTwoText);
            info.AddValue("StateOneIsPositiveFinding", StateOneIsPositiveFinding);
        }
        */
        #endregion

    }
}
