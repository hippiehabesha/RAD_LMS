using LMS.DataBase;
using LMS.Model;
using System.Windows;

namespace LMS.View.Admin
{
    /// <summary>
    /// Interaction logic for saveUser.xaml
    /// </summary>
    public partial class saveUser : Window
    {
        public saveUser()
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window backToAdmin = new adminView();
            backToAdmin.Show();
            this.Close();
        }
    }
}
