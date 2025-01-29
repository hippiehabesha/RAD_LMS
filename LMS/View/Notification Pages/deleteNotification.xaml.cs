using LMS.DataBase;
using LMS.Model;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.Notification_Pages
{
    /// <summary>
    /// Interaction logic for deleteNotification.xaml
    /// </summary>
    public partial class deleteNotification : Page
    {
        public deleteNotification()
        {
            InitializeComponent();
            view();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                notificationModel notificationModel = new notificationModel
                {
                    NotificationID = int.Parse(txtNotificationID.Text)
                };

                new notificationConnection().DeleteNotification(notificationModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
