using LMS.DataBase;
using LMS.Model;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace LMS.View.Notification_Pages
{
    /// <summary>
    /// Interaction logic for viewNotification.xaml
    /// </summary>
    public partial class viewNotification : Page
    {
        public viewNotification()
        {
            InitializeComponent();
        }

        private void View_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                notificationModel notificationModel = new notificationModel
                {
                    UserID = int.Parse(txtUserId.Text)
                };

                DataTable dt = new notificationConnection().FetchNotifications(notificationModel);
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
