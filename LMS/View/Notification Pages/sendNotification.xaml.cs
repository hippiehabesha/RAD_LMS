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
    /// Interaction logic for sendNotification.xaml
    /// </summary>
    public partial class sendNotification : Page
    {
        public sendNotification()
        {
            InitializeComponent();
        }

        private void Create_Notification_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                notificationModel notificationModel = new notificationModel
                {
                    UserID = int.Parse(txtUserId.Text),
                    Message = txtMessage.Text
                };

                new notificationConnection().CreateNotification(notificationModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
