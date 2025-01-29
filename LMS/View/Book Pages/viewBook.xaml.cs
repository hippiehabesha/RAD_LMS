using LMS.DataBase;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.Book_Pages
{
    /// <summary>
    /// Interaction logic for viewBook.xaml
    /// </summary>
    public partial class viewBook : Page
    {
        public viewBook()
        {
            InitializeComponent();
        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text;
                DataTable dt = new bookConnection().SearchBook(searchTerm);
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
                DataTable dt = new bookConnection().ViewBook();
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
