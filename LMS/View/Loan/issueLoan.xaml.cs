using LMS.DataBase;
using LMS.Model;
using System.Windows;

namespace LMS.View.Loan
{
    /// <summary>
    /// Interaction logic for issueLoan.xaml
    /// </summary>
    public partial class issueLoan : Window
    {
        private Window _previousWindow;
        public issueLoan(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }

        private void Issue_Loan_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                int userID = int.Parse(txtUserID.Text);
                int bookID = int.Parse(txtBookID.Text);
                DateTime loanDate = dpLoanDate.SelectedDate.Value;
                DateTime dueDate = dpDueDate.SelectedDate.Value;

                LoanModel loan = new LoanModel
                {
                    UserID = userID,
                    BookID = bookID,
                    LoanDate = loanDate,
                    DueDate = dueDate
                };

                new LoanConnection().IssueBook(loan);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error issuing loan: " + ex.Message);
            }
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            if (_previousWindow is viewLibrarian)
            {
                Window gotoViewLibrarian = new viewLibrarian();
                gotoViewLibrarian.Show();
                this.Close();
            }

        }
    }
}
