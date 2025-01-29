using LMS.DataBase;
using LMS.Model;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.User_Pages
{
    public partial class addUser : Page
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            userSaveModel save = new userSaveModel
            {
                username = txtUsername.Text,
                password = txtPassword.Password,
                role = cmbRole.Text
            };

            new UserConnection().saveUser(save);
        }
    }
}
