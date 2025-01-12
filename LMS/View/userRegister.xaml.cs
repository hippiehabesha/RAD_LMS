using LMS.DataBase;
using LMS.Model;
using System.Windows;

namespace LMS.View
{
    /// <summary>
    /// Interaction logic for userView.xaml
    /// </summary>
    public partial class userRegister : Window
    {

        public userRegister()
        {
            InitializeComponent();
        }
        protected void Register_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != string.Empty || txtPassword.Password != string.Empty || cmbRole.Text != string.Empty)
            {
                userModel user = new userModel
                {
                    username = txtUsername.Text,
                    password = txtPassword.Password,
                    role = cmbRole.Text
                };

                if (txtPassword.Password == txtConfirmPassword.Password)
                {
                    new UserConnection().registerUser(user);
                    Window login = new userLogin();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Passwords do not match");
                }
            }
            else {
                MessageBox.Show("Please insert value.");
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Window login = new userLogin();
            login.Show();
            this.Close();
        }
    }
}