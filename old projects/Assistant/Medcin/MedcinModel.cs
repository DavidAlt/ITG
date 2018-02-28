using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlacialSystems.ITG
{
    
    public class MedcinObject
    {
        // PROPERTIES
        public int MedcinID { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int TreeDepth { get; set; }
        public string StateOneText { get; set; }
        public string StateTwoText { get; set; }
        public bool StateOneIsAbnormal { get; set; } // if not, then StateTwo is abnormal
        public bool CustomTextReplacesDefault { get; set; }

        // CONSTRUCTOR
        public MedcinObject()
        {
            this.MedcinID = 0;
            this.Prefix = "";
            this.Name = "";
            this.Category = "";
            this.TreeDepth = 1;
            this.StateOneText = "";
            this.StateTwoText = "";
            this.StateOneIsAbnormal = true;
            this.CustomTextReplacesDefault = false;
        }

        public string UID()
        {
            string value = "";

            if (MedcinID.ToString().Equals("") | MedcinID == 0 | Prefix == null)
            {
                value = "Invalid UID - at least one component is null";
            }
            else if (MedcinID == 0)
            {
                value = "Invalid UID - MedcinID is 0";
            }
            else
            {
                value = MedcinID.ToString() + Prefix;
            }
            return value;
        }

        public override string ToString()
        {
            return (UID() + ": " + Name);
        }
    }
}
