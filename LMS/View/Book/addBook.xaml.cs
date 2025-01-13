using LMS.DataBase;
using LMS.Model;
using LMS.View.Admin;
using System.Windows;

namespace LMS.View.Book
{
    /// <summary>
    /// Interaction logic for addBook.xaml
    /// </summary>
    public partial class addBook : Window
    {
        private Window _previousWindow;

        public addBook(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }

        private void Add_Book_Button(object sender, RoutedEventArgs e)
        {
            bookModel bookModel = new bookModel
            {
                title = txtTitle.Text,
                author = txtAuthor.Text,
                genre = txtGenre.Text,
                isbn = txtISBN.Text,
                availability = int.Parse(txtAvailability.Text)
            };

            new bookConnection().AddBook(bookModel);
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
    }
}
