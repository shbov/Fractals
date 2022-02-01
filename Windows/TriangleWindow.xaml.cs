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
        private readonly TriangleFractal _fractral = new();

        public TriangleWindow()
        {
            InitializeComponent();
            _fractral.Canvas = canvas;
        }

        private void DepthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Depth = Math.Max(1, (int) e.NewValue);

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        private void ViewboxLoaded(object sender, RoutedEventArgs e)
        {
            if (_fractral.Canvas != null)
                _fractral.Render();
        }
    }
}