using SunClouds.ViewModel.Helpers;

namespace SunClouds.ViewModel
{
    internal class WeatherInfViewModel : PropertyChangedHelper
    {
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


        public WeatherInfViewModel(string city)
        {
            City = city;
        }
    }
}
