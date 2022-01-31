using System.Windows.Controls;

namespace Fractals.Components
{
    internal abstract class Fractal
    {
        /// <summary>
        ///     Глубина рекурсии.
        /// </summary>
        public int Depth { get; set; }

        public Canvas Canvas { get; set; }
        public abstract void Render();
    }
}