using System;
using System.Windows;
using Fractals.Components;

namespace Fractals.Windows
{
    /// <summary>
    ///     Interaction logic for TriangleWindow.xaml
    /// </summary>
    public partial class TriangleWindow : Window
    {
        private readonly TriangleFractal fractral = new();

        public TriangleWindow()
        {
            InitializeComponent();
            fractral.Canvas = canvas;
        }

        private void DepthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fractral.Depth = Math.Max(1, (int) e.NewValue);

            if (fractral.Canvas != null)
                fractral.Render();
        }

        private void ViewboxLoaded(object sender, RoutedEventArgs e)
        {
            if (fractral.Canvas != null)
                fractral.Render();
        }
    }
}