﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ZdoroviePraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        ZdorovieDBEntities context;
        DispatcherTimer timer;
        public Authorization(ZdorovieDBEntities cont)
        {
            InitializeComponent();
            context = cont;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,30);
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            EnterButton.IsEnabled = true;
            timer.Stop();
        }

        int countClick = 0;
        private void BottomClick(object sender, RoutedEventArgs e)
        {
            countClick++;
            string log = LoginBox.Text;
            string pass = PasswordBox.Password;
            User user = context.User.Find(log);
            if (user != null) 
            {
                if (user.Password.Equals(pass)) 
                {
                    MessageBox.Show("Вы успешно авторизованны");
                    countClick = 0;
                    ///LoginBox.Background("Green");
                }
                else 
                {
                    MessageBox.Show("Вы ввели неверный пароль");
                    if (countClick >= 3) 
                    {
                        EnterButton.IsEnabled=false;
                        timer.Start();
                        MessageBox.Show("Повторите попытку через 30 сек");
                    }
                }

            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
                if (countClick >= 3)
                {
                    EnterButton.IsEnabled = false;
                    timer.Start();
                    MessageBox.Show("Повторите попытку через 30 сек");
                }
            }
        }
    }
}
