using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALT.ITG.Shared.Core;
using DALT.ITG.Shared.Utilities;

namespace DALT.ITG.Models
{
    public class PrefixContainer : ObservableObject
    {
        public static readonly string DefaultString = " |||||||0|0||0|0|||0|||0|0|0|0|0|0|||";
        public static readonly string MedcinString = " |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||";

        #region Fields

        // "0|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25"
        private string _prefix;                     //  0
        private string _modifier;                   //  1
        private string _result;                     //  2
        private string _status;                     //  3
        private string _value;                      //  4
        private string _linkGroup;                  //  5
        private string _units;                      //  6
        private int _boxOffset = 0;                 //  7
        private int _inlineTextboxWidth = 0;        //  8
        private string _componentSequence;          //  9
        private int _indexToReferenceList = 0;      // 10
        private int _narrativeGroupAssignment = 0;  // 11
        private string _chkYCaption = "";           // 12
        private string _chkNCaption = "";           // 13
        private int _bitFlags = 0;                  // 14
        private string _limitMax;                   // 15
        private string _limitMin;                   // 16
        private int _ribbonTriggerId = 0;           // 17
        private int _clusterId = 0;                 // 18
        private int _parentRibbonId = 0;            // 19
        private int _radioButtonGroup = 0;          // 20
        private int _imageId = 0;                   // 21
        private int _hotSpotSetId = 0;              // 22
        private string _parentFrame;                // 23
        private string _codeMapping;                // 24
        private string _userAssignedSubgroup;       // 25

        #endregion

        #region Properties

        public string Prefix
        {
            get { return _prefix; }
            set { SetProperty(ref _prefix, value); }
        }

        public string Modifier
        {
            get { return _modifier; }
            set { SetProperty(ref _modifier, value); }
        }
        
        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }
        
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
        
        public string LinkGroup
        {
            get { return _linkGroup; }
            set { SetProperty(ref _linkGroup, value); }
        }
        
        public string Units
        {
            get { return _units; }
            set { SetProperty(ref _units, value); }
        }
        
        public int BoxOffset
        {
            get { return _boxOffset; }
            set { SetProperty(ref _boxOffset, value); }
        }
        
        public int InlineTextboxWidth
        {
            get { return this._inlineTextboxWidth; }
            set { SetProperty(ref _inlineTextboxWidth, value); }
        }
        
        public string ComponentSequence
        {
            get { return _componentSequence; }
            set { SetProperty(ref _componentSequence, value.ToUpper()); }
        }
        
        public int IndexToReferenceList
        {
            get { return _indexToReferenceList; }
            set { SetProperty(ref _indexToReferenceList, value); }
        }
        
        public int NarrativeGroupAssignment
        {
            get { return _narrativeGroupAssignment; }
            set { SetProperty(ref _narrativeGroupAssignment, value); }
        }
        
        public string CHKYCaption
        {
            get { return _chkYCaption; }
            set { SetProperty(ref _chkYCaption, value.ToUpper()); }
        }
        
        public string CHKNCaption
        {
            get { return _chkNCaption; }
            set { SetProperty(ref _chkNCaption, value.ToUpper()); }
        }
        
        public int BitFlags
        {
            get { return _bitFlags; }
            set { SetProperty(ref _bitFlags, value); }
        }

        public string LimitMax
        {
            get { return _limitMax; }
            set { SetProperty(ref _limitMax, value); }
        }

        public string LimitMin
        {
            get { return _limitMin; }
            set { SetProperty(ref _limitMin, value); }
        }
        
        public int RibbonTriggerId
        {
            get { return _ribbonTriggerId; }
            set { SetProperty(ref _ribbonTriggerId, value); }
        }
        
        public int ClusterId
        {
            get { return _clusterId; }
            set { SetProperty(ref _clusterId, value); }
        }
        
        public int ParentRibbonId
        {
            get { return _parentRibbonId; }
            set { SetProperty(ref _parentRibbonId, value); }
        }

        public int RadioButtonGroup
        {
            get { return _radioButtonGroup; }
            set { SetProperty(ref _radioButtonGroup, value); }
        }
        
        public int ImageId
        {
            get { return _imageId; }
            set { SetProperty(ref _imageId, value); }
        }
        
        public int HotSpotSetId
        {
            get { return _hotSpotSetId; }
            set { SetProperty(ref _hotSpotSetId, value); }
        }
        
        public string ParentFrame
        {
            get { return _parentFrame; }
            set { SetProperty(ref _parentFrame, value); }
        }
        
        public string CodeMapping
        {
            get { return _codeMapping; }
            set { SetProperty(ref _codeMapping, value); }
        }
        
        public string UserAssignedSubgroup
        {
            get { return _userAssignedSubgroup; }
            set { SetProperty(ref _userAssignedSubgroup, value); }
        }

        #endregion

        public PrefixContainer() { }

        public void Import(string[] prefix)
        {
            Prefix = prefix[0];
            Modifier = prefix[1];
            Result = prefix[2];
            Status = prefix[3];
            Value = prefix[4];
            LinkGroup = prefix[5];
            Units = prefix[6];
            BoxOffset = int.Parse(prefix[7]);
            InlineTextboxWidth = int.Parse(prefix[8]);
            ComponentSequence = prefix[9];
            IndexToReferenceList = int.Parse(prefix[10]);
            NarrativeGroupAssignment = int.Parse(prefix[11]);
            CHKYCaption = prefix[12];
            CHKNCaption = prefix[13];
            BitFlags = int.Parse(prefix[14]);
            LimitMax = prefix[15];
            LimitMin = prefix[16];
            RibbonTriggerId = int.Parse(prefix[17]);
            ClusterId = int.Parse(prefix[18]);
            ParentRibbonId = int.Parse(prefix[19]);
            RadioButtonGroup = int.Parse(prefix[20]);
            ImageId = int.Parse(prefix[21]);
            HotSpotSetId = int.Parse(prefix[22]);
            ParentFrame = prefix[23];
            CodeMapping = prefix[24];
            UserAssignedSubgroup = prefix[25];
        }

        public string Export()
        {
            string prefix = String.Format(
                "{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}",
                Prefix, Modifier, Result, Status, Value,
                LinkGroup, Units, BoxOffset, InlineTextboxWidth, ComponentSequence,
                IndexToReferenceList, NarrativeGroupAssignment, CHKYCaption, CHKNCaption, BitFlags,
                LimitMax, LimitMin, RibbonTriggerId, ClusterId, ParentRibbonId,
                RadioButtonGroup, ImageId, HotSpotSetId, ParentFrame, CodeMapping,
                UserAssignedSubgroup);
            return prefix.QuoteWrap();
        }

        public override string ToString()
        {
            return Export();
        }
    }
}
