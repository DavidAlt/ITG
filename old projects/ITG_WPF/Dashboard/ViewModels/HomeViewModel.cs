using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITG;

namespace ITG.ViewModels
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
    }
}