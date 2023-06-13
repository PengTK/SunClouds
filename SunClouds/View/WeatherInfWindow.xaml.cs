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
        public WeatherInfWindow()
        {
            InitializeComponent();
            SimulateChangeTextEffect();
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
            // Введите желаемое время для симуляции
            int simulatedHour = 23;

            if (simulatedHour >= 4 && simulatedHour < 21)
            {
                ApplyTextEffect(Colors.Yellow);
            }
            else if (simulatedHour >= 22 || simulatedHour < 4)
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
                BlurRadius = 40,
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
