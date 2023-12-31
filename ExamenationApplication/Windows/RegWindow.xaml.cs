﻿using ExamenationApplication.Controllers;
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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        ApiController controller; 
        public RegWindow()
        {
            InitializeComponent();
            controller = new ApiController("http://192.168.50.194:8080");
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account() { FIO = FIO.Text, Login = Login.Text, Password = Password.Text };
            RestResponse response = controller.CreateAccount(account);
            if(response.IsSuccessStatusCode)
            {
                AuthWindow wnd = new AuthWindow();
                wnd.Show();
                this.Close();
                MessageBox.Show("Хорошо! Отлично!");
                return;
            }
            MessageBox.Show(response.Content);
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow window = new AuthWindow();
            window.Show();
            this.Close();
        }
    }
}
