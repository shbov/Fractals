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
        private readonly CarpetFractal fractral = new();

        public CarpetWindow()
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