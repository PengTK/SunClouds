using System.Windows;
using System.Windows.Input;
using SunClouds.ViewModel.Helpers;
using SunClouds.View;
using CommunityToolkit.Mvvm.Input;

namespace SunClouds.ViewModel
{
    internal class MainViewModel : PropertyChangedHelper
    {
        private object windowContent;
        public object WindowContent
        {
            get { return windowContent; }
            set
            {
                windowContent = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        public ICommand OpenSecondWindowCommand { get; }

        public MainViewModel()
        {
            OpenSecondWindowCommand = new RelayCommand(OpenSecondWindow);
        }

        private void OpenSecondWindow()
        {
            WeatherInfWindow secondWindow = new WeatherInfWindow(/*City*/) { DataContext = new WeatherInfViewModel(City) };
            WindowContent = secondWindow;
            secondWindow.Show();

            Application.Current.MainWindow.Hide();
            /*Application.Current.MainWindow.Hide();*/
        }
    }
}
