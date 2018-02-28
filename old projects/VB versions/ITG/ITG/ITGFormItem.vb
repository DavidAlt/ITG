Imports System.Text, System.ComponentModel
Imports ITG.ITGConstants

<DefaultProperty("MedcinID")>
Public Class ITGFormItem

#Region "Author Notes"
    ' This might need to implement IEnumerable or something
#End Region

#Region "Enums and Flags"

    Enum Prefix As Integer
        Prefix = 0
        Modifier = 1
        Result = 2
        Status = 3
        Value = 4
        LinkGroup = 5
        Units = 6
        BoxOffset = 7
        InlineTextboxWidth = 8
        ComponentSequence = 9
        IndexToReferenceList = 10
        NarrativeGroupAssignment = 11
        CHKYCaption = 12
        CHKNCaption = 13
        BitFlags = 14
        LimitMax = 15
        LimitMin = 16
        RibbonTriggerID = 17
        ClusterID = 18
        ParentRibbonID = 19
        RadioButtonGroup = 20
        ImageID = 21
        HotSpotSetID = 22
        ParentFrame = 23
        CodeMapping = 24
        UserAssignedSubgroup = 25
    End Enum

    <FlagsAttribute>
    Enum MedcinOption
        None = 0
        fc_HAS_BEEN_EDITED = 1
        fc_DISABLE_MOUSE_BROWSING = 2
        fc_DISABLE_CLUSTER_ON_Y = 8
        fc_DISABLE_CLUSTER_ON_N = 16
        fc_DESIGNER_INVERTED_CONCEPT = 256
    End Enum

    <FlagsAttribute>
    Enum LinkOption
        fc_FIRE_WHEN_LOGIC_TRUE = 1
        fc_RAISE_MESSAGE_WHEN_LOGIC_TRUE = 2
        fc_IS_USER_BUTTON = 4
        fc_IS_AUTONEG_BUTTON = 8
        fc_IS_AUTOPOS_BUTTON = 16
        fc_IS_NEGBLOCK_BUTTON = 32
        fc_IS_POSBLOCK_BUTTON = 64
        fc_IS_FLOWSHEET_BUTTON = 128
        fc_IS_REFERENCE_BUTTON = 256
    End Enum

    <FlagsAttribute>
    Enum RibbonOption
        fc_EXPAND_ON_YES = 1
        fc_COLLAPSE_ON_NO = 2
        fc_HIDE_ON_COLLAPSE = 4
        fc_SHOW_BUTTON = 8
        fc_EXPAND_ON_NO = 16
        fc_COLLAPSE_ON_YES = 32
    End Enum

    <FlagsAttribute>
    Enum PictureOption
        fc_IS_IMAGER_COMPONENT = 2
        fc_SET_POSITIVE_ON_CLICK = 4
        fc_SET_NEGATIVE_ON_CLICK = 8
        fc_SET_PREFIX_ON_CLICK = 16
        fc_SET_VALUE_ON_CLICK = 32
    End Enum

    <FlagsAttribute>
    Enum ListOption
        fc_LIST_ALLOW_NODE_EXPANSION = 2
        fc_LIST_LOGIC = 4 ' disabled=0, enabled=1
        fc_LIST_DISABLE_UNTIL_LOGIC_TRUE = 8
        fc_LIST_ACTIVATE_WHEN_LOGIC_TRUE = 16
        fc_TREEVIEW_RELOCATE_ORIGIN_RELATIVE_OBJECT = 32
        fc_LIST_SORT_INLINE_CAPTIONS = 64
        fc_LISTVIEW_USE_COLOR = 128
        fc_LISTVIEW_AUTO_RESIZE_COLUMNS = 256
    End Enum

    

#End Region

#Region "Properties"
#Region "Location Properties"
    <Category("Location"), Description("")>
    Public Property Tab() As Integer
    <Category("Location"), Description("")>
    Public Property Left() As Integer
    <Category("Location"), Description("")>
    Public Property Top() As Integer
    <Category("Location"), Description("")>
    Public Property Right() As Integer
    <Category("Location"), Description("")>
    Public Property Bottom() As Integer
#End Region

#Region "Other Properties"
    Public Property MedcinID() As Integer = 0
    Public Property ControlType() As ITGComponent
#End Region

#Region "Prefix Properties"
    <Category("Prefix"), Description("(Unknown) Possibly affects placement in note, to differentiate several objects with identical MedcinIDs")>
    Public Property PF_Prefix() As String = "" '0
    ' public string PF_Prefix { get; set; }

    <Category("Prefix"), Description("(Unknown) Possibly enum values - used for wellness levels EX, GD, FR, PR, etc")>
    Public Property PF_Modifier() As String = "" '1

    <Category("Prefix"), Description("(Unknown)")>
    Public Property PF_Result() As String = "" '2

    <Category("Prefix"), Description("(Unknown)")>
    Public Property PF_Status() As String = "" '3

    <Category("Prefix"), Description("(Unknown)")>
    Public Property PF_Value() As String = "" '4

    <Category("Prefix"), Description("Specifies the object's relative value/order within a linked group, such as radiobuttons (0..5)")>
    Public Property PF_LinkGroup() As String = "" '5

    <Category("Prefix"), Description("Units associated with the control's data, such as cm, days, etc")>
    Public Property PF_Units() As String = "" '6

    <Category("Prefix"), Description("(Unknown) Possibly the height of the control? Tends to be 19 in most cases")>
    Public Property PF_BoxOffset() As String = "19" '7

    <Category("Prefix"), Description("Width of an inline textbox component, as measured in pixels from right to left")>
    Public Property PF_InlineTextboxWidth() As String = "80" '8

    <Category("Prefix"), Description("Helps determine the order of the components (ex: YCN)")>
    Public Property PF_ComponentSequence() As String = "YCN" '9

    <Category("Prefix"), Description("Used to reference a URL object; use 0 for null")>
    Public Property PF_IndexToReferenceList() As String = "0" '10

    <Category("Prefix"), Description("(Unknown) 0 seems to be the default value")>
    Public Property PF_NarrativeGroupAssignemnt() As String = "0" '11

    <Category("Prefix"), Description("The character assigned to the first checkbox component")>
    Public Property PF_CHKYCaption() As String = "Y" '12

    <Category("Prefix"), Description("The character assigned to the second checkbox component (if any)")>
    Public Property PF_CHKNCaption() As String = "N" '13

    <Category("Prefix"), Description("Bits 0-1: automatic browse; Bit 2: disable HPI-ROS toggle; Bit 3: disable gender check; Bit 4: ValueSum")>
    Public Property PF_BitFlags() As String = "" '14

    <Category("Prefix"), Description("Maximum allowed value")>
    Public Property PF_LimitMax() As String = "" '15

    <Category("Prefix"), Description("Minimum allowed value")>
    Public Property PF_LimitMin() As String = "" '16

    <Category("Prefix"), Description("Specifies the ribbon to expand when this object is activated")>
    Public Property PF_RibbonTriggerID() As String = "" '17

    <Category("Prefix"), Description("Specifies the cluster that this object belongs to")>
    Public Property PF_ClusterID() As String = "" '18

    <Category("Prefix"), Description("Specifies the ribbon that this object belongs to")>
    Public Property PF_ParentRibbonID() As String = "" '19

    <Category("Prefix"), Description("Specifies the radio button group that this object belongs to")>
    Public Property PF_RadioButtonGroup() As String = "" '20

    <Category("Prefix"), Description("(Unknown)")>
    Public Property PF_ImageID() As String = "" '21

    <Category("Prefix"), Description("(Unknown)")>
    Public Property PF_HotSpotSetID() As String = "" '22

    <Category("Prefix"), Description("Specifies the parent frame for all objects other than boxes and grids")>
    Public Property PF_ParentFrame() As String = "" '23

    <Category("Prefix"), Description("(Unknown)")>
    Public Property PF_CodeMapping() As String = "" '24

    <Category("Prefix"), Description("(Unknown)")>
    Public Property PF_UserAssignedSubgroup() As String = "" '25
#End Region

#Region "ItemData Properties"
    <Category("ItemData"), Description("Specifies the parent frame associated with a Grid object; A=<?>")>
    Public Property ID_GridParentFrame() As String = "" 'A=

    <Category("ItemData"), Description("Specifies the parent ribbon of a Grid object; P=<RibbonID As Integer>")>
    Public Property ID_GridParentRibbon() As String = "" 'P=

    <Category("ItemData"), Description("Specifies the back color of a Grid object's even rows; E=<AHLTAColor As Integer>")>
    Public Property ID_GridEvenRowBackColor() As String = "" 'E=

    <Category("ItemData"), Description("Specifies the back color of a Grid object's odd rows; O=<AHLTAColor As Integer>")>
    Public Property ID_GridOddRowBackColor() As String = "" 'O=

    <Category("ItemData"), Description("Specifies the row interval of a Grid object; R=<?>")>
    Public Property ID_GridRowInterval() As String = "" 'R=

    <Category("ItemData"), Description("Specifies the font used for the object's caption; F=<FontName As String>")>
    Public Property ID_FontName() As String = "" 'F=

    <Category("ItemData"), Description("Specifies whether the object's caption is BOLD; B=<T,F>")>
    Public Property ID_Bold() As String = "" 'B=

    <Category("ItemData"), Description("Specifies whether the object's caption is ITALICIZED; I=<T,F>")>
    Public Property ID_Italic() As String = "" 'I=

    <Category("ItemData"), Description("Specifies whether the object's caption is UNDERLINED; U=<T,F>")>
    Public Property ID_Underline() As String = "" 'U=

    <Category("ItemData"), Description("Specifies the forecolor of the object; C=<AHLTAColor As Integer>")>
    Public Property ID_ForeColor() As String = "" 'C=

    <Category("ItemData"), Description("Specifies the backcolor of the object; K=<AHLTAColor As Integer>")>
    Public Property ID_BackColor() As String = "" 'K=

    <Category("ItemData"), Description("Specifies the RibbonID; G=<RibbonID As Integer>")>
    Public Property ID_RibbonID() As String = "" 'G=

    <Category("ItemData"), Description("Specifies the top offset of a Ribbon object; Y=<Integer>")>
    Public Property ID_RibbonTop() As String = "" 'Y=

    <Category("ItemData"), Description("Specifies the bottom of a Ribbon object; B=<Integer>")>
    Public Property ID_RibbonBottom() As String = "" 'B=

    <Category("ItemData"), Description("Specifies the left edge of a Ribbon object; T=<Integer>")>
    Public Property ID_RibbonLeft() As String = "" 'T=

    <Category("ItemData"), Description("Specifies the right edge of a Ribbon object; R=<Integer>")>
    Public Property ID_RibbonRight() As String = "" 'R=

    <Category("ItemData"), Description("(Specifies a chapter assignment for a Ribbon or Frame object; H=<?>")>
    Public Property ID_ChapterAssignment() As String = "" 'H=

    <Category("ItemData"), Description("Specifies the collapse offset of a Ribbon object; C=<Integer>")>
    Public Property ID_RibbonCollapseOffset() As String = "" 'C=

    <Category("ItemData"), Description("Specifies the ColumnSpan property of a Ribbon object; S=<?>")>
    Public Property ID_RibbonColumnSpan() As String = "" 'S=

    <Category("ItemData"), Description("Specifies the BackStyle of an object, where 0 = transparent and 1 = opaque; T=<0,1>")>
    Public Property ID_BackStyle() As String = "" 'T=

    <Category("ItemData"), Description("Specifies the BorderStyle of an object; S=<0,1>")>
    Public Property ID_BorderStyle() As String = "" 'S=

    <Category("ItemData"), Description("Specifies the draw width of a Drawing object; W=<?>")>
    Public Property ID_DrawWidth() As String = "" 'W=

    <Category("ItemData"), Description("Indicates whether a Frame object is DrawOnly; T=<?>")>
    Public Property ID_FrameDrawOnly() As String = "" 'T=

    <Category("ItemData"), Description("Specifies the composite image marker style; M=<Integer>")>
    Public Property ID_ImageMarkerStyle() As String = "" 'M=

    <Category("ItemData"), Description("Specifies the comma-delimited list of chart column item enum values for listview associated with Medcin or Picklist objects; G=<?>")>
    Public Property ID_ListviewColumnItems() As String = "" 'G=

    <Category("ItemData"), Description("Specifies the logic equation or other list, if any, and is always last. It may contain a list of Medcinids for use with an internal drop list pick list. It may contain a list of ImageIDs for use with an imager control object; L=<?>")>
    Public Property ID_Logic() As String = "" 'L=

    <Category("ItemData"), Description("Specifies a unique numeric ID for this object; N=<Integer>")>
    Public Property ID_ObjectID() As String = "" 'N=

    <Category("ItemData"), Description("Represents the combined flag values for the options; O=<Integer>")>
    Public Property ID_Options() As String = "" 'O=

    <Category("ItemData"), Description("Specifies the tooltip for objects with captions; P=<String>")>
    Public Property ID_Tooltip() As String = "" 'P=

    <Category("ItemData"), Description("Specifies the availability of intelligent prompting for a Tree object; I=<?>")>
    Public Property ID_TreeIntelligentPrompting() As String = "" 'I=

    <Category("ItemData"), Description("Specifies the availability of mouse browsing for a Tree object; B=<?>")>
    Public Property ID_TreeMouseBrowsing() As String = "" 'B=

    <Category("ItemData"), Description("Specifies the availability of word search for a Tree object; S=<?>")>
    Public Property ID_TreeWordSearch() As String = "" 'S=

    <Category("ItemData"), Description("Specifies the ValueBoxChars enum value designating restrictions on what type of characters are allowed in a value box: 0=AllowAll, 1=AllowNumbers, 2=AllowLetters; V=<0,1,2>")>
    Public Property ID_ValueBoxChars() As String = "" 'V=

    <Category("ItemData"), Description("Specifies the appearance of checkboxes; Y=<0,1,2,4,5,6>")>
    Public Property ID_YesNoStyle() As String = "" 'Y=
#End Region

#Region "Description Properties"
    <Category("Description"), Description("The caption associated with the control")>
    Public Property D_Caption() As String = ""

    <Category("Description"), Description("The default text associated with the control")>
    Public Property D_Content() As String = ""
#End Region
#End Region

#Region "Constructors"
    Sub New()
    End Sub

    ' Sub New(ByVal _combinedargs As String)
    '    Dim args As String() = Split(_combinedargs, ",")
    '     Tab = CInt(args(0))
    '      Left = CInt(args(1))
    '       Top = CInt(args(2))
    '        Right = CInt(args(3))
    '         Bottom = CInt(args(4))
    '          MedcinID = CInt(args(5))
    '           ControlType = CLng(args(6))
    ' Prefix = args(7)
    ' ItemData = args(8)
    ' Description = args(9)
    '        End Sub
#End Region

#Region "Methods"
    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder()
        sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", _
                          Tab, Left, Top, Right, Bottom, MedcinID, _
                          ControlType) ' , Prefix, ItemData, Description)
        Return sb.ToString()
    End Function
#End Region

End Class
