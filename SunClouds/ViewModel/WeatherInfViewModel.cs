﻿using SunClouds.Model;
using SunClouds.ViewModel.Helpers;
using static SunClouds.ForecastApi;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Net.Http;
using System.Timers;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SunClouds.ViewModel
{
    internal class WeatherInfViewModel : PropertyChangedHelper
    {
        private string city;

        private RootObject rootObject;

        private bool flag = true;

        private string _mainPng;
        private string _onePng;
        private string _twoPng;
        private string _threePng;
        private BitmapImage[] _cardMassive;
        private BitmapImage[] _onetwothree;
        public BitmapImage[] OneTwoTrhee
        {
            get => _onetwothree;
            set
            {
                _onetwothree = value;
                OnPropertyChanged();
            }
        }

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
        private string _tempa;
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
        public string Tempa { get => _tempa;  set { _tempa = value; OnPropertyChanged(); }}
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

        public ICommand CnDiagr01 { get; }
        public ICommand CnDiagr02 { get; }
        public ICommand CnDiagr03 { get; }

        //таймер для обновления данных каждый час
        private readonly Timer _timer = new Timer();
        public WeatherInfViewModel(string city)
        {
            OneTwoTrhee = new BitmapImage[4];
            CardMassive = new BitmapImage[9];
            City = city;

            _timer.Elapsed += async (sender, e) => await Selected();
            _timer.Interval = TimeSpan.FromHours(1).TotalMilliseconds;
            _timer.Start();

            CnDiagr01 = new RelayCommand(Diagram01);
            CnDiagr02 = new RelayCommand(Diagram02);
            CnDiagr03 = new RelayCommand(Diagram03);
        }

        //вывод данных из API
        public async Task Selected()
        {
            if (DateTime.Now.Hour%2 == 1 || flag)
            {
                _ = new RootObject();
                rootObject = await WeatherForecast.GetWeatherForecast(city);
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

                Tempa = Math.Round(rootObject.list[0].main.temp).ToString() + '°';


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

                ChartValues<double> doubles = new ChartValues<double>();

                SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Температура",
                        Values = doubles
                    },
                };

                for (int i = 0; i < 10; i++)
                {
                    doubles.Add(Math.Round(rootObject.list[i].main.temp));
                }

                Labels = new string[9];
                for (int i = 0; i < 9; i++)
                {
                    Labels[i] = TimeConverter.UnixToUtc(rootObject.list[i].dt, rootObject.city.timezone).ToString("HH");
                }
                YFormatter = value => value.ToString();

                for (int i = 0; i < 13; i++)
                {

                    if (i == 1 || i == 2 || i == 3)
                    {
                        if (rootObject.list[i].weather[0].icon.ToString() == "01d" || rootObject.list[i].weather[0].icon.ToString() == "01n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Sunny.png");
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Sunny.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "09d" || rootObject.list[i].weather[0].icon.ToString() == "10d" || rootObject.list[i].weather[0].icon.ToString() == "09n" || rootObject.list[i].weather[0].icon.ToString() == "10n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Rainy.png");
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Rainy.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "03d" || rootObject.list[i].weather[0].icon.ToString() == "02d" || rootObject.list[i].weather[0].icon.ToString() == "04d" || rootObject.list[i].weather[0].icon.ToString() == "02n" || rootObject.list[i].weather[0].icon.ToString() == "03n" || rootObject.list[i].weather[0].icon.ToString() == "04n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Cloudy.png");
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Cloudy.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "13d" || rootObject.list[i].weather[0].icon.ToString() == "13n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Snow.png");
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Snow.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "50d" || rootObject.list[i].weather[0].icon.ToString() == "50n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Wind.png");
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Wind.png");
                        }
                    }
                    else if (i == 0)
                    {
                        if (rootObject.list[i].weather[0].icon.ToString() == "01d" || rootObject.list[i].weather[0].icon.ToString() == "01n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Sunny.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "09d" || rootObject.list[i].weather[0].icon.ToString() == "10d" || rootObject.list[i].weather[0].icon.ToString() == "09n" || rootObject.list[i].weather[0].icon.ToString() == "10n")

                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Rainy.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "03d" || rootObject.list[i].weather[0].icon.ToString() == "02d" || rootObject.list[i].weather[0].icon.ToString() == "04d" || rootObject.list[i].weather[0].icon.ToString() == "02n" || rootObject.list[i].weather[0].icon.ToString() == "03n" || rootObject.list[i].weather[0].icon.ToString() == "04n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Cloudy.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "13d" || rootObject.list[i].weather[0].icon.ToString() == "13n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Snow.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "50d" || rootObject.list[i].weather[0].icon.ToString() == "50n")
                        {
                            OneTwoTrhee[i] = ToBitmapImage("/WeatherIcons/Wind.png");
                        }
                    }
                    else if (i == 9)
                    {
                        Notify("OneTwoTrhee", "CardMassive");
                    }
                    else
                    {
                        if (rootObject.list[i].weather[0].icon.ToString() == "01d" || rootObject.list[i].weather[0].icon.ToString() == "01n")
                        {
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Sunny.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "09d" || rootObject.list[i].weather[0].icon.ToString() == "10d" || rootObject.list[i].weather[0].icon.ToString() == "09n" || rootObject.list[i].weather[0].icon.ToString() == "10n")

                        {
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Rainy.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "03d" || rootObject.list[i].weather[0].icon.ToString() == "02d" || rootObject.list[i].weather[0].icon.ToString() == "04d" || rootObject.list[i].weather[0].icon.ToString() == "02n" || rootObject.list[i].weather[0].icon.ToString() == "03n" || rootObject.list[i].weather[0].icon.ToString() == "04n")
                        {
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Cloudy.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "13d" || rootObject.list[i].weather[0].icon.ToString() == "13n")
                        {
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Snow.png");
                        }
                        else if (rootObject.list[i].weather[0].icon.ToString() == "50d" || rootObject.list[i].weather[0].icon.ToString() == "50n")
                        {
                            CardMassive[i] = ToBitmapImage("/WeatherIcons/Wind.png");
                        }
                    }
                }

                flag = false;
            }
            else
            {

            }
        }

        private void Diagram01()
        {
            ChartValues<double> doubles = new ChartValues<double>();            

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Температура",
                    Values = doubles
                },
            };

            for (int i = 0; i < 10; i++)
            {
                doubles.Add(Math.Round(rootObject.list[i].main.temp));
                
            }
        }
        private void Diagram02()
        {
            ChartValues<double> doubles = new ChartValues<double>();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Ощущается как",
                    Values = doubles
                },
            };

            for (int i = 0; i < 10; i++)
            {
                doubles.Add(Math.Round(rootObject.list[i].main.feels_like));
            }           
        }
        private void Diagram03()
        {
            ChartValues<double> doubles = new ChartValues<double>();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Давление",
                    Values = doubles
                },
            };

            for (int i = 0; i < 10; i++)
            {
                doubles.Add(rootObject.list[i].main.pressure);
            }            
        }

        public BitmapImage ToBitmapImage(string imagePath)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            return bitmapImage;
        }

        //для картинок
        public string MainPng { get { return _mainPng; } set { _mainPng = value; OnPropertyChanged(); } }
        public string OnePng { get => _onePng; set { _onePng = value; OnPropertyChanged(); } }
        public string TwoPng { get => _twoPng; set { _twoPng = value; OnPropertyChanged(); } }
        public string ThreePng { get => _threePng; set { _threePng = value; OnPropertyChanged(); } }
        public BitmapImage[] CardMassive { get => _cardMassive; set { _cardMassive = value; OnPropertyChanged(); } }
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

        private SeriesCollection _SeriesCollection;
        private string[] _Labels;
        private Func<double, string> _YFormatter;
        public SeriesCollection SeriesCollection { get => _SeriesCollection; set { _SeriesCollection = value; OnPropertyChanged(); } }
        public string[] Labels { get => _Labels; set { _Labels = value; OnPropertyChanged(); } }
        public Func<double, string> YFormatter { get => _YFormatter; set { _YFormatter = value; OnPropertyChanged(); } }
    } 
}
