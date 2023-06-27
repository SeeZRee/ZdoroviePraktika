using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace ZdoroviePraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для RememberPassPage.xaml
    /// </summary>
    public partial class RememberPassPage : Window
    {
        ZdorovieDBEntities context;
        User _user;
        public RememberPassPage(User user)
        {
            InitializeComponent();
            RemLoginBox.Text = user.Email;
            _user = user;
        }

        private void ShowPassClick(object sender, RoutedEventArgs e)
        {
            /* User _user = context.User.Find(Convert.ToInt32(RemAgeBox.Text));
             if (_user != null)
             {
                 MessageBox.Show("Введите логин и возраст");
             }
             else
             {*/
            /*User _user = context.User.Find(RemAgeBox.Text);
            if (_user == null)
            {
                MessageBox.Show("Неверный возраст");

                if (Convert.ToInt32(RemAgeBox.Text) != _user.Age || RemAgeBox.Text == null)
                {
                    MessageBox.Show("Неверный возраст");
                }
                else
                {
                    MessageBox.Show($"Ваш пароль: {_user.Password}", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }*/
            

            if (_user.Email == RemLoginBox.Text && _user.Age == Convert.ToInt32(RemAgeBox.Text))
            {
                MessageBox.Show($"Ваш пароль: {_user.Password}", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или возраст");
            }
        }
    }
}
