using ExamenationApplication.Controllers;
using ExamenationApplication.Models;
using RestSharp;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        ApiController ApiController;
        public AuthWindow()
        {
            InitializeComponent();
            ApiController = new ApiController("http://192.168.50.194:8080");

        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            RegWindow window = new RegWindow();
            window.Show();
            this.Close();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            TokenResult result = ApiController.GetToken(Login.Text, Password.Text);
            if(result != null)
            {
                List<City> Cities = ApiController.GetCities(result);
                MainMenuWindow window = new MainMenuWindow(result, Cities);
                window.Show();
                this.Close();
                MessageBox.Show("Хорошо! Отлично!");
                return;
            }
            MessageBox.Show("Нехорошо! Неотлично");

        }
    }
}
