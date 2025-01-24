using LMS.View.Loan;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.User.Librarian
{
    /// <summary>
    /// Interaction logic for librarianLoanActions.xaml
    /// </summary>
    public partial class librarianLoanActions : Page
    {
        public librarianLoanActions()
        {
            InitializeComponent();
        }

        private void View_Loan_Button(object sender, RoutedEventArgs e)
        {
            Window librarianView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Librarian");
            if (librarianView != null)
            {
                Window gotoViewLoan = new viewLoan(librarianView);
                gotoViewLoan.Show();
                librarianView.Close();
            }
        }

        private void Issue_Loan_Button(object sender, RoutedEventArgs e)
        {
            Window librarianView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Librarian");
            if (librarianView != null)
            {
                Window gotoIssueLoan = new issueLoan(librarianView);
                gotoIssueLoan.Show();
                librarianView.Close();
            }
        }

        private void Return_Loan_Button(object sender, RoutedEventArgs e)
        {
            Window librarianView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Librarian");
            if (librarianView != null)
            {
                Window gotoReturnLoan = new returnLoan(librarianView);
                gotoReturnLoan.Show();
                librarianView.Close();
            }
        }
    }
}
