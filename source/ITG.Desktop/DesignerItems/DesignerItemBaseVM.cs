using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITG.Helper;
using ITG.Desktop.Services;
using ITG.Desktop.Designer;
using DALT.Utility;
using DALT.Controls;
using DALT.Controls.Converters;
using ITG.Common;
using DALT.Utility.Extensions;


namespace ITG.Desktop.DesignerItems
{
    public class DesignerItemBaseVM : ViewModelBase
    {
        // "0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25"
        private enum PF : int
        {
            Prefix = 0,
            Modifier = 1,
            Result = 2,
            Status = 3,
            Value = 4,
            LinkGroup = 5,
            Units = 6,
            BoxOffset = 7,
            InlineTextboxWidth = 8,
            ComponentSequence = 9,
            IndexToReferenceList = 10,
            NarrativeGroupAssignment = 11,
            CHKYCaption = 12,
            CHKNCaption = 13,
            BitFlags = 14,
            LimitMax = 15,
            LimitMin = 16,
            RibbonTriggerId = 17,
            ClusterId = 18,
            ParentRibbonId = 19,
            RadioButtonGroup = 20,
            ImageId = 21,
            HotSpotSetId = 22,
            ParentFrame = 23,
            CodeMapping = 24,
            UserAssignedSubgroup = 25
        };
                
        public DesignerItemBaseVM() : base()
        {
            //Init();
            SelectItemCommand = new MyCommand(ExecuteSelectItemCommand);
            EnforceSizeConstraints();
        }


        #region Size/Position Properties

        protected double left;
        public double Left
        {
            get { return left; }
            set
            {
                value = Math.Round(value, MidpointRounding.AwayFromZero);
                if (left != value)
                {
                    left = value;
                    OnPropertyChanged();
                    NotifyPropertyChanged("Right");
                }
            }
        }

        protected double top;
        public double Top
        {
            get { return top; }
            set
            {
                value = Math.Round(value, MidpointRounding.AwayFromZero);
                if (top != value)
                {
                    top = value;
                    OnPropertyChanged();
                    NotifyPropertyChanged("Bottom");
                }
            }
        }

        protected double width;
        public double Width
        {
            get { return width; }
            set
            {
                value = Math.Round(value, MidpointRounding.AwayFromZero);
                if (this.width != value)
                {
                    this.width = value;
                    EnforceSizeConstraints();
                    NotifyPropertyChanged("Width");
                    NotifyPropertyChanged("Left"); // may not need both of these
                    NotifyPropertyChanged("Right");
                }
            }
        }

        protected double height;
        public double Height
        {
            get { return height; }
            set
            {
                value = Math.Round(value, MidpointRounding.AwayFromZero);
                if (height != value)
                {
                    height = value;
                    EnforceSizeConstraints();

                    OnPropertyChanged();
                    NotifyPropertyChanged("Top");
                    NotifyPropertyChanged("Bottom");
                }
            }
        }

        public double Right { get { return (Left + Width - 1); } }

        public double Bottom { get { return (Top + Height - 1); } }

        protected double defWidth = 100;
        public double DefWidth { get { return defWidth; } }

        protected double defHeight = 20;
        public double DefHeight { get { return defHeight; } }

        protected double minWidth = 20;
        public double MinWidth { get { return minWidth; } }

        protected double maxWidth = 1000;
        public double MaxWidth { get { return maxWidth; } }

        protected double minHeight = 20;
        public double MinHeight { get { return minHeight; } }

        protected double maxHeight = 1000;
        public double MaxHeight { get { return maxHeight; } }

        #endregion


        #region General Properties

        protected bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        public List<DesignerItemBaseVM> SelectedItems
        { get { return ParentTab.SelectedItems; } }

        // reference to parent designer - this is set in DesignerVM.ExecuteAddItemCommand
        public DesignerVM ParentForm { get; set; }

        public DesignerTabVM ParentTab { get; set; }

        protected int tab;
        public int Tab
        {
            get
            {
                if (ParentTab != null) return ParentTab.Index + 1;
                else return -1;// AHLTA "tabs" are not 0-based, since 0 is used for resources
            }
        }

        protected bool isMedcinItem;
        public bool IsMedcinItem { get { return isMedcinItem; } }

        protected string controlType = "DesignerItemBase";
        public string ControlType { get { return controlType; } }

        protected int controlFlag = -1;
        public int ControlFlag { get { return controlFlag; } }

        protected string tooltip = "DesignerItemBase";
        public string Tooltip { get { return tooltip; } }

        protected int medcinId = 0;
        public int MedcinId
        {
            get { return medcinId; }
            set { SetProperty(ref medcinId, value); }
        }

        public string Prefix { get { return GetPrefix(); } }

        public string ItemData { get { return GetItemData(); } }

        public string Description { get { return GetDescription(); } }

        #endregion
        

        #region Prefix Properties

        //<Category("Prefix"), Description("(Unknown) Possibly affects placement in note, to differentiate several objects with identical MedcinIDs")>
        //Public Property PF_Prefix() As String = "" '0
        protected string pf_Prefix;
        public string PF_Prefix
        {
            get { return pf_Prefix; }
            set { SetProperty(ref pf_Prefix, value); }
        }

        //<Category("Prefix"), Description("(Unknown) Possibly enum values - used for wellness levels EX, GD, FR, PR, etc")>
        //Public Property PF_Modifier() As String = "" '1
        protected string pf_Modifier;
        public string PF_Modifier
        {
            get { return pf_Modifier; }
            set { SetProperty(ref pf_Modifier, value); }
        }

        //<Category("Prefix"), Description("(Unknown)")>
        //Public Property PF_Result() As String = "" '2
        protected string pf_Result;
        public string PF_Result
        {
            get { return pf_Result; }
            set { SetProperty(ref pf_Result, value); }
        }

        //<Category("Prefix"), Description("(Unknown)")>
        //Public Property PF_Status() As String = "" '3
        protected string pf_Status;
        public string PF_Status
        {
            get { return pf_Status; }
            set { SetProperty(ref pf_Status, value); }
        }

        //<Category("Prefix"), Description("(Unknown)")>
        //Public Property PF_Value() As String = "" '4
        protected string pf_Value;
        public string PF_Value
        {
            get { return pf_Value; }
            set { SetProperty(ref pf_Value, value); }
        }

        //<Category("Prefix"), Description("Specifies the object's relative value/order within a linked group, such as radiobuttons (0..5)")>
        //Public Property PF_LinkGroup() As String = "" '5
        protected string pf_LinkGroup;
        public string PF_LinkGroup
        {
            get { return pf_LinkGroup; }
            set { SetProperty(ref pf_LinkGroup, value); }
        }

        //<Category("Prefix"), Description("Units associated with the control's data, such as cm, days, etc")>
        //Public Property PF_Units() As String = "" '6
        protected string pf_Units;
        public string PF_Units
        {
            get { return pf_Units; }
            set { SetProperty(ref pf_Units, value); }
        }

        //<Category("Prefix"), Description("(Unknown) Possibly the height of the control? Tends to be 19 in most cases")>
        //Public Property PF_BoxOffset() As String = "19" '7
        protected int pf_BoxOffset = 0;
        public int PF_BoxOffset 
        {
            get { return pf_BoxOffset; }
            set { SetProperty(ref pf_BoxOffset, value); }
        }

        //<Category("Prefix"), Description("Width of an inline textbox component, as measured in pixels from right to left")>
        //Public Property PF_InlineTextboxWidth() As String = "80" '8
        protected int pf_InlineTextboxWidth = 0;
        public int PF_InlineTextboxWidth
        {
            get { return this.pf_InlineTextboxWidth; }
            set { SetProperty(ref pf_InlineTextboxWidth, value); }
        }

        //<Category("Prefix"), Description("Helps determine the order of the components (ex: YCN)")>
        //Public Property PF_ComponentSequence() As String = "YCN" '9
        protected string pf_ComponentSequence;
        public string PF_ComponentSequence
        {
            get { return pf_ComponentSequence; }
            set { SetProperty(ref pf_ComponentSequence, value.ToUpper()); }
        }

        //<Category("Prefix"), Description("Used to reference a URL object; use 0 for null")>
        //Public Property PF_IndexToReferenceList() As String = "0" '10
        protected int pf_IndexToReferenceList = 0;
        public int PF_IndexToReferenceList
        {
            get { return pf_IndexToReferenceList; }
            set { SetProperty(ref pf_IndexToReferenceList, value); }
        }

        //<Category("Prefix"), Description("(Unknown) 0 seems to be the default value")>
        //Public Property PF_NarrativeGroupAssignemnt() As String = "0" '11
        protected int pf_NarrativeGroupAssignment = 0;
        public int PF_NarrativeGroupAssignment
        {
            get { return pf_NarrativeGroupAssignment; }
            set { SetProperty(ref pf_NarrativeGroupAssignment, value); }
        }

        //<Category("Prefix"), Description("The character assigned to the first checkbox component")>
        //Public Property PF_CHKYCaption() As String = "Y" '12
        protected string pf_CHKYCaption = "";
        public string PF_CHKYCaption
        {
            get { return pf_CHKYCaption; }
            set { SetProperty(ref pf_CHKYCaption, value.ToUpper()); }
        }

        //<Category("Prefix"), Description("The character assigned to the second checkbox component (if any)")>
        //Public Property PF_CHKNCaption() As String = "N" '13
        protected string pf_CHKNCaption = "";
        public string PF_CHKNCaption
        {
            get { return pf_CHKNCaption; }
            set { SetProperty(ref pf_CHKNCaption, value.ToUpper()); }
        }

        //<Category("Prefix"), Description("Bits 0-1: automatic browse; Bit 2: disable HPI-ROS toggle; Bit 3: disable gender check; Bit 4: ValueSum")>
        //Public Property PF_BitFlags() As String = "" '14
        protected int pf_BitFlags = 0;
        public int PF_BitFlags
        {
            get { return pf_BitFlags; }
            set { SetProperty(ref pf_BitFlags, value); }
        }

        //<Category("Prefix"), Description("Maximum allowed value")>
        //Public Property PF_LimitMax() As String = "" '15
        protected string pf_LimitMax;
        public string PF_LimitMax
        {
            get { return pf_LimitMax; }
            set { SetProperty(ref pf_LimitMax, value); }
        }

        //<Category("Prefix"), Description("Minimum allowed value")>
        //Public Property PF_LimitMin() As String = "" '16
        protected string pf_LimitMin;
        public string PF_LimitMin
        {
            get { return pf_LimitMin; }
            set { SetProperty(ref pf_LimitMin, value); }
        }

        //<Category("Prefix"), Description("Specifies the ribbon to expand when this object is activated")>
        //Public Property PF_RibbonTriggerId() As String = "" '17
        protected int pf_RibbonTriggerId = 0;
        public int PF_RibbonTriggerId
        {
            get { return pf_RibbonTriggerId; }
            set { SetProperty(ref pf_RibbonTriggerId, value); }
        }

        //<Category("Prefix"), Description("Specifies the cluster that this object belongs to")>
        //Public Property PF_ClusterID() As String = "" '18
        protected int pf_ClusterId = 0;
        public int PF_ClusterId
        {
            get { return pf_ClusterId; }
            set { SetProperty(ref pf_ClusterId, value); }
        }

        //<Category("Prefix"), Description("Specifies the ribbon that this object belongs to")>
        //Public Property PF_ParentRibbonID() As String = "" '19
        protected int pf_ParentRibbonId = 0;
        public int PF_ParentRibbonId
        {
            get { return pf_ParentRibbonId; }
            set { SetProperty(ref pf_ParentRibbonId, value); }
        }

        //<Category("Prefix"), Description("Specifies the radio button group that this object belongs to")>
        //Public Property PF_RadioButtonGroup() As String = "" '20
        protected int pf_RadioButtonGroup = 0;
        public int PF_RadioButtonGroup
        {
            get { return pf_RadioButtonGroup; }
            set { SetProperty(ref pf_RadioButtonGroup, value); }
        }

        //<Category("Prefix"), Description("(Unknown)")>
        //Public Property PF_ImageID() As String = "" '21
        protected int pf_ImageId = 0;
        public int PF_ImageId
        {
            get { return pf_ImageId; }
            set { SetProperty(ref pf_ImageId, value); }
        }

        //<Category("Prefix"), Description("(Unknown)")>
        //Public Property PF_HotSpotSetID() As String = "" '22
        protected int pf_HotSpotSetId = 0;
        public int PF_HotSpotSetId
        {
            get { return pf_HotSpotSetId; }
            set { SetProperty(ref pf_HotSpotSetId, value); }
        }

        //<Category("Prefix"), Description("Specifies the parent frame for all objects other than boxes and grids")>
        //Public Property PF_ParentFrame() As String = "" '23
        protected string pf_ParentFrame;
        public string PF_ParentFrame
        {
            get { return pf_ParentFrame; }
            set { SetProperty(ref pf_ParentFrame, value); }
        }

        //<Category("Prefix"), Description("(Unknown)")>
        //Public Property PF_CodeMapping() As String = "" '24
        protected string pf_CodeMapping;
        public string PF_CodeMapping
        {
            get { return pf_CodeMapping; }
            set { SetProperty(ref pf_CodeMapping, value); }
        }

        //<Category("Prefix"), Description("(Unknown)")>
        //Public Property PF_UserAssignedSubgroup() As String = "" '25
        protected string pf_UserAssignedSubgroup;
        public string PF_UserAssignedSubgroup
        {
            get { return pf_UserAssignedSubgroup; }
            set { SetProperty(ref pf_UserAssignedSubgroup, value); }
        }

        #endregion


        #region ItemData Properties

        //<Category("ItemData"), Description("Specifies the font used for the object's caption; F=<FontName As String>")>
        //Public Property ID_FontName() As String = "" 'F=
        protected string id_Font = "Arial";
        public string ID_Font
        {
            get { return id_Font; }
            set { SetProperty(ref id_Font, value); }
        }

        //<Category("ItemData"), Description("Specifies whether the object's caption is BOLD; B=<T,F>")>
        //Public Property ID_Bold() As String = "" 'B=
        protected string id_Bold;
        public string ID_Bold
        {
            get { return id_Bold; }
            set { SetProperty(ref id_Bold, value); }
        }

        //<Category("ItemData"), Description("Specifies whether the object's caption is ITALICIZED; I=<T,F>")>
        //Public Property ID_Italic() As String = "" 'I=
        protected string id_Italic;
        public string ID_Italic
        {
            get { return id_Italic; }
            set { SetProperty(ref id_Italic, value); }
        }

        //<Category("ItemData"), Description("Specifies whether the object's caption is UNDERLINED; U=<T,F>")>
        //Public Property ID_Underline() As String = "" 'U=
        protected string id_Underline;
        public string ID_Underline
        {
            get { return id_Underline; }
            set { SetProperty(ref id_Underline, value); }
        }

        //<Category("ItemData"), Description("Specifies the forecolor of the object; C=<AHLTAColor As Integer>")>
        //Public Property ID_ForeColor() As String = "" 'C=
        protected int id_ForeColor = AhltaColors.GetBGRInt(AhltaColors.CurrentTheme, "ControlText");
        public int ID_ForeColor
        {
            get { return id_ForeColor; }
            set { SetProperty(ref id_ForeColor, value); }
        }

        //<Category("ItemData"), Description("Specifies the backcolor of the object; K=<AHLTAColor As Integer>")>
        //Public Property ID_BackColor() As String = "" 'K=
        protected int id_BackColor = AhltaColors.GetBGRInt(AhltaColors.CurrentTheme, "Control");
        public int ID_BackColor
        {
            get { return id_BackColor; }
            set { SetProperty(ref id_BackColor, value); }
        }

        //<Category("ItemData"), Description("Specifies the BackStyle of an object, where 0 = transparent and 1 = opaque; T=<0,1>")>
        //Public Property ID_BackStyle() As String = "" 'T=
        protected string id_BackStyle;
        public string ID_BackStyle
        {
            get { return id_BackStyle; }
            set { SetProperty(ref id_BackStyle, value); }
        }

        //<Category("ItemData"), Description("Specifies the BorderStyle of an object; S=<0,1>")>
        //Public Property ID_BorderStyle() As String = "" 'S=
        protected string id_BorderStyle;
        public string ID_BorderStyle
        {
            get { return id_BorderStyle; }
            set { SetProperty(ref id_BorderStyle, value); }
        }

        //<Category("ItemData"), Description("Specifies the draw width of a Drawing object; W=<?>")>
        //Public Property ID_DrawWidth() As String = "" 'W=
        protected string id_DrawWidth;
        public string ID_DrawWidth
        {
            get { return id_DrawWidth; }
            set { SetProperty(ref id_DrawWidth, value); }
        }

        //<Category("ItemData"), Description("Specifies the composite image marker style; M=<Integer>")>
        //Public Property ID_ImageMarkerStyle() As String = "" 'M=
        protected string id_ImageMarkerStyle;
        public string ID_ImageMarkerStyle
        {
            get { return id_ImageMarkerStyle; }
            set { SetProperty(ref id_ImageMarkerStyle, value); }
        }

        //<Category("ItemData"), Description("Specifies the comma-delimited list of chart column item enum values for listview associated with Medcin or Picklist objects; G=<?>")>
        //Public Property ID_ListviewColumnItems() As String = "" 'G=
        protected string id_ListviewColumnItems;
        public string ID_ListviewColumnItems
        {
            get { return id_ListviewColumnItems; }
            set { SetProperty(ref id_ListviewColumnItems, value); }
        }

        //<Category("ItemData"), Description("Specifies the logic equation or other list, if any, and is always last. It may contain a list of Medcinids for use with an internal drop list pick list. It may contain a list of ImageIDs for use with an imager control object; L=<?>")>
        //Public Property ID_Logic() As String = "" 'L=
        protected string id_Logic;
        public string ID_Logic
        {
            get { return id_Logic; }
            set { SetProperty(ref id_Logic, value); }
        }

        //<Category("ItemData"), Description("Specifies a unique numeric ID for this object; N=<Integer>")>
        //Public Property ID_ObjectID() As String = "" 'N=
        protected string id_ObjectId;
        public string ID_ObjectId
        {
            get { return id_ObjectId; }
            set { SetProperty(ref id_ObjectId, value); }
        }

        //<Category("ItemData"), Description("Represents the combined flag values for the options; O=<Integer>")>
        //Public Property ID_Options() As String = "" 'O=
        protected string id_Options;
        public string ID_Options
        {
            get { return id_Options; }
            set { SetProperty(ref id_Options, value); }
        }

        //<Category("ItemData"), Description("Specifies the tooltip for objects with captions; P=<String>")>
        //Public Property ID_Tooltip() As String = "" 'P=
        protected string id_Tooltip;
        public string ID_Tooltip
        {
            get { return id_Tooltip; }
            set { SetProperty(ref id_Tooltip, value); }
        }

        //<Category("ItemData"), Description("Specifies the availability of intelligent prompting for a Tree object; I=<?>")>
        //Public Property ID_TreeIntelligentPrompting() As String = "" 'I=
        protected string id_TreeIntelligentPrompting;
        public string ID_TreeIntelligentPrompting
        {
            get { return id_TreeIntelligentPrompting; }
            set { SetProperty(ref id_TreeIntelligentPrompting, value); }
        }

        //<Category("ItemData"), Description("Specifies the availability of mouse browsing for a Tree object; B=<?>")>
        //Public Property ID_TreeMouseBrowsing() As String = "" 'B=
        protected string id_TreeMouseBrowsing;
        public string ID_TreeMouseBrowsing
        {
            get { return id_TreeMouseBrowsing; }
            set { SetProperty(ref id_TreeMouseBrowsing, value); }
        }

        //<Category("ItemData"), Description("Specifies the availability of word search for a Tree object; S=<?>")>
        //Public Property ID_TreeWordSearch() As String = "" 'S=
        protected string id_TreeWordSearch;
        public string ID_TreeWordSearch
        {
            get { return id_TreeWordSearch; }
            set { SetProperty(ref id_TreeWordSearch, value); }
        }

        //<Category("ItemData"), Description("Specifies the ValueBoxChars enum value designating restrictions on what type of characters are allowed in a value box: 0=AllowAll, 1=AllowNumbers, 2=AllowLetters; V=<0,1,2>")>
        //Public Property ID_ValueBoxChars() As String = "" 'V=
        protected string id_ValueBoxChars;
        public string ID_ValueBoxChars
        {
            get { return id_ValueBoxChars; }
            set { SetProperty(ref id_ValueBoxChars, value); }
        }

        //<Category("ItemData"), Description("Specifies the appearance of checkboxes; Y=<0,1,2,4,5,6>")>
        //Public Property ID_YesNoStyle() As String = "" 'Y=
        protected string id_YesNoStyle;
        public string ID_YesNoStyle
        {
            get { return id_YesNoStyle; }
            set { SetProperty(ref id_YesNoStyle, value); }
        }

        #endregion


        #region Description Properties

        //<Category("Description"), Description("The caption associated with the control")>
        //Public Property D_Caption() As String = ""
        protected string d_Caption = "";
        public string D_Caption 
        {
            get { return d_Caption; }
            set
            {
                if (d_Caption != value)
                {
                    d_Caption = value;
                    OnPropertyChanged();
                    NotifyPropertyChanged("Width");
                }
            }
        }

        //<Category("Description"), Description("The default text associated with the control")>
        //Public Property D_Content() As String = ""
        protected string d_Content = "";    
        public string D_Content
        {
            get { return d_Content; }
            set { SetProperty(ref d_Content, value); }
        }

        #endregion


        #region Commands

        public MyCommand SelectItemCommand { get; private set; }
        private void ExecuteSelectItemCommand(object param)
        {
            SelectItem((bool)param, !IsSelected);
        }

        private void SelectItem(bool newselect, bool select)
        {
            if (newselect)
            {
                foreach (var designerItemBaseVM in ParentTab.SelectedItems.ToList())
                {
                    designerItemBaseVM.isSelected = false;
                }
            }

            IsSelected = select;
        }

        #endregion


        #region Methods

        protected void SetControlDefaults(string controlType, int controlFlag, string tooltip)
        {
            this.controlType = controlType;
            this.controlFlag = controlFlag;
            this.tooltip = tooltip;
        }

        protected void SetSizeConstraints(double defWidth, double minWidth, double maxWidth, double defHeight, double minHeight, double maxHeight)
        {
            //System.Console.WriteLine("Setting size constraints ... {0} {1} {2} {3}",minWidth,maxWidth,minHeight,maxHeight);
            this.defWidth = defWidth;
            this.Width = this.defWidth;
            this.minWidth = minWidth;
            this.maxWidth = maxWidth;
            this.defHeight = defHeight;
            this.Height = this.defHeight;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
        }

        protected void EnforceSizeConstraints()
        {
            //System.Console.WriteLine("Enforcing size constraints ...");
            if (Width < minWidth) Width = minWidth;
            if (Width > maxWidth) Width = maxWidth;
            if (Height < minHeight) Height = minHeight;
            if (Height > maxHeight) Height = maxHeight;
        }

        protected string GetGeneral()
        {
            return String.Format("{0},{1},{2},{3},{4},{5},{6}", Tab, Left, Top, Right, Bottom, MedcinId, ControlFlag);
        }
        
        protected string GetPrefix()
        {
            string prefix = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}",
                PF_Prefix, PF_Modifier, PF_Result, PF_Status, PF_Value,
                PF_LinkGroup, PF_Units, PF_BoxOffset, PF_InlineTextboxWidth, PF_ComponentSequence, 
                PF_IndexToReferenceList, PF_NarrativeGroupAssignment, PF_CHKYCaption, PF_CHKNCaption, PF_BitFlags,
                PF_LimitMax, PF_LimitMin, PF_RibbonTriggerId, PF_ClusterId, PF_ParentRibbonId,
                PF_RadioButtonGroup, PF_ImageId, PF_HotSpotSetId, PF_ParentFrame, PF_CodeMapping,
                PF_UserAssignedSubgroup);
            return prefix.QuoteWrap();
        }

        public void SetPrefix(String[] prefix)
        {
            PF_Prefix = prefix[0];
            PF_Modifier = prefix[1];
            PF_Result = prefix[2];
            PF_Status = prefix[3];
            PF_Value = prefix[4];
            PF_LinkGroup = prefix[5];
            PF_Units = prefix[6];
            PF_BoxOffset = int.Parse(prefix[7]);
            PF_InlineTextboxWidth = int.Parse(prefix[8]);
            PF_ComponentSequence = prefix[9];
            PF_IndexToReferenceList = int.Parse(prefix[10]);
            PF_NarrativeGroupAssignment = int.Parse(prefix[11]);
            PF_CHKYCaption = prefix[12];
            PF_CHKNCaption = prefix[13];
            PF_BitFlags = int.Parse(prefix[14]);
            PF_LimitMax = prefix[15];
            PF_LimitMin = prefix[16];
            PF_RibbonTriggerId = int.Parse(prefix[17]);
            PF_ClusterId = int.Parse(prefix[18]);
            PF_ParentRibbonId = int.Parse(prefix[19]);
            PF_RadioButtonGroup = int.Parse(prefix[20]);
            PF_ImageId = int.Parse(prefix[21]);
            PF_HotSpotSetId = int.Parse(prefix[22]);
            PF_ParentFrame = prefix[23];
            PF_CodeMapping = prefix[24];
            PF_UserAssignedSubgroup = prefix[25];
        }

        protected string GetItemData()
        {
            // temporarily hardcoded
            return ("F=Arial|T=T").QuoteWrap();
        
        }

        protected string GetDescription()
        {
            if (string.IsNullOrWhiteSpace(D_Content))
            {
                return D_Caption.QuoteWrap();
            }
            else return (D_Caption + "~" + D_Content.ToggleLineReturn()).QuoteWrap();
        }

        public override string ToString()
        {
            return GetGeneral() + "," +
                GetPrefix() + "," +
                GetItemData() + "," +
                GetDescription();
        }
        
        #endregion
    }
}



