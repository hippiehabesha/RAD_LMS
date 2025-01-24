using LMS.View.Book;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.User.Member
{
    /// <summary>
    /// Interaction logic for memberBookActions.xaml
    /// </summary>
    public partial class memberBookActions : Page
    {
        public memberBookActions()
        {
            InitializeComponent();
        }

        private void View_Book_Button(object sender, RoutedEventArgs e)
        {
            Window memberView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Member");
            if (memberView != null)
            {
                Window gotoViewBook = new viewBook(memberView);
                gotoViewBook.Show();
                memberView.Close();
            }
        }
    }
}
