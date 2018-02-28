using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlacialSystems.ITG
{
    // Responsible for internal list management and XML I/O operations
    public class MedcinViewModel
    {
        // PROPERTIES
        public BindingList<MedcinObject> MedcinObjects { get; private set; }

        // CONSTRUCTOR
        public MedcinViewModel()
        {
            MedcinObjects = new BindingList<MedcinObject>();
        }
    }
}
