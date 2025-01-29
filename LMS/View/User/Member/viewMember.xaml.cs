using LMS.View.Book_Pages;
using LMS.View.Loan_Pages;
using LMS.View.Notification_Pages;
using System.Windows;

namespace LMS.View
{
    /// <summary>
    /// Interaction logic for viewMember.xaml
    /// </summary>
    public partial class viewMember : Window
    {
        public viewMember()
        {
            InitializeComponent();
        }

        private void ViewBook_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewBook());
        }

        private void ViewLoans_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewLoan());
        }

        private void ViewNotification_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new viewNotification());
        }
        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            Window logout = new userLogin();
            logout.Show();
            this.Close();
        }
    }
}
