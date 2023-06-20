using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SunClouds
{
    internal class ForecastApi
    {
        public class WeatherForecast
        {
            public async static Task<RootObject> GetWeatherForecast(string sityName)
            {
                try
                {
                    var httpn = new HttpClient();
                    var uri = String.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&lang=ru&cnt=12&appid=564b5aadf3e12ef181a4035457b6e0b3&units=metric", sityName);
                    var response = await httpn.GetAsync(uri);
                    var result = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<RootObject>(result);

                    return data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    return null;
                }
            }

        }
        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double pressure { get; set; } 
            public int humidity { get; set; }
            public double temp_kf { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }          
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }       

        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }
        public class List
        {
            public int dt { get; set; }
            public Main main { get; set; }
            public List<Weather> weather { get; set; }            
            public Wind wind { get; set; }           
            public string dt_txt { get; set; }
        }

        public class Coord
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public int timezone { get; set; }

        }

        public class RootObject
        {
            public string cod { get; set; }
            public double message { get; set; }
            public int cnt { get; set; }
            public List<List> list { get; set; }
            public City city { get; set; }
            
        }
    }
}
