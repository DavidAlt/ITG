
namespace DALT.ITG.Models
{
    //<Category("ItemData"), Description("Specifies a unique numeric ID for this object; N=<Integer>")>
    public class ObjectIdOption : ItemDataIntOption
    {
        public ObjectIdOption(int value)
            : base(value)
        {
            _name = "ObjectId";
            _code = "N";
        }
    }

    //<Category("ItemData"), Description("Specifies the font used for the object's caption; F=<FontName As String>")>
    public class FontOption : ItemDataStringOption
    {
        public FontOption(string value)
            : base(value)
        {
            _name = "Font";
            _code = "F";
        }
    }

    //<Category("ItemData"), Description("Specifies whether the object's caption is BOLD; B=<T,F>")>
    public class BoldOption : ItemDataBoolOption
    {
        public BoldOption(bool value)
            : base(value)
        {
            _name = "Bold";
            _code = "B";
        }
    }

    //<Category("ItemData"), Description("Specifies whether the object's caption is ITALICIZED; I=<T,F>")>
    public class ItalicOption : ItemDataBoolOption
    {
        public ItalicOption(bool value)
            : base(value)
        {
            _name = "Italic";
            _code = "I";
        }
    }

    //<Category("ItemData"), Description("Specifies whether the object's caption is UNDERLINED; U=<T,F>")>
    public class UnderlineOption : ItemDataBoolOption
    {
        public UnderlineOption(bool value)
            : base(value)
        {
            _name = "Underline";
            _code = "U";
        }
    }

    //<Category("ItemData"), Description("Specifies the forecolor of the object; C=<AHLTAColor As Integer>")>
    public class ForeColorOption : ItemDataIntOption
    {
        public ForeColorOption(int value)
            : base(value)
        {
            _name = "ForeColor";
            _code = "C";
        }
    }

    //<Category("ItemData"), Description("Specifies the backcolor of the object; K=<AHLTAColor As Integer>")>
    public class BackColorOption : ItemDataIntOption
    {
        public BackColorOption(int value)
            : base(value)
        {
            _name = "BackColor";
            _code = "K";
        }
    }

    //<Category("ItemData"), Description("Specifies the BackStyle of an object, where 0 = transparent and 1 = opaque; T=<0,1>")>
    public class BackStyleOption : ItemDataIntOption
    {
        public BackStyleOption(int value)
            : base(value)
        {
            _name = "BackStyle";
            _code = "T";
        }
    }

    //<Category("ItemData"), Description("Specifies the BorderStyle of an object; S=<0,1>")>
    public class BorderStyleOption : ItemDataIntOption
    {
        public BorderStyleOption(int value)
            : base(value)
        {
            _name = "BorderStyle";
            _code = "S";
        }
    }

    //<Category("ItemData"), Description("Specifies the draw width of a Drawing object; W=<?>")>
    public class DrawWidthOption : ItemDataIntOption
    {
        public DrawWidthOption(int value)
            : base(value)
        {
            _name = "DrawWidth";
            _code = "W";
        }
    }

    //<Category("ItemData"), Description("Specifies the composite image marker style; M=<Integer>")>
    public class ImageMarkerStyleOption : ItemDataIntOption
    {
        public ImageMarkerStyleOption(int value)
            : base(value)
        {
            _name = "ImageMarkerStyle";
            _code = "M";
        }
    }

    //<Category("ItemData"), Description("Specifies the comma-delimited list of chart column item enum values for listview associated with Medcin or Picklist objects; G=<?>")>
    public class ListviewColumnItemsOption : ItemDataStringOption
    {
        public ListviewColumnItemsOption(string value)
            : base(value)
        {
            _name = "ListviewColumnItems";
            _code = "G";
        }
    }

    //<Category("ItemData"), Description("Specifies the logic equation or other list, if any, and is always last. It may contain a list of Medcinids for use with an internal drop list pick list. It may contain a list of ImageIDs for use with an imager control object; L=<?>")>
    public class LogicOption : ItemDataStringOption
    {
        public LogicOption(string value)
            : base(value)
        {
            _name = "Logic";
            _code = "L";
        }
    }

    //<Category("ItemData"), Description("Represents the combined flag values for the options; O=<Integer>")>
    public class OptionsOption : ItemDataIntOption
    {
        public OptionsOption(int value)
            : base(value)
        {
            _name = "Options";
            _code = "O";
        }
    }

    //<Category("ItemData"), Description("Specifies the tooltip for objects with captions; P=<String>")>
    public class TooltipOption : ItemDataStringOption
    {
        public TooltipOption(string value)
            : base(value)
        {
            _name = "Tooltip";
            _code = "P";
        }
    }

    //<Category("ItemData"), Description("Specifies the availability of intelligent prompting for a Tree object; I=<?>")>
    public class TreeIntelligentPromptingOption : ItemDataBoolOption
    {
        public TreeIntelligentPromptingOption(bool value)
            : base(value)
        {
            _name = "TreeIntelligentPrompting";
            _code = "I";
        }
    }

    //<Category("ItemData"), Description("Specifies the availability of mouse browsing for a Tree object; B=<?>")>
    public class TreeMouseBrowsingOption : ItemDataBoolOption
    {
        public TreeMouseBrowsingOption(bool value)
            : base(value)
        {
            _name = "TreeMouseBrowsing";
            _code = "B";
        }
    }

    //<Category("ItemData"), Description("Specifies the availability of word search for a Tree object; S=<?>")>
    public class TreeWordSearchOption : ItemDataBoolOption
    {
        public TreeWordSearchOption(bool value)
            : base(value)
        {
            _name = "TreeWordSearch";
            _code = "S";
        }
    }

    //<Category("ItemData"), Description("Specifies the ValueBoxChars enum value designating restrictions on what type of characters are allowed in a value box: 0=AllowAll, 1=AllowNumbers, 2=AllowLetters; V=<0,1,2>")>
    public class ValueBoxCharsOption : ItemDataStringOption
    {
        public ValueBoxCharsOption(string value)
            : base(value)
        {
            _name = "ValueBoxChars";
            _code = "V";
        }
    }

    //<Category("ItemData"), Description("Specifies the appearance of checkboxes; Y=<0,1,2,4,5,6>")>
    public class YesNoStyleOption : ItemDataIntOption
    {
        public YesNoStyleOption(int value)
            : base(value)
        {
            _name = "YesNoStyle";
            _code = "Y";
        }
    }

    //<Category("ItemData"), Description("Specifies the RibbonID; G=<RibbonID As Integer>")>
    public class RibbonIdOption : ItemDataIntOption
    {
        public RibbonIdOption(int value)
            : base(value)
        {
            _name = "RibbonId";
            _code = "G";
        }
    }

    //<Category("ItemData"), Description("Specifies the top offset of a Ribbon object; Y=<Integer>")>
    public class RibbonTopOffsetOption : ItemDataIntOption
    {
        public RibbonTopOffsetOption(int value)
            : base(value)
        {
            _name = "RibbonTopOffset";
            _code = "Y";
        }
    }

    //<Category("ItemData"), Description("Specifies the bottom of a Ribbon object; B=<Integer>")>
    public class RibbonBottomOffsetOption : ItemDataIntOption
    {
        public RibbonBottomOffsetOption(int value)
            : base(value)
        {
            _name = "RibbonBottomOffset";
            _code = "B";
        }
    }

    //<Category("ItemData"), Description("Specifies the left edge of a Ribbon object; T=<Integer>")>
    public class RibbonLeftOffsetOption : ItemDataIntOption
    {
        public RibbonLeftOffsetOption(int value)
            : base(value)
        {
            _name = "RibbonLeftOffset";
            _code = "T";
        }
    }

    //<Category("ItemData"), Description("Specifies the right edge of a Ribbon object; R=<Integer>")>
    public class RibbonRightOffsetOption : ItemDataIntOption
    {
        public RibbonRightOffsetOption(int value)
            : base(value)
        {
            _name = "RibbonRightOffset";
            _code = "R";
        }
    }

    //<Category("ItemData"), Description("(Specifies a chapter assignment for a Ribbon object; H=<?>")>
    public class RibbonChapterAssignmentOption : ItemDataIntOption
    {
        public RibbonChapterAssignmentOption(int value)
            : base(value)
        {
            _name = "RibbonChapterAssignment";
            _code = "H";
        }
    }

    //<Category("ItemData"), Description("Specifies the collapse offset of a Ribbon object; C=<Integer>")>
    public class RibbonCollapseOffsetOption : ItemDataIntOption
    {
        public RibbonCollapseOffsetOption(int value)
            : base(value)
        {
            _name = "RibbonCollapseOffset";
            _code = "C";
        }
    }

    //<Category("ItemData"), Description("Specifies the ColumnSpan property of a Ribbon object; S=<?>")>
    public class RibbonColumnSpanOption : ItemDataIntOption
    {
        public RibbonColumnSpanOption(int value)
            : base(value)
        {
            _name = "RibbonColumnSpan";
            _code = "S";
        }
    }

    //<Category("ItemData"), Description("Specifies the parent frame associated with a Grid object; A=<?>")>
    public class GridParentFrameOption : ItemDataIntOption
    {
        public GridParentFrameOption(int value)
            : base(value)
        {
            _name = "GridParentFrame";
            _code = "A";
        }
    }

    //<Category("ItemData"), Description("Specifies the parent ribbon of a Grid object; P=<RibbonID As Integer>")>
    public class GridParentRibbonOption : ItemDataIntOption
    {
        public GridParentRibbonOption(int value)
            : base(value)
        {
            _name = "GridParentRibbon";
            _code = "P";
        }
    }

    //<Category("ItemData"), Description("Specifies the back color of a Grid object's even rows; E=<AHLTAColor As Integer>")>
    public class GridEvenRowBackColorOption : ItemDataIntOption
    {
        public GridEvenRowBackColorOption(int value)
            : base(value)
        {
            _name = "GridEvenRowBackColor";
            _code = "E";
        }
    }

    //<Category("ItemData"), Description("Specifies the back color of a Grid object's odd rows; O=<AHLTAColor As Integer>")>
    public class GridOddRowBackColorOption : ItemDataIntOption
    {
        public GridOddRowBackColorOption(int value)
            : base(value)
        {
            _name = "GridOddRowBackColor";
            _code = "O";
        }
    }

    //<Category("ItemData"), Description("Specifies the row interval of a Grid object; R=<?>")>
    public class GridRowIntervalOption : ItemDataIntOption
    {
        public GridRowIntervalOption(int value)
            : base(value)
        {
            _name = "GridRowInterval";
            _code = "R";
        }
    }

    //<Category("ItemData"), Description("Indicates whether a Frame object is DrawOnly; T=<?>")>
    public class FrameDrawOnlyOption : ItemDataBoolOption
    {
        public FrameDrawOnlyOption(bool value)
            : base(value)
        {
            _name = "FrameDrawOnly";
            _code = "T";
        }
    }

    //<Category("ItemData"), Description("(Specifies a chapter assignment for a Frame object; H=<?>")>
    public class FrameChapterAssignmentOption : ItemDataIntOption
    {
        public FrameChapterAssignmentOption(int value)
            : base(value)
        {
            _name = "FrameChapterAssignment";
            _code = "H"; // verify
        }
    }
      
     
}
