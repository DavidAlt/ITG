using System;

namespace DALT.Utility
{
    public abstract class SharedViewModelBase : ViewModelBase
    {
        public static ViewModelBase SharedVM { get; private set; }

        public SharedViewModelBase(ViewModelBase sharedVM)
           : base() 
        {
            if (sharedVM == null)
                throw new ArgumentNullException("ViewModelBase sharedVM was null.");
            
            SharedVM = sharedVM;
        }
    }
    
}
