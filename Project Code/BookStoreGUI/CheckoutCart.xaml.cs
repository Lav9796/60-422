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
using BookStoreLIB;
using System.Data;
using System.Collections.ObjectModel;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for CheckoutCart.xaml
    /// </summary>
    public partial class CheckoutCart : Window
    {
        ObservableCollection<OrderItem> orderBooksList;
        int userID = 0;
        public CheckoutCart(int userid)
        {
            InitializeComponent();
            userID = userid;
            this.Loaded += new RoutedEventHandler(CheckoutCart_Loaded);
        }

        private void CheckoutCart_Loaded(object sender, EventArgs e)
        {
            this.orderView.ItemsSource = getBooksInfo();
        }

        public void setOrderBooks(ObservableCollection<OrderItem> orderItemList) 
        {
            this.orderBooksList = orderItemList;
        }

        private ObservableCollection<OrderItem> getBooksInfo()
        {
            return this.orderBooksList;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderView.SelectedItem != null)
            {
                var selectedOrderItem = this.orderView.SelectedItem as OrderItem;
                orderBooksList.Remove(selectedOrderItem);
                this.setOrderBooks(orderBooksList);
            }
            else
            {
                MessageBox.Show("Please select a book to remove");
            }
        }

        private void checkoutButton_Click(object sender, RoutedEventArgs e)
        {
            BookOrder bookOrder = new BookOrder();
            bookOrder.updateOrderList(getBooksInfo());
            if (userID == 0 || userID <= -1)
            {
                MessageBox.Show("You must be logged in to check out!");
            }
            else if (getBooksInfo().Count == 0)
            {
                MessageBox.Show("Please add books to cart before checking out.");
            }
            else
            {
               int orderId1 = bookOrder.PlaceOrderFinal(userID);
               
                if(orderId1 == 0)
                {
                    MessageBox.Show("Error placing order");
                }
                else
                {
                    MessageBox.Show(" Your order has been placed! \n\n Order Number: " + 
                        orderId1.ToString() + "\n\n Order Total with Tax(13%): $" + (bookOrder.GetOrderTotal()).ToString() 
                        + "\n\n Thank you for shopping at Novel Cloud!");

                    orderBooksList.ToList().ForEach(x =>
                    {
                        orderBooksList.Remove(x);
                        this.setOrderBooks(orderBooksList);
                    });
                }
            }
    }
    }
}
