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
    /// Логика взаимодействия для ManeMenuPage.xaml
    /// </summary>
    public partial class ManeMenuPage : Page
    {
        Window Window;
        ZdorovieDBEntities _context;
        public ManeMenuPage(ZdorovieDBEntities context, Window window)
        {
            InitializeComponent();
            Window = window;
            _context = context;
        }

        private void EscapeManeMenuClick(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }

        private void PatientsManeMenuClick(object sender, RoutedEventArgs e)
        {
            FrameToManePage.Navigate(new PatientsPage(_context));
        }
    }
}
