/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace BookStoreLIB {
    public class BookOrder {
        ObservableCollection<OrderItem> orderItemList = new
            ObservableCollection<OrderItem>();
        public ObservableCollection<OrderItem> OrderItemList
        {
            get { return orderItemList; }
        }
        public void AddItem(OrderItem orderItem)
        {
            foreach (var item in orderItemList)
            {
                if (item.BookID == orderItem.BookID)
                {
                    item.Quantity += orderItem.Quantity;
                    return;
                }
            }
            orderItemList.Add(orderItem);
        }

        // Added method for seeing if an OrderItem is in this BookOrder.
        public bool HasItem (OrderItem orderItem)
        {
            foreach (var item in orderItemList)
            {
                if (item.BookID.Equals(orderItem.BookID))
                    return true;
            }
            return false;
        }

        public void RemoveItem(string productID)
        {
            foreach (var item in orderItemList)
            {
                if (item.BookID == productID)
                {
                    orderItemList.Remove(item);
                    return;
                }
            }
        }
        public double GetOrderTotal()
        {
            if (orderItemList.Count == 0)
            {
                return 0.00;
            }
            else
            {
                double total = 0;
                foreach (var item in orderItemList)
                {
                    total += item.SubTotal;
                }
                total *= 1.13;
                return total;
            }
        }
        public void updateOrderList(ObservableCollection<OrderItem> orderItem)
        {
            this.orderItemList = orderItem;
        }
        public int PlaceOrder(int userID)
        {
            string xmlOrder;
            xmlOrder = "<Orders UserID='" + userID.ToString() + "'>";
            foreach (var item in orderItemList)
            {
                xmlOrder += item.ToString();
            }
            xmlOrder += "</Orders>";
            DALOrder dbOrder = new DALOrder();
            return dbOrder.Proceed2Order(xmlOrder);
        }
        public int PlaceOrderFinal(int userID)
        {
            DBQueries dbQ = new DBQueries();
            bool res = false;
            var conn = new SqlConnection(Properties.Settings.Default.dbConnectionString);
            int orderId = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Orders (UserID, Status) VALUES "
                    + " (@UserID, @Status)";
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Status", "P");
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            DBGetID dbG = new DBGetID();
            orderId = (dbG.GetID("Orders", conn)) - 1;
            foreach (var item in orderItemList)
            {
                List<object> bookstore1 = new List<object>(
                new object[] { orderId, item.BookID, item.Quantity }
                );
                dbQ.INSERT_INTO_TABLE("OrderItem", bookstore1);
            }

            return orderId;
        }
    }
}
