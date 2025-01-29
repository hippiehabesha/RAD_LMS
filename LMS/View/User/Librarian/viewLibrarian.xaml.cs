using LMS.View.Book_Pages;
using LMS.View.Loan_Pages;
using System.Windows;

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
    }
}
