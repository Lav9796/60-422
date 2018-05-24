using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BookStoreLIB.TestCases
{
    [TestClass]
    public class TestQuestions1
    {
        [TestMethod]
        public void TestMethodQuestion2()
        {
            String Question = "Testing question input";

            try
            {
                DBQueries dbQ = new DBQueries();
                bool result;
                bool expectedResult = true;

                List<object> newstore = new List<object>(
                    new object[] { Question, "chawl113" }
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
