using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ITG.Helper;
using ITG.Desktop.Services;
using ITG.Desktop.DesignerItems;
using System.IO;
using DALT.Utility;


namespace ITG.Desktop.Designer
{
    public class DesignerTabVM : ViewModelBase
    {

        #region Members
        private string name;
        private ObservableCollection<DesignerItemBaseVM> items = new ObservableCollection<DesignerItemBaseVM>();
        private DesignerItemBaseVM selectedItem;

        #endregion


        #region Constructor

        public DesignerTabVM(DesignerVM parent)
        {
            ParentForm = parent;

            AddItemCommand = new MyCommand(ExecuteAddItemCommand);
            RemoveItemCommand = new MyCommand(ExecuteRemoveItemCommand);
            RemoveSelectedItemsCommand = new MyCommand(ExecuteRemoveSelectedItemsCommand);
            ClearSelectedItemsCommand = new MyCommand(ExecuteClearSelectedItemsCommand);
            ExportItemsCommand = new MyCommand(ExecuteExportItemsCommand);

            Mediator.Instance.Register(this);
        }

        #endregion


        #region Properties

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        // reference to parent designer - set in DesignerVM.ExecuteAddItemCommand
        public DesignerVM ParentForm { get; set; }

        public int Index
        {
            get
            {
                //if (ParentForm != null)
                //    return ParentForm.Tabs.IndexOf(this);
                //else return -99;
                //DesignerTabVM me = this;
                return ParentForm.Tabs.IndexOf(this);
                //System.Console.WriteLine(ParentForm.Tabs.Count);
                // it's choking on ParentForm.Tabs / null exception
                // and didn't print anything when ParentForm was called, but also didn't throw exception
                //return -99;
            }
        }

        public DesignerItemBaseVM SelectedItem
        {
            get
            {   // untested code
                if (SelectedItems.Count > 1)
                    return SelectedItems[0];
                else
                    return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                }
            }
        }

        public ObservableCollection<DesignerItemBaseVM> Items
        {
            get { return items; }
        }

        public List<DesignerItemBaseVM> SelectedItems
        {
            get { return Items.Where(x => x.IsSelected).ToList(); }
        }

        #endregion


        #region Commands

        public MyCommand AddItemCommand { get; private set; }
        public MyCommand RemoveItemCommand { get; private set; }
        public MyCommand RemoveSelectedItemsCommand { get; private set; }
        public MyCommand ClearSelectedItemsCommand { get; private set; }
        public MyCommand CreateNewFormTemplateCommand { get; private set; }
        public MyCommand ExportItemsCommand { get; private set; }


        private void ExecuteAddItemCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteAddItemCommand in DesignerTabVM.cs");
            if (parameter is DesignerItemBaseVM)
            {
                DesignerItemBaseVM item = (DesignerItemBaseVM)parameter;
                item.ParentTab = this;
                item.ParentForm = this.ParentForm;
                if (item.IsMedcinItem)
                {
                    // force user to assign a MedcinTerm
                    ChooseMedcinTermDialog dlg = new ChooseMedcinTermDialog(item);
                    if (dlg.ShowDialog() == false)
                    {
                        // user canceled
                        return;
                    }
                    else
                    {
                        // item has a Medcin code (presumably)
                    }
                    
                }
                items.Add(item);
            }
        }

        private void ExecuteRemoveItemCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteRemoveItemCommand in DesignerTabVM.cs");
            if (parameter is DesignerItemBaseVM)
            {
                DesignerItemBaseVM item = (DesignerItemBaseVM)parameter;
                if (SelectedItem == item) SelectedItem = null;
                items.Remove(item);
            }
        }

        private void ExecuteRemoveSelectedItemsCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteRemoveSelectedItemsCommand in DesignerTabVM.cs");
            foreach (var selectedItem in SelectedItems)
            {
                ExecuteRemoveItemCommand(selectedItem);
            }
        }

        private void ExecuteClearSelectedItemsCommand(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("Reached ExecuteClearSelectedItemsCommand in DesignerTabVM.cs");
            foreach (DesignerItemBaseVM item in Items)
            {
                item.IsSelected = false;
            }
            SelectedItem = null;
        }

        private void ExecuteExportItemsCommand(object parameter)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("test.txt"))
                {
                    foreach (var item in Items)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception thrown: ");
                System.Console.WriteLine(e.Message);
            }
        }

        #endregion


        #region Methods
        
        public void ClearSelection()
        {
            foreach (DesignerItemBaseVM item in Items)
            {
                item.IsSelected = false;
            }
            SelectedItem = null;
        }

        public string Export()
        {
            using (StringWriter sw = new StringWriter())
            {
                foreach (var item in Items)
                {
                    sw.WriteLine(item);
                }
                return sw.ToString();
            }
        }

        // not currently used
        public bool ValidateItems()
        {
            return true;
        }

        
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
