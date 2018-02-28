using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITG.Common;
using ITG.Desktop.DesignerItems;
using ITG.Helper;
using ITG.Desktop.Services;
using DALT.Utility;
using DALT.Utility.Extensions;


/* TODO:
 * This would be a good place to store "Resources" - the stuff that gets assigned tab 0 in AHLTA templates
 */

namespace ITG.Desktop.Designer
{
    public class DesignerVM : ViewModelBase
    {
        #region Members

        private string templateName = "New Template";
        private string version = "MedcinForm-V1.1";
        private string owner = "Anonymous";
        private string ownerType = "System";

        // initial height and width
        private double height = 700;
        private double width = 700;
        private double minWidth = 600;
        private double maxWidth = 2000;
        private double minHeight = 400;
        private double maxHeight = 3000;


        private ObservableCollection<DesignerTabVM> tabs = new ObservableCollection<DesignerTabVM>();
        private DesignerTabVM activeTab;
        private DesignerTabVM resourceTab;

        #endregion


        #region Constructor

        public DesignerVM()
        {
            // trigger the MedcinData static constructor; yeah, it's a hack
            Console.WriteLine("Loading MedcinTerms ({0}) ...", Terms.ToString());

            // instantiate the resource tab
            this.resourceTab = new DesignerTabVM(this);
            
            // first page of template; we leave the resource tab out
            // so it doesn't interfere with assigning the collection to the tabcontrol later
            Tabs.Add(new DesignerTabVM(this));
            Tabs.Add(new DesignerTabVM(this));
            
            Tabs[0].Name = "Tab 1";
            Tabs[1].Name = "Tab 2";
            ActiveTab = Tabs[0];

            // Register MyCommands
            AddTabCommand = new MyCommand(ExecuteAddTabCommand);
            RemoveTabCommand = new MyCommand(ExecuteRemoveTabCommand);
            CreateNewFormTemplateCommand = new MyCommand(ExecuteCreateNewFormTemplateCommand);
            ExportTemplateCommand = new MyCommand(ExecuteExportTemplateCommand);

            Mediator.Instance.Register(this);

            
        }

        #endregion


        #region Properties

        public DesignerItemBaseVM SelectedItem
        {
            get { return activeTab.SelectedItem; }
            set
            {
                if (activeTab.SelectedItem != value)
                {
                    activeTab.SelectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<MedcinTerm> Terms
        { get { return MedcinData.Terms; } }

        [Description("The name of the template.")]
        public string TemplateName
        {
            get { return this.templateName; }
            set
            {
                if (this.templateName != value)
                {
                    this.templateName = value;
                    NotifyPropertyChanged("TemplateName");
                }
            }
        }

        [Description("Version of the Forms Designer used to create the template.")]
        public string Version
        {
            get { return this.version; }
        }
        
        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (this.owner != value)
                {
                    this.owner = value;
                    OnPropertyChanged("Owner");
                }
            }
        }

        public string OwnerType
        {
            get { return this.ownerType; }
            set
            {
                if (this.ownerType != value)
                {
                    this.ownerType = value;
                    OnPropertyChanged("OwnerType");
                }
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (this.height != value)
                {
                    if (MinHeight > value) value = MinHeight;
                    if (MaxHeight < value) value = MaxHeight;
                    this.height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (this.width != value)
                {
                    if (MinWidth > value) value = MinWidth;
                    if (MaxWidth < value) value = MaxWidth;
                    this.width = value;
                    OnPropertyChanged("Width");
                }
            }
        }

        public double MinWidth
        { get { return this.minWidth; } }

        public double MaxWidth
        { get { return this.maxWidth; } }

        public double MinHeight
        { get { return this.minHeight; } }

        public double MaxHeight
        { get { return this.maxHeight; } }

        public int TabCount
        {
            get { return tabs.Count; }
        }

        public DesignerTabVM ResourceTab
        {
            get
            {
                return this.resourceTab;
            }
            set
            {
                if (this.resourceTab != value)
                {
                    this.resourceTab = value;
                    NotifyPropertyChanged("ResourceTab");
                }
            }
        }

        public DesignerTabVM ActiveTab
        {
            get
            {
                return this.activeTab;
            }
            set
            {
                if (this.activeTab != value)
                {
                    this.activeTab = value;
                    NotifyPropertyChanged("ActiveTab");
                }
            }
        }

        public ObservableCollection<DesignerTabVM> Tabs
        { 
            get { return tabs; } 
        }

        #endregion


        #region Commands

        public MyCommand AddTabCommand { get; private set; }
        public MyCommand RemoveTabCommand { get; private set; }
        public MyCommand CreateNewFormTemplateCommand { get; private set; }
        public MyCommand ExportTemplateCommand { get; private set; }

        private void ExecuteAddTabCommand(object parameter)
        {
            if (parameter is DesignerTabVM)
            {
                DesignerTabVM tab = (DesignerTabVM)parameter;
                tab.ParentForm = this;
                tabs.Add(tab);
            }
        }

        private void ExecuteRemoveTabCommand(object parameter)
        {
            if (parameter is DesignerTabVM)
            {
                DesignerTabVM tab = (DesignerTabVM)parameter;
                tabs.Remove(tab);
            }
        }

        private void ExecuteCreateNewFormTemplateCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteCreateNewFormTemplateCommand in DesignerVM.cs");
            ActiveTab = null;
            Tabs.Clear();
            Tabs.Add(new DesignerTabVM(this));
            ActiveTab = Tabs[0];      
        }

        private void ExecuteExportTemplateCommand(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, Export());
        }

        #endregion

        public override string ToString()
        {
            return TemplateName;
        }

        private string GetPrefix()
        {
            return (" |||||||0|0||0|0|||0|||0|0|0|0|0|0|||").QuoteWrap();
        }

        private string GetItemData()
        {
            string itemData = "N=1|L=V=13:DF=1:PS=1:TP=0:MR=T:BS=0:TWS=0:PB=0:NB=0:ROS=0:PL=0:FB=0:EM=0:CB=2:HHL=F";
            return itemData.QuoteWrap();
        }

        private string GetDescription()
        {
            return (":-2147483633:" + GetTabNames()).QuoteWrap();
        }

        private string GetTabNames()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Tabs.Count; i++)
            {
                if (i == (Tabs.Count - 1))
                    sb.Append(Tabs[i].Name);
                else sb.Append(Tabs[i].Name + "|");
            }
            return sb.ToString();
        }
            
        

        private string GetHeader()
        {
            StringBuilder sb = new StringBuilder();
            
            // LINE 1
            sb.AppendLine(Version.QuoteWrap());
            
            // LINE 2
            sb.Append(TemplateName.QuoteWrap() + ",");
            sb.Append(Owner.QuoteWrap() + ",");
            sb.AppendLine(OwnerType.QuoteWrap());
            
            // LINE 3 - FORM
            sb.AppendLine(String.Format("0,0,0,{0},{1},0,1048576,\"\",\"\",\"\"", Width, Height));
            
            // LINE 4 - TABCONTROL
            sb.AppendLine(String.Format("{0},5,377,295,395,0,32,{1},{2},{3}", TabCount, GetPrefix(), GetItemData(), GetDescription()));
            
            // LINE 5 - BROWSETREE
            // FWST-PedsGeneral: 0,555,10,1065,610,0,4,"","N=2|I=F|S=F|B=T",""
            //sb.AppendLine(String.Format("");

            return sb.ToString();
        }

        private string GetItems()
        {
            return ActiveTab.Export();
        }

        public string Export()
        {
            return GetHeader() + GetItems();
        }

            
    }
}
