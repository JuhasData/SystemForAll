using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SystemForAll.Editor
{
    class CustomVisualFrameworkElement : FrameworkElement
    {

        // A collection of all the visuals we are building.
        VisualCollection theVisuals;

        public CustomVisualFrameworkElement()
        {
            // Fill the VisualCollection with a few DrawingVisual objects.
            // The ctor arg represents the owner of the visuals.
            theVisuals = new VisualCollection(this);
            theVisuals.Add(AddRect());
            theVisuals.Add(AddCircle());
        }
        private Visual AddCircle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            // Retrieve the DrawingContext in order to create new drawing content.
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Create a circle and draw it in the DrawingContext.
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawEllipse(Brushes.DarkBlue, null, new Point(70, 90), 40, 50);
            }
            return drawingVisual;
        }
        private Visual AddRect()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                drawingContext.DrawRectangle(Brushes.Tomato, null, rect);
            }
            return drawingVisual;
        }

        protected override int VisualChildrenCount
        {
            get { return theVisuals.Count; }
        }
        protected override Visual GetVisualChild(int index)
        {
            // Value must be greater than zero, so do a sanity check.
            if (index < 0 || index >= theVisuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return theVisuals[index];
        }
    }
}
