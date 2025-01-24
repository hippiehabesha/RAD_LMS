using LMS.View.User.Librarian;
using LMS.View.User.Member;
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
using System.Windows.Shapes;

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

        private void Book_Button(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new memberBookActions());
        }

        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            Window logout = new userLogin();
            logout.Show();
            this.Close();
        }

        private void Loan_Button(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new memberLoanActions());
        }
    }
}
