using LMS.View.Book_Pages;
using LMS.View.User_Pages;
using System.Windows;

namespace LMS.View.Admin
{
    /// <summary>
    /// Interaction logic for adminView.xaml
    /// </summary>
    public partial class adminView : Window
    { 
        public adminView()
        {
            InitializeComponent();
        }


        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            Window logout = new userLogin();
            logout.Show();
            this.Close();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new addUser());
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new updateUser());
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new deleteUser());
        }

        private void ViewUser_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewUser());
        }

        private void ChangeUserPassword_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new changeUserPassword());
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new addBook());
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new updateBook());
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new deleteBook());
        }

        private void ViewBook_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewBook());
        }
    }
}
