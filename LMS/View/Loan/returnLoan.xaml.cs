using LMS.DataBase;
using LMS.Model;
using System.Windows;

namespace LMS.View.Loan
{
    /// <summary>
    /// Interaction logic for returnLoan.xaml
    /// </summary>
    public partial class returnLoan : Window
    {
        private Window _previousWindow;
        public returnLoan(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
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

        private void ReturnBook_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                int loanID = int.Parse(txtLoanID.Text);
                DateTime dueDate = dpDueDate.SelectedDate.Value;
                DateTime returnDate = dpReturnDate.SelectedDate.Value;
                int BookID = int.Parse(txtBookID.Text);
               

                LoanModel loan = new LoanModel
                {
                    LoanID = loanID,
                    ReturnDate = returnDate,
                    DueDate = dueDate,
                    BookID = BookID
                   

                };

                new LoanConnection().ReturnBook(loan);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message);
            }
        }
    }
}
