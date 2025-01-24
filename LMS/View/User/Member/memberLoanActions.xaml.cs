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

namespace LMS.View.User.Member
{
    /// <summary>
    /// Interaction logic for memberLoanActions.xaml
    /// </summary>
    public partial class memberLoanActions : Page
    {
        public memberLoanActions()
        {
            InitializeComponent();
        }

        private void View_Own_Loan_Button(object sender, RoutedEventArgs e)
        {
            Window memberView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Member");
            if (memberView != null)
            {
                Window gotoViewOwnLoan = new viewOwnLoan(memberView);
                gotoViewOwnLoan.Show();
                memberView.Close();
            }
        }
    }
}
