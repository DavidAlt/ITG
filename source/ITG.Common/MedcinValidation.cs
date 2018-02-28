using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Common
{
    public static class MedcinValidation
    {
        // Parses a string to an enum
        // Ex:
        //   var categoryAsString = "HPI";
        //   Medcin.Category cat = MedcinValidation.ParseToEnum<Medcin.Category>(categoryAsString);
        public static T ParseToEnum<T>(string value)
        {
            // no error checking implemented!
            return (T)Enum.Parse(typeof(T), value);
        }

    }
}
