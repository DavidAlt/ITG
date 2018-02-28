using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

//using ITG.Desktop.DesignerItems;
using DALT.Utility;


namespace DALT.Controls.DesignerCanvas
{
    public class RubberbandAdorner : Adorner
    {
        #region FIELDS

        private Point? startPoint;
        private Point? endPoint;
        private Pen rubberbandPen;
        private DesignerCanvas designerCanvas;

        #endregion


        #region CONSTRUCTOR

        public RubberbandAdorner(DesignerCanvas designerCanvas, Point? dragStartPoint)
            : base(designerCanvas)
        {
            this.designerCanvas = designerCanvas;
            this.startPoint = dragStartPoint;
            rubberbandPen = new Pen(Brushes.LightSlateGray, 1);
            rubberbandPen.DashStyle = new DashStyle(new double[] { 2 }, 1);
        }

        #endregion


        #region METHODS

        protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!this.IsMouseCaptured)
                    this.CaptureMouse();

                endPoint = e.GetPosition(this);
                UpdateSelection(); // flag captured items as selected
                this.InvalidateVisual(); // this makes the rubber band actually appear
            }
            else
            {
                if (this.IsMouseCaptured) this.ReleaseMouseCapture();
            }

            e.Handled = true;
        }

        private void UpdateSelection()
        {
            /*
            DesignerVM vm = (designerCanvas.DataContext as DesignerVM);
            Rect rubberBand = new Rect(startPoint.Value, endPoint.Value);
            ItemsControl itemsControl = TreeHelper.TryFindParent<ItemsControl>(designerCanvas);

            int i = 0;

            foreach (DesignerItemBaseVM item in vm.ActiveTab.Items)
            {
                if (item is DesignerItemBaseVM)
                {
                    DependencyObject container = itemsControl.ItemContainerGenerator.ContainerFromItem(item);

                    Rect itemRect = VisualTreeHelper.GetDescendantBounds((Visual)container);
                    Rect itemBounds = ((Visual)container).TransformToAncestor(designerCanvas).TransformBounds(itemRect);

                    if (rubberBand.Contains(itemBounds))
                    {
                        item.IsSelected = true;
                        // IMPROVE: following always selects first item as ordered in the list, rather than the first
                        //          item encountered by the rubber band selector
                        if (i == 0) vm.ActiveTab.SelectedItem = item;
                        i++;
                    }
                    else
                    {
                        if (!(Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                        {
                            item.IsSelected = false;
                        }
                    }
                }
            } */
        }

        protected override void OnMouseUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            // release mouse capture
            if (this.IsMouseCaptured) this.ReleaseMouseCapture();

            // remove this adorner from adorner layer
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.designerCanvas);
            if (adornerLayer != null)
                adornerLayer.Remove(this);

            e.Handled = true;
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            // without a background the OnMouseMove event would not be fired !
            // Alternative: implement a Canvas as a child of this adorner, like
            // the ConnectionAdorner does.
            dc.DrawRectangle(Brushes.Transparent, null, new Rect(RenderSize));

            if (this.startPoint.HasValue && this.endPoint.HasValue)
                dc.DrawRectangle(Brushes.Transparent, rubberbandPen, new Rect(this.startPoint.Value, this.endPoint.Value));
        }

        #endregion
    }
}