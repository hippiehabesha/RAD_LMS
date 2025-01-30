using LMS.DataBase;
using LMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for viewAllNotification.xaml
    /// </summary>
    public partial class viewAllNotification : Page
    {
        public viewAllNotification()
        {
            InitializeComponent();
            view();
        }

        public void view() 
        {
            try
            {
                DataTable dt = new notificationConnection().FetchAllNotifications();
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
