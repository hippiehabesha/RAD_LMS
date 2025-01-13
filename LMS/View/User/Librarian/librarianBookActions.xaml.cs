using LMS.View.Book;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.User.Librarian
{

    public partial class librarianBookActions : Page
    {
        public librarianBookActions()
        {
            InitializeComponent();
        }

        private void Add_Book_Button(object sender, RoutedEventArgs e)
        {
            Window librarianView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Librarian");
            if (librarianView != null)
            {
                Window gotoAddBook = new addBook(librarianView);
                gotoAddBook.Show();
                librarianView.Close();
            }
        }

        private void Delete_Book_Button(object sender, RoutedEventArgs e)
        {
            Window librarianView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Librarian");
            if (librarianView != null)
            {
                Window gotoDeleteBook = new deleteBook(librarianView);
                gotoDeleteBook.Show();
                librarianView.Close();
            }
        }
    }
}
