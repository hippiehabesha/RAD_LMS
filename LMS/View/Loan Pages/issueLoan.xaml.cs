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
    /// Interaction logic for issueLoan.xaml
    /// </summary>
    public partial class issueLoan : Page
    {
        public issueLoan()
        {
            InitializeComponent();
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
    }
}
