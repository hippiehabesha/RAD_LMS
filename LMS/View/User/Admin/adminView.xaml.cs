using LMS.View.User.Admin;
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

        private void User_Button_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new adminUserActions());
        }

        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new adminBookActions());
        }

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            Window logout = new userLogin();
            logout.Show();
            this.Close();
        }

        private void Loan_Button_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new adminLoanActions());
        }
    }
}
