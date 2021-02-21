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
using CollageOrganization1.Windows.DAL;
using CollageOrganization1.Windows.Helpers;

namespace CollageOrganization1.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lblUserName.Content = "Welcome, " + ProgramUser.FullName;
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            Employees.EmployeeList listWindow = new Employees.EmployeeList();
            listWindow.Show();
        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            Students.StudentList listWindow = new Students.StudentList();
            listWindow.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            ProgramUser.Id = null;
            ProgramUser.FirstName = null;
            ProgramUser.LastName = null;
            ProgramUser.EmailAddress = null;

            LoginWindow login = new LoginWindow();
            login.Show();

            this.Close();
        }
    }
}
