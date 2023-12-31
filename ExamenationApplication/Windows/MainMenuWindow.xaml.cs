﻿using ExamenationApplication.Controllers;
using ExamenationApplication.Models;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExamenationApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        TokenResult token;
        public List<City> Cities { get; set; }
        public City SelectedCity { get; set; }

        ApiController ApiController;
        public MainMenuWindow(TokenResult tokenResult, List<City> Cities)
        {
            DataContext = this;
            ApiController = new ApiController("http://192.168.50.194:8080");
            InitializeComponent();
            CitiesBox.ItemsSource = Cities;

            token = tokenResult;

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            WeatherBlock.Text = string.Empty;
            List<WeatherResult> results = ApiController.GetWeatherByCity(token, SelectedCity);
            foreach(WeatherResult weather in results)
            {
                WeatherBlock.Text += $"{SelectedCity.Name}: Температура: {weather.Temperature}, Дата: {weather.Date}";
            }
        }
    }
}
