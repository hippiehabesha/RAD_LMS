using LMS.DataBase;
using LMS.Model;
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

namespace LMS.View.Notification_Pages
{
    /// <summary>
    /// Interaction logic for updateNotification.xaml
    /// </summary>
    public partial class updateNotification : Page
    {
        public updateNotification()
        {
            InitializeComponent();
        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            int notificationId = int.Parse(txtNotificationId.Text);
            notificationConnection notification = new notificationConnection();
            notificationModel model = notification.NotificationSearch(notificationId);


            if (notification != null)
            {
                txtUserId.Text = model.UserID.ToString();
                txtMessage.Text = model.Message;
            }
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            notificationModel notification = new notificationModel
            {
                NotificationID = int.Parse(txtNotificationId.Text),
                UserID = int.Parse(txtUserId.Text),
                Message = txtMessage.Text
            };

            new notificationConnection().UpdateNotification(notification);
        }
    }
}
