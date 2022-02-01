﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fractals.Components
{
    public abstract class Fractal
    {
        /// <summary>
        ///     Глубина рекурсии.
        /// </summary>
        public int Depth { get; set; }

        public Canvas Canvas { get; set; }
        public abstract void Render();

        public void Save()
        {
            try
            {
                double dpi = 300;
                var scale = dpi / 96;

                var bmp = new RenderTargetBitmap(
                    (int) (Canvas.ActualWidth * scale),
                    (int) (Canvas.ActualHeight * scale),
                    dpi,
                    dpi,
                    PixelFormats.Pbgra32);

                bmp.Render(Canvas);

                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));

                var current = DateTime.Now.Ticks;
                var stream = File.Create($"./image-{current}.png");
                encoder.Save(stream);
                var path = stream.Name;

                MessageBox.Show(
                    $"Путь к файлу: {path}",
                    "Файл успешно сохранен",
                    MessageBoxButton.OK
                );
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}