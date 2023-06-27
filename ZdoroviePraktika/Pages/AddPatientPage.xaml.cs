using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace ZdoroviePraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPatientPage.xaml
    /// </summary>
    public partial class AddPatientPage : Page
    {
        ZdorovieDBEntities context;
        ///Patient patient;
        public AddPatientPage(ZdorovieDBEntities c)
        {
            InitializeComponent();
            context = c;
        }
/*        public AddPatientPage(ZdorovieDBEntities c, Patient pat)
        {
            InitializeComponent();
            context = c;
            patient = pat;
            ButtonAU.Content = "Редактировать";
            ButtonAU.Click += UpdateClick;
            FioBox.Text = patient.fio;
            SeriaBox.Text = patient.seriesAndNumberPassword;
            PhoneBox.Text = patient.phone.ToString();
            OmsBox.Text = patient.oms.ToString();

        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                patient.fio = FioBox.Text;
                patient.seriesAndNumberPassword = SeriaBox.Text;
                patient.phone = Convert.ToDecimal(PhoneBox.Text);
                patient.oms = Convert.ToDecimal(OmsBox.Text);
                context.SaveChanges();
                NavigationService.Navigate(new PatientsPage(context));
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
        }*/

        private void CancelAddPatientClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddPatientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patt = new Patient()
                {
                    ///Appel = context.Appel.Last().idAppel + 1,
                    fio = FioBox.Text,
                    seriesAndNumberPassword = SeriaBox.Text,
                    phone = Convert.ToDecimal(PhoneBox.Text),
                    oms = Convert.ToDecimal(OmsBox.Text)
                };
                context.Patient.Add(patt);
                context.SaveChanges();
                MessageBox.Show("Пациент успешно добавлен");
                NavigationService.Navigate(new PatientsPage(context));
            }
            catch(FormatException)
            {
                MessageBox.Show("Ошибка вводимых данных");
            }
            catch
            {
                MessageBox.Show("Что-то не так...");
            }
        }
    }
}
