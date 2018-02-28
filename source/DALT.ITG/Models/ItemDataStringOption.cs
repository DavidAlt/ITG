using DALT.ITG.Interfaces;

namespace DALT.ITG.Models
{
    public class ItemDataStringOption : ItemData, IItemDataType<string>
    {
        public ItemDataStringOption(string value)
        {
            Value = value;
        }

        public string Value
        {
            get { return (string)_value; }
            set { SetProperty(ref _value, value); }
        }
    }
}
