using LMS.DataBase;
using LMS.Model;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.User_Pages
{
    /// <summary>
    /// Interaction logic for updateUser.xaml
    /// </summary>
    public partial class updateUser : Page
    {
        public updateUser()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            userUpdateModel updateModel = new userUpdateModel
            {
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
    }
}
