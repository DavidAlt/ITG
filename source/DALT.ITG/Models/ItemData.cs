using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALT.ITG.Shared.Core;
using DALT.ITG.Interfaces;

namespace DALT.ITG.Models
{

    public abstract class ItemData : ObservableObject
    {
        protected static string _name;
        protected string _code;
        protected object _value;
        protected bool _isEnabled = false;

        protected abstract void Validate();

        public static string Name { get { return _name; } }
        
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        public virtual string Export()
        {
            if (_value == null)
                throw new ArgumentNullException("Value was null.");
            return (_code + "=" + _value);
        }
        
        public sealed override string ToString()
        {
            return Export();
        }
    }
}
