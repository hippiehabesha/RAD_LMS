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
    /// Interaction logic for viewLoan.xaml
    /// </summary>
    public partial class viewLoan : Page
    {
        public viewLoan()
        {
            InitializeComponent();
        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text;
                DataTable dt = new LoanConnection().SearchLoanView(searchTerm);
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void View_All_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = new LoanConnection().ViewLoans();
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
