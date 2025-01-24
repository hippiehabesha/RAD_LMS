﻿using LMS.DataBase;
using LMS.Model;
using LMS.View.Admin;
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
using System.Windows.Shapes;

namespace LMS.View.Book
{
    /// <summary>
    /// Interaction logic for updateBook.xaml
    /// </summary>
    public partial class updateBook : Window
    {
        private Window _previousWindow;
        public updateBook(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }

        private void Get_Book_Info_Button(object sender, RoutedEventArgs e)
        {
            int bookId = int.Parse(txtBookID.Text);
            bookConnection connection = new bookConnection();
            bookModel book = connection.BookSearch(bookId);

            if (book != null)
            {
                txtTitle.Text = book.title;
                txtAuthor.Text = book.author;
                txtGenre.Text = book.genre;
            }
        }

        private void Update_Book_Button(object sender, RoutedEventArgs e)
        {
            bookModel bookModel = new bookModel
            {
                bookID = int.Parse(txtBookID.Text),
                title = txtTitle.Text,
                author = txtAuthor.Text,
                genre = txtGenre.Text
            };

            new bookConnection().UpdateBook(bookModel);
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
