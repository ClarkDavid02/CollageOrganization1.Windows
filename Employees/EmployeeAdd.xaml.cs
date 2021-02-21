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
using CollageOrganization1.Windows.Models.Enums;
using CollageOrganization1.Windows.Models;
using CollageOrganization1.Windows.BLL;

namespace CollageOrganization1.Windows.Employees
{
    /// <summary>
    /// Interaction logic for EmployeeAdd.xaml
    /// </summary>
    public partial class EmployeeAdd : Window
    {
        EmployeeList myParentWindow = new EmployeeList();

        public EmployeeAdd(EmployeeList parentWindow)
        {
            InitializeComponent();
            cboAssignment.ItemsSource = new List<string>() { "None", "Field", "Office" };
            cboGender.ItemsSource = new List<string>() { "None", "Regular", "Probationary" };
            myParentWindow = parentWindow;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errors.Add("First Name is required.");
            };

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errors.Add("Last Name is required.");
            };

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errors.Add("Email Address is required.");
            };

            if (string.IsNullOrEmpty(txtDepartmentName.Text))
            {
                errors.Add("Department Name is required.");
            };

            if (string.IsNullOrEmpty(txtContactNumber.Text))
            {
                errors.Add("Contact Number is required.");
            };

            if (cboAssignment.SelectedValue == null)
            {
                errors.Add("Please select an Assignment.");
            }

                if (cboGender.SelectedValue == null)
            {
                errors.Add("Please select a Gender.");
            }

            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    txtbErrors.Text = txtbErrors.Text + error + "\n";
                }

                return;
            }
            Assignment assignment = Assignment.Field;
            if (cboAssignment.SelectedValue.ToString().ToLower() == "office")
            {
                assignment = Assignment.Office;
            }

            Gender gender = Gender.Male;
            if (cboGender.SelectedValue.ToString().ToLower() == "Female")
            {
                gender = Gender.Female;
            }

            var op = EmployeeBLL.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                EmailAddress = txtEmailAddress.Text,
                DepartmentName = txtDepartmentName.Text,
                ContactNumber = txtContactNumber.Text,
                Gender = gender,
                Assignment = assignment
            }) ;

            if (op.Code != "200")
            {
                MessageBox.Show("Error : " + op.Message);
            }
            else
            {
                MessageBox.Show("Employee is successfully added to table");
            }

            myParentWindow.showData();
            this.Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

