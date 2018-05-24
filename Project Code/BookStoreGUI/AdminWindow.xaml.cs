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

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        int userID = 0;
        public AdminWindow(int userid)
        {
            InitializeComponent();
            userID = userid;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) {

            this.DialogResult = false;
        }

        private void viewquestionsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewQuestions newQuestions = new ViewQuestions(userID);
            newQuestions.Owner = this;
            newQuestions.ShowDialog();
        }
    }
}
