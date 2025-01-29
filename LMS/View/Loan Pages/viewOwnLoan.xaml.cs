using LMS.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for viewOwnLoan.xaml
    /// </summary>
    public partial class viewOwnLoan : Page
    {
        public viewOwnLoan()
        {
            InitializeComponent();
        }

        private void Search_User_button(object sender, RoutedEventArgs e)
        {
            try
            {
                int userID = int.Parse(txtSearch.Text);
                DataTable dt = new LoanConnection().ViewOwnLoans(userID);
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
