using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using ITG.Desktop.DesignerItems;

namespace ITG.Desktop.DragAndDrop
{
    public class ResizeThumb : Thumb
    {

        public ResizeThumb()
        {
            base.DragDelta += new DragDeltaEventHandler(ResizeThumb_DragDelta);
        }

        void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            DesignerItemBaseVM item = this.DataContext as DesignerItemBaseVM;

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
            }
        }

        private bool CanShrinkHeight(DesignerItemBaseVM item, double amount)
        {
            if (item.Height - Math.Abs(amount) <= item.MinHeight) return false;
            else return true;
        }

        private bool CanGrowHeight(DesignerItemBaseVM item, double amount)
        {
            if ((item.Height + Math.Abs(amount) >= item.MaxHeight) ||
                (item.Top - Math.Abs(amount) < 0) ||
                ( (item.Top + item.Height + Math.Abs(amount)) > item.ParentForm.Height )    ) return false;
            else return true;
        }

        private bool CanShrinkWidth(DesignerItemBaseVM item, double amount)
        {
            if (item.Width - Math.Abs(amount) <= item.MinWidth) return false;
            else return true;
        }

        private bool CanGrowWidth(DesignerItemBaseVM item, double amount)
        {
            if ((item.Width + Math.Abs(amount) >= item.MaxWidth) ||
                 (item.Left - Math.Abs(amount) < 0) ||
                ( (item.Left + item.Width + Math.Abs(amount)) > item.ParentForm.Width) ) return false;
            else return true;
        }

        private bool CanGrowLeft(DesignerItemBaseVM item, double amount)
        {
            if ((item.Width + Math.Abs(amount) >= item.MaxWidth) ||
                 (item.Left - Math.Abs(amount) < 0)) return false;
            else return true;
        }

        private bool CanGrowRight(DesignerItemBaseVM item, double amount)
        {
            if ( (item.Width + Math.Abs(amount) >= item.MaxWidth) ||
                 (item.Left + item.Width + Math.Abs(amount) > item.ParentForm.Width) ) return false;
            else return true;
        }

        private bool CanGrowUp(DesignerItemBaseVM item, double amount)
        {
            if ((item.Height + Math.Abs(amount) >= item.MaxHeight) ||
                 (item.Top - Math.Abs(amount) < 0)) return false;
            else return true;
        }

        private bool CanGrowDown(DesignerItemBaseVM item, double amount)
        {
            if ((item.Height + Math.Abs(amount) >= item.MaxHeight) ||
                 (item.Top + item.Height + Math.Abs(amount) > item.ParentForm.Height)) return false;
            else return true;
        }

        private void AdjustLeft(DesignerItemBaseVM item, double amount)
        {
            double delta = Math.Abs(amount);
            if (amount > 0 && CanShrinkWidth(item, delta))
            {
                item.Left += delta;
                item.Width -= delta;
            }
            if (amount < 0 && CanGrowLeft(item, delta))
            {
                item.Left -= delta;
                item.Width += delta;
            }
        }

        private void AdjustRight(DesignerItemBaseVM item, double amount)
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

        private void AdjustUp(DesignerItemBaseVM item, double amount)
        {
            double delta = Math.Abs(amount);
            if (amount > 0 && CanShrinkHeight(item, delta))
            {
                item.Top += delta;
                item.Height -= delta;
            }
            if (amount < 0 && CanGrowUp(item, delta))
            {
                item.Top -= delta;
                item.Height += delta;
            }
             
        }

        private void AdjustDown(DesignerItemBaseVM item, double amount)
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
                        