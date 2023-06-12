using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SunClouds.ForecastApi;

namespace SunClouds.Model
{
    internal class CurientWeatherApi
    {
        public async static Task<Root> GetCurientWeather(string sityName)
        {
            try
            {
                var httpn = new HttpClient();
                var uri = String.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&lang=ru&appid=564b5aadf3e12ef181a4035457b6e0b3&units=metric", sityName);
                var response = await httpn.GetAsync(uri);
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Root>(result);
                return data;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);

                return null;
            }          

            
        }
        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class Weather
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double FeelsLike { get; set; }
            public double TempMin { get; set; }
            public double TempMax { get; set; }
            public int Pressure { get; set; }
            public int Humidity { get; set; }
            public int SeaLevel { get; set; }
            public int GrndLevel { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
            public int Deg { get; set; }
            public double Gust { get; set; }
        }

        public class Clouds
        {
            public int All { get; set; }
        }

        public class Sys
        {
            public int Type { get; set; }
            public int Id { get; set; }
            public string Country { get; set; }
            public int Sunrise { get; set; }
            public int Sunset { get; set; }
        }

        public class Root
        {
            public Coord Coord { get; set; }
            public List<Weather> Weather { get; set; }
            public string Base { get; set; }
            public Main Main { get; set; }
            public int Visibility { get; set; }
            public Wind Wind { get; set; }
            public Clouds Clouds { get; set; }
            public int Dt { get; set; }
            public Sys Sys { get; set; }
            public int Timezone { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Cod { get; set; }
        }

    }
}
