using System;
using System.Windows;
using Fractals.Windows;

namespace Fractals
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var window = new WinTreeWindow();
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new KochWindow();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new CarpetWindow();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new TriangleWindow();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}