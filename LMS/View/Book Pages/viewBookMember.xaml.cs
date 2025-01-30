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

namespace LMS.View.Book_Pages
{
    /// <summary>
    /// Interaction logic for viewBookMember.xaml
    /// </summary>
    public partial class viewBookMember : Page
    {
        public viewBookMember()
        {
            InitializeComponent();
        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text;
                DataTable dt = new bookConnection().SearchBookMember(searchTerm);
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
                DataTable dt = new bookConnection().ViewBookMember();
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
