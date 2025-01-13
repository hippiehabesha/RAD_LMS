using LMS.View.Admin;
using LMS.View.Book;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LMS.View.User.Admin
{
    /// <summary>
    /// Interaction logic for adminBookActions.xaml
    /// </summary>
    public partial class adminBookActions : Page
    {
        public adminBookActions()
        {
            InitializeComponent();
        }

        private void Add_Book_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotoAddBook = new addBook(adminView);
                gotoAddBook.Show();
                adminView.Close();
            }
        }

        private void Delete_Book_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotoDeleteBook = new deleteBook(adminView);
                gotoDeleteBook.Show();
                adminView.Close();
            }
        }
    }
}
