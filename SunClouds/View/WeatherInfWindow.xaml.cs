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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SunClouds.View
{
    /// <summary>
    /// Логика взаимодействия для WeatherInfWindow.xaml
    /// </summary>
    public partial class WeatherInfWindow : Window
    {
        private bool isDragging = false;
        private Point startPoint;
        private bool isMenuVisible = false;
        public WeatherInfWindow()
        {
            InitializeComponent();
            SimulateChangeTextEffect();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualHeight < 550)
            {
                // Меняем высоту второй, третьей и четвертой строк на Auto
                for (int i = 1; i < 4; i++)
                {
                    RowDefinition rowDefinition = SunnyGrid.RowDefinitions[i];
                    rowDefinition.Height = GridLength.Auto;
                }
            }
            else
            {
                // Меняем высоту второй, третьей и четвертой строк на *
                for (int i = 1; i < 4; i++)
                {
                    RowDefinition rowDefinition = SunnyGrid.RowDefinitions[i];
                    rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                }
            }
        }

        private void AdjustRowHeights(object sender, SizeChangedEventArgs e)
        {

            if (this.ActualWidth < 1100)
            {
                // Меняем ширину всех столбцов на заданные значения
                SunniGrid.ColumnDefinitions[0].Width = new GridLength(5.156, GridUnitType.Star);
                SunniGrid.ColumnDefinitions[1].Width = new GridLength(35, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[2].Width = new GridLength(15, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[3].Width = new GridLength(115, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[4].Width = new GridLength(115, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[5].Width = new GridLength(115, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[6].Width = new GridLength(115, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[7].Width = new GridLength(115, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[8].Width = new GridLength(115, GridUnitType.Pixel);
                SunniGrid.ColumnDefinitions[9].Width = new GridLength(58, GridUnitType.Pixel);
            }
            else
            {
                // Меняем ширину всех столбцов на исходные значения с звездочками
                string[] originalWidths = { "5.156*", "20*", "10*", "70*", "70*", "70*", "77*", "70*", "58*", "58" };
                for (int i = 0; i < SunniGrid.ColumnDefinitions.Count; i++)
                {
                    ColumnDefinition columnDefinition = SunniGrid.ColumnDefinitions[i];
                    string widthString = originalWidths[i].TrimEnd('*'); // Удаляем символ '*' в конце строки
                    if (double.TryParse(widthString, out double widthValue)) // Преобразуем оставшуюся часть в число
                    {
                        columnDefinition.Width = new GridLength(widthValue, GridUnitType.Star);
                    }
                }
            }
        }




        //КОД ДЛЯ СЛАЙДЕРА ->
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            startPoint = e.GetPosition(null);
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPoint = e.GetPosition(null);
                Vector offset = startPoint - currentPoint;

                if (Math.Abs(offset.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(offset.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    // Выполните здесь логику перемещения карточек, используя offset.X и offset.Y
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + offset.X);
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + offset.Y);

                    startPoint = currentPoint;
                }
            }
        }
        //КОД ДЛЯ СЛАЙДЕРА <-

        //ПРИКОЛЬНАЯ СМЕНА РАСЦВЕТОЧКИ В ЗАВИСИМОСТИ ОТ ВРЕМЕНИ ->
        private void SimulateChangeTextEffect()
        {
            int currentHour = DateTime.Now.Hour;

            if (currentHour >= 4 && currentHour < 21)
            {
                ApplyTextEffect(Colors.Yellow);
            }
            else if (currentHour >= 22 || currentHour < 4)
            {
                ApplyTextEffect(Colors.BlueViolet);
            }
        }

        private void ApplyTextEffect(Color color)
        {
            DropShadowEffect dropShadowEffect = new DropShadowEffect
            {
                Color = color,
                ShadowDepth = 0,
                BlurRadius = 0,
                Opacity = 0.5
            };

            FirstTextBox.Effect = dropShadowEffect;
            SecondTextBox.Effect = dropShadowEffect;
            ThirdTextBox.Effect = dropShadowEffect;
            ForthTextBox.Effect = dropShadowEffect;
        }
        //ПРИКОЛЬНАЯ СМЕНА РАСЦВЕТОЧКИ В ЗАВИСИМОСТИ ОТ ВРЕМЕНИ <-
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window.WindowState != WindowState.Maximized)
                window.WindowState = WindowState.Maximized;
            else
                window.WindowState = WindowState.Normal;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
