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

namespace ZdoroviePraktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        ZdorovieDBEntities context;
        public PatientsPage(ZdorovieDBEntities _cont)
        {
            InitializeComponent();
            context = _cont;
            CountPatient.Text = $"{context.Patient.Count()} пациентов";
            PatientsData.ItemsSource = context.Patient.ToList();
        }

        private void AddNewPatient(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPatientPage(context));
        }

        private void DeletePatientClick (object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить пациента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Patient _pat = PatientsData.SelectedItem as Patient;
                    context.Patient.Remove(_pat);
                    context.SaveChanges();
                    PatientsData.ItemsSource = context.Patient.ToList();

                }
                catch
                {
                    MessageBox.Show("Ошибка в PatientsPage.cs");
                }
            }
        }

        private void EditPatientClick(object sender, RoutedEventArgs e)
        {
            Patient pat = PatientsData.SelectedItem as Patient;
            NavigationService.Navigate(new EditPatientPage(context, pat));
        }
    }
}
