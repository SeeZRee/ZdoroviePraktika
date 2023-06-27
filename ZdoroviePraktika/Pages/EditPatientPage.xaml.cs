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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZdoroviePraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page
    {
        ZdorovieDBEntities context;
        Patient patient;
        public EditPatientPage(ZdorovieDBEntities c, Patient patt)
        {
            InitializeComponent();
            context = c;
            patient = patt;
            EditFioBox.Text = patient.fio;
            EditSeriaBox.Text = patient.seriesAndNumberPassword;
            EditPhoneBox.Text = patient.phone.ToString();
            EditOmsBox.Text = patient.oms.ToString();
        }

        private void EditEditPatientClick(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal omss;
                patient.fio = EditFioBox.Text;
                patient.seriesAndNumberPassword = EditSeriaBox.Text;
                patient.phone = Convert.ToDecimal(EditPhoneBox.Text);
                patient.oms = Convert.ToDecimal(EditOmsBox.Text);
                context.SaveChanges();
                NavigationService.Navigate(new PatientsPage(context));
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void CancelEditPatientClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
