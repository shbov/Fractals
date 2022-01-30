using Fractals.Components;
using System;
using System.Collections.Generic;
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
        }

        private void DepthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void LeftAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void RightAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.fractral.Size = e.NewSize;
        }
    }
}
