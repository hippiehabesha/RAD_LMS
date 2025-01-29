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

namespace LMS.View.User_Pages
{
    /// <summary>
    /// Interaction logic for deleteUser.xaml
    /// </summary>
    public partial class deleteUser : Page
    {
        public deleteUser()
        {
            InitializeComponent();
            view();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            userSaveModel save = new userSaveModel
            {
                username = txtUserId.Text
            };
            new UserConnection().deleteUser(save);
        }

        private void view() 
        {
            try
            {
                DataTable dt = new UserConnection().userView();
                dataGridView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
