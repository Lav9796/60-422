using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;

namespace BookStoreLIB.TestCases
{
    [TestClass]
    public class TestAddBookToLibrary
    {
       


        [TestMethod]
        public void TestMethodISBN()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 0;
            int category = 1;
            string title = "Of Mice and Men";
            string author = "John Steinbeck";
            double price = 12.80;
            int supplier = 1;
            int year = 2014;
            int edition = 2;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] {isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            } 
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodCategory()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445551;
            int category = 0;
            string title = "Of Mice and Men";
            string author = "John Steinbeck";
            double price = 12.80;
            int supplier = 1;
            int year = 2014;
            int edition = 2;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodTitle()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445552;
            int category = 1;
            string title = "";
            string author = "John Steinbeck";
            double price = 12.80;
            int supplier = 1;
            int year = 2014;
            int edition = 2;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodAuthor()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445553;
            int category = 0;
            string title = "Of Mice and Men";
            string author = "";
            double price = 12.80;
            int supplier = 1;
            int year = 2014;
            int edition = 2;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodPrice()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445554;
            int category = 0;
            string title = "Of Mice and Men";
            string author = "John Steinbeck";
            double price = 0;
            int supplier = 1;
            int year = 2014;
            int edition = 2;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodSupplier()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445555;
            int category = 0;
            string title = "Of Mice and Men";
            string author = "John Steinbeck";
            double price = 12.80;
            int supplier = 0;
            int year = 2014;
            int edition = 2;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodYear()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445556;
            int category = 0;
            string title = "Of Mice and Men";
            string author = "John Steinbeck";
            double price = 12.80;
            int supplier = 1;
            int year = 0;
            int edition = 2;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodEdition()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445557;
            int category = 0;
            string title = "Of Mice and Men";
            string author = "John Steinbeck";
            double price = 12.80;
            int supplier = 1;
            int year = 2014;
            int edition = 0;
            string publisher = "Wiley";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodPublisher()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();
            Boolean expectedInsert = false;
            int isbn = 1234445558;
            int category = 0;
            string title = "Of Mice and Men";
            string author = "John Steinbeck";
            double price = 12.80;
            int supplier = 1;
            int year = 2014;
            int edition = 2;
            string publisher = "";
            string description = "Lots of Mice, Not many men";

            try
            {

                List<object> bookstore = new List<object>(
                new object[] { isbn, category, title, author, price, supplier, year, edition, publisher, description }
                );
                bool actualInsert = dbQ.INSERT_INTO_TABLE("BookData_Insert", bookstore);
                Assert.AreEqual(expectedInsert, actualInsert);
            }
            catch
            {
                Assert.Fail("Exception should've been thrown");
            }

        }
        [TestMethod]
        public void TestMethodAdd()
        {
            DBQueries dbQ = new DBQueries();
            DataSet ds = new DataSet();

            int expectedISBN = 1234445559;
            int expectedCategoryID = 1;
            string expectedTitle = "Of Mice and Men";
            string expectedAuthor = "John Steinbeck";
            double expectedPrice = 12.80;
            int expectedSupplierID = 1;
            int expectedYear = 2014;
            int expectedEdition = 2;
            string expectedPublisher = "Wiley";
            string expectedDescription = "Lots of Mice, Not many men";
            List<object> bookstore = new List<object>(
                new object[] { expectedISBN, expectedCategoryID, expectedTitle, expectedAuthor, expectedPrice, expectedSupplierID,
                    expectedYear, expectedEdition, expectedPublisher, expectedDescription }
                );
            Boolean expectedInsert = true;
            Boolean expectedDelete = true;

            Boolean actualInsert = dbQ.INSERT_INTO_TABLE("BookData", bookstore);    //Insert method for database
            Assert.AreEqual(expectedInsert, actualInsert);

            ds = dbQ.SELECT_FROM_TABLE("SELECT * FROM BookData WHERE ISBN = '" + expectedISBN + "'");

            int actualISBN = Int32.Parse(ds.Tables[0].Rows[0]["ISBN"].ToString());
            int actualCategoryID = Int32.Parse(ds.Tables[0].Rows[0]["CategoryID"].ToString());
            string actualTitle = ds.Tables[0].Rows[0]["Title"].ToString();
            string actualAuthor = ds.Tables[0].Rows[0]["Author"].ToString();
            double actualPrice = Double.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
            int actualSupplierID = Int32.Parse(ds.Tables[0].Rows[0]["SupplierId"].ToString());
            int actualYear = Int32.Parse(ds.Tables[0].Rows[0]["Year"].ToString());
            int actualEdition = Int32.Parse(ds.Tables[0].Rows[0]["Edition"].ToString());
            string actualPublisher = ds.Tables[0].Rows[0]["Publisher"].ToString();
            string actualDescription = ds.Tables[0].Rows[0]["Description"].ToString();

            Assert.AreEqual(expectedISBN, actualISBN);
            Assert.AreEqual(expectedCategoryID, actualCategoryID);
            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedAuthor, actualAuthor);
            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedSupplierID, actualSupplierID);
            Assert.AreEqual(expectedYear, actualYear);
            Assert.AreEqual(expectedEdition, actualEdition);
            Assert.AreEqual(expectedPublisher, actualPublisher);
            Assert.AreEqual(expectedDescription, actualDescription);

            Boolean actualDelete = dbQ.DELETE_FROM_TABLE("DELETE FROM BookData WHERE ISBN = '" + expectedISBN + "'");

            Assert.AreEqual(expectedDelete, actualDelete);

        }
    }
}
