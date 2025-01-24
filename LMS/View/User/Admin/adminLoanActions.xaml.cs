using LMS.View.Book;
using LMS.View.Loan;
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

namespace LMS.View.User.Admin
{
    /// <summary>
    /// Interaction logic for adminLoanActions.xaml
    /// </summary>
    public partial class adminLoanActions : Page
    {
        public adminLoanActions()
        {
            InitializeComponent();
        }

        private void View_Loan_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotoViewLoan = new viewLoan(adminView);
                gotoViewLoan.Show();
                adminView.Close();
            }
        }
    }
}
