using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Data;
using System;

// ItemsControlAdorner
namespace DALT.Controls
{
    public class ItemsControlAdorner : Adorner
    {
        private ContentPresenter _contentPresenter;
        private AdornerLayer _adornerLayer;
        private static Button _btn;
        private VisualCollection _visualChildren;

        private double _marginRight = 5;
        private double _adornerDistance = 5;
        private PointCollection _points;

        private static ItemsControlAdorner _currentInstance;

        public ItemsControlAdorner(Button adornedElement, AdornerLayer adornerLayer, object data, DataTemplate dataTemplate)
            : base(adornedElement)
        {
            if (_currentInstance != null)
                _currentInstance.Hide(); // hides other adorners of the same type

            if (_btn != null && _btn == adornedElement)
            {
                _currentInstance.Hide(); // hides the adorner of this button (toggle)
                _btn = null;
            }
            else
            {
                _adornerLayer = adornerLayer;
                _btn = adornedElement;

                // adjust position if sizes change
                _adornerLayer.SizeChanged += (s, e) => { UpdatePosition(); };
                _btn.SizeChanged += (s, e) => { UpdatePosition(); };

                _contentPresenter = new ContentPresenter() { Content = data, ContentTemplate = dataTemplate };

                // apply template explicitly: http://stackoverflow.com/questions/5679648/why-would-this-contenttemplate-findname-throw-an-invalidoperationexception-on
                _contentPresenter.ApplyTemplate();

                // get close button from datatemplate
                Button closeBtn = _contentPresenter.ContentTemplate.FindName("PART_CloseButton", _contentPresenter) as Button;
                if (closeBtn != null)
                    closeBtn.Click += (s, e) => { this.Hide(); _btn = null; };

                _visualChildren = new VisualCollection(this); // this is needed for user interaction with the adorner layer
                _visualChildren.Add(_contentPresenter);

                _adornerLayer.Add(this);

                _currentInstance = this;

                UpdatePosition(); // position adorner
            }
        }


        /// <summary>
        /// Positioning is a bit fiddly. 
        /// Also, this method is only dealing with the right clip, not yet with the bottom clip.
        /// </summary>
        private void UpdatePosition()
        {
            double marginLeft = 0;
            _contentPresenter.Margin = new Thickness(marginLeft, 0, _marginRight, 0); // "reset" margin to get a good measure pass
            _contentPresenter.Measure(_adornerLayer.RenderSize); // measure the contentpresenter to get a DesiredSize
            var contentRect = new Rect(_contentPresenter.DesiredSize);
            double right = _btn.TranslatePoint(new Point(contentRect.Width, 0), _adornerLayer).X; // this does not work with the contentpresenter, so use _adornedElement

            if (right > _adornerLayer.ActualWidth) // if adorner is clipped by right window border, move it to the left
                marginLeft = _adornerLayer.ActualWidth - right;

            // ToDo: implement "if clipped by left window border, move it to the right
            // ToDo: implement "if clipped by top window border, move it down
            // ToDo: implement "if clipped by bottom window border, move it up

            _contentPresenter.Margin = new Thickness(marginLeft, _btn.ActualHeight + _adornerDistance, _marginRight, 0); // position adorner

            DrawArrow();
        }

        // Draws an arrow pointing at the item it represents
        private void DrawArrow()
        {
            Point bottomMiddleButton = new Point(_btn.ActualWidth / 2, _btn.ActualHeight - _btn.Margin.Bottom);
            Point topLeftAdorner = new Point(_btn.ActualWidth / 2 - 10, _contentPresenter.Margin.Top);
            Point topRightAdorner = new Point(_btn.ActualWidth / 2 + 10, _contentPresenter.Margin.Top);

            PointCollection points = new PointCollection();
            points.Add(bottomMiddleButton);
            points.Add(topLeftAdorner);
            points.Add(topRightAdorner);

            _points = points; // actual drawing executed in OnRender
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            // Drawing the arrow
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                if (_points != null && _points.Any())
                {
                    geometryContext.BeginFigure(_points[0], true, true);
                    geometryContext.PolyLineTo(_points.Where(p => _points.IndexOf(p) > 0).ToList(), true, true);
                }
            }

            // Draw the polygon visual
            drawingContext.DrawGeometry(Brushes.DarkOrchid, new Pen(_btn.Background, 0.5), streamGeometry);

            base.OnRender(drawingContext);
        }

        private void Hide()
        {
            _adornerLayer.Remove(this);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _contentPresenter.Measure(constraint);
            return _contentPresenter.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return _visualChildren[index];
        }

        protected override int VisualChildrenCount
        {
            get { return _visualChildren.Count; }
        }
    }
}
