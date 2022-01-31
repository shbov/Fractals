using System;
using System.Windows;
using Fractals.Components;

namespace Fractals.Windows
{
    /// <summary>
    ///     Interaction logic for Koch.xaml
    /// </summary>
    public partial class KochWindow : Window
    {
        private readonly KochFractal fractral = new();

        public KochWindow()
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