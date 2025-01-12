using LMS.DataBase;
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
    /// Interaction logic for updateUser.xaml
    /// </summary>
    public partial class updateUser : Window
    {
        public updateUser()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            userUpdateModel updateModel = new userUpdateModel { 
                userId = int.Parse(txtUserID.Text),
                username = txtUsername.Text,
                role = cmbRole.Text
            };

            new UserConnection().updateUser(updateModel);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int userId = int.Parse(txtUserID.Text); 
            UserConnection connection = new UserConnection();
            userUpdateModel user = connection.searchUser(userId);

            if (user != null)
            {
                txtUsername.Text = user.username; 
                cmbRole.Text = user.role; 
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
