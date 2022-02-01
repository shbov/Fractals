using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals.Components
{
    /// <summary>
    ///     Класс, отвечающий за работу фрактала треугольника.
    /// </summary>
    internal class TriangleFractal : Fractal
    {
        /// <summary>
        ///     Отрисовка фрактала.
        /// </summary>
        /// <returns>Обновление canvas.</returns>
        public override void Render()
        {
            Canvas.Children.Clear();
            const int coefficient = 0;

            var x = new Point(Canvas.ActualWidth / 2, coefficient * Canvas.ActualHeight);
            var y = new Point(coefficient * Canvas.ActualWidth, Canvas.ActualHeight);
            var z = new Point(Canvas.ActualWidth - coefficient * Canvas.ActualWidth, Canvas.ActualHeight);

            DrawTriangle(Depth, x, y, z);
        }

        /// <summary>
        ///     Рекурсивная отрисовка дочерних элементов.
        /// </summary>
        /// <param name="level">текущая итерация.</param>
        /// <param name="topPoint">Верхняя точка.</param>
        /// <param name="leftPoint">Левая точка.</param>
        /// <param name="rightPoint">Правая точка.</param>
        /// <returns>Отрисовка дочерного элемента.</returns>
        private void DrawTriangle(int level, Point topPoint,
            Point leftPoint, Point rightPoint)
        {
            // Посмотрим, остановимся ли мы.
            if (level == 0)
            {
                var polygon = new Polygon
                {
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };

                polygon.Points.Add(topPoint);
                polygon.Points.Add(leftPoint);
                polygon.Points.Add(rightPoint);

                Canvas.Children.Add(polygon);
                return;
            }

            // Найти граничные точки.
            var leftMid = new Point(
                (topPoint.X + leftPoint.X) / 2,
                (topPoint.Y + leftPoint.Y) / 2);
            var rightMid = new Point(
                (topPoint.X + rightPoint.X) / 2,
                (topPoint.Y + rightPoint.Y) / 2);
            var bottomMid = new Point(
                (leftPoint.X + rightPoint.X) / 2,
                (leftPoint.Y + rightPoint.Y) / 2);

            // Рекурсивно рисуем меньшие треугольники.
            DrawTriangle(level - 1, topPoint, leftMid, rightMid);
            DrawTriangle(level - 1, leftMid, leftPoint, bottomMid);
            DrawTriangle(level - 1, rightMid, bottomMid, rightPoint);
        }
    }
}