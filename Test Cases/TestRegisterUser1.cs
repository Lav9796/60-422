using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Diagnostics;

/// <summary>
/// Public TEST class for User Registration. Test case creates a new user with set parameters, 
/// tests if the database matches the given values, checks success reply, and then deletes
/// the test user account.
/// </summary>
namespace BookStoreLIB
{
    [TestClass]
    public class TestRegisterUser1
    {
        UserRegister userRegister = new UserRegister();
        UserData userData = new UserData();
        DataSet ds = new DataSet();
        DBQueries dbQ = new DBQueries();
        string inputName, inputPassword, inputPasswordV, inputFullName;

        [TestMethod]
        public void TestMethodRegisterUser1()
        {
            
            inputName = "Doll";
            inputPassword = "lb1234";
            inputPasswordV = "lb123";
            inputFullName = "User1";

            bool expectedRegister = false;
            

            var c = new SqlConnection(Properties.Settings.Default.dbConnectionString);

            bool actualRegister = userRegister.Register(inputName, inputPassword, inputPasswordV, inputFullName);
           
            DBDelete dbD = new DBDelete();
            bool actualDelete = dbD.deleteRow("DELETE FROM UserData WHERE UserName = '" + inputName + "'", c);

            Assert.AreEqual(expectedRegister, actualRegister);
            
            c.Close();
        }


        [TestMethod]
        public void TestMethodRegisterUser2()
        {
            
            inputName = "bandla";
            inputPassword = "as";
            inputPasswordV = "as";
            inputFullName = "User2";

            bool expectedRegister = false;
            

            var c = new SqlConnection(Properties.Settings.Default.dbConnectionString);

            bool actualRegister = userRegister.Register(inputName, inputPassword, inputPasswordV, inputFullName);
            


           

            DBDelete dbD = new DBDelete();
            bool actualDelete = dbD.deleteRow("DELETE FROM UserData WHERE UserName = '" + inputName + "'", c);

            Assert.AreEqual(expectedRegister, actualRegister);
            

            c.Close();
        }










    }
}
