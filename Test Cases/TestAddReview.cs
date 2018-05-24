using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreLIB.TestCases
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestAddReview
    {
        [TestMethod]
        public void TestMethodAddReview()   //checks if bookISBN is NULL (it cannot be null)
        {      
            DALReviewItem revItem = new DALReviewItem();
            

            string bookISBN = null; //"1617290890";
            int orderID = 4;
            int rating = 1;
            string comments = "good book";

            bool expectedReturnWithBook = false;

           
            bool actualReturnWithBook = revItem.Review(bookISBN, orderID, rating, comments);

            Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
        }

        [TestMethod]
        public void TestMethodAddReview1()   //checks if book actually exists in the library before adding a review to it
        {
            DALReviewItem revItem = new DALReviewItem();


            string bookISBN = "121212121212"; 
            int orderID = 4;
            int rating = 1;
            string comments = "Awesome book!";


            bool expectedReturnWithBook = false;// as book does not exist in the database


            bool actualReturnWithBook = revItem.Review(bookISBN, orderID, rating, comments);

            Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
        }

        [TestMethod]
        public void TestMethodAddReview2()   //This Test case will pass, as all the conditions are met
        {
            DALReviewItem revItem = new DALReviewItem();


            string bookISBN = "0321146530";
            int orderID = 29;
            int rating = 5;
            string comments = "Awesome book!";


            bool expectedReturnWithBook = true;
            bool expectedDelete = true;

            bool actualReturnWithBook = revItem.Review(bookISBN, orderID, rating, comments);

            DBQueries delete = new DBQueries();

            bool actualdelete = delete.DELETE_FROM_TABLE("delete from UserReviews where OrderID = '29'");  //delete from table after testing


            Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
            Assert.AreEqual(expectedDelete, actualdelete);


        }

        [TestMethod]
        public void TestMethodAddReview3()   //checks if OrderID is valid (cannot be negative)
        {
            DALReviewItem revItem = new DALReviewItem();


            string bookISBN = "0321146530"; 
            int orderID = -1;  //enter invalid orderID (negative)
            int rating = 1;
            string comments = "good book";

            bool expectedReturnWithBook = false;


            bool actualReturnWithBook = revItem.Review(bookISBN, orderID, rating, comments);

            Assert.AreEqual(expectedReturnWithBook, actualReturnWithBook);
        }




    }
}
