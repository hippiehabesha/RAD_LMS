using LMS.DataBase;
using LMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LMS.View.Loan_Pages
{
    /// <summary>
    /// Interaction logic for returnLoan.xaml
    /// </summary>
    public partial class returnLoan : Page
    {
        public returnLoan()
        {
            InitializeComponent();
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
