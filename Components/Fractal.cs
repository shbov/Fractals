using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fractals.Components
{
    internal abstract class Fractal
    {
        /// <summary>
        /// Глубина рекурсии.
        /// </summary>
        public int Depth { get; set; } = 1;

        public Size Size { get; set; }

        public abstract void Render();
    }

}
