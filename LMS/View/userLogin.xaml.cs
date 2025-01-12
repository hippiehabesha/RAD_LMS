using System.Windows;
using LMS.DataBase;
using LMS.Model;
using LMS.View.Admin;
namespace LMS.View
{
    /// <summary>
    /// Interaction logic for userLogin.xaml
    /// </summary>
    public partial class userLogin : Window
    {
        public userLogin()
        {
            InitializeComponent();
        }
        protected void Login_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != string.Empty || txtPassword.Password != string.Empty)
            {
                userLoginModel login = new userLoginModel
                {
                    username = txtUsername.Text,
                    password = txtPassword.Password

                };

                string actualRole = new UserConnection().loginUser(login);

                if (actualRole == "Admin")
                {
                    Window viewAdmin = new adminView();
                    viewAdmin.Show();
                    this.Close();

                }
                else if (actualRole == "Member")
                {
                    Window viewMember = new viewMember();
                    viewMember.Show();
                    this.Close();
                }
                else if (actualRole == "Librarian")
                {
                    Window viewLibrarian = new viewLibrarian();
                    viewLibrarian.Show();
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("User not found.");
                }

                
            }
            else {
                MessageBox.Show("Please insert value.");

            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Window register = new userRegister();
            register.Show();
            this.Close();
        }
    }
}
