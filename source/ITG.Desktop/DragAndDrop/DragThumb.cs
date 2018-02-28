using System;
using System.Linq;
using System.Windows.Controls.Primitives;
using ITG.Desktop.Designer;
using ITG.Desktop.DesignerItems;

namespace ITG.Desktop.DragAndDrop
{
    public class DragThumb : Thumb
    {
        public DragThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(DragThumb_DragDelta);
        }

        void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // Set up the data sources we'll need to work with
            DesignerItemBaseVM sourceItem = this.DataContext as DesignerItemBaseVM;
            DesignerVM vm = sourceItem.ParentForm;

            // Make sure something exists and is selected
            if (sourceItem != null && sourceItem.IsSelected)
            {
                // Set up the selected items
                var selectedItems = vm.ActiveTab.SelectedItems;

                double minLeft = double.MaxValue;
                double minTop = double.MaxValue;

                /*
                // if more than one item is selected, treat them as a group - 
                // when one stops moving, they all do
                double TopmostItemTop = vm.Height;
                double LeftmostItemLeft = 0;
                double RightmostItemLeft = 0;
                double BottomMostItemTop = 0;
                
                if (vm.SelectedItems.Count > 1)
                {
                    foreach (DesignerItemBaseVM item in selectedItems.OfType<DesignerItemBaseVM>())
                    {

                        if (item.Top < TopmostItemTop) TopmostItemTop = item.Top;
                        if (item.Left < LeftmostItemLeft) LeftmostItemLeft = item.Left;
                        if (item.Top > BottomMostItemTop) BottomMostItemTop = item.Top;
                        if (item.Left < RightmostItemLeft) RightmostItemLeft = item.Left;
                        
                    }
                    System.Console.WriteLine("Extreme edges: Top({0}), Left({1}), Right({2}), Bottom({3})", TopmostItemTop, LeftmostItemLeft, RightmostItemLeft, BottomMostItemTop);
                } */

                foreach (DesignerItemBaseVM item in selectedItems.OfType<DesignerItemBaseVM>())
                {                    
                    double maxItemLeft = vm.Width - item.Width;
                    double maxItemTop = vm.Height - item.Height;
                    
                    minLeft = double.IsNaN(item.Left) ? 0 : Math.Min(item.Left, minLeft);
                    minTop = double.IsNaN(item.Top) ? 0 : Math.Min(item.Top, minTop);


                    double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
                    double deltaVertical = Math.Max(-minTop, e.VerticalChange);

                    double desiredLeft = item.Left + deltaHorizontal;
                    double desiredTop = item.Top + deltaVertical;
                     
                    
                    if (desiredLeft > maxItemLeft) item.Left = maxItemLeft;
                    else item.Left += deltaHorizontal;

                    if (desiredTop > maxItemTop) item.Top = maxItemTop;
                    else item.Top += deltaVertical;
                }
                e.Handled = true;
            }
        }
    }
}

/* http://www.codeproject.com/Articles/15354/Dragging-Elements-in-a-Canvas
protected override void OnPreviewMouseMove( MouseEventArgs e )
{
 base.OnPreviewMouseMove( e );

 // If no element is being dragged, there is nothing to do.
 if( this.ElementBeingDragged == null || !this.isDragInProgress )
  return;

 // Get the position of the mouse cursor, relative to the Canvas.
 Point cursorLocation = e.GetPosition( this );

 // These values will store the new offsets of the drag element.
 double newHorizontalOffset, newVerticalOffset;

 #region Calculate Offsets

 // Determine the horizontal offset.
 if( this.modifyLeftOffset )
  newHorizontalOffset = 
    this.origHorizOffset + (cursorLocation.X - this.origCursorLocation.X);
 else
  newHorizontalOffset = 
    this.origHorizOffset - (cursorLocation.X - this.origCursorLocation.X);

 // Determine the vertical offset.
 if( this.modifyTopOffset )
  newVerticalOffset = 
    this.origVertOffset + (cursorLocation.Y - this.origCursorLocation.Y);
 else
  newVerticalOffset = 
    this.origVertOffset - (cursorLocation.Y - this.origCursorLocation.Y);

 #endregion // Calculate Offsets

 if( ! this.AllowDragOutOfView )
 {
  #region Verify Drag Element Location

  // Get the bounding rect of the drag element.
  Rect elemRect = 
    this.CalculateDragElementRect( newHorizontalOffset, newVerticalOffset );

  //
  // If the element is being dragged out of the viewable area, 
  // determine the ideal rect location, so that the element is 
  // within the edge(s) of the canvas.
  //
  bool leftAlign = elemRect.Left < 0;
  bool rightAlign = elemRect.Right > this.ActualWidth;

  if( leftAlign )
   newHorizontalOffset = 
    modifyLeftOffset ? 0 : this.ActualWidth - elemRect.Width;
  else if( rightAlign )
   newHorizontalOffset = 
    modifyLeftOffset ? this.ActualWidth - elemRect.Width : 0;

  bool topAlign = elemRect.Top < 0;
  bool bottomAlign = elemRect.Bottom > this.ActualHeight;

  if( topAlign )
   newVerticalOffset = 
    modifyTopOffset ? 0 : this.ActualHeight - elemRect.Height;
  else if( bottomAlign )
   newVerticalOffset = 
    modifyTopOffset ? this.ActualHeight - elemRect.Height : 0;

  #endregion // Verify Drag Element Location
 }

 #region Move Drag Element

 if( this.modifyLeftOffset )
  Canvas.SetLeft( this.ElementBeingDragged, newHorizontalOffset );
 else
  Canvas.SetRight( this.ElementBeingDragged, newHorizontalOffset );

 if( this.modifyTopOffset )
  Canvas.SetTop( this.ElementBeingDragged, newVerticalOffset );
 else
  Canvas.SetBottom( this.ElementBeingDragged, newVerticalOffset );

 #endregion // Move Drag Element
}
*/

/* COMMENT ON ORIGINAL CODE - ADDING UNIDIRECTIONAL DRAGGING
t is a wonderful code sample, saves us from tons of devil's code  Wink | ;) 
 
Well, I had an situation where I need to move content either left/right or Top/Bottom only. So, I added two additional dependency properties to do so:
 
a) public static readonly DependencyProperty AllowHorizontalDragProperty;
b) public static readonly DependencyProperty AllowVerticalDragProperty; 
 
Setting there default value as True;
 
Tweaked "OnPreviewMouseMove" to amend these changes to perform STEP 2.
 
Code: 
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            //IsHorizontalMoveAllowed = false;
            base.OnPreviewMouseMove(e);
 
            // If no element is being dragged, there is nothing to do.
            if (this.ElementBeingDragged == null || !this.isDragInProgress)
                return;
 
            // Get the position of the mouse cursor, relative to the Canvas.
            Point cursorLocation = e.GetPosition(this);
 
            // These values will store the new offsets of the drag element.
            double newHorizontalOffset, newVerticalOffset;
 
            #region Calculate Offsets
 
            // Determine the horizontal offset.
            if (AllowHorizontalDrag)
            {
                if (this.modifyLeftOffset)
                    newHorizontalOffset = this.origHorizOffset + (cursorLocation.X - this.origCursorLocation.X);
                else
                    newHorizontalOffset = this.origHorizOffset - (cursorLocation.X - this.origCursorLocation.X);
            }
            else
            {
                newHorizontalOffset = this.origHorizOffset;
            }
 
            // Determine the vertical offset.
            if (AllowVerticalDrag)
            {
                if (this.modifyTopOffset)
                    newVerticalOffset = this.origVertOffset + (cursorLocation.Y - this.origCursorLocation.Y);
                else
                    newVerticalOffset = this.origVertOffset - (cursorLocation.Y - this.origCursorLocation.Y);
            }
            else
            {
                newVerticalOffset = this.origVertOffset;
            }
 
            #endregion // Calculate Offsets

            if (!this.AllowDragOutOfView)
            {
                #region Verify Drag Element Location
 
                // Get the bounding rect of the drag element.
                Rect elemRect = this.CalculateDragElementRect(newHorizontalOffset, newVerticalOffset);
 
                //
                // If the element is being dragged out of the viewable area, 
                // determine the ideal rect location, so that the element is 
                // within the edge(s) of the canvas.
                //
                bool leftAlign = elemRect.Left < 0;
                bool rightAlign = elemRect.Right > this.ActualWidth;
 
                if (leftAlign)
                    newHorizontalOffset = modifyLeftOffset ? 0 : this.ActualWidth - elemRect.Width;
                else if (rightAlign)
                    newHorizontalOffset = modifyLeftOffset ? this.ActualWidth - elemRect.Width : 0;
 
                bool topAlign = elemRect.Top < 0;
                bool bottomAlign = elemRect.Bottom > this.ActualHeight;
 
                if (topAlign)
                    newVerticalOffset = modifyTopOffset ? 0 : this.ActualHeight - elemRect.Height;
                else if (bottomAlign)
                    newVerticalOffset = modifyTopOffset ? this.ActualHeight - elemRect.Height : 0;
 
                #endregion // Verify Drag Element Location
            }
 
            #region Move Drag Element
 
                if (this.modifyLeftOffset)
                    Canvas.SetLeft(this.ElementBeingDragged, newHorizontalOffset);
                else
                    Canvas.SetRight(this.ElementBeingDragged, newHorizontalOffset);
 
                if (this.modifyTopOffset)
                    Canvas.SetTop(this.ElementBeingDragged, newVerticalOffset);
                else
                    Canvas.SetBottom(this.ElementBeingDragged, newVerticalOffset);
 
            #endregion // Move Drag Element
        }
 
So, now if I want, I can just move the element left/Right or Top/Bottom by setting these 2 property.
*/