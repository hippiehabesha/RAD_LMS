using LMS.DataBase;
using LMS.Model;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.Book_Pages
{
    public partial class addBook : Page
    {
        public addBook()
        {
            InitializeComponent();
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

    }
}
