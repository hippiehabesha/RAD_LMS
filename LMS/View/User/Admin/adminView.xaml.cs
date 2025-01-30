using LMS.View.Book_Pages;
using LMS.View.User_Pages;
using LMS.View.Loan_Pages;
using LMS.View.Notification_Pages;
using System.Windows;
using System.Windows.Controls;

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

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            foreach (var child in ((StackPanel)((Expander)sender).Parent).Children)
            {
                if (child is Expander expander && expander != sender)
                {
                    expander.IsExpanded = false;
                }
            }
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

        private void ViewLoans_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewLoan());
        }

        private void SendNotification_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new sendNotification());
        }

        private void ViewNotifications_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewAllNotification());
        }

        private void UpdateNotification_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new updateNotification());
        }

        private void deleteNotification_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new deleteNotification());
        }
    }
}
