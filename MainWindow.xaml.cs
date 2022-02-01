using System.Windows;
using Fractals.Windows;

namespace Fractals
{
    /// <summary>
    /// Класс, отвечающий за работу главного окна.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик событий при клике на кнопку.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Открытие нового окна.</returns>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var window = new WinTreeWindow();
            window.Show();
        }
        
        /// <summary>
        /// Обработчик событий при клике на кнопку.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Открытие нового окна.</returns>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new KochWindow();
            window.Show();
        }
        
        /// <summary>
        /// Обработчик событий при клике на кнопку.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Открытие нового окна.</returns>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new CarpetWindow();
            window.Show();
        }
        
        /// <summary>
        /// Обработчик событий при клике на кнопку.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Открытие нового окна.</returns>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new TriangleWindow();
            window.Show();
        }
        
        /// <summary>
        /// Обработчик событий при клике на кнопку.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        /// <returns>Открытие нового окна.</returns>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var window = new KantorWindow();
            window.Show();
        }
    }
}