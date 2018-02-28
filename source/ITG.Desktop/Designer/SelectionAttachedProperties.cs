using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ITG.Desktop.DesignerItems;

namespace ITG.Desktop.Designer
{
    public static class SelectionAttachedProperties
    {

        #region EnabledForSelection

        public static readonly DependencyProperty EnabledForSelectionProperty =
            DependencyProperty.RegisterAttached("EnabledForSelection", typeof(bool), typeof(SelectionAttachedProperties),
                new FrameworkPropertyMetadata((bool)false,
                    new PropertyChangedCallback(OnEnabledForSelectionChanged)));


        public static bool GetEnabledForSelection(DependencyObject d)
        {
            return (bool)d.GetValue(EnabledForSelectionProperty);
        }


        public static void SetEnabledForSelection(DependencyObject d, bool value)
        {
            d.SetValue(EnabledForSelectionProperty, value);
        }


        private static void OnEnabledForSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement fe = (FrameworkElement)d;
            if ((bool)e.NewValue)
            {
                fe.PreviewMouseDown += Fe_PreviewMouseDown;
            }
            else
            {
                fe.PreviewMouseDown -= Fe_PreviewMouseDown;
            }
        }

        #endregion


        static void Fe_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((e.LeftButton == MouseButtonState.Pressed) || (e.RightButton == MouseButtonState.Pressed))
            {
                DesignerItemBaseVM item = (DesignerItemBaseVM)((FrameworkElement)sender).DataContext;

                if (item != null)
                {
                    if ((Keyboard.Modifiers & (ModifierKeys.Control)) != ModifierKeys.None)
                    {
                        item.IsSelected = !item.IsSelected;
                    }
                    else if (!item.IsSelected) // item clicked on was NOT selected and no modifier keys were used
                    {
                        foreach (DesignerItemBaseVM i in item.ParentTab.SelectedItems)
                            i.IsSelected = false; // for items in selected list, turn their IsSelected flag off

                        item.ParentTab.SelectedItems.Clear(); // empty the selected items list
                        item.IsSelected = true; // mark this item as selected
                        item.ParentTab.SelectedItem = item; // set the parent's SelectedItem to this object
                    }
                }
            }
        }

    }
}