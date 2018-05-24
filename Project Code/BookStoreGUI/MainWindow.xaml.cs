/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
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
using System.Collections.ObjectModel;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        DataSet dsBookCat;
        UserData userData;
        BookOrder bookOrder;

        bool Manager;
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginDialog dlg = new LoginDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
            // Process data entered by user if dialog box is accepted
            if (dlg.DialogResult == true)
            {
                if (userData.LogIn(dlg.nameTextBox.Text, dlg.passwordTextBox.Password) == true)
                {
                    this.logoutButton.Visibility = Visibility.Visible;
                    this.loginButton.Visibility = Visibility.Collapsed;
                    this.statusTextBlock.Text = "You are logged in. Welcome " +
                    userData.FullName;

                    DBQueries dbQ = new DBQueries();
                    DataSet ds = new DataSet();
                    String s1 = "Select Manager from UserData Where UserID ='" + userData.UserID + "'";
                    ds = dbQ.SELECT_FROM_TABLE(s1);
                    Manager = bool.Parse(ds.Tables[0].Rows[0]["Manager"].ToString());

                    if (Manager)
                    {
                        this.AdminPanelbutton.Visibility = Visibility.Visible;
                        this.AskButton.Visibility = Visibility.Collapsed;
                    }
                }
                else
                    this.statusTextBlock.Text = "Your login failed. Please try again.";
            }
        }
        private void exitButton_Click(object sender, RoutedEventArgs e) { this.Close(); }
        public MainWindow() { InitializeComponent(); }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BookCatalog bookCat = new BookCatalog();
            dsBookCat = bookCat.GetBookInfo();
            //this.DataContext = dsBookCat.Tables["Category"];
            bookOrder = new BookOrder();
            userData = new UserData();

            if (!userData.LoggedIn)
            {
                this.statusTextBlock.Text = "You are currently browsing as a Guest. Please log in.";
            }
            // this.orderListView.ItemsSource = bookOrder.OrderItemList;
        }
        private void books_Library_Button_Click(object sender, RoutedEventArgs e)
        {
            LibHome lh = new LibHome(userData.UserID);
            lh.ShowDialog();
        }

        private void AskButton_Click(object sender, RoutedEventArgs e)
        {
            Questions questionDialog = new Questions();
            questionDialog.Owner = this;
            questionDialog.ShowDialog();

            if ((questionDialog.questionTextBox.Text != "") && (questionDialog.DialogResult == true))
            {
                String AskedBy;
                if (!(this.userData.UserID > 0))
                {
                    AskedBy = "Guest";
                }
                else
                {
                    AskedBy = userData.FullName;
                }
                DBQueries dbQ = new DBQueries();
                bool result;

                List<object> bookstore = new List<object>(
                    new object[] { questionDialog.questionTextBox.Text, AskedBy }
                    );

                result = dbQ.INSERT_INTO_TABLE("Questions", bookstore);
                if (result == true)
                {
                    MessageBox.Show("Thank you for your question " + AskedBy);
                }
                else
                {
                    MessageBox.Show("Question could not be submitted.");
                }
            }
            else if(questionDialog.DialogResult == false)
            {
                questionDialog.Close();
            }
            else
            {
                MessageBox.Show("Please ask a question before submitting");
            }
        }
        private void AdminPanelbutton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminDialog = new AdminWindow(userData.UserID);
            adminDialog.Owner = this;
            adminDialog.ShowDialog();
            adminDialog.isbnTextBox.MaxLength = 10;
            if ((adminDialog.isbnTextBox.Text != "") && adminDialog.categoryTextBox.Text != "" 
                && (adminDialog.titleTextBox.Text != "") && (adminDialog.priceTextBox.Text != "") 
                && (adminDialog.descriptionTextBox.Text != "") && (adminDialog.authorTextBox.Text != "") 
                && (adminDialog.supplierTextBox.Text != "") && (adminDialog.yearTextBox.Text != "") 
                && (adminDialog.publisherTextBox.Text != "") && (adminDialog.editionTextBox.Text != "")
                && (adminDialog.DialogResult == true))
            {
                DBQueries dbQ = new DBQueries();
                DataSet ds = new DataSet();

                List<object> bookstore = new List<object>(
                    new object[] { adminDialog.isbnTextBox.Text, adminDialog.categoryTextBox.Text, adminDialog.titleTextBox.Text, adminDialog.authorTextBox.Text, adminDialog.priceTextBox.Text, adminDialog.supplierTextBox.Text, adminDialog.yearTextBox.Text, adminDialog.editionTextBox.Text, adminDialog.publisherTextBox.Text, adminDialog.descriptionTextBox.Text }
                    );

                bool add = dbQ.INSERT_INTO_TABLE("BookData", bookstore);
                if (add == true)
                {
                    MessageBox.Show("Book Added Successfully!");
                }
                else
                {
                    MessageBox.Show("Book could not be Added."); 
                }
            }
            else if (adminDialog.DialogResult == false)
            {
                adminDialog.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all areas before submitting.\n" +
                    "Requirements as given: \n\n ISBN: 10 numbers \n\n Category: a number \n\n    1 (for Programming Languages) \n    2 (for Software Development) \n    3 (for New Books) \n    4 (for Textbooks) \n\n Title: String (Max 80) \n\n Author: String (Max 255) \n\n Price: 10 digits, 2 decimal \n\n Supplier: Number\n\n Year: 4 numbers\n\n Edition: 2 numbers max\n\n Publisher: String (400 max)");
            }
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            userData.LogOut();
            this.logoutButton.Visibility = Visibility.Collapsed;
            this.loginButton.Visibility = Visibility.Visible;
            this.AdminPanelbutton.Visibility = Visibility.Collapsed;
            this.AskButton.Visibility = Visibility.Visible;
            this.statusTextBlock.Text = "You are currently browsing as a Guest. Please log in";

        }
    }
}