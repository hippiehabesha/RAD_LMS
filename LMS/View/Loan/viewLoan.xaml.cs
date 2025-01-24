using LMS.DataBase;
using LMS.View.Admin;
using System.Data;
using System.Windows;

namespace LMS.View.Loan
{
    /// <summary>
    /// Interaction logic for viewLoan.xaml
    /// </summary>
    public partial class viewLoan : Window
    {
        private Window _previousWindow;
        public viewLoan(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }
        private void Back_button(object sender, RoutedEventArgs e)
        {
            if (_previousWindow is adminView)
            {
                Window gotoAdminView = new adminView();
                gotoAdminView.Show();
                this.Close();
            }

            if (_previousWindow is viewLibrarian)
            {
                Window gotoViewLibrarian = new viewLibrarian();
                gotoViewLibrarian.Show();
                this.Close();
            }
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
