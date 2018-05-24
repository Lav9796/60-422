using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreLIB
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace BookStoreLIB
    {
        [TestClass]
        public class TestAddBookToCart
        {
            [TestMethod]
            public void TestMethodAddBook()
            {
                BookOrder bookOrder = new BookOrder();
                OrderItem orderItem;

                string bookISBN = "8398230985";
                string bookTitle = "Agile Software Development";
                double bookPrice = 50.40;
                int bookQuantity = 1;
                string description = "sample description";

                // Creating a sample book entry 
                orderItem = new OrderItem(bookISBN, bookTitle, bookPrice, bookQuantity, description);
                bookOrder.AddItem(orderItem);

                bool expectedReturnWithBook = true;

                //Checking if newly created item exists in orderItem
                bool actualReturnWithBook = bookOrder.HasItem(orderItem);

                Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
            }

            public void TestMethodAddBook1()
            {
                BookOrder bookOrder = new BookOrder();
                OrderItem orderItem;

                string bookISBN = "5555555";
                string bookTitle = "Comp Sci";
                double bookPrice = 99.99;
                int bookQuantity = 1;
                string description = "sample description";

                // Creating a sample book entry 
                orderItem = new OrderItem(bookISBN, bookTitle, bookPrice, bookQuantity, description);
                bookOrder.AddItem(orderItem);

                bool expectedReturnWithBook = true;

                //Checking if newly created item exists in orderItem
                bool actualReturnWithBook = bookOrder.HasItem(orderItem);

                Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
            }

            public void TestMethodAddBook2()
            {
                BookOrder bookOrder = new BookOrder();
                OrderItem orderItem;

                string bookISBN = " ";
                string bookTitle = "Comp Sci";
                double bookPrice = 99.99;
                int bookQuantity = 1;
                string description = "sample description";

                // Creating a sample book entry 
                orderItem = new OrderItem(bookISBN, bookTitle, bookPrice, bookQuantity, description);
                bookOrder.AddItem(orderItem);

                bool expectedReturnWithBook = false;

                //Checking if newly created item exists in orderItem
                bool actualReturnWithBook = bookOrder.HasItem(orderItem);

                Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
            }

            public void TestMethodAddBook3()
            {
                BookOrder bookOrder = new BookOrder();
                OrderItem orderItem;

                string bookISBN = "8398230985";
                string bookTitle = "Agile Software Development";
                double bookPrice = 50.40;
                int bookQuantity = 1;
                string description = "sample description";

                // Creating a sample book entry 
                orderItem = new OrderItem(bookISBN, bookTitle, bookPrice, bookQuantity, description);
                bookOrder.AddItem(orderItem);

                bool expectedReturnWithBook = true;

                //Checking if newly created item exists in orderItem
                bool actualReturnWithBook = bookOrder.HasItem(orderItem);

                Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
            }





        }
    }


}
