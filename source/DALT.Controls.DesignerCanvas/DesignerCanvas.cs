using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
//using ITG.Desktop.DragAndDrop;
//using ITG.Desktop.Services;
//using ITG.Desktop.DesignerItems;

namespace DALT.Controls.DesignerCanvas
{
    public class DesignerCanvas : Canvas
    {
        static DesignerCanvas()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DesignerCanvas), 
                new FrameworkPropertyMetadata(typeof(DesignerCanvas)));
        }

        public DesignerCanvas()
        {
            this.AllowDrop = true;
            this.Focusable = true;
            //Mediator.Instance.Register(this);
        }

        private Point? rubberbandSelectionStartPoint = null;

        
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                /*
                // if the canvas ("this") is the source of the event, assume rubberband selecting
                if (e.Source == this)
                {
                    // cache the start point
                    rubberbandSelectionStartPoint = e.GetPosition(this);

                    // unless holding down control, clear the selection
                    DesignerVM dc = (DataContext as DesignerVM);
                    if (!(Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
                        dc.ActiveTab.ClearSelection();
                  */  
                    e.Handled = true;
            } 
        }



        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            //Mediator.Instance.NotifyColleagues<bool>("DoneDrawingMessage", true);
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            /*
                // if mouse button is not pressed we have no drag operation, ...
                if (e.LeftButton != MouseButtonState.Pressed)
                    rubberbandSelectionStartPoint = null;

                // ... but if mouse button is pressed and start
                // point value is set we do have one
                if (this.rubberbandSelectionStartPoint.HasValue)
                {
                    // create rubberband adorner
                    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                    if (adornerLayer != null)
                    {
                        RubberbandAdorner adorner = new RubberbandAdorner(this, rubberbandSelectionStartPoint);
                        if (adorner != null)
                            adornerLayer.Add(adorner);
                    }
                } */
            e.Handled = true;
        }


        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();

            foreach (UIElement element in this.InternalChildren)
            {
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                left = double.IsNaN(left) ? 0 : left; //evaluate if "left" is not a number; if evaluates true, return 0, else return left
                top = double.IsNaN(top) ? 0 : top;

                //measure desired size for each child
                element.Measure(constraint);

                Size desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }
            return size;
        }


        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
/*
            DragObject dragObject = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (dragObject != null)
            {
                DesignerVM dc = (DataContext as DesignerVM);
                dc.ActiveTab.ClearSelection();
                Point position = e.GetPosition(this);
                DesignerItemBaseVM item = (DesignerItemBaseVM)Activator.CreateInstance(dragObject.ContentType);
                item.Left = Math.Max(0, position.X - item.Width / 2); // want drop point to be upper left corner, not center of item
                item.Top = Math.Max(0, position.Y - item.Height / 2);
                item.IsSelected = true;
                dc.ActiveTab.AddItemCommand.Execute(item);
                dc.ActiveTab.SelectedItem = item;
                // Give the DesignerCanvas focus so it can receive arrow key presses
                this.Focus();
            } */
            e.Handled = true;
        }
    }
}