using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin f = new FormLogin();
            if (f.ShowDialog() == DialogResult.OK)
            {
                FormMain f2 = new FormMain();
                Application.Run(f2);
            }

            //FormMain f2 = new FormMain();
            //Application.Run(f2);
        }
    }
}
