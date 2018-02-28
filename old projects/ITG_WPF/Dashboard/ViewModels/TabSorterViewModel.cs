using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITG.ViewModels
{
    class TabSorterViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "TabSorter";
            }
        }
    }
}
