using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Desktop.DesignerItems
{
    public class MedcinItemBase : DesignerItemBaseVM
    {
        // anything deriving from this class MUST have a non-zero MedcinId
        // in order to be valid in AHLTA

        public MedcinItemBase()
            : base()
        {
            // set some defaults for properties that are common to MedcinItems
            PF_BoxOffset = 19;
            PF_InlineTextboxWidth = 80;
            PF_ComponentSequence = "YCN";
            PF_CHKYCaption = "X";
            PF_CHKNCaption = "X";
        }
    }
}

/*
<FlagsAttribute>
    Enum MedcinOption
        None = 0
        fc_HAS_BEEN_EDITED = 1
        fc_DISABLE_MOUSE_BROWSING = 2
        fc_DISABLE_CLUSTER_ON_Y = 8
        fc_DISABLE_CLUSTER_ON_N = 16
        fc_DESIGNER_INVERTED_CONCEPT = 256
    End Enum
*/