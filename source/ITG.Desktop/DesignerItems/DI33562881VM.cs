using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.Desktop.DesignerItems
{
    public class DI33562881VM : MedcinItemBase
    {
        // " |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||"
        private string[] defaultPrefix = {" ", "", "", "", "", "", "",
                                          "19", "80", "YCN", "0", "0", "X", "X",
                                          "0", "", "", "0", "0", "0", "0", 
                                          "0", "0", "", "", ""};

        public DI33562881VM()
            : base()
        {
            Init();
        }

        private void Init()
        {
            SetControlDefaults("33562881", 33562881, "Checkbox with label and singleline textbox");
            SetSizeConstraints(200, 60, 2000, 20, 20, 20);
            //ToolBoxImageUrl = "Resources/ToolBoxImages/DI4202753_TBI.png";
            D_Caption = "Caption";
            SetPrefix(defaultPrefix);
        }
    }
}
