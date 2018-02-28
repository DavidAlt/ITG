using System.Windows;
using System.Windows.Input;
//using ITG.Desktop.DesignerItems;


namespace DALT.Controls.DesignerCanvas
{
    public static class DragAndDropAttachedProperties
    {
        #region EnabledForDrag
        public static readonly DependencyProperty EnabledForDragProperty =
            DependencyProperty.RegisterAttached("EnabledForDrag", typeof(bool), typeof(DragAndDropAttachedProperties),
                new FrameworkPropertyMetadata((bool)false,
                    new PropertyChangedCallback(OnEnabledForDragChanged)));

        public static bool GetEnabledForDrag(DependencyObject d)
        {
            return (bool)d.GetValue(EnabledForDragProperty);
        }

        public static void SetEnabledForDrag(DependencyObject d, bool value)
        {
            d.SetValue(EnabledForDragProperty, value);
        }

        private static void OnEnabledForDragChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement fe = (FrameworkElement)d;


            if ((bool)e.NewValue)
            {
                fe.PreviewMouseDown += Fe_PreviewMouseDown;
                fe.MouseMove += Fe_MouseMove;
            }
            else
            {
                fe.PreviewMouseDown -= Fe_PreviewMouseDown;
                fe.MouseMove -= Fe_MouseMove;
            }
        }
        #endregion



        #region DragStartPoint
        public static readonly DependencyProperty DragStartPointProperty =
            DependencyProperty.RegisterAttached("DragStartPoint", typeof(Point?), typeof(DragAndDropAttachedProperties));

        public static Point? GetDragStartPoint(DependencyObject d)
        {
            return (Point?)d.GetValue(DragStartPointProperty);
        }

        public static void SetDragStartPoint(DependencyObject d, Point? value)
        {
            d.SetValue(DragStartPointProperty, value);
        }
        #endregion



        static void Fe_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point? dragStartPoint = GetDragStartPoint((DependencyObject)sender);

            if (e.LeftButton != MouseButtonState.Pressed)
                dragStartPoint = null;

            if (dragStartPoint.HasValue)
            {
                DragObject dataObject = new DragObject();
                //dataObject.ContentType = (((FrameworkElement)sender).DataContext as ToolBoxItemType).Type;
                //dataObject.ContentType = (((FrameworkElement)sender).DataContext as DesignerItem).GetType();
                dataObject.ContentType = (((FrameworkElement)sender).DataContext.GetType()); // probably returns "DataContext" type or something
                
                // Ideally this would be dynamic, or determined from the item type - add DesiredSize properties to ToolBoxItemType? 
                // dataObject.DesiredSize = new Size(100, 20); // didn't seem to change the size of the item on the canvas ...
                System.Windows.DragDrop.DoDragDrop((DependencyObject)sender, dataObject, DragDropEffects.Copy);
                e.Handled = true;
            }
        }

        static void Fe_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetDragStartPoint((DependencyObject)sender, e.GetPosition((IInputElement)sender));
        }
    }
}