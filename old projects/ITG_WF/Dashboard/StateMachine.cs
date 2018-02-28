using System;
using System.Windows.Forms;
using ITG.DataLayer;

namespace Dashboard
{
      
    class StateMachine
    {
        public Control HomeView { get; set; }
        public Control ColorConverterView { get; set; }
        public Control TextConverterView { get; set; }
        public Control TabSorterView { get; set; }
        public Control TemplateView { get; set; }

        public FormTemplate CurrentTemplate { get; set; }

        public StateMachine()
        {
            // Views
            HomeView = null;
            ColorConverterView = null;
            TextConverterView = null;
            TabSorterView = null;
            TemplateView = null;

            // Other
            CurrentTemplate = new FormTemplate();
        }
    }
}
