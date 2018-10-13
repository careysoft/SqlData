using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Access
{
    public class User
    {
        public static bool Login(string username, string password)
        {
            Access.FactoryT_B_USERAccess af = new Access.FactoryT_B_USERAccess();
            Model.T_B_USERModel user = af.Query(username);
            if (String.IsNullOrEmpty(user.USERNAME))
            {
                return false;
            }
            if (user.PASSWORD == Careysoft.Basic.Public.DES.Encrypt(password, "Pass@)!#"))
            {
                return true;
            }
            return false;
        }
    }
}
