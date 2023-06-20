using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SunClouds
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string theme;
        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/ThemesLib;component/Themes/{value}Theme.xaml", UriKind.Absolute) };

                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dict);

            }
        }

        TimeSpan nightTimeStart = new TimeSpan(0, 0, 0);
        TimeSpan nightTimeEnd = new TimeSpan(3, 0, 0);

        TimeSpan morningTimeStart = new TimeSpan(4, 0, 0);
        TimeSpan morningTimeEnd = new TimeSpan(11, 0, 0);

        TimeSpan dayTimeStart = new TimeSpan(12, 0, 0);
        TimeSpan dayTimeEnd = new TimeSpan(16, 0, 0);

        TimeSpan eveningTimeStart = new TimeSpan(17, 0, 0);
        TimeSpan eveningTimeEnd = new TimeSpan(23, 0, 0);

        public App()
        {
            InitializeComponent();
            CheckThemeTime();
        }

        public async Task CheckThemeTime()
        {
            var currentTime = DateTime.Now;
            var time = currentTime.TimeOfDay;

            if (time >= nightTimeStart && time <= nightTimeEnd)
            {
                Theme = "Night";
            }
            else if ((time >= morningTimeStart && time <= morningTimeEnd) || (time >= eveningTimeStart && time <= eveningTimeEnd))
            {
                Theme = "Morning-Evening";
            }
            else if (time >= dayTimeStart && time <= dayTimeEnd)
            {
                Theme = "Day";
            }

            /*await Task.Delay(TimeSpan.FromMinutes(1));*/
            await Task.Delay(1000);

            await CheckThemeTime();
        }
    }
}
