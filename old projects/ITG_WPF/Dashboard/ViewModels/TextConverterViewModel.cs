using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.ViewModels
{
    class TextConverterViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Text Converter";
            }
        }
    }
}
