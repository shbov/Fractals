using System;
using System.Windows;
using Fractals.Components;

namespace Fractals.Windows
{
    /// <summary>
    ///     Interaction logic for WinTree.xaml
    /// </summary>
    public partial class WinTreeWindow : Window
    {
        private readonly TreeFractal _fractral = new();

        public WinTreeWindow()
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

        private void LeftAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.LeftAngle = e.NewValue * Math.PI / 180;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        private void RightAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.RightAngle = e.NewValue * Math.PI / 180;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        private void RatioChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Ratio = e.NewValue;
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