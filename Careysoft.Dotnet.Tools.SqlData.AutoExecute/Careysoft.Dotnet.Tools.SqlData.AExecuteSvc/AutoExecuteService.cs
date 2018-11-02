using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.AutoExecute;

namespace Careysoft.Dotnet.Tools.SqlData.AExecuteSvc
{
    public partial class AutoExecuteService : ServiceBase
    {
        private AutoServer m_AutoServer = null;
        public AutoExecuteService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            m_AutoServer = new AutoServer();
            m_AutoServer.EventReceiveThreadMessage += new Model.EventMessageHandler(EventReceiveThreadMessage);
            if (!m_AutoServer.StartServer())
            {
                Careysoft.Basic.Public.Log.ErrorWrite("The server started fail");
                return;
            }
        }

        protected override void OnStop()
        {
            m_AutoServer.StopServer();
        }

        static void EventReceiveThreadMessage(Model.EventMessageModel model)
        {
            //Console.WriteLine(model.ToString());
            if (model.Code == "error")
            {
                Careysoft.Basic.Public.Log.ErrorWrite(model.ToString());
            }
        }
    }
}
