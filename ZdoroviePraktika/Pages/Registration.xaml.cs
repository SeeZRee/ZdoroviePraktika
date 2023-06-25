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

namespace ZdoroviePraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        ZdorovieDBEntities context;
        public Registration(ZdorovieDBEntities cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            
            User user = new User()
            {
                Email = EmailBox.Text,
                Age = Convert.ToInt32(AgeBox.Text),
                Password = PasswordForRegBox.Text,
                DateOfLastLog = DateTime.Now,
                DateOfRegistration = DateTime.Now
            };

            string Email = EmailBox.Text;
            context.User.Find(Email);
            if (user.Email.Equals(Email))
            {
                MessageBox.Show("Данный пользователь уже существует");
            }
            else
            {
                context.User.Add(user);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
