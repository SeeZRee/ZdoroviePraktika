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
        Window window;
        public Authorization(ZdorovieDBEntities cont, Window w)
        {
            InitializeComponent();
            context = cont;
            window = w;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            EnterButton.IsEnabled = true;
            LoginBox.Background = Brushes.White;
            PasswordBox.Background = Brushes.White;
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
                    countClick = 0;
                    LoginBox.Background = Brushes.Green;
                    PasswordBox.Background = Brushes.Green;
                    MessageBox.Show("Вы успешно авторизованны");
                    user.DateOfLastLog= DateTime.Now;
                    context.SaveChanges();
                    NavigationService.Navigate(new ManeMenuPage(context, window));
                }
                else 
                {
                    MessageBox.Show("Вы ввели неверный пароль");
                    if (countClick >= 3) 
                    {
                        EnterButton.IsEnabled=false;
                        LoginBox.Background = Brushes.Red;
                        PasswordBox.Background = Brushes.Red;
                        timer.Start();
                        MessageBox.Show("Повторите попытку через 30 сек");
                        RememberPass.Visibility = Visibility.Visible;
                    }
                }

            }
            else
            {
                MessageBox.Show("Такого пользователя не существует");
                if (countClick >= 3)
                {
                    EnterButton.IsEnabled = false;
                    LoginBox.Background = Brushes.Red;
                    PasswordBox.Background = Brushes.Red;
                    RememberPass.Visibility = Visibility.Visible;
                    timer.Start();
                    MessageBox.Show("Повторите попытку через 30 сек");
                    
                }
            }
        }

        private void RegNewClick(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(context);
            registration.Show();
        }

        private void RememberPassClick(object sender, RoutedEventArgs e)
        {
            User user = context.User.Find(LoginBox.Text);
            if (user == null)
            {
                MessageBox.Show("Введите логин");
            }
            else
            {
                ///User us = context.User.Find(LoginBox.Text);
                ///NavigationService.Navigate(new RememberPassPage(us));
                RememberPassPage rememberPassPage = new RememberPassPage(user);
                rememberPassPage.Show();
                ///Myframe.Navigate(new Pages.Authorization(context));
                ///RememberPassPage.Navigate(new Pages.RememberPassPage(user));
            }
        }
    }
}
