using System.Drawing;
using System.Windows;
using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace Fractals.Components
{
    /// <summary>
    ///     Класс, отвечающий за отрисовку фрактала.
    /// </summary>
    internal class CarpetFractal : Fractal
    {
        /// <summary>
        ///     Отрисовка фрактала.
        /// </summary>
        /// <returns>Обновление canvas.</returns>
        public override void Render()
        {
            Canvas.Children.Clear();

            Draw(DrawMain(), Depth);
        }

        /// <summary>
        ///     Отрисовка первого квадрата.
        /// </summary>
        /// <returns></returns>
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

            Canvas.Children.Add(CreateRectangle(rectangle));
            return rectangle;
        }

        /// <summary>
        ///     Рекурсивная отрисовка квадратов.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <param name="count">текущая итерация.</param>
        /// <returns>Отрисовка дочерних квадратов.</returns>
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

            Canvas.Children.Add(CreateRectangle(newRectangles[4]));

            for (var i = 0; i < newRectangles.Length; i++)
                if (i != 4)
                    Draw(newRectangles[i], count - 1);
        }

        /// <summary>
        ///     Конвертация квадрата.
        /// </summary>
        /// <param name="rectangle">Квадрат типа RectangleF.</param>
        /// <returns>Квадрат типа Rectangle.</returns>
        private static Rectangle CreateRectangle(RectangleF rectangle)
        {
            return new Rectangle
            {
                Width = rectangle.Width,
                Height = rectangle.Height,
                Margin = new Thickness(rectangle.X, rectangle.Y, 0, 0),
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
        }
    }
}