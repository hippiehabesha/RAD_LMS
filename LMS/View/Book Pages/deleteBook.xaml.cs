using LMS.DataBase;
using LMS.Model;
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
    /// Interaction logic for deleteBook.xaml
    /// </summary>
    public partial class deleteBook : Page
    {
        public deleteBook()
        {
            InitializeComponent();
            view();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            bookModel bookModel = new bookModel
            {
                bookID = int.Parse(txtBookID.Text)
            };

            new bookConnection().DeleteBook(bookModel);
            view();
        }
        private void view() 
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
