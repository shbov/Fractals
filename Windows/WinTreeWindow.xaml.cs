using System;
using System.Windows;
using Fractals.Components;

namespace Fractals
{
    /// <summary>
    ///     Interaction logic for WinTree.xaml
    /// </summary>
    public partial class WinTreeWindow : Window
    {
        private readonly TreeFractal fractral = new();

        public WinTreeWindow()
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

        private void LeftAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fractral.LeftAngle = e.NewValue * Math.PI / 180;

            if (fractral.Canvas != null)
                fractral.Render();
        }

        private void RightAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fractral.RightAngle = e.NewValue * Math.PI / 180;

            if (fractral.Canvas != null)
                fractral.Render();
        }

        private void RatioChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            fractral.Ratio = e.NewValue;
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