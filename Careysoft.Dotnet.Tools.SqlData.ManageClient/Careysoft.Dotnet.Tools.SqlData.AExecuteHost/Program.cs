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

            //var websocketserver = BootstrapFactory.CreateBootstrap();
            //if (!websocketserver.Initialize())
            //{
            //    Console.WriteLine("Failed to initialize!");
            //    Console.ReadKey();
            //    return;
            //}

            //Console.WriteLine();
            //if (websocketserver.Start() == SuperSocket.SocketBase.StartResult.Failed)
            //{
            //    Console.WriteLine("Failed to start!");
            //    Console.ReadKey();
            //    return;
            //}
            TaskServer taskServer = new TaskServer();
            taskServer.EventRecieveThreadMessage += new Model.EventMessageHandler(EventReceiveThreadMessage);
            if (!taskServer.TaskInit()) {
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

            taskServer.TaskDispose();
            //Stop the appServer
            //websocketserver.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }

        static void EventReceiveThreadMessage(Model.EventMessageModel model) {
            Console.WriteLine(model.ToString());
        }
    }
}
