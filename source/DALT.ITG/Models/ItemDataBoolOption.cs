using System;
using DALT.ITG.Interfaces;

namespace DALT.ITG.Models
{
    public class ItemDataBoolOption : ItemData, IItemDataType<bool>
    {
        public ItemDataBoolOption(bool value)
        {
            Value = value;
        }

        public bool Value
        {
            get { return (bool)_value; }
            set { SetProperty(ref _value, value); }
        }

        public sealed override string Export()
        {
            if (_value == null)
                throw new ArgumentNullException("Value was null.");
            string boolResult;
            if (Value)
                boolResult = "T";
            else
                boolResult = "F";
            return (_code + "=" + boolResult);
        }
    }
}
