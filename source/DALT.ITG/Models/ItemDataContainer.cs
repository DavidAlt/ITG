using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DALT.ITG.Shared.Utilities;
using DALT.ITG.Interfaces;
using System.Collections.Generic;

namespace DALT.ITG.Models
{
    public class ItemDataContainer
    {
        private IList<ItemData> _options = new ObservableCollection<ItemData>();
        // might be better to use a dictionary<string=typename, object=ItemDataOption>
        // private IDictionary<string, ItemDataOption> _options = new Dictionary<string, ItemDataOption>();

        public void Add(params ItemData[] options)
        {
            foreach (ItemData option in options)
            {
                if (option == null)
                    throw new ArgumentNullException("ItemDataOption was null.");
                // IMPLEMENT: check if _options contains duplicate type
                //if (_options.ToList().Exists(x => x.Name == "ObjectId"))
                    // performance heavy?
                _options.Add(option);
            }            
        }

        public void Remove(ItemData option)
        {
            if (option == null)
                throw new ArgumentNullException("ItemDataOption option was null.");
            if (_options.Contains(option)) // likewise not effective - needs to operate on type
                _options.Remove(option);
        }

        public void Import(string[] source)
        {
            // parse the strings into new ItemDataOptions ... sensing stupidly large switch upcoming
            foreach (string s in source)
            {
                // does it match a known option?
                // is the value valid?
            }
        }

        public string Export(string delimiter = "|") // default; Tabstrip uses ":"
        {
            if (_options == null || !_options.Any()) // list is null or empty
                throw new InvalidOperationException("List of options is either null or empty.");

            StringBuilder sb = new StringBuilder();
            foreach (ItemData option in _options)
            {
                if (_options.IndexOf(option) == _options.Count - 1) // last item
                    sb.Append(option);
                else
                    sb.Append(option + delimiter);
            }
            return sb.ToString().QuoteWrap();
        }

        public override string ToString()
        {
            return Export();
        }

       

        private void _sort()
        {
            // ensure ObjectId/N= is first, Logic/L= is last
        }


        #region CONSTRUCTORS

        public ItemDataContainer()
        { }

        public ItemDataContainer(ObservableCollection<ItemData> options)
        {
            _options = options;
        }

        #endregion
    }
}

/*

#Region "Enums and Flags"

    
    End Enum

    

    <FlagsAttribute>
    Enum LinkOption
        fc_FIRE_WHEN_LOGIC_TRUE = 1
        fc_RAISE_MESSAGE_WHEN_LOGIC_TRUE = 2
        fc_IS_USER_BUTTON = 4
        fc_IS_AUTONEG_BUTTON = 8
        fc_IS_AUTOPOS_BUTTON = 16
        fc_IS_NEGBLOCK_BUTTON = 32
        fc_IS_POSBLOCK_BUTTON = 64
        fc_IS_FLOWSHEET_BUTTON = 128
        fc_IS_REFERENCE_BUTTON = 256
    End Enum

    

    <FlagsAttribute>
    Enum PictureOption
        fc_IS_IMAGER_COMPONENT = 2
        fc_SET_POSITIVE_ON_CLICK = 4
        fc_SET_NEGATIVE_ON_CLICK = 8
        fc_SET_PREFIX_ON_CLICK = 16
        fc_SET_VALUE_ON_CLICK = 32
    End Enum

    <FlagsAttribute>
    Enum ListOption
        fc_LIST_ALLOW_NODE_EXPANSION = 2
        fc_LIST_LOGIC = 4 ' disabled=0, enabled=1
        fc_LIST_DISABLE_UNTIL_LOGIC_TRUE = 8
        fc_LIST_ACTIVATE_WHEN_LOGIC_TRUE = 16
        fc_TREEVIEW_RELOCATE_ORIGIN_RELATIVE_OBJECT = 32
        fc_LIST_SORT_INLINE_CAPTIONS = 64
        fc_LISTVIEW_USE_COLOR = 128
        fc_LISTVIEW_AUTO_RESIZE_COLUMNS = 256
    End Enum

    

#End Region


*/