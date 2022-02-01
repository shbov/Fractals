using System;
using System.Windows;
using Fractals.Components;

namespace Fractals.Windows
{
    /// <summary>
    ///     Логика взаимодействия для CarpetWindow.xaml
    /// </summary>
    public partial class CarpetWindow : Window
    {
        private readonly CarpetFractal _fractral = new();

        public CarpetWindow()
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