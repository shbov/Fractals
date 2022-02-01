using System;
using System.Windows.Shapes;

namespace Fractals.Components
{
    /// <summary>
    /// Класс, отвечающий за работу фрактала Коха.
    /// </summary>
    internal class KochFractal : Fractal
    {
        /// <summary>
        /// Отрисовка фрактала.
        /// </summary>
        /// <returns>Обновление canvas.</returns>
        public override void Render()
        {
            Canvas.Children.Clear();

            Draw(
                new LineExtension
                {
                    Item = new Line
                    {
                        X1 = 0,
                        X2 = Canvas.ActualWidth,
                        Y1 = Canvas.ActualHeight / 1.5,
                        Y2 = Canvas.ActualHeight / 1.5
                    }
                },
                Depth
            );
        }

        /// <summary>
        /// Рекурсивная отрисовка элементов.
        /// </summary>
        /// <param name="line">Линия.</param>
        /// <param name="depth">Текущая итерация.</param>
        /// <returns>Отрисовка дочерних элементов.</returns>
        private void Draw(LineExtension line, int depth)
        {
            if (depth == 0)
            {
                Canvas.Children.Add(line.Item);
                return;
            }

            var newLength = line.Length / 3;
            var line1 = new LineExtension
            {
                Item = new Line
                {
                    X1 = line.Item.X1,
                    X2 = line.Item.X1 + newLength * Math.Cos(line.Angle),
                    Y1 = line.Item.Y1,
                    Y2 = line.Item.Y1 - newLength * Math.Sin(line.Angle)
                },
                Angle = line.Angle
            };

            var angle2 = line1.Angle + Math.PI / 3;
            var line2 = new LineExtension
            {
                Item = new Line
                {
                    X1 = line1.Item.X2,
                    Y1 = line1.Item.Y2,
                    X2 = line1.Item.X2 + newLength * Math.Cos(angle2),
                    Y2 = line1.Item.Y2 - newLength * Math.Sin(angle2)
                },
                Angle = angle2
            };

            var angle3 = angle2 - 2 * Math.PI / 3;
            var line3 = new LineExtension
            {
                Item = new Line
                {
                    X1 = line2.Item.X2,
                    Y1 = line2.Item.Y2,
                    X2 = line2.Item.X2 + newLength * Math.Cos(angle3),
                    Y2 = line2.Item.Y2 - newLength * Math.Sin(angle3)
                },
                Angle = angle3
            };

            var angle4 = angle3 + Math.PI / 3;
            var line4 = new LineExtension
            {
                Item = new Line
                {
                    X1 = line3.Item.X2,
                    Y1 = line3.Item.Y2,
                    X2 = line3.Item.X2 + newLength * Math.Cos(angle4),
                    Y2 = line3.Item.Y2 - newLength * Math.Sin(angle4)
                },
                Angle = angle4
            };

            Draw(line1, depth - 1);
            Draw(line2, depth - 1);
            Draw(line3, depth - 1);
            Draw(line4, depth - 1);
        }
    }
}