using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BookStoreLIB.TestCases
{
    [TestClass]
    public class TestQuestions
    {

        [TestMethod]
        public void TestMethodQuestion1()
        {
            String invalidQuestion = null;   

            try
            {
                DBQueries dbQ = new DBQueries();
                bool result;
                bool expectedResult = false;

                List<object> newstore = new List<object>(
                    new object[] { invalidQuestion, "chawl113" }
                    );

                result = dbQ.INSERT_INTO_TABLE("Questions", newstore);

                dbQ.DELETE_FROM_TABLE("Delete from Questions Where AskedBy ='chawl113'");

                Assert.AreEqual(expectedResult, result);

            }
            catch (ArgumentOutOfRangeException ae)
            {
                Assert.AreEqual("Question parameter cannot be null or empty.", ae.Message);
            }
        }
 
    }
}
