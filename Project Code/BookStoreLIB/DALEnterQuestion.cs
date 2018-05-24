using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLIB
{
   public class DALEnterQuestion
    {
        public bool EnterQuestion(string userID, string question)
        {
            

            //string newType = "CU";

            DBQueries db = new DBQueries();

            List<object> bookstore = new List<object>(
                new object[] { userID, question }
                );

            return db.INSERT_INTO_TABLE("UserData", bookstore);
        }




    }
}
