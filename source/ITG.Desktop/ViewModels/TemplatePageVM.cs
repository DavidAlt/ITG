using System.Collections.ObjectModel;
using DALT.Utility;
using ITG.Desktop.BaseClasses;

namespace ITG.Desktop.ViewModels
{
    public class TemplatePageVM : ViewModelBase
    {

        #region PUBLIC ACCESS

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ObservableCollection<TemplateItemBase> Items
        {
            get { return _items; }
        }

        #endregion


        #region FIELDS

        private string _name = "";
        private TemplateVM _parent;
        private ObservableCollection<TemplateItemBase> _items = new ObservableCollection<TemplateItemBase>();

        #endregion


        #region CONSTRUCTOR

        public TemplatePageVM(string name, TemplateVM parent)
            : base()
        {
            _name = name;
            _parent = parent;
        }

        #endregion

    }
}
