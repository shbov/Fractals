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

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public WinTreeWindow()
        {
            InitializeComponent();
            _fractral.Canvas = Canvas;
        }

        /// <summary>
        ///     Обратчик события при изменении глубины рекурсии.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void DepthChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Depth = Math.Max(1, (int) e.NewValue);

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        /// <summary>
        ///     Обратчик события при изменении левого угла.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void LeftAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.LeftAngle = e.NewValue * Math.PI / 180;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        /// <summary>
        ///     Обратчик события при изменении правого угла.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void RightAngleChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.RightAngle = e.NewValue * Math.PI / 180;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        /// <summary>
        ///     Обратчик события при изменении коэффициента.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void RatioChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Ratio = e.NewValue;
            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        /// <summary>
        ///     Обратчик события при загруке canvas.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void ViewboxLoaded(object sender, RoutedEventArgs e)
        {
            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        /// <summary>
        ///     Обратчик события при сохранении canvas.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_fractral.Canvas != null)
                _fractral.Save();
        }
    }
}