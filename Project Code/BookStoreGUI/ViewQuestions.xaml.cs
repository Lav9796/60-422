using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BookStoreLIB;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for ViewQuestions.xaml
    /// </summary>
    public partial class ViewQuestions : Window
    {
        int userID = 0;
        public ViewQuestions(int userid)
        {
            InitializeComponent();
            userID = userid;
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }
        private void Window_Loaded(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DBQueries dbQ = new DBQueries();

            ds = dbQ.SELECT_FROM_TABLE("SELECT * FROM Questions");
            ReviewsDataGrid.ItemsSource = ds.Tables[0].DefaultView;
            ReviewsDataGrid.Columns[0].Width = 50;
            ReviewsDataGrid.Columns[1].Width = 295;
            ReviewsDataGrid.Columns[2].Width = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
