using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Win32;
using System.Windows.Media;
using ITG.Desktop.Designer;
using ITG.Desktop.DesignerItems;
using ITG.Helper;
using ITG.Desktop.Services;
using ITG.Common;
using DALT.Utility;


namespace ITG.Desktop
{
    public class MainWindowVM : ViewModelBase
    {
        #region FIELDS

        // not loading multiple templates at once, so not necessary ... unless needed for multiple tabs later
        // private List<int> savedDiagrams = new List<int>();
        // private IDatabaseAccessService databaseAccessService;
        // private int? savedFormTemplateId; // this would need a property SavedFormTemplateId
        
        private IMessageBoxService messageBoxService;
        private DesignerVM designerVM = new DesignerVM();
        private List<DesignerItemBaseVM> selectedItems;
        private bool isBusy = false;
        //private LogService appLog = new LogService();
        private ObservableCollection<FontFamily> systemFonts = new ObservableCollection<FontFamily>();

        #endregion


        #region CONSTRUCTOR

        public MainWindowVM()
        {
            // Setup services
            messageBoxService = new WPFMessageBoxService();

            // Instantiate the view models owned by MainWindow
            DesignerVM = new DesignerVM();

            LoadSystemFonts();

            // Declare commands (this is what links the xaml command bindings to the actual code)
            CreateNewFormTemplateCommand = new MyCommand(ExecuteCreateNewFormTemplateCommand);
            SaveFormTemplateCommand = new MyCommand(ExecuteSaveFormTemplateCommand);
            SaveAsFormTemplateCommand = new MyCommand(ExecuteSaveAsFormTemplateCommand);
            ExportFormTemplateCommand = new MyCommand(ExecuteExportFormTemplateCommand);
            LoadFormTemplateCommand = new MyCommand(ExecuteLoadFormTemplateCommand);
            ExitApplicationCommand = new MyCommand(ExecuteExitApplicationCommand);
            ShowPreferencesDialogCommand = new MyCommand(ExecuteShowPreferencesDialogCommand);
            LaunchProjectWebsiteCommand = new MyCommand(ExecuteLaunchProjectWebsiteCommand);
            ShowAboutDialogCommand = new MyCommand(ExecuteShowAboutDialogCommand);

            SelectDesignerItemCommand = new MyCommand(AreThereItemsCommand, ExecuteSelectDesignerItemCommand);

            MoveSelectedItemsUpCommand = new MyCommand(AreItemsSelectedCommand, ExecuteMoveSelectedItemsUpCommand);
            MoveSelectedItemsDownCommand = new MyCommand(AreItemsSelectedCommand, ExecuteMoveSelectedItemsDownCommand);
            MoveSelectedItemsLeftCommand = new MyCommand(AreItemsSelectedCommand, ExecuteMoveSelectedItemsLeftCommand);
            MoveSelectedItemsRightCommand = new MyCommand(AreItemsSelectedCommand, ExecuteMoveSelectedItemsRightCommand);

            DeleteSelectedItemsCommand = new MyCommand(AreItemsSelectedCommand, ExecuteDeleteSelectedItemsCommand);
            ToggleGroupOnSelectedItemsCommand = new MyCommand(AreItemsSelectedCommand, ExecuteToggleGroupOnSelectedItemsCommand);
        }

        #endregion


        #region PROPERTIES

        public DesignerVM DesignerVM
        {
            get
            {
                return designerVM;
            }
            set
            {
                if (designerVM != value)
                {
                    designerVM = value;
                    NotifyPropertyChanged("DesignerVM");
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    NotifyPropertyChanged("IsBusy");
                }
            }
        }

        // public LogService AppLog { get { return this.appLog; } }

        public ObservableCollection<FontFamily> SystemFonts
        { get { return systemFonts; } }

        #endregion


        #region COMMAND DECLARATIONS
        
        // Menu commands
        public MyCommand CreateNewFormTemplateCommand { get; private set; }
        public MyCommand SaveFormTemplateCommand { get; private set; }
        public MyCommand SaveAsFormTemplateCommand { get; private set; }
        public MyCommand ExportFormTemplateCommand { get; private set; }
        public MyCommand LoadFormTemplateCommand { get; private set; }
        public MyCommand ExitApplicationCommand { get; private set; }
        public MyCommand ShowPreferencesDialogCommand { get; private set; }
        public MyCommand LaunchProjectWebsiteCommand { get; private set; }
        public MyCommand ShowAboutDialogCommand { get; private set; }

        // Misc commands
        public MyCommand SelectDesignerItemCommand { get; private set; }

        // Key bindings
        public MyCommand MoveSelectedItemsUpCommand { get; private set; }
        public MyCommand MoveSelectedItemsDownCommand { get; private set; }
        public MyCommand MoveSelectedItemsLeftCommand { get; private set; }
        public MyCommand MoveSelectedItemsRightCommand { get; private set; }
        public MyCommand DeleteSelectedItemsCommand { get; private set; }
        public MyCommand ToggleGroupOnSelectedItemsCommand { get; private set; }

        #endregion


        #region MENU COMMAND IMPLEMENTATION

        private void ExecuteCreateNewFormTemplateCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteCreateNewFormTemplateCommand in MainWindowVM.cs");
            selectedItems = new List<DesignerItemBaseVM>();
            DesignerVM.CreateNewFormTemplateCommand.Execute(null);
        }

        private void ExecuteSaveFormTemplateCommand(object parameter)
        {
            messageBoxService.ShowError("Saving not implemented.");
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteSaveFormTemplateCommand in MainWindowVM.cs");
            //if (!DesignerVM.Items.Any())
            //{
                // It works!
                // messageBoxService.ShowError("There must be at least one item in order save a template.");
              //  return;
            //}

            // We're about to do some heavy work, so mark that we're busy
            //IsBusy = true;
            
            // Original code used tasks - presuming asynchronous work?
           	//System.Diagnostics.Debug.WriteLine("Saving template ...");

            // Implement FormTemplate saving here 
            //DesignerVM.ExportItemsCommand.Execute(null);

           	// All done saving
         	//IsBusy = false;
            //System.Diagnostics.Debug.WriteLine("Template saved.");
            
            // messageBoxService.ShowInformation(string.Format("Template saved"));
        }

        private void ExecuteSaveAsFormTemplateCommand(object parameter)
        {
            messageBoxService.ShowError("Saving not implemented.");
        }

        private void ExecuteExportFormTemplateCommand(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
              File.WriteAllText(saveFileDialog.FileName, DesignerVM.Export());
        }

        private void ExecuteLoadFormTemplateCommand(object parameter)
        {
            messageBoxService.ShowError("Loading not implemented.");
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteLoadFormTemplateCommand in MainWindowVM.cs");
            // About to perform some work, so mark that we're busy
            //IsBusy = true;

            // Implement FormTemplate loading here, using tasks/something asynchronous
            //System.Diagnostics.Debug.WriteLine("Loading template ...");

           	// All done loading
            //IsBusy = false;
            //System.Diagnostics.Debug.WriteLine("Template loaded.");
        }

        private void ExecuteExitApplicationCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteExitApplicationCommand in MainWindowVM.cs");
            messageBoxService.ShowError("Exit command not implemented.");
        }


        private void ExecuteShowPreferencesDialogCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteShowPreferencesDialogCommand in MainWindowVM.cs");
            messageBoxService.ShowError("Preferences not implemented");
        }


        private void ExecuteLaunchProjectWebsiteCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteLaunchProjectWebsiteCommand in MainWindowVM.cs");
            messageBoxService.ShowError("Launch project website not implemented.");
        }

        private void ExecuteShowAboutDialogCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteShowAboutDialogCommand in MainWindowVM.cs");
            messageBoxService.ShowError("About dialog not implemented.");
        }

        private bool AreThereItemsCommand(object parameter)
        {
            if (designerVM.ActiveTab.Items.Count > 0)
                return true;
            else return false;
        }

        private bool AreItemsSelectedCommand(object parameter)
        {
            if (designerVM.SelectedItem != null)
                return true;
            else return false;
        }

        private void ExecuteSelectDesignerItemCommand(object parameter)
        {
            var item = (DesignerItemBaseVM)parameter;
            designerVM.SelectedItem = item;
        }

        private void ExecuteMoveSelectedItemsUpCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteMoveSelectedItemsUpCommand in MainWindowVM.cs");
            selectedItems = DesignerVM.ActiveTab.SelectedItems;

            foreach (var selectedItem in selectedItems)
            {
                if (selectedItem.Top > 0) selectedItem.Top -= 1;
            }
        }
        
        private void ExecuteMoveSelectedItemsDownCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteMoveSelectedItemsDownCommand in MainWindowVM.cs");
            selectedItems = DesignerVM.ActiveTab.SelectedItems;

            foreach (var selectedItem in selectedItems)
            {
                if (selectedItem.Bottom < (DesignerVM.Height-1)) selectedItem.Top += 1;
            }
        }

        private void ExecuteMoveSelectedItemsLeftCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteMoveSelectedItemsLeftCommand in MainWindowVM.cs");
            selectedItems = DesignerVM.ActiveTab.SelectedItems;

            foreach (var selectedItem in selectedItems)
            {
                if (selectedItem.Left > 0) selectedItem.Left -= 1;
            }
        }

        private void ExecuteMoveSelectedItemsRightCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteMoveSelectedItemsRightCommand in MainWindowVM.cs");
            selectedItems = DesignerVM.ActiveTab.SelectedItems;

            foreach (var selectedItem in selectedItems)
            {
                if (selectedItem.Right < (DesignerVM.Width-1)) selectedItem.Left += 1;
            }
        }

        private void ExecuteDeleteSelectedItemsCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteDeleteSelectedItemsCommand in MainWindowVM.cs");
            selectedItems = DesignerVM.ActiveTab.SelectedItems;

            foreach (var selectedItem in selectedItems)
            {
                DesignerVM.ActiveTab.RemoveItemCommand.Execute(selectedItem);
            }
        }

        private void ExecuteToggleGroupOnSelectedItemsCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteToggleGroupOnSelectedItemsCommand in MainWindowVM.cs");
            messageBoxService.ShowError("ToggleGroupOnSelectedItems not implemented.");
            // equivalent to DesignerTabVM.SelectedItems property
            // since you can already move them as a group, is there utility to this function?
            
        }

        #endregion


        #region OTHER METHODS
        
        private Type GetTypeOfDesignerItem(DesignerItemBaseVM vmType)
        {
            //System.Diagnostics.Debug.WriteLine("Reached GetTypeOfDesignerItem in MainWindowVM.cs");
        	// Not quite sure I understand this; might be due to VM vs M confusion
            if (vmType is DesignerItemBaseVM) return typeof(DesignerItemBaseVM);
            if (vmType is FrameVM) return typeof(FrameVM);
            if (vmType is DI8449VM) return typeof(DI8449VM);
            if (vmType is GridVM) return typeof(GridVM);
            if (vmType is LabelVM) return typeof(LabelVM);
            if (vmType is RibbonVM) return typeof(RibbonVM);
                
            // Add additional item types here as you create them

            // Throw an exception if the item type is not supported
            throw new InvalidOperationException(string.Format("Unknown item type. Currently supported types include: {0}, {1}, {2}, {3}, {4}, {5}",
                typeof(DesignerItemBaseVM).AssemblyQualifiedName, 
                typeof(FrameVM).AssemblyQualifiedName,
                typeof(DI8449VM).AssemblyQualifiedName,
                typeof(GridVM).AssemblyQualifiedName,
                typeof(LabelVM).AssemblyQualifiedName,
                typeof(RibbonVM).AssemblyQualifiedName));
            
        }

        public void LoadSystemFonts()
        {
            systemFonts.Clear();
            var fonts = Fonts.SystemFontFamilies.OrderBy(f => f.ToString());
            foreach (var f in fonts)
                systemFonts.Add(f);
        }

        #endregion

    }
}
