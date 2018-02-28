using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ITG.Desktop.BaseClasses;

namespace ITG.Desktop.ViewModels
{
    public sealed class TemplateVM : CanvasItemBase
    {

        #region PUBLIC ACCESS

        public ICommand AddPageCommand { get; private set; }
        public ICommand RemovePageCommand { get; private set; }
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand SelectAllItemsCommand { get; private set; }
        public ICommand DeleteAllItemsCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
        public ICommand ImportCommand { get; private set; }
        public ICommand ExportCommand { get; private set; }

        public string TemplateName
        {
            get { return _templateName; }
            set { SetProperty(ref _templateName, value); }
        }
        public string TemplateOwner
        {
            get { return _templateOwner; }
            set { SetProperty(ref _templateOwner, value); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        public bool IsDirty
        {
            get { return _isDirty; }
            set { SetProperty(ref _isDirty, value); }
        }

        public ObservableCollection<TemplateItemBase> Items
        {
            get { return _currentPage.Items; }
        }

        public TemplateItemBase SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public ObservableCollection<TemplateItemBase> SelectedItems
        {
            get { return _selectedItems; }
        }

        #endregion


        #region FIELDS

        private readonly string _templateDesignerVersion = "1.1"; // pull from application settings
        private readonly string _templateOwnerType = "System";    // pull from application settings
        
        private string _templateName;
        private string _templateOwner;

        private bool _isBusy = false;
        private bool _isDirty = false;

        private TemplatePageVM _currentPage;
        private ObservableCollection<TemplatePageVM> _pages = new ObservableCollection<TemplatePageVM>();
        
        private TemplateItemBase _selectedItem;
        private ObservableCollection<TemplateItemBase> _selectedItems = new ObservableCollection<TemplateItemBase>();
        
        #endregion


        #region COMMAND IMPLEMENTATION        

        private void ExecuteAddPageCommand(object parameter)
        {
            _pages.Add((TemplatePageVM)parameter);
            IsDirty = true;
        }
        private bool CanExecuteAddPageCommand(object parameter)
        {
            if (parameter == null)
                return false;
            else
                return true;
        }

        private void ExecuteRemovePageCommand(object parameter)
        {
            _pages.Remove((TemplatePageVM)parameter);
            IsDirty = true;
        }
        private bool CanExecuteRemovePageCommand(object parameter)
        {
            if (parameter == null)
                return false;
            else
                return true;
        }

        private void ExecuteAddItemCommand(object parameter)
        {
            Items.Add((TemplateItemBase)parameter);
            IsDirty = true;
        }
        private bool CanExecuteAddItemCommand(object parameter)
        {
            if (_currentPage == null || parameter == null) 
                return false;
            else 
                return true;
        }

        private void ExecuteRemoveItemCommand(object parameter)
        {
            Items.Remove((TemplateItemBase)parameter);
            IsDirty = true;
        }
        private bool CanExecuteRemoveItemCommand(object parameter)
        {
            if (_currentPage == null || parameter == null)
                return false;
            else 
                return true;
        }

        private void ExecuteSelectAllItemsCommand(object parameter) 
        {
            foreach (TemplateItemBase item in Items)
                _selectItem(item);
        }
        private bool CanExecuteSelectAllItemsCommand(object parameter)
        { return (Items.Count != 0) ? true : false; }

        private void ExecuteDeleteAllItemsCommand(object parameter) 
        {
            Items.Clear();
            IsDirty = true;
        }
        private bool CanExecuteDeleteAllItemsCommand(object parameter)
        { return (Items.Count != 0) ? true : false; }

        private void ExecuteSaveCommand(object parameter) { IsDirty = false; }
        private bool CanExecuteSaveCommand(object parameter) { return true; }

        private void ExecuteLoadCommand(object parameter) { IsDirty = false; }
        private bool CanExecuteLoadCommand(object parameter) { return true; }

        private void ExecuteImportCommand(object parameter) { IsDirty = false; }
        private bool CanExecuteImportCommand(object parameter) { return true; }

        private void ExecuteExportCommand(object parameter) { IsDirty = false; }
        private bool CanExecuteExportCommand(object parameter) { return true; }

        #endregion


        #region METHODS

        private void _selectItem(TemplateItemBase item)
        {
            if (!item.IsSelected)
                item.IsSelected = true;
            if (!SelectedItems.Contains(item))
                SelectedItems.Add(item);
        }

        private void _deselectItem(TemplateItemBase item)
        {
            if (item.IsSelected)
                item.IsSelected = false;
            if (SelectedItems.Contains(item))
                SelectedItems.Remove(item);
        }

        private void _addTemplatePage(TemplatePageVM page)
        { 
            _pages.Add(page); 
        }

        private void _removeTemplatePage(TemplatePageVM page) 
        {
            if (_pages.Contains(page))
                _pages.Remove(page);
        }

        private void _addTemplateItem(TemplateItemBase item) 
        {
            Items.Add(item);
        }

        private void _removeTemplateItem(TemplateItemBase item) 
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }

        private void _save() { }
        private void _load() { }
        private void _import() { }
        private void _export() { }

        #endregion


        #region SINGLETON SETUP

        // Instance created when first accessed
        private static readonly TemplateVM _instance = new TemplateVM();

        // Provide access to the singleton instance
        public static TemplateVM Instance { get { return _instance; } }

        static TemplateVM() { }

        private TemplateVM()
            : base()
        {
            Init();
        }

        private void Init()
        {
            // apply a default size
            Width = 700;
            Height = 700;

            // apply size constraints
            _constraints = new SizeConstraints(600, 2000, 400, 3000);
            Constrained = true;

            // setup the pages
            _pages.Add(new TemplatePageVM("Resources", this)); // by default will be at index 0
            _pages.Add(new TemplatePageVM("Tab 1", this));
            _currentPage = _pages[1];

            // setup commands
        }

        #endregion
    }
}
