using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace Fractals.Components
{
    internal class CarpetFractal : Fractal
    {
        public override void Render()
        {
            Canvas.Children.Clear();

            Draw(DrawMain(), Depth);
        }

        private RectangleF DrawMain()
        {
            float x, y, side;

            if (Canvas.ActualWidth > Canvas.ActualHeight)
            {
                side = (float) Canvas.ActualHeight;
                x = (float) (Canvas.ActualWidth - side) / 2;
                y = 0;
            }
            else
            {
                side = (float) Canvas.ActualWidth;
                x = 0;
                y = (float) (Canvas.ActualHeight - side) / 2;
            }

            var rectangle = new RectangleF(
                new PointF(x, y),
                new SizeF(side, side)
            );


            Canvas.Children.Add(new Rectangle
            {
                Width = side,
                Height = side,
                Margin = new Thickness(x, y, 0, 0),
                StrokeThickness = 1,
                Stroke = Brushes.Black
            });

            return rectangle;
        }

        /// <summary>
        ///     Recursion draw
        /// </summary>
        /// <param name="rectangle">Previous rectangle</param>
        /// <param name="count">Recursion depth</param>
        private void Draw(RectangleF rectangle, int count)
        {
            if (count == 0)
                return;

            var newRectangles = new RectangleF[9];
            var newSide = rectangle.Height / 3;

            var tempLocation = rectangle.Location;
            for (var i = 0; i < newRectangles.Length; i++)
            {
                newRectangles[i] = new RectangleF(
                    tempLocation,
                    new SizeF(newSide, newSide)
                );

                tempLocation = i % 3 == 2
                    ? new PointF(rectangle.X, tempLocation.Y + newSide)
                    : PointF.Add(tempLocation, new SizeF(newSide, 0));
            }

            Canvas.Children.Add(new Rectangle
            {
                Width = newRectangles[4].Width,
                Height = newRectangles[4].Height,
                Margin = new Thickness(newRectangles[4].X, newRectangles[4].Y, 0, 0),
                StrokeThickness = 1,
                Stroke = Brushes.Black
            });

            for (var i = 0; i < newRectangles.Length; i++)
                if (i != 4)
                    Draw(newRectangles[i], count - 1);
        }
    }
}