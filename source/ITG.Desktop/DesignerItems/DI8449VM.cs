using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITG.Desktop.Designer;
using System.Reflection;

namespace ITG.Desktop.DesignerItems
{
    public class DI8449VM : MedcinItemBase
    {
        //" |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||"
        private string[] defaultPrefix = {" ", "", "", "", "", "", "",
                                          "19", "80", "YCN", "0", "0", "X", "X",
                                          "0", "", "", "0", "0", "0", "0", 
                                          "0", "0", "", "", ""};

        public DI8449VM()
            : base()
        {
            Init();
        }

        private void Init()
        {
            SetControlDefaults("8449", 8449, "Checkbox with label and 'More Text' button");
            SetSizeConstraints(100, 15, 2000, 20, 20, 20);
            //ToolBoxImageUrl = "Resources/ToolBoxImages/DI8449_TBI.png";
            D_Caption = "Caption";
            //SetPrefix(defaultPrefix);
        }

    }
}
