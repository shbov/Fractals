using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    /// <summary>
    ///     Класс, дополняющий функционал линии.
    /// </summary>
    public sealed class LineExtension
    {
        private readonly Line _line;

        /// <summary>
        ///     Линия.
        /// </summary>
        public Line Item
        {
            get => _line;
            init
            {
                _line = value;
                _line.StrokeThickness = 1;
                _line.Stroke = Brushes.Black;
            }
        }

        /// <summary>
        ///     Длина линии.
        /// </summary>
        public double Length => Math.Sqrt(Math.Pow(Item.X2 - Item.X1, 2) + Math.Pow(Item.Y2 - Item.Y1, 2));

        /// <summary>
        ///     Угол линии.
        /// </summary>
        public double Angle { get; init; }
    }
}