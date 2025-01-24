using LMS.DataBase;
using LMS.Model;
using LMS.View.Admin;
using System.Windows;

namespace LMS.View.Notification
{
    /// <summary>
    /// Interaction logic for createNotification.xaml
    /// </summary>
    public partial class createNotification : Window
    {
        private Window _previousWindow;
        public createNotification(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
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
