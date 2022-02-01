using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace Fractals.Components
{
    public class KantorFractal : Fractal
    {
        public double Space { get; set; }
        public double Height { get; set; }

        public override void Render()
        {
            Canvas.Children.Clear();

            Draw(
                new RectangleF(
                    new PointF(0, 0),
                    new SizeF((float) Canvas.ActualWidth, (float) Height)
                ),
                Depth
            );
        }

        private void Draw(RectangleF rectangle, int count)
        {
            if (count == 0)
                return;

            Canvas.Children.Add(new Rectangle
            {
                Width = rectangle.Width,
                Height = rectangle.Height,
                Margin = new Thickness(rectangle.X, rectangle.Y, 0, 0),
                StrokeThickness = 1,
                Stroke = Brushes.Black
            });

            Draw(
                new RectangleF(
                    PointF.Add(
                        rectangle.Location,
                        new SizeF(0, (float) (Height + Space))
                    ),
                    SizeF.Subtract(rectangle.Size, new SizeF(2 * rectangle.Width / 3f, 0))
                ),
                count - 1
            );

            Draw(
                new RectangleF(
                    PointF.Add(
                        rectangle.Location,
                        new SizeF(2 * rectangle.Width / 3f, (float) (Height + Space))
                    ),
                    SizeF.Subtract(rectangle.Size, new SizeF(2 * rectangle.Width / 3f, 0))
                ),
                count - 1
            );
        }
    }
}