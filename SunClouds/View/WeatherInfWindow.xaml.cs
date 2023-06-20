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
        // добавление города
        private List<string> cityList = new List<string>();
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string cityName = CityTextBox.Text;

            if (!string.IsNullOrEmpty(cityName))
            {
                Grid grid = CreatePanel(cityName);
                myWrapPanel.Children.Add(grid);
                cityList.Add(cityName);
                CityTextBox.Clear();
            }
        }

        private void DeleteButton_Click(string cityName)
        {
            cityList.Remove(cityName);
            RefreshWrapPanel();
        }

        private Grid CreatePanel(string cityName)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(5, 10, 0, 0);
            grid.Height = 55;
            grid.Width = 120;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.HorizontalAlignment = HorizontalAlignment.Left;

            StackPanel stackPanel1 = new StackPanel();
            stackPanel1.Margin = new Thickness(0, 21, 0, 0);
            stackPanel1.Background = new SolidColorBrush(Color.FromArgb(0x7F, 0x3D, 0x95, 0xB9));

            TextBlock textBlock1 = new TextBlock();
            textBlock1.TextWrapping = TextWrapping.Wrap;
            textBlock1.Text = "55°45′07″ с.ш.       37°36′56″ в.д.";
            textBlock1.FontSize = 12;
            textBlock1.Padding = new Thickness(4);
            textBlock1.TextAlignment = TextAlignment.Center;
            textBlock1.Height = 34;

            stackPanel1.Children.Add(textBlock1);

            StackPanel stackPanel2 = new StackPanel();
            stackPanel2.Margin = new Thickness(0, 0, 0, 34);
            stackPanel2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x3D, 0x95, 0xB9));

            Grid innerGrid = new Grid();
            innerGrid.Height = 21;

            TextBlock textBlock2 = new TextBlock();
            textBlock2.TextWrapping = TextWrapping.Wrap;
            textBlock2.Text = cityName;
            textBlock2.FontSize = 13;
            textBlock2.Padding = new Thickness(2);
            textBlock2.TextAlignment = TextAlignment.Center;

            Button deleteButton = new Button();
            deleteButton.Content = "X";
            deleteButton.Margin = new Thickness(106, 0, 0, 5);
            deleteButton.Padding = new Thickness(0);
            deleteButton.FontSize = 12;
            deleteButton.Background = new SolidColorBrush(Colors.Transparent);
            deleteButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
            deleteButton.Width = 16;
            deleteButton.Height = 16;
            deleteButton.Click += (s, e) => DeleteButton_Click(cityName);

            innerGrid.Children.Add(textBlock2);
            innerGrid.Children.Add(deleteButton);

            stackPanel2.Children.Add(innerGrid);

            grid.Children.Add(stackPanel1);
            grid.Children.Add(stackPanel2);
            return grid;
        }

        private void RefreshWrapPanel()
        {
            myWrapPanel.Children.Clear();

            foreach (string cityName in cityList)
            {
                Grid grid = CreatePanel(cityName);
                myWrapPanel.Children.Add(grid);
            }
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            CityTextBox.Text = string.Empty;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            CityTextBox.Clear();
        }

        
    }
}
