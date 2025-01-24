using LMS.DataBase;
using System.Data;
using System.Windows;

namespace LMS.View.Loan
{
    /// <summary>
    /// Interaction logic for viewOwnLoan.xaml
    /// </summary>
    public partial class viewOwnLoan : Window
    {
        private Window _previousWindow;
        public viewOwnLoan(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            if (_previousWindow is viewMember)
            {
                Window gotoViewMember = new viewMember();
                gotoViewMember.Show();
                this.Close();
            }
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
