using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DALT.Utility;
using DALT.Utility.Extensions;

namespace ITG.Desktop.BaseClasses
{

    public abstract class MovableCanvasItemBase : CanvasItemBase
    {
        protected double _left;
        protected double _top;

        protected bool _isSelected;


        public MovableCanvasItemBase()
            : base()
        {

        }


        #region SIZE Properties

        public override double Width
        {
            get { return _width; }
            set
            {
                value.RoundToNearestWholeNumber();
                if (Constrained)
                    value.Constrain(_constraints.MinimumWidth, _constraints.MaximumWidth);
                SetProperty(ref _width, value);
                NotifyPropertyChanged("Left");  // these notifications are the only difference
                NotifyPropertyChanged("Right"); // from the base implementation
            }
        }

        public override double Height
        {
            get { return _height; }
            set
            {
                value.RoundToNearestWholeNumber();
                if (Constrained)
                    value.Constrain(_constraints.MinimumHeight, _constraints.MaximumHeight);
                SetProperty(ref _height, value);
                NotifyPropertyChanged("Top");    // these notifications are the only difference
                NotifyPropertyChanged("Bottom"); // from the base implementation
            }
        }

        #endregion


        #region POSITION Properties

        public double Left
        {
            get { return _left; }
            set
            {
                value.RoundToNearestWholeNumber();
                SetProperty(ref _left, value);
                NotifyPropertyChanged("Right");
            }
        }

        public double Top
        {
            get { return _top; }
            set
            {
                value.RoundToNearestWholeNumber();
                SetProperty(ref _top, value);
                NotifyPropertyChanged("Bottom");
            }
        }

        public double Right 
        { 
            get { return (Left + Width - 1); } 
        }

        public double Bottom 
        { 
            get { return (Top + Height - 1); }
        }

        #endregion

        
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }


        #region MOVEMENT Methods

        public void MoveLeft(double distance, double canvasWidth)
        {
            Move(distance, canvasWidth);
        }

        public void MoveRight(double distance, double canvasWidth)
        {
            Move(distance, canvasWidth);
        }

        public void MoveUp(double distance, double canvasHeight)
        {
            Move(distance, canvasHeight);
        }

        public void MoveDown(double distance, double canvasHeight)
        {
            Move(distance, canvasHeight);
        }

        public void MoveToPoint(Point destination, double canvasWidth, double canvasHeight)
        {
            // adjust Left and Top
        }

        private void Move(double distance, double boundary)
        {

        }

        #endregion
    }

  }

/*
 * double rightBoundary = canvas.Width - item.Width; // accounts for item width when adjusting left edge
 * double bottomBoundary = canvas.Height - item.Height; // accounts for item height when adjusting top edge
 * 
                double minLeft = double.MaxValue;
                double minTop = double.MaxValue;

                foreach (DesignerItemBaseVM item in selectedItems.OfType<DesignerItemBaseVM>())
                {                    
                    double maxItemLeft = vm.Width - item.Width;
                    double maxItemTop = vm.Height - item.Height;
                    
                    minLeft = double.IsNaN(item.Left) ? 0 : Math.Min(item.Left, minLeft);
 * if (Left is not a number) --> minLeft = 0;
 * else --> minLeft = Left
                    
                    minTop = double.IsNaN(item.Top) ? 0 : Math.Min(item.Top, minTop);
 * if (Top is NotANumber) --> minTop = 0;
 * else --> minTop = Top;


                    double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
                    double deltaVertical = Math.Max(-minTop, e.VerticalChange);

                    double requestedLeft = Left + deltaHorizontal;
                    double requestedTop = Top + deltaVertical;
                    
                    if(requestedLeft > rightBoundary) 
                        Left = rightBoundary;
                    else 
                        Left += deltaHorizontal;

                    if(requestedTop > bottomBoundary) 
                        Top = bottomBoundary;
                    else 
                        Top += deltaVertical;
                }
*/