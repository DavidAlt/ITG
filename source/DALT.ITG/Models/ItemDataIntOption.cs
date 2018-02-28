using DALT.ITG.Interfaces;

namespace DALT.ITG.Models
{
    public class ItemDataIntOption : ItemData, IItemDataType<int>
    {
        public ItemDataIntOption(int value)
        {
            Value = value;
        }

        public int Value
        {
            get { return (int)_value; }
            set { SetProperty(ref _value, value); }
        }
    }
}
