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
using System.Data;
using BookStoreLIB;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        DALReviewItem reviewItem;
        public Cart()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
   
            this.orderListView.ItemsSource = MainWindow.bookOrder.OrderItemList;
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderListView.SelectedItem != null)
            {
                var selectedOrderItem = this.orderListView.SelectedItem as OrderItem;
                MainWindow.bookOrder.RemoveItem(selectedOrderItem.BookID);
            }
            else
            {
                MessageBox.Show("Please select a book to remove");
            }
        }
        private void reviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderListView.SelectedItem != null)
            {
                var dlg = new ReviewItem();
                reviewItem = new DALReviewItem();

                var selectedOrderItem = this.orderListView.SelectedItem as OrderItem;
                var isbn = selectedOrderItem.BookID;
                var title = selectedOrderItem.BookTitle;

                dlg.isbnTextBox.Text = isbn;
                dlg.titleTextBox.Text = title;
                dlg.Owner = this;
                dlg.ShowDialog();
                if (dlg.DialogResult == true)
                {

                    if (reviewItem.Review(isbn, int.Parse(dlg.orderNoTextBox.Text), int.Parse(dlg.ratingsbutton.Text), dlg.commentsTextBox.Text))
                    {
                        MessageBox.Show("Your Review Has been submitted.");

                    }
                    else
                    {
                        MessageBox.Show("Your Review Could not be added");
                    }

                }

            }
            else
            {
                MessageBox.Show("Please add a book to review it.");
            }

        }
        private void chechoutButton_Click(object sender, RoutedEventArgs e)
        {
            int orderId;
            orderId = MainWindow.bookOrder.PlaceOrder(MainWindow.userData.UserID);
            MessageBox.Show("Your order has been placed. Your order id is " +
            orderId.ToString());
        }
    }
}

