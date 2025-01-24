using LMS.DataBase;
using LMS.Model;
using LMS.View.Admin;
using System.Data;
using System.Windows;

namespace LMS.View.Notification
{
    /// <summary>
    /// Interaction logic for viewNotificaion.xaml
    /// </summary>
    public partial class viewNotification : Window
    {
        private Window _previousWindow;

        public viewNotification(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
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
