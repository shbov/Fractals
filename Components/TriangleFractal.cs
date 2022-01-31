using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals.Components
{
    internal class TriangleFractal : Fractal
    {
        public override void Render()
        {
            Canvas.Children.Clear();
            var coef = 0;

            var x = new Point(Canvas.ActualWidth / 2, coef * Canvas.ActualHeight);
            var y = new Point(coef * Canvas.ActualWidth, Canvas.ActualHeight);
            var z = new Point(Canvas.ActualWidth - coef * Canvas.ActualWidth, Canvas.ActualHeight);

            DrawTriangle(Depth, x, y, z);
        }


        private void DrawTriangle(int level, Point top_point,
            Point left_point, Point right_point)
        {
            // Посмотрим, остановимся ли мы.
            if (level == 0)
            {
                var polygon = new Polygon
                {
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };

                polygon.Points.Add(top_point);
                polygon.Points.Add(left_point);
                polygon.Points.Add(right_point);

                Canvas.Children.Add(polygon);
                return;
            }

            // Найти граничные точки.
            var left_mid = new Point(
                (top_point.X + left_point.X) / 2,
                (top_point.Y + left_point.Y) / 2);
            var right_mid = new Point(
                (top_point.X + right_point.X) / 2,
                (top_point.Y + right_point.Y) / 2);
            var bottom_mid = new Point(
                (left_point.X + right_point.X) / 2,
                (left_point.Y + right_point.Y) / 2);

            // Рекурсивно рисуем меньшие треугольники.
            DrawTriangle(level - 1,
                top_point, left_mid, right_mid);
            DrawTriangle(level - 1,
                left_mid, left_point, bottom_mid);
            DrawTriangle(level - 1,
                right_mid, bottom_mid, right_point);
        }
    }
}