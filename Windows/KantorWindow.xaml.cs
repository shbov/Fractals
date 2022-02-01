using System;
using System.Windows;
using Fractals.Components;

namespace Fractals.Windows
{
    /// <summary>
    /// Класс, отвечающий за работу окна фрактала Кантора.
    /// </summary>
    public partial class KantorWindow : Window
    {
        private readonly KantorFractal _fractral = new();

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public KantorWindow()
        {
            InitializeComponent();
            _fractral.Canvas = Canvas;
        }

        /// <summary>
        /// Обратчик события при изменении отступа.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void SpaceChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Space = e.NewValue;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        /// <summary>
        /// Обратчик события при изменении глубины рекурсии.
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
        /// Обратчик события при изменении высоты.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Обновление canvas на экране.</returns>
        private void HeightChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _fractral.Height = e.NewValue;

            if (_fractral.Canvas != null)
                _fractral.Render();
        }

        /// <summary>
        /// Обратчик события при загрузке canvas.
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
        /// Обратчик события при сохранении canvas.
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