using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DALT.Controls.DesignerCanvas
{
    public class DesignerItem : ContentPresenter
    {
        #region DependencyProperty: X
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register(
            "X",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnXChanged)));

        private static void OnXChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static double GetX(DependencyObject obj)
        {
            return (double)obj.GetValue(XProperty);
        }

        public static void SetX(DependencyObject obj, double value)
        {
            obj.SetValue(XProperty, value);
        }

        public double X
        {
            get { return GetX(this); }
            set { SetX(this, value); }
        }

        #endregion

        #region DependencyProperty: Y
        public static readonly DependencyProperty YProperty = 
            DependencyProperty.Register(
            "Y",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnYChanged)));

        private static void OnYChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
 	        throw new NotImplementedException();
        }

        public static double GetY(DependencyObject obj)
        {
            return (double)obj.GetValue(YProperty);
        }

        public static void SetY(DependencyObject obj, double value)
        {
            obj.SetValue(YProperty, value);
        }

        public double Y
        {
            get { return GetY(this); }
            set { SetY(this, value); }
        }

        #endregion

        /*
        #region DependencyProperty: Width
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register(
            "Width",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnWidthChanged)));

        private static void OnWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        public static double GetWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(WidthProperty);
        }

        public static void SetWidth(DependencyObject obj, double value)
        {
            obj.SetValue(WidthProperty, value);
        }
        #endregion
        
        #region DependencyProperty: MinimumWidth
        public static readonly DependencyProperty MinimumWidthProperty =
            DependencyProperty.Register(
            "MinimumWidth",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnMinimumWidthChanged)));

        private static void OnMinimumWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static double GetMinimumWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(MinimumWidthProperty);
        }

        public static void SetMinimumWidth(DependencyObject obj, double value)
        {
            obj.SetValue(MinimumWidthProperty, value);
        }
        #endregion

        #region DependencyProperty: MaximumWidth
        public static readonly DependencyProperty MaximumWidthProperty =
            DependencyProperty.Register(
            "MaximumWidth",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnMaximumWidthChanged)));

        private static void OnMaximumWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static double GetMaximumWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(MaximumWidthProperty);
        }

        public static void SetMaximumWidth(DependencyObject obj, double value)
        {
            obj.SetValue(MaximumWidthProperty, value);
        }
        #endregion

        #region DependencyProperty: Height
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register(
            "Height",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnHeightChanged)));

        private static void OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }

        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }
        #endregion

        #region DependencyProperty: MinimumHeight
        public static readonly DependencyProperty MinimumHeightProperty =
            DependencyProperty.Register(
            "MinimumHeight",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnMinimumHeightChanged)));

        private static void OnMinimumHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static double GetMinimumHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(MinimumHeightProperty);
        }

        public static void SetMinimumHeight(DependencyObject obj, double value)
        {
            obj.SetValue(MinimumHeightProperty, value);
        }
        #endregion

        #region DependencyProperty: MaximumHeight
        public static readonly DependencyProperty MaximumHeightProperty =
            DependencyProperty.Register(
            "MaximumHeight",
            typeof(double),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((double)0, new PropertyChangedCallback(OnMaximumHeightChanged)));

        private static void OnMaximumHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static double GetMaximumHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(MaximumHeightProperty);
        }

        public static void SetMaximumHeight(DependencyObject obj, double value)
        {
            obj.SetValue(MaximumHeightProperty, value);
        }
        #endregion
         */

        #region DependencyProperty: EnabledForSelection
        public static readonly DependencyProperty EnabledForSelectionProperty =
            DependencyProperty.Register(
            "EnabledForSelection", 
            typeof(bool), 
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnEnabledForSelectionChanged)));

        private static void OnEnabledForSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static bool GetEnabledForSelection(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnabledForSelectionProperty);
        }

        public static void SetEnabledForSelection(DependencyObject obj, bool value)
        {
            obj.SetValue(EnabledForSelectionProperty, value);
        }

        public bool EnabledForSelection
        {
            get { return GetEnabledForSelection(this); }
            set { SetEnabledForSelection(this, value); }
        }

        #endregion

        #region DependencyProperty: IsSelected
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(
            "IsSelected",
            typeof(bool),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnIsSelectedChanged)));

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static bool GetIsSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSelectedProperty);
        }

        public static void SetIsSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSelectedProperty, value);
        }

        public bool IsSelected
        {
            get { return GetIsSelected(this); }
            set { SetIsSelected(this, value); }
        }
        #endregion

        #region DependencyProperty: ParentDesigner
        public static readonly DependencyProperty ParentDesignerProperty =
            DependencyProperty.Register(
            "ParentDesigner",
            typeof(DesignerCanvas),
            typeof(DesignerItem),
            new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnParentDesignerChanged)));

        private static void OnParentDesignerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static DesignerCanvas GetParentDesigner(DependencyObject obj)
        {
            return (DesignerCanvas)obj.GetValue(ParentDesignerProperty);
        }

        public static void SetParentDesigner(DependencyObject obj, DesignerCanvas value)
        {
            obj.SetValue(ParentDesignerProperty, value);
        }

        public DesignerCanvas ParentDesigner
        {
            get { return GetParentDesigner(this); }
            set { SetParentDesigner(this, value); }
        }
        #endregion

        /*
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

        /*
        public static bool GetEnabledForSelection
        {
            get { return (bool)GetValue(EnabledForSelectionProperty); }
            set { SetValue(GetEnabledForSelectionProperty, value); }
        }
        
        PropertyMetadata ageMetadata =
        new PropertyMetadata(
            18,     // Default value
            new PropertyChangedCallback(OnAgeChanged),
            new CoerceValueCallback(OnAgeCoerceValue));
 
        public string MyCustom
        {
            get
            {
                return this.GetValue(MyCustomProperty) as string;
            }
            set
            {
                this.SetValue(MyCustomProperty, value);
            }
        }
        */

    }
}
