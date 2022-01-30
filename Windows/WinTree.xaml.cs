using Fractals.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Fractals
{
    /// <summary>
    /// Interaction logic for WinTree.xaml
    /// </summary>
    public partial class WinTree : Window
    {
        private TreeFractal fractral = new();

        public WinTree()
        {
            InitializeComponent();
            fractral.Canvas = canvas;
        }

        private void DepthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fractral.Depth = Math.Max(1, (int)e.NewValue);
            fractral.Render();
        }

        private void LeftAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.fractral.LeftAngle = e.NewValue * Math.PI / 180;
            fractral.Render();
        }

        private void RightAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.fractral.RightAngle = e.NewValue * Math.PI / 180;
            fractral.Render();
        }

        private void CanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.fractral.Size = e.NewSize;
            fractral.Render();
        }
    }
}
