using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.AutoExecute;

namespace Careysoft.Dotnet.Tools.SqlData.AExecuteHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press wait to start the server!");
            AutoServer autoServer = new AutoServer();
            autoServer.EventReceiveThreadMessage += new Model.EventMessageHandler(EventReceiveThreadMessage);
            if (!autoServer.StartServer()) {
                Console.WriteLine("The server started fail!");
                return;
            }

            Console.WriteLine();

            Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            autoServer.StopServer();
            //Stop the appServer
            //websocketserver.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }

        static void EventReceiveThreadMessage(Model.EventMessageModel model) {
            Console.WriteLine(model.ToString());
            if (model.Code == "error") {
                Careysoft.Basic.Public.Log.ErrorWrite(model.ToString());
            }
        }
    }
}
