using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Careysoft.Dotnet.Tools.SqlData.Access
{
    public class ConnectDB
    {
        public static void GetDBSetWindow()
        {
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            Form form = af.GetDBSetUserFrom();
            form.ShowDialog();
        }
    }
}
