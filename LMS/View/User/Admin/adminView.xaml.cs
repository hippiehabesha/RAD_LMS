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

namespace LMS.View.Admin
{
    /// <summary>
    /// Interaction logic for adminView.xaml
    /// </summary>
    public partial class adminView : Window
    {
        public adminView()
        {
            InitializeComponent();
        }

        private void User_Button_Click(object sender, RoutedEventArgs e)
        {
            frameHolder.Navigate(new adminUserActions());
        }
    }
}
