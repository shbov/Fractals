using System;
using System.Windows;
using Fractals.Components;

namespace Fractals.Windows
{
    public partial class KantorWindow : Window
    {
        private readonly KantorFractal _fractral = new();

        public KantorWindow()
        {
            InitializeComponent();
            _fractral.Canvas = Canvas;
        }

        private void SpaceChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Space = e.NewValue;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        private void DepthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Depth = Math.Max(1, (int) e.NewValue);

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        private void HeightChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Height = e.NewValue;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        private void ViewboxLoaded(object sender, RoutedEventArgs e)
        {
            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_fractral.Canvas != null)
                _fractral.Save();
        }
    }
}