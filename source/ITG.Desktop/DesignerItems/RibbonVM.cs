using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITG.Desktop.Designer;
using System.Reflection;

namespace ITG.Desktop.DesignerItems
{
    public class RibbonVM : DesignerItemBaseVM
    {
        public RibbonVM()
            : base()
        {
            SetControlDefaults("Ribbon", 16, "Expanding ribbon");
            SetSizeConstraints(500, 100, 1000, 31, 20, 1000);
        }

        //<Category("ItemData"), Description("Specifies the RibbonID; G=<RibbonID As Integer>")>
        //Public Property ID_RibbonID() As String = "" 'G=
        protected string id_RibbonId = "";
        public string ID_RibbonId { get; set; }

        //<Category("ItemData"), Description("Specifies the top offset of a Ribbon object; Y=<Integer>")>
        //Public Property ID_RibbonTop() As String = "" 'Y=
        protected string id_RibbonTopOffset = "2";
        public string ID_RibbonTopOffset { get; set; }

        //<Category("ItemData"), Description("Specifies the bottom of a Ribbon object; B=<Integer>")>
        //Public Property ID_RibbonBottom() As String = "" 'B=
        protected string id_RibbonBottomOffset = "";
        public string ID_RibbonBottomOffset { get; set; }

        //<Category("ItemData"), Description("Specifies the left edge of a Ribbon object; T=<Integer>")>
        //Public Property ID_RibbonLeft() As String = "" 'T=
        protected string id_RibbonLeftOffset = "5";
        public string ID_RibbonLeftOffset { get; set; }

        //<Category("ItemData"), Description("Specifies the right edge of a Ribbon object; R=<Integer>")>
        //Public Property ID_RibbonRight() As String = "" 'R=
        protected string id_RibbonRightOffset = "";
        public string ID_RibbonRightOffset { get; set; }

        //<Category("ItemData"), Description("(Specifies a chapter assignment for a Ribbon or Frame object; H=<?>")>
        //Public Property ID_ChapterAssignment() As String = "" 'H=
        protected string id_RibbonChapterAssignment = "";
        public string ID_RibbonChapterAssignment { get; set; }

        //<Category("ItemData"), Description("Specifies the collapse offset of a Ribbon object; C=<Integer>")>
        //Public Property ID_RibbonCollapseOffset() As String = "" 'C=
        protected string id_RibbonCollapseOffset = "2";
        public string ID_RibbonCollapseOffset { get; set; }

        //<Category("ItemData"), Description("Specifies the ColumnSpan property of a Ribbon object; S=<?>")>
        //Public Property ID_RibbonColumnSpan() As String = "" 'S=
        protected string id_RibbonColumnSpan = "";
        public string ID_RibbonColumnSpan { get; set; }
    }
}

/*
<FlagsAttribute>
    Enum RibbonOption
        fc_EXPAND_ON_YES = 1
        fc_COLLAPSE_ON_NO = 2
        fc_HIDE_ON_COLLAPSE = 4
        fc_SHOW_BUTTON = 8
        fc_EXPAND_ON_NO = 16
        fc_COLLAPSE_ON_YES = 32
    End Enum
*/