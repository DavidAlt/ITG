using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DALT.Controls.DesignerCanvas
{
    public class ResizeThumb : Thumb
    {

        public ResizeThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(ResizeThumb_DragDelta);
        }

        void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            /*
            DesignerItem item = this.DataContext as DesignerItem;

            if (item != null)
            {

                // TOP LEFT
                if (VerticalAlignment == VerticalAlignment.Top &&
                    HorizontalAlignment == HorizontalAlignment.Left)
                {
                    AdjustUp(item, e.VerticalChange);
                    AdjustLeft(item, e.HorizontalChange);
                }
                // TOP
                if (VerticalAlignment == VerticalAlignment.Top &&
                    HorizontalAlignment == HorizontalAlignment.Stretch)
                {
                    AdjustUp(item, e.VerticalChange);
                }
                // TOP RIGHT
                if (VerticalAlignment == VerticalAlignment.Top &&
                    HorizontalAlignment == HorizontalAlignment.Right)
                {
                    AdjustUp(item, e.VerticalChange);
                    AdjustRight(item, e.HorizontalChange);
                }
                // LEFT
                if (HorizontalAlignment == HorizontalAlignment.Left &&
                    VerticalAlignment == VerticalAlignment.Stretch)
                {
                    AdjustLeft(item, e.HorizontalChange);
                }
                // RIGHT
                if (HorizontalAlignment == HorizontalAlignment.Right &&
                    VerticalAlignment == VerticalAlignment.Stretch)
                {
                    AdjustRight(item, e.HorizontalChange);
                }
                // BOTTOM LEFT
                if (VerticalAlignment == VerticalAlignment.Bottom &&
                    HorizontalAlignment == HorizontalAlignment.Left)
                {
                    AdjustDown(item, e.VerticalChange);
                    AdjustLeft(item, e.HorizontalChange);
                }
                // BOTTOM
                if (VerticalAlignment == VerticalAlignment.Bottom &&
                    HorizontalAlignment == HorizontalAlignment.Stretch)
                {
                    AdjustDown(item, e.VerticalChange);
                }
                // BOTTOM RIGHT
                if (VerticalAlignment == VerticalAlignment.Bottom &&
                    HorizontalAlignment == HorizontalAlignment.Right)
                {
                    AdjustDown(item, e.VerticalChange);
                    AdjustRight(item, e.HorizontalChange);
                }
            
                e.Handled = true;
            }*/
        }

        private bool CanShrinkHeight(DesignerItem item, double amount)
        {
            if (item.Height - Math.Abs(amount) <= item.MinHeight) return false;
            else return true;
        }

        private bool CanGrowHeight(DesignerItem item, double amount)
        {
            if ((item.Height + Math.Abs(amount) >= item.MaxHeight) ||
                (item.Y - Math.Abs(amount) < 0) ||
                ( (item.Y + item.Height + Math.Abs(amount)) > item.ParentDesigner.Height )    ) return false;
            else return true;
        }

        private bool CanShrinkWidth(DesignerItem item, double amount)
        {
            if (item.Width - Math.Abs(amount) <= item.MinWidth) return false;
            else return true;
        }

        private bool CanGrowWidth(DesignerItem item, double amount)
        {
            if ((item.Width + Math.Abs(amount) >= item.MaxWidth) ||
                 (item.X - Math.Abs(amount) < 0) ||
                ( (item.X + item.Width + Math.Abs(amount)) > item.ParentDesigner.Width) ) return false;
            else return true;
        }

        private bool CanGrowLeft(DesignerItem item, double amount)
        {
            if ((item.Width + Math.Abs(amount) >= item.MaxWidth) ||
                 (item.X - Math.Abs(amount) < 0)) return false;
            else return true;
        }

        private bool CanGrowRight(DesignerItem item, double amount)
        {
            if ( (item.Width + Math.Abs(amount) >= item.MaxWidth) ||
                 (item.X + item.Width + Math.Abs(amount) > item.ParentDesigner.Width) ) return false;
            else return true;
        }

        private bool CanGrowUp(DesignerItem item, double amount)
        {
            if ((item.Height + Math.Abs(amount) >= item.MaxHeight) ||
                 (item.Y - Math.Abs(amount) < 0)) return false;
            else return true;
        }

        private bool CanGrowDown(DesignerItem item, double amount)
        {
            if ((item.Height + Math.Abs(amount) >= item.MaxHeight) ||
                 (item.Y + item.Height + Math.Abs(amount) > item.ParentDesigner.Height)) return false;
            else return true;
        }

        private void AdjustLeft(DesignerItem item, double amount)
        {
            double delta = Math.Abs(amount);
            if (amount > 0 && CanShrinkWidth(item, delta))
            {
                item.X += delta;
                item.Width -= delta;
            }
            if (amount < 0 && CanGrowLeft(item, delta))
            {
                item.X -= delta;
                item.Width += delta;
            }
        }

        private void AdjustRight(DesignerItem item, double amount)
        {
            double delta = Math.Abs(amount);
            if (amount < 0 && CanShrinkWidth(item, delta))
            {
                item.Width -= delta;
            }
            if (amount > 0 && CanGrowRight(item, delta))
            {
                item.Width += delta;
            }
        }

        private void AdjustUp(DesignerItem item, double amount)
        {
            double delta = Math.Abs(amount);
            if (amount > 0 && CanShrinkHeight(item, delta))
            {
                item.Y += delta;
                item.Height -= delta;
            }
            if (amount < 0 && CanGrowUp(item, delta))
            {
                item.Y -= delta;
                item.Height += delta;
            }
             
        }

        private void AdjustDown(DesignerItem item, double amount)
        {
            double delta = Math.Abs(amount);
            if (amount < 0 && CanShrinkHeight(item, delta))
            {
                item.Height -= delta;
            }
            if (amount > 0 && CanGrowDown(item, delta))
            {
                item.Height += delta;
            }
        }
    }
}
                        