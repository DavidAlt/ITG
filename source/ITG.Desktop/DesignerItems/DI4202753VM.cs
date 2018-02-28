using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Desktop.DesignerItems
{
    public class DI4202753VM : MedcinItemBase
    {
        // " |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||"
        private string[] defaultPrefix = {" ", "", "", "", "", "", "",
                                          "19", "80", "YCN", "0", "0", "X", "X",
                                          "0", "", "", "0", "0", "0", "0", 
                                          "0", "0", "", "", ""};

        public DI4202753VM() : base()
        {
            Init();
        }

        private void Init()
        {
            SetControlDefaults("4202753", 4202753, "Checkbox with label and multiline textbox");
            SetSizeConstraints(200, 60, 2000, 60, 40, 2000);
            //ToolBoxImageUrl = "Resources/ToolBoxImages/DI4202753_TBI.png";
            D_Caption = "Caption";
            isMedcinItem = true;
            SetPrefix(defaultPrefix);
        }
    }
}
