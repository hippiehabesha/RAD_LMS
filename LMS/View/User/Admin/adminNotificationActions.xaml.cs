using LMS.View.Book;
using LMS.View.Notification;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.User.Admin
{
    /// <summary>
    /// Interaction logic for adminNotificationActions.xaml
    /// </summary>
    public partial class adminNotificationActions : Page
    {
        public adminNotificationActions()
        {
            InitializeComponent();
        }

        private void Create_Notification_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotocreateNotificaion = new createNotification(adminView);
                gotocreateNotificaion.Show();
                adminView.Close();
            }
        }

        private void Delete_Notification_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotodeleteNotificaion = new deleteNotification(adminView);
                gotodeleteNotificaion.Show();
                adminView.Close();
            }
        }

        private void Update_Notification_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotodUpdateNotificaion = new updateNotification(adminView);
                gotodUpdateNotificaion.Show();
                adminView.Close();
            }
        }
        private void View_Notification_Button(object sender, RoutedEventArgs e)
        {
            Window adminView = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == "Admin");
            if (adminView != null)
            {
                Window gotoViewNotificaion = new viewNotification(adminView);
                gotoViewNotificaion.Show();
                adminView.Close();
            }
        }
    }
}
