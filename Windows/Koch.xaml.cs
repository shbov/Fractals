using Fractals.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fractals.Windows
{
    /// <summary>
    /// Interaction logic for Koch.xaml
    /// </summary>
    public partial class Koch : Window
    {
        private KochFractal fractral = new();

        public Koch()
        {
            InitializeComponent();
            fractral.Canvas = canvas;

        }

        private void CanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (fractral.Canvas != null)
                fractral.Render();
        }

        private void DepthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fractral.Depth = Math.Max(1, (int)e.NewValue);

            if (fractral.Canvas != null)
                fractral.Render();
        }
    }
}
