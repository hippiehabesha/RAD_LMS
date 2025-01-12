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
using System.Windows.Shapes;
using LMS.DataBase;

namespace LMS.View.Admin
{
    /// <summary>  
    /// Interaction logic for viewUser.xaml  
    /// </summary>  
    public partial class viewUser : Window
    {
        public viewUser()
        {
            InitializeComponent();

            view();
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
        private void Back_click(object sender, RoutedEventArgs e)
        {
            Window backToAdmin = new adminView();
            backToAdmin.Show();
            this.Close();
        }
    }
}
