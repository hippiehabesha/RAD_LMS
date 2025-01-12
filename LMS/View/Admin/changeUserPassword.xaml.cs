﻿using LMS.DataBase;
using LMS.Model;
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

namespace LMS.View.Admin
{
    /// <summary>
    /// Interaction logic for changeUserPassword.xaml
    /// </summary>
    public partial class changeUserPassword : Window
    {
        public changeUserPassword()
        {
            InitializeComponent();
        }

        private void Change_Password_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == txtConfirmPassword.Password)
            {
                userUpdateModel updateModel = new userUpdateModel
                {
                    userId = int.Parse(txtUserID.Text),
                    password = txtPassword.Password
                };

                new UserConnection().changePassword(updateModel);
            }
            else {
                MessageBox.Show("The password does not match.");
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window backToAdmin = new adminView();
            backToAdmin.Show();
            this.Close();
        }
    }
}
