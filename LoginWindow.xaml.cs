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
using System.Windows.Shapes;
using CollageOrganization1.Windows.BLL;
using CollageOrganization1.Windows.Helpers;

namespace CollageOrganization1.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            lblErrors.Content = "";

            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                lblErrors.Content = "Invalid Login";
                return;
            };

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblErrors.Content = "Invalid Login";
                return;
            };

            var op = EmployeeBLL.Login(txtEmailAddress.Text, txtPassword.Text);

            if (op.Code == "200")
            {
                var employee = EmployeeBLL.GetById(op.ReferenceId);

                ProgramUser.Id = op.ReferenceId;
                ProgramUser.FirstName = employee.FirstName;
                ProgramUser.LastName = employee.LastName;
                ProgramUser.EmailAddress = employee.EmailAddress;

                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                lblErrors.Content = "Invalid Login";
            }

        }

        
    }
    
}
        
    

