using System.Windows.Input;
using ITG;
using ITG.Models;
using ITG.ViewModels;
using ITG.Views;

namespace ITG.ViewModels
{
    public class FormTemplateViewModel : ObservableObject, IPageViewModel
    {
        #region Fields

        private string _templateName;
        private FormTemplateModel _currentTemplate;
        private ICommand _getTemplateCommand;
        private ICommand _saveTemplateCommand;

        #endregion

        #region Public Properties/Commands

        public FormTemplateModel CurrentTemplate
        {
            get { return _currentTemplate; }
            set
            {
                if (value != _currentTemplate)
                {
                    _currentTemplate = value;
                    OnPropertyChanged("CurrentTemplate");
                }
            }
        }

        public ICommand SaveTemplateCommand
        {
            get
            {
                if (_saveTemplateCommand == null)
                {
                    _saveTemplateCommand = new RelayCommand(
                        param => SaveTemplate(),
                        param => (CurrentTemplate != null)
                    );
                }
                return _saveTemplateCommand;
            }
        }

        public ICommand GetTemplateCommand
        {
            get
            {
                if (_getTemplateCommand == null)
                {
                    _getTemplateCommand = new RelayCommand(
                        param => GetTemplate(),
                        // param => ProductId > 0
                        param => true
                    );
                }
                return _getTemplateCommand;
            }
        }

        public string Name
        {
            get { return "FormTemplateViewModel";  }
        }
        
        public string TemplateName
        {
            get { return _templateName; }
            set
            {
                if (value != _templateName)
                {
                    _templateName = value;
                    OnPropertyChanged("TemplateName");
                }
            }
        }

        #endregion

        #region Private Helpers

        private void GetTemplate()
        {
            // You should get the product from the database
            // but for now we'll just return a new object
            FormTemplateModel ft = new FormTemplateModel();
            ft.TemplateName = "Template Name";
            CurrentTemplate = ft;
        }

        private void SaveTemplate()
        {
            // You would implement your Template save here
        }

        #endregion
    }
}
