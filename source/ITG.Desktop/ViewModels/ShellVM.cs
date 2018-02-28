
using DALT.Utility;

namespace ITG.Desktop.ViewModels
{
    public class ShellVM : ViewModelBase
    {

        #region PUBLIC ACCESS

        // MENU - FILE
        public MyCommand NewCommand { get; private set; }
        public MyCommand OpenCommand { get; private set; }
        public MyCommand SaveCommand { get; private set; }
        public MyCommand SaveAsCommand { get; private set; }
        public MyCommand CloseCommand { get; private set; }
        public MyCommand ExitCommand { get; private set; }

        // MENU - EDIT
        public MyCommand CutCommand { get; private set; }
        public MyCommand CopyCommand { get; private set; }
        public MyCommand PasteCommand { get; private set; }
        public MyCommand SelectAllCommand { get; private set; }
        public MyCommand DeselectAllCommand { get; private set; }
        public MyCommand FindCommand { get; private set; }

        // MENU - HELP
        public MyCommand HelpCommand { get; private set; }
        public MyCommand AboutCommand { get; private set; }

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