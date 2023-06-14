using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThemesLib.Selectors
{
    public class ThemeSelector : ResourceDictionary
    {
        public ThemeSelector()
        {
            DateTime currentTime = DateTime.Now;

            string theme;
            if (currentTime.Hour >= 4 && currentTime.Hour < 11)
            {
                theme = "Themes/DayTheme.xaml";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour < 23)
            {
                theme = "Themes/Morning-EveningTheme.xaml";
            }
            else
            {
                theme = "Themes/NightTheme.xaml";
            }

            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri(theme, UriKind.RelativeOrAbsolute);

            MergedDictionaries.Add(resourceDictionary);
        }
    }
}
