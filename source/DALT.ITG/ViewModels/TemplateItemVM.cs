using System;
using System.Text;
using DALT.ITG.Models;
using DALT.ITG.Shared.Core;
using DALT.ITG.Shared.Utilities;

namespace DALT.ITG.ViewModels
{
    public class TemplateItemVM : ObservableObject
    {
        // Binding source for DesignerItems 

        #region Fields
        
        // Size
        protected SizeConstraints _constraints;
        private double _width;
        private double _height;

        // Position
        private double _left;
        private double _top;

        // Selection
        private bool _isSelected;

        // TemplateItem
        private int _page;
        private int _medcinId;
        private int _controlFlag;
        private PrefixContainer _prefix = new PrefixContainer();
        private ItemDataContainer _itemData = new ItemDataContainer();
        private string _caption = "";
        private string _content = "";

        private bool _isContentFlat = true; // line returns are tildes
        
        #endregion


        #region Size Properties
        
        public bool Constrained { get; set; }

        public double Width
        {
            get { return _width; }
            set
            {
                value.RoundToNearestWholeNumber();
                if (Constrained)
                    value.Constrain(_constraints.MinimumWidth, _constraints.MaximumWidth);
                SetProperty(ref _width, value);
                NotifyPropertyChanged("Left");
                NotifyPropertyChanged("Right");
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                value.RoundToNearestWholeNumber();
                if (Constrained)
                    value.Constrain(_constraints.MinimumHeight, _constraints.MaximumHeight);
                SetProperty(ref _height, value);
                NotifyPropertyChanged("Top");
                NotifyPropertyChanged("Bottom");
            }
        }
        
        #endregion


        #region POSITION Properties

        public double Left
        {
            get { return _left; }
            set
            {
                value.RoundToNearestWholeNumber();
                SetProperty(ref _left, value);
                NotifyPropertyChanged("Right");
            }
        }

        public double Top
        {
            get { return _top; }
            set
            {
                value.RoundToNearestWholeNumber();
                SetProperty(ref _top, value);
                NotifyPropertyChanged("Bottom");
            }
        }

        public double Right
        {
            get { return (Left + Width - 1); }
        }

        public double Bottom
        {
            get { return (Top + Height - 1); }
        }

        #endregion


        #region Selection Properties

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        #endregion


        #region TemplateItem Properties

        public int Page
        {
            get { return _page; }
            set { SetProperty(ref _page, value); }
        }

        public int MedcinId
        {
            get { return _medcinId; }
            set { SetProperty(ref _medcinId, value); }
        }

        public int ControlFlag
        {
            get { return _controlFlag; }
            set { SetProperty(ref _controlFlag, value); }
        }

        public ItemDataContainer ItemData
        {
            get { return _itemData; }
            private set { _itemData = value; }
        }

        public PrefixContainer Prefix
        {
            get { return _prefix; }
            private set { _prefix = value; }
        }

        // The caption associated with the control
        public string Caption
        {
            get { return _caption; }
            set
            {
                if (_caption != value)
                {
                    SetProperty(ref _caption, value);
                    NotifyPropertyChanged("Width");
                }
            }
        }

        // The default text associated with the control
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        public string Description
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Content))
                    return Caption.QuoteWrap();
                else
                    return (Caption + "~" + Content).QuoteWrap();
            }
        }

        #endregion


        #region Methods

        public void Import(string source)
        {
            // 1,630,37,720,55,115033,8449," |||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0|0|||","N=68|K=16777215|T=T","HPI~ ~Here for well-child check."
            char[] commaDelimiter = { ',' };
            char[] pipeDelimiter = { '|' };
            string[] itemTokens = source.Split(commaDelimiter, 10);

            Page = int.Parse(itemTokens[0]);

            Left = double.Parse(itemTokens[1]);
            
            Top = double.Parse(itemTokens[2]);

            double right = int.Parse(itemTokens[3]);
            Width = right - Left + 1; // +1 required due to 0 counting as 1

            double bottom = int.Parse(itemTokens[4]);
            Height = bottom - Top + 1;

            MedcinId = int.Parse(itemTokens[5]);
            
            ControlFlag = int.Parse(itemTokens[6]);

            string[] prefix = itemTokens[7].QuoteUnwrap().Split(pipeDelimiter, 26);
            Prefix.Import(prefix);

            string[] itemdata = itemTokens[8].QuoteUnwrap().Split(pipeDelimiter);
            ItemData.Import(itemdata);

            string[] description = itemTokens[9].QuoteUnwrap().Split("~".ToCharArray(), 2);

            Caption = description[0];
            Content = description[1];
        }

        public string Export()
        {
            StringBuilder sb = new StringBuilder();
            
            string controlData = String.Format("{0},{1},{2},{3},{4},{5},{6},", 
                Page, Left, Top, Right, Bottom, MedcinId, ControlFlag);

            sb.Append(controlData);
            sb.Append(Prefix.Export() + ",");
            sb.Append(ItemData.Export() + ",");
            sb.Append(Description);

            return sb.ToString();
        }

        #endregion


        #region Constructors

        public TemplateItemVM() 
        {
            Constrained = false; // must initialize _constraints before setting to true
        }

        #endregion

    }
}
