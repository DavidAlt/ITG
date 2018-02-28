using System;

namespace ITG.Models
{
    public class FormTemplateModel : ITG.ObservableObject
    {
        private string _templateName;
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
        

    }
}