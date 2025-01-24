using LMS.DataBase;
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

namespace LMS.View.Notification
{
    /// <summary>
    /// Interaction logic for deleteNotificaion.xaml
    /// </summary>
    public partial class deleteNotification : Window
    {
        private Window _previousWindow;
        public deleteNotification(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }

        private void Delete_Notification_Button(object sender, RoutedEventArgs e)
        {
          
            try
            {
                notificationModel notificationModel = new notificationModel
                {
                   NotificationID = int.Parse(txtNotificationId.Text)
                };

                new notificationConnection().DeleteNotification(notificationModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            if (_previousWindow is adminView)
            {
                Window gotoadminView = new adminView();
                gotoadminView.Show();
                this.Close();
            }
        }
    }
}
