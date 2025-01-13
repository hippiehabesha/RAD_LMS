using System.Windows;
using System.Windows.Controls;

namespace LMS.View.Admin
{
    /// <summary>
    /// Interaction logic for adminUserActions.xaml
    /// </summary>
    public partial class adminUserActions : Page
    {
        public adminUserActions()
        {
            InitializeComponent();
        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotoSave = new saveUser();
                gotoSave.Show();
                adminView.Close();
            }

        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)

            {
                Window gotoDelete = new DeleteUser();
                gotoDelete.Show();

                adminView.Close();
            }

        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)

            {
                Window gotoUpdate = new updateUser();
                gotoUpdate.Show();

                adminView.Close();
            }

        }

        private void View_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)

            {
                Window gotoView = new viewUser();
                gotoView.Show();

                adminView.Close();
            }
        }

        private void Change_Password_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)

            {
                Window gotoChangePassword = new changeUserPassword();
                gotoChangePassword.Show();

                adminView.Close();
            }
        }
    }
}
