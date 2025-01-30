using LMS.View.Book_Pages;
using LMS.View.Loan_Pages;
using LMS.View.Notification_Pages;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View
{
    /// <summary>
    /// Interaction logic for viewLibrarian.xaml
    /// </summary>
    public partial class viewLibrarian : Window
    {
        public viewLibrarian()
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

        private void IssueLoans_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new issueLoan());
        }

        private void ReturnLoans_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new returnLoan());
        }

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            Window logout = new userLogin();
            logout.Show();
            this.Close();
        }

        private void SendNotification_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new sendNotification());
        }

        private void ViewNotifications_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewAllNotification());
        }
    }
}
