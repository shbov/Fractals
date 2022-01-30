using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Fractals.Components
{
    internal class TreeFractal : Fractal
    {
        public double LeftAngle { get; set; }
        public double RightAngle { get; set; }

        public override void Render()
        {

            Canvas.Children.Clear();

            Draw(
                 (X: Canvas.ActualWidth / 2, Y: Canvas.ActualHeight),
                    Math.PI / 2,
                    Canvas.ActualHeight / 4,
                    Depth
            );
        }

        private void Draw((double X, double Y) start, double angle, double length, int count)
        {
            if (count == 0)
                return;

            var end = (
                X: start.X + length * Math.Cos(angle),
                Y: start.Y - length * Math.Sin(angle)
            );

            Canvas.Children.Add(
                new Line()
                {
                    X1 = start.X,
                    X2 = end.X,
                    Y1 = start.Y,
                    Y2 = end.Y,
                    StrokeThickness = 1,
                    Stroke = System.Windows.Media.Brushes.Black
                });

            Draw(end, angle + LeftAngle, length / 1.4, count - 1);
            Draw(end, angle - RightAngle, length / 1.4, count - 1);
        }
    }
}
