using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Fractals
{
    public class LineExt
    {
        private Line _line;
        public Line Item
        {
            get
            {
                return _line;
            }
            set
            {
                _line = value;
                _line.StrokeThickness = 1;
                _line.Stroke = System.Windows.Media.Brushes.Black;
            }
        }
        public double Length => Math.Sqrt(Math.Pow(Item.X2 - Item.X1, 2) + Math.Pow(Item.Y2 - Item.Y1, 2));
        public double Angle { get; set; }
    }
}
