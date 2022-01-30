using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Fractals.Components
{
    internal class TreeFractal : Fractal
    {
        public double LeftAngle { get; set; } = 0;

        public double RightAngle { get; set; } = 0;

        public Canvas Canvas { get; set; }

        public override void Render()
        {
            Draw(
                new Point(
                    Canvas.Width / 2, Canvas.Height),
                    Math.PI / 2,
                    Canvas.Height / 4,
                    Depth
            );
        }

        private void Draw(Point start, double angle, double length, int count)
        {
            if (count == 0)
                return;

            var end = new Point(
                start.X + length * Math.Cos(angle),
                start.Y - length * Math.Sin(angle)
            );

            var line = new Line
            {
                X1 = start.X,
                X2 = end.X,
                Y1 = start.Y,
                Y2 = end.Y,
                StrokeThickness = 4,
                Stroke = System.Windows.Media.Brushes.Black
            };

            Canvas.Children.Add(line);

            Draw(end, angle + LeftAngle, length / 1.4, count - 1);
            Draw(end, angle - RightAngle, length / 1.4, count - 1);

        }
    }
}
