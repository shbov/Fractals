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

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public TriangleWindow()
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
        ///     Обратчик события при загрузке canvas.
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