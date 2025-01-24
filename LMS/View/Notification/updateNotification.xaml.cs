using System.Windows;

namespace LMS.View.Notification
{
    public partial class updateNotification : Window
    {
        private Window _previousWindow;
        public updateNotification(Window previousWindow)
        {
            InitializeComponent();
            _previousWindow = previousWindow;
        }
    }
}
