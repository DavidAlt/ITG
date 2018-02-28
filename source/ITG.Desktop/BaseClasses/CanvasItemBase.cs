using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALT.Utility;
using DALT.Utility.Extensions;

namespace ITG.Desktop.BaseClasses
{
    public abstract class CanvasItemBase : ViewModelBase
    {
        protected double _width;
        protected double _height;

        protected SizeConstraints _constraints;

        public CanvasItemBase()
            : base()
        {
            Constrained = false;
        }

        public CanvasItemBase(SizeConstraints constraints)
            : base()
        {
            _constraints = constraints;
            Constrained = true;
        }

        public bool Constrained { get; set; }


        #region SIZE Properties

        public virtual double Width
        {
            get { return _width; }
            set
            {
                value.RoundToNearestWholeNumber();
                if (Constrained)
                    value.Constrain(_constraints.MinimumWidth, _constraints.MaximumWidth);
                SetProperty(ref _width, value);
            }
        }

        public virtual double Height
        {
            get { return _height; }
            set
            {
                value.RoundToNearestWholeNumber();
                if (Constrained)
                    value.Constrain(_constraints.MinimumHeight, _constraints.MaximumHeight);
                SetProperty(ref _height, value);
            }
        }

        #endregion


        
    }
}
