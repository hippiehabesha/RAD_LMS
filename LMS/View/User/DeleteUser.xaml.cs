using LMS.DataBase;
using LMS.Model;
using System.Windows;

namespace LMS.View.Admin
{
    /// <summary>
    /// Interaction logic for DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        public DeleteUser()
        {
            InitializeComponent();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window backToAdmin = new adminView();
            backToAdmin.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            userSaveModel save = new userSaveModel
            {
                username = txtUsername.Text,
            };
            new UserConnection().deleteUser(save);
        }
    }
}
