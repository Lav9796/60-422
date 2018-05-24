/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreLIB
{
    public class UserData
    {
        public int UserID { set; get; }
        public string MessageString { set; get; }
        public string LoginName { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public Boolean LoggedIn { set; get; }

        public Boolean LogIn(string loginName, string passWord)
        {
            UserID = -1;

            if ((loginName != "") && (passWord != ""))
            {
                var dbUser = new DALUserInfo();
                UserID = dbUser.LogIn(loginName, passWord);
                if (UserID > 0)
                {
                    LoginName = loginName;
                    Password = passWord;
                    FullName = dbUser.GetName(loginName, passWord);
                    LoggedIn = true;
                    return true;
                }
                else
                {
                    MessageString = dbUser.ErrorMessage;
                    LoggedIn = false;
                    return false;
                }
            }
            else
            {
                MessageString = "Please fill in all slots.";
                LoggedIn = false;
                return false;
            }
        }

        public Boolean LogOut()
        {
            if (0 < UserID)
            {
                UserID = -1;
                LoggedIn = false;
                return true;
            }
            else
                return false;
        }
        public Boolean IsNotEmpty(string loginName, string passWord)
        {
            if (loginName != "" && passWord != "")
            {
                return true;
            }
            else
                return false;
        }
        public Boolean PasswordLength(string passWord)
        {
            if (passWord.Length >= 6)
            {
                return true;
            }
            else
                return false;
        }
        public Boolean PasswordFormat(string passWord)
        {
            if (char.IsLetter(passWord[0]) && passWord.All(c => char.IsLetterOrDigit(c)))
            {
                return true;
            }
            else
                return false;
        }
    }
}