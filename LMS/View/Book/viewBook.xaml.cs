using LMS.DataBase;
using LMS.View.Admin;
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
using System.Windows.Shapes;

namespace LMS.View.Book
{
    /// <summary>
    /// Interaction logic for viewBook.xaml
    /// </summary>
    public partial class viewBook : Window
    {
        private Window _previousWindow;
        public viewBook(Window previousWindow)
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

            if (_previousWindow is viewMember) 
            {
                Window gotoViewMember = new viewMember();
                gotoViewMember.Show();
                this.Close();
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

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text; // Assuming you have a TextBox named searchTextBox
                DataTable dt = new bookConnection().SearchBook(searchTerm);
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
