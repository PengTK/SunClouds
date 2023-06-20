﻿using SunClouds.Model;
using SunClouds.ViewModel.Helpers;
using static SunClouds.ForecastApi;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Net.Http;
using System.Timers;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Newtonsoft.Json.Linq;

namespace SunClouds.ViewModel
{
    internal class WeatherInfViewModel : PropertyChangedHelper
    {
        private string city;

        private bool flag = true;

        private string _mainPng;
        private string _onePng;
        private string _twoPng;
        private string _threePng;
        private string _card01Png;
        private string _card02Png;
        private string _card03Png;
        private string _card04Png;
        private string _card05Png;
        private string _card06Png;
        private string _card07Png;
        private string _card08Png;
        private string _card09Png;

        //время 
        private string _weatherLeftPanelNow;
        private string _weatherLeftPanelOne;
        private string _weatherLeftPanelTwo;
        private string _weatherLeftPanelThree;
        private string _weatherLeftPanelFour;
        private string _weatherLeftPanelFive;
        private string _weatherLeftPanelSix;
        private string _weatherLeftPanelSeven;
        private string _weatherLeftPanelEight;
        private string _weatherLeftPanelNine;
        //температура
        private string _tempaOne;
        private string _tempaTwo;
        private string _tempaThree;
        private string _tempaFour;
        private string _tempaFive;
        private string _tempaSix;
        private string _tempaSeven;
        private string _tempaEight;
        private string _tempaNine;
        //ощущения
        private string _feelsLeftNow;
        private string _feelsLeftOne;
        private string _feelsLeftTwo;
        private string _feelsLeftThree;

        //для влажности в правое окно
        private string _humidityOne;
        private string _humidityTwo;
        private string _humidityThree;
        private string _humidityFour;
        private string _humidityFive;
        private string _humiditySix;
        private string _humiditySeven;
        private string _humidityEight;
        private string _humidityNine;

        //для ощущений в правое окно 
        private string _feelsOne;
        private string _feelsTwo;
        private string _feelsThree;
        private string _feelsFour;
        private string _feelsFive;
        private string _feelsSix;
        private string _feelsSeven;
        private string _feelsEight;
        private string _feelsNine;

        //для ощущений в карточки
        public string FeelsOne { get => _feelsOne; set { _feelsOne = value; OnPropertyChanged(); } }
        public string FeelsTwo { get => _feelsTwo; set { _feelsTwo = value; OnPropertyChanged(); } }
        public string FeelsThree { get => _feelsThree; set { _feelsThree = value; OnPropertyChanged(); } }
        public string FeelsFour { get => _feelsFour; set { _feelsFour = value; OnPropertyChanged(); } }
        public string FeelsFive { get => _feelsFive; set { _feelsFive = value; OnPropertyChanged(); } }
        public string FeelsSix { get => _feelsSix; set { _feelsSix = value; OnPropertyChanged(); } }
        public string FeelsSeven { get => _feelsSeven; set { _feelsSeven = value; OnPropertyChanged(); } }
        public string FeelsEight { get => _feelsEight; set { _feelsEight = value; OnPropertyChanged(); } }
        public string FeelsNine { get => _feelsNine; set { _feelsNine = value; OnPropertyChanged(); } }

        //для влажности в карточки
        public string HumidityOne { get => _humidityOne; set { _humidityOne = value; OnPropertyChanged(); } }
        public string HumidityTwo { get => _humidityTwo; set { _humidityTwo = value; OnPropertyChanged(); } }
        public string HumidityThree { get => _humidityThree; set { _humidityThree = value; OnPropertyChanged(); } }
        public string HumidityFour { get => _humidityFour; set { _humidityFour = value; OnPropertyChanged(); } }
        public string HumidityFive { get => _humidityFive; set { _humidityFive = value; OnPropertyChanged(); } }
        public string HumiditySix { get => _humiditySix; set { _humiditySix = value; OnPropertyChanged(); } }
        public string HumiditySeven { get => _humiditySeven; set { _humiditySeven = value; OnPropertyChanged(); } }
        public string HumidityEight { get => _humidityEight; set { _humidityEight = value; OnPropertyChanged(); } }
        public string HumidityNine { get => _humidityNine; set { _humidityNine = value; OnPropertyChanged(); } }


        // для температуры
        public string TempaOne { get => _tempaOne;  set { _tempaOne = value; OnPropertyChanged(); }}
        public string TempaTwo {get => _tempaTwo;  set { _tempaTwo = value; OnPropertyChanged(); }}
        public string TempaThree {get => _tempaThree;set { _tempaThree = value; OnPropertyChanged(); }}
        public string TempaFour { get => _tempaFour; set { _tempaFour = value; OnPropertyChanged(); } }
        public string TempaFive { get => _tempaFive; set { _tempaFive = value; OnPropertyChanged(); } }
        public string TempaSix { get => _tempaSix; set { _tempaSix = value; OnPropertyChanged(); }}
        public string TempaSeven { get => _tempaSeven; set { _tempaSeven = value; OnPropertyChanged(); } }
        public string TempaEight { get => _tempaEight; set { _tempaEight = value; OnPropertyChanged(); } }
        public string TempaNine { get => _tempaNine; set { _tempaNine = value; OnPropertyChanged(); } }

        // для времени
        public string WeatherLeftPanelNow { get => _weatherLeftPanelNow; set { _weatherLeftPanelNow = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelOne { get => _weatherLeftPanelOne; set { _weatherLeftPanelOne = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelTwo { get => _weatherLeftPanelTwo; set { _weatherLeftPanelTwo = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelThree { get => _weatherLeftPanelThree; set { _weatherLeftPanelThree = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelFour{ get => _weatherLeftPanelFour; set { _weatherLeftPanelFour = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelFive { get => _weatherLeftPanelFive; set { _weatherLeftPanelFive = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelSix { get => _weatherLeftPanelSix; set { _weatherLeftPanelSix = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelSeven { get => _weatherLeftPanelSeven; set { _weatherLeftPanelSeven = value; OnPropertyChanged(); } }
        public string WeatherLeftPanelEight { get => _weatherLeftPanelEight; set { _weatherLeftPanelEight = value; OnPropertyChanged(); } }        
        public string WeatherLeftPanelNine { get => _weatherLeftPanelNine; set { _weatherLeftPanelNine = value; OnPropertyChanged(); } }  
        //для ощущений в левой панели
        public string FeelsLeftNow { get => _feelsLeftNow; set{_feelsLeftNow = value; OnPropertyChanged();} }
        public string FeelsLeftOne { get => _feelsLeftOne;  set{_feelsLeftOne = value;OnPropertyChanged();} }
        public string FeelsLeftTwo { get => _feelsLeftTwo; set{_feelsLeftTwo = value; OnPropertyChanged();} }
        public string FeelsLeftThree { get => _feelsLeftThree; set { _feelsLeftThree = value; OnPropertyChanged(); } }
        //получение города
        public string City 
        {  
            get { return city; } 
            set 
            {
                city = value;
                OnPropertyChanged();
                Selected();
            } 
        }

        //таймер для обновления данных каждый час
        private readonly Timer _timer = new Timer();
        public WeatherInfViewModel(string city)
        {
            City = city;

            _timer.Elapsed += async (sender, e) => await Selected();
            _timer.Interval = TimeSpan.FromHours(1).TotalMilliseconds;
            _timer.Start();
            
        }

        //вывод данных из API
        public async Task Selected()
        {
            if (DateTime.Now.Hour%2 == 1 || flag)
            {
                _ = new RootObject();
                RootObject rootObject = await WeatherForecast.GetWeatherForecast(city);
                WeatherLeftPanelNow = TimeConverter.UnixToUtc(rootObject.list[0].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelOne = TimeConverter.UnixToUtc(rootObject.list[1].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelTwo = TimeConverter.UnixToUtc(rootObject.list[2].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelThree = TimeConverter.UnixToUtc(rootObject.list[3].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelFour = TimeConverter.UnixToUtc(rootObject.list[4].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelFive = TimeConverter.UnixToUtc(rootObject.list[5].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelSix = TimeConverter.UnixToUtc(rootObject.list[6].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelSeven = TimeConverter.UnixToUtc(rootObject.list[7].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelEight = TimeConverter.UnixToUtc(rootObject.list[8].dt, rootObject.city.timezone).ToString("HH:mm");
                WeatherLeftPanelNine = TimeConverter.UnixToUtc(rootObject.list[9].dt, rootObject.city.timezone).ToString("HH:mm");

                TempaOne = Math.Round(rootObject.list[1].main.temp).ToString() + '°';
                TempaTwo = Math.Round(rootObject.list[2].main.temp).ToString() + '°';
                TempaThree = Math.Round(rootObject.list[3].main.temp).ToString() + '°';
                TempaFour = Math.Round(rootObject.list[4].main.temp).ToString() + '°';
                TempaFive = Math.Round(rootObject.list[5].main.temp).ToString() + '°';
                TempaSix = Math.Round(rootObject.list[6].main.temp).ToString() + '°';
                TempaSeven = Math.Round(rootObject.list[7].main.temp).ToString() + '°';
                TempaEight = Math.Round(rootObject.list[8].main.temp).ToString() + '°';
                TempaNine = Math.Round(rootObject.list[9].main.temp).ToString() + '°';

                HumidityOne = rootObject.list[1].main.humidity.ToString() + '°';
                HumidityTwo = rootObject.list[2].main.humidity.ToString() + '°';
                HumidityThree = rootObject.list[3].main.humidity.ToString() + '°';
                HumidityFour = rootObject.list[4].main.humidity.ToString() + '°';
                HumidityFive = rootObject.list[5].main.humidity.ToString() + '°';
                HumiditySix = rootObject.list[6].main.humidity.ToString() + '°';
                HumiditySeven = rootObject.list[7].main.humidity.ToString() + '°';
                HumidityEight = rootObject.list[8].main.humidity.ToString() + '°';
                HumidityNine = rootObject.list[9].main.humidity.ToString() + '°';

                FeelsOne = Math.Round(rootObject.list[1].main.feels_like).ToString() + '°';
                FeelsTwo = Math.Round(rootObject.list[2].main.feels_like).ToString() + '°';
                FeelsThree = Math.Round(rootObject.list[3].main.feels_like).ToString() + '°';
                FeelsFour = Math.Round(rootObject.list[4].main.feels_like).ToString() + '°';
                FeelsFive = Math.Round(rootObject.list[5].main.feels_like).ToString() + '°';
                FeelsSix = Math.Round(rootObject.list[6].main.feels_like).ToString() + '°';
                FeelsSeven = Math.Round(rootObject.list[7].main.feels_like).ToString() + '°';
                FeelsEight = Math.Round(rootObject.list[8].main.feels_like).ToString() + '°';
                FeelsNine = Math.Round(rootObject.list[9].main.feels_like).ToString() + '°';

                FeelsLeftNow = rootObject.list[0].weather[0].description.ToString() + "," + Math.Round(rootObject.list[0].main.temp).ToString() + '°' + "\n" + "Ощущается как " + Math.Round(rootObject.list[0].main.feels_like).ToString() + '°';
                FeelsLeftOne = rootObject.list[1].weather[0].description.ToString() + "," + Math.Round(rootObject.list[1].main.temp).ToString() + '°' + "\n" + "Ощущается как " + Math.Round(rootObject.list[1].main.feels_like).ToString() + '°';
                FeelsLeftTwo = rootObject.list[2].weather[0].description.ToString() + "," + Math.Round(rootObject.list[2].main.temp).ToString() + '°' + "\n" + "Ощущается как " + Math.Round(rootObject.list[2].main.feels_like).ToString() + '°';
                FeelsLeftThree = rootObject.list[3].weather[0].description.ToString() + "," + Math.Round(rootObject.list[3].main.temp).ToString() + '°' + "\n" + "Ощущается как " + Math.Round(rootObject.list[3].main.feels_like).ToString() + '°';

                Feels = Math.Round(rootObject.list[0].main.feels_like).ToString() + '°';
                MinTempa = rootObject.list[0].main.temp_min.ToString() + '°';
                MaxTempa = rootObject.list[0].main.temp_max.ToString() + '°';
                //давление
                Pressure = rootObject.list[0].main.pressure.ToString() + "мм. рт. ст.";
                //влажность
                Humidity = rootObject.list[0].main.humidity.ToString() + "%";
                //скорость ветра
                Wind = rootObject.list[0].wind.speed.ToString() + "м/с";
                // темпа ветра
                WindTemp = rootObject.list[0].wind.deg.ToString() + "°";

                if (rootObject.list[0].weather[0].description.ToString() == "ясно")
                {
                    MainPng = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[0].weather[0].description.ToString() == "дождь" || rootObject.list[0].weather[0].description.ToString() == "небольшой дождь")
                {
                    MainPng = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[0].weather[0].description.ToString() == "пасмурно" || rootObject.list[0].weather[0].description.ToString() == "переменная облачность" || rootObject.list[0].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[0].weather[0].description.ToString() == "небольшая облачность")
                {
                    MainPng = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[1].weather[0].description.ToString() == "ясно")
                {
                    OnePng = "/WeatherIcons/Sunny.png";
                    Card01Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[1].weather[0].description.ToString() == "дождь" || rootObject.list[1].weather[0].description.ToString() == "небольшой дождь")
                {
                    OnePng = "/WeatherIcons/Rainy.png";
                    Card01Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[1].weather[0].description.ToString() == "пасмурно" || rootObject.list[1].weather[0].description.ToString() == "переменная облачность" || rootObject.list[1].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[1].weather[0].description.ToString() == "небольшая облачность")
                {
                    OnePng = "/WeatherIcons/Cloudy.png";
                    Card01Png = "/WeatherIcons/Cloudy.png";
                }


                if (rootObject.list[2].weather[0].description.ToString() == "ясно")
                {
                    TwoPng = "/WeatherIcons/Sunny.png";
                    Card02Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[2].weather[0].description.ToString() == "дождь" || rootObject.list[2].weather[0].description.ToString() == "небольшой дождь")
                {
                    TwoPng = "/WeatherIcons/Rainy.png";
                    Card02Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[2].weather[0].description.ToString() == "пасмурно" || rootObject.list[2].weather[0].description.ToString() == "переменная облачность" || rootObject.list[2].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[2].weather[0].description.ToString() == "небольшая облачность")
                {
                    TwoPng = "/WeatherIcons/Cloudy.png";
                    Card02Png = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[3].weather[0].description.ToString() == "ясно")
                {
                    ThreePng = "/WeatherIcons/Sunny.png";
                    Card03Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[3].weather[0].description.ToString() == "дождь" || rootObject.list[3].weather[0].description.ToString() == "небольшой дождь")
                {
                    ThreePng = "/WeatherIcons/Rainy.png";
                    Card03Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[3].weather[0].description.ToString() == "пасмурно" || rootObject.list[3].weather[0].description.ToString() == "переменная облачность" || rootObject.list[3].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[3].weather[0].description.ToString() == "небольшая облачность")
                {
                    ThreePng = "/WeatherIcons/Cloudy.png";
                    Card03Png = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[4].weather[0].description.ToString() == "ясно")
                {
                    Card04Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[4].weather[0].description.ToString() == "дождь" || rootObject.list[3].weather[0].description.ToString() == "небольшой дождь")
                {
                    Card04Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[4].weather[0].description.ToString() == "пасмурно" || rootObject.list[3].weather[0].description.ToString() == "переменная облачность" || rootObject.list[3].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[3].weather[0].description.ToString() == "небольшая облачность")
                {
                    Card04Png = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[5].weather[0].description.ToString() == "ясно")
                {
                    Card05Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[5].weather[0].description.ToString() == "дождь" || rootObject.list[3].weather[0].description.ToString() == "небольшой дождь")
                {
                    Card05Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[5].weather[0].description.ToString() == "пасмурно" || rootObject.list[3].weather[0].description.ToString() == "переменная облачность" || rootObject.list[3].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[3].weather[0].description.ToString() == "небольшая облачность")
                {
                    Card05Png = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[6].weather[0].description.ToString() == "ясно")
                {
                    Card06Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[6].weather[0].description.ToString() == "дождь" || rootObject.list[3].weather[0].description.ToString() == "небольшой дождь")
                {
                    Card06Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[6].weather[0].description.ToString() == "пасмурно" || rootObject.list[3].weather[0].description.ToString() == "переменная облачность" || rootObject.list[3].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[3].weather[0].description.ToString() == "небольшая облачность")
                {
                    Card06Png = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[7].weather[0].description.ToString() == "ясно")
                {
                    Card07Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[7].weather[0].description.ToString() == "дождь" || rootObject.list[3].weather[0].description.ToString() == "небольшой дождь")
                {
                    Card07Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[7].weather[0].description.ToString() == "пасмурно" || rootObject.list[3].weather[0].description.ToString() == "переменная облачность" || rootObject.list[3].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[3].weather[0].description.ToString() == "небольшая облачность")
                {
                    Card07Png = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[8].weather[0].description.ToString() == "ясно")
                {
                    Card08Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[8].weather[0].description.ToString() == "дождь" || rootObject.list[3].weather[0].description.ToString() == "небольшой дождь")
                {
                    Card08Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[8].weather[0].description.ToString() == "пасмурно" || rootObject.list[3].weather[0].description.ToString() == "переменная облачность" || rootObject.list[3].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[3].weather[0].description.ToString() == "небольшая облачность")
                {
                    Card08Png = "/WeatherIcons/Cloudy.png";
                }

                if (rootObject.list[9].weather[0].description.ToString() == "ясно")
                {
                    Card09Png = "/WeatherIcons/Sunny.png";
                }
                else if (rootObject.list[9].weather[0].description.ToString() == "дождь" || rootObject.list[3].weather[0].description.ToString() == "небольшой дождь")
                {
                    Card09Png = "/WeatherIcons/Rainy.png";
                }
                else if (rootObject.list[9].weather[0].description.ToString() == "пасмурно" || rootObject.list[3].weather[0].description.ToString() == "переменная облачность" || rootObject.list[3].weather[0].description.ToString() == "облачно с прояснениями" || rootObject.list[3].weather[0].description.ToString() == "небольшая облачность")
                {
                    Card09Png = "/WeatherIcons/Cloudy.png";
                }

                flag = false;

                ChartValues<ObservablePoint> _values1 = new ChartValues<ObservablePoint>();
                ChartValues<ObservablePoint> _values2 = new ChartValues<ObservablePoint>();
                ChartValues<ObservablePoint> _values3 = new ChartValues<ObservablePoint>();

                for (int i = 0; i < 13; i++)
                {

                    _values1.Add(new ObservablePoint(i, Convert.ToDouble(rootObject.list[i].main.pressure)));
                }

                for (int i = 0; i < 13; i++)
                {
                    _values2.Add(new ObservablePoint(i, Convert.ToDouble(rootObject.list[i].main.temp)));
                }

                for (int i = 0; i < 13; i++)
                {
                    _values3.Add(new ObservablePoint(i, Convert.ToDouble(rootObject.list[i].main.feels_like)));
                }

                Labels = new[] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00"};


                Diagrramma = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Давление",
                        Values = _values1,
                    },
                    new LineSeries
                    {
                        Title = "Температура",
                        Values = _values2,
                    },
                    new LineSeries
                    {
                        Title = "Ощущается как",
                        Values = _values3,
                    }
                };

                Formatter = value =>value.ToString();


            }
            else
            {

            }
        }
       

        //для картинок
        public string MainPng {get { return _mainPng; } set { _mainPng = value; OnPropertyChanged(); } }
        public string OnePng { get => _onePng; set { _onePng = value; OnPropertyChanged(); } }
        public string TwoPng { get => _twoPng; set { _twoPng = value; OnPropertyChanged(); } }
        public string ThreePng { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card01Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card02Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card03Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card04Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card05Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card06Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card07Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card08Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public string Card09Png { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }        


        //для левой части окна (подробные данные)
        private string _feels;
        private string _minTempa;
        private string _maxTempa;
        private string _pressure;
        private string _humidity;
        private string _wind;
        private string _windTemp;
        public string Feels {  get => _feels; set { _feels = value; OnPropertyChanged(); } }
        public string MinTempa {  get => _minTempa; set { _minTempa = value; OnPropertyChanged(); }  }
        public string MaxTempa { get => _maxTempa; set{_maxTempa = value; OnPropertyChanged();} }
        public string Pressure { get => _pressure; set { _pressure = value; OnPropertyChanged(); } }
        public string Humidity { get => _humidity; set { _humidity = value; OnPropertyChanged(); } }
        public string Wind { get => _wind; set { _wind = value; OnPropertyChanged();} }
        public string WindTemp { get => _windTemp; set { _windTemp = value; OnPropertyChanged(); } }

        private SeriesCollection _diagr;
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public SeriesCollection Diagrramma
        {
            get { return _diagr; }
            set
            {
                _diagr = value;
            }
        }
        
    }

}
