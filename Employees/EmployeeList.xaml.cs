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
using CollageOrganization1.Windows.Models;

namespace CollageOrganization1.Windows.Employees
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Window
    {
        private string sortBy = "employee name";
        private string sortOrder = "asc";
        private string keyword = "";
        private string filterAssignment = "";
        private string filterGender = "";
        private int pageSize = 5;
        private int pageIndex = 1;
        private long pageCount = 1;
        public EmployeeList()
        {

            InitializeComponent();
             
            cboSortBy.ItemsSource = new List<string>() { "Salary", "LastName" };
            cboSortOrder.ItemsSource = new List<string>() { "Ascending", "Descending" };
            cboFilterAssignment.ItemsSource = new List<string>() { "None", "Field", "Office" };
            cboFilterGender.ItemsSource = new List<string>() { "None", "Regular", "Probationary" };
            showData();

        }

        public void showData()
        {


            var employees = EmployeeBLL.Search(pageIndex, pageSize, sortBy, sortOrder, filterAssignment, filterGender, keyword);

            dgEmployees.ItemsSource = employees.Items;
            pageCount = employees.PageCount;

        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = (int)pageCount;
            showData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                keyword = txtSearch.Text;
                showData();
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            showData();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex - 1;
            if (pageIndex < 1)
            {
                pageIndex = 1;
            };
            showData();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex + 1;
            if (pageIndex > pageCount)
            {
                pageIndex = (int)pageCount;

            };
            showData();
        }

        private void cboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sortBy = cboSortBy.SelectedValue.ToString();
            showData();
        }

        private void cboSortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboSortOrder.SelectedValue.ToString().ToLower() == "ascending")
            {
                sortOrder = "asc";
            }
            else
            {
                sortOrder = "desc";
            }
            showData();
        }

        private void txtPageSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPageSize.Text.Length > 0)
            {
                int.TryParse(txtPageSize.Text, out pageSize);
            }

            showData();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAdd addWindow = new Employees.EmployeeAdd(this);
            addWindow.Show();
        }

        private void cboFilterGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboFilterGender.SelectedValue.ToString().ToLower() == "male")
            {
                filterGender = "male";
            }
            else if (cboFilterGender.SelectedValue.ToString().ToLower() == "female")
            {
                filterGender = "female";
            }
            else
            {
                filterGender = "";
            }
            showData();
        }

        private void cboFilterAssignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboFilterAssignment.SelectedValue.ToString().ToLower() == "office")
            {
                filterAssignment = "office";
            }
            else if (cboFilterAssignment.SelectedValue.ToString().ToLower() == "field")
            {
                filterAssignment = "field";
            }
            else
            {
                filterAssignment = "";
            }
            showData();
        }
    }
}
