using System.Collections.ObjectModel;
using DALT.ITG.Shared.Core;

namespace DALT.ITG.ViewModels
{
    public class TemplatePageVM : ObservableObject
    {

        #region Fields

        private string _name = "";
        private TemplateVM _parent;
        private ObservableCollection<TemplateItemVM> _items = new ObservableCollection<TemplateItemVM>();

        #endregion


        #region Properties

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ObservableCollection<TemplateItemVM> Items
        {
            get { return _items; }
        }

        #endregion


        #region CONSTRUCTOR

        public TemplatePageVM(string name, TemplateVM parent)
        {
            _name = name;
            _parent = parent;
        }

        #endregion

    }
}
