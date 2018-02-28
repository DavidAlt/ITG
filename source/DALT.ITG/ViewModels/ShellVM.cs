using DALT.ITG.Shared.Core;

namespace DALT.ITG.ViewModels
{
    public class ShellVM : ObservableObject
    {

        #region PUBLIC ACCESS

        // MENU - FILE
        public RelayCommand NewCommand { get; private set; }
        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand SaveAsCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }

        // MENU - EDIT
        public RelayCommand CutCommand { get; private set; }
        public RelayCommand CopyCommand { get; private set; }
        public RelayCommand PasteCommand { get; private set; }
        public RelayCommand SelectAllCommand { get; private set; }
        public RelayCommand DeselectAllCommand { get; private set; }
        public RelayCommand FindCommand { get; private set; }

        // MENU - HELP
        public RelayCommand HelpCommand { get; private set; }
        public RelayCommand AboutCommand { get; private set; }

        #endregion


        #region FIELDS

        private TemplateVM _template = TemplateVM.Instance;
                
        #endregion


        #region COMMAND IMPLEMENTATION - EMPTY

        
        #endregion


        #region METHODS - EMPTY

        #endregion


        #region SINGLETON SETUP

        // Instance created when first accessed
        private static readonly ShellVM _instance = new ShellVM();

        // Provide access to the singleton instance
        public static ShellVM Instance { get { return _instance; } }

        static ShellVM() { }

        private ShellVM()
            : base()
        {
            Init();
        }

        private void Init()
        {
            // setup commands
        }

        #endregion


        






    }
}