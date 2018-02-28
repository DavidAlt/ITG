using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITG.Desktop.Designer;
using System.Reflection;

namespace ITG.Desktop.DesignerItems
{
    public class FrameVM : DesignerItemBaseVM
    {
        //" |||||||0|0||0|0|||0|||0|0|0|0|0|0|||"
        private string[] defaultPrefix = {" ", "", "", "", "", "", "",
                                          "0", "0", "", "0", "0", "", "",
                                          "0", "", "", "0", "0", "0", "0", 
                                          "0", "0", "", "", ""};

        public FrameVM() : base()
        {
            Init();
        }

        private void Init()
        {
            SetControlDefaults("Frame", 2, "Frame");
            SetSizeConstraints(100, 4, 1000, 50, 4, 1000);
            //ToolBoxImageUrl = "Resources/ToolBoxImages/Frame_TBI.png";
            SetPrefix(defaultPrefix);
        }


        //<Category("ItemData"), Description("Indicates whether a Frame object is DrawOnly; T=<?>")>
        //Public Property ID_FrameDrawOnly() As String = "" 'T=
        public string ID_FrameDrawOnly { get; set; }

        public string ID_FrameChapterAssignment { get; set; }
    }
}
