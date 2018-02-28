using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITG.Desktop.Designer;
using System.Reflection;

namespace ITG.Desktop.DesignerItems
{
    public class GridVM : DesignerItemBaseVM
    {

        public GridVM()
            : base()
        {
            Init();
        }

        private void Init()
        {
            SetControlDefaults("Grid", 8, "Grid");
            SetSizeConstraints(500, 4, 1000, 31, 4, 1000);
            //ToolBoxImageUrl = "Resources/ToolBoxImages/Ribbon_TBI.png";

        }

        //<Category("ItemData"), Description("Specifies the parent frame associated with a Grid object; A=<?>")>
        //Public Property ID_GridParentFrame() As String = "" 'A=
        public string ID_GridParentFrame { get; set; }

        //<Category("ItemData"), Description("Specifies the parent ribbon of a Grid object; P=<RibbonID As Integer>")>
        //Public Property ID_GridParentRibbon() As String = "" 'P=
        public string ID_GridParentRibbon { get; set; }

        //<Category("ItemData"), Description("Specifies the back color of a Grid object's even rows; E=<AHLTAColor As Integer>")>
        //Public Property ID_GridEvenRowBackColor() As String = "" 'E=
        public int ID_GridEvenRowBackColor { get; set; }

        //<Category("ItemData"), Description("Specifies the back color of a Grid object's odd rows; O=<AHLTAColor As Integer>")>
        //Public Property ID_GridOddRowBackColor() As String = "" 'O=
        public int ID_GridOddRowBackColor { get; set; }

        //<Category("ItemData"), Description("Specifies the row interval of a Grid object; R=<?>")>
        //Public Property ID_GridRowInterval() As String = "" 'R=
        public string ID_GridRowInterval { get; set; }
    }
}