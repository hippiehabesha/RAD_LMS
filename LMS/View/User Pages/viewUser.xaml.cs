using LMS.DataBase;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.User_Pages
{
    /// <summary>
    /// Interaction logic for viewUser.xaml
    /// </summary>
    public partial class viewUser : Page
    {
        public viewUser()
        {
            InitializeComponent();
        }

        private void View_All_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = new UserConnection().userView();
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text; // Assuming you have a TextBox named txtSearch
                DataTable dt = new UserConnection().SearchUserView(searchTerm);
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
