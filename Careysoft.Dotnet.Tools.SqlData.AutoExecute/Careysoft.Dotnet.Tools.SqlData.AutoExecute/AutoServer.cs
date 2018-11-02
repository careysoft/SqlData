using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute
{
    public class AutoServer
    {
        private MessageSocketClient m_MessageSocketClient = null;

        private TaskServer m_TaskServer = null;

        public AutoServer() {
            
        }

        public bool StartServer(){
            m_MessageSocketClient = new MessageSocketClient(ConfigurationManager.AppSettings["MessageIpAddr"], ConfigurationManager.AppSettings["MessagePort"]);
            m_MessageSocketClient.EventRecieveMessage += new EventHandler(m_MessageSocketClient_EventRecieveMessage);
            m_MessageSocketClient.StartConnect();
            m_TaskServer = new TaskServer();
            m_TaskServer.EventRecieveThreadMessage += new Model.EventMessageHandler(EventReceiveThreadMessage);
            m_TaskServer.TaskInit();
            Careysoft.Dotnet.Server.MessageServer.Model.MessageBodyModel model = new Server.MessageServer.Model.MessageBodyModel();
            model.Header.TagetType = Server.MessageServer.Model.EnumClientType.Normal;
            model.Header.MessageType = Server.MessageServer.Model.EnumMessageType.Group;
            model.MessageContentType = Server.MessageServer.Model.EnumMessageContentType.Text;
            model.MessageContent = Model.EnumServerMessage.StateWorked.ToString();
            m_MessageSocketClient.SendGroupMessage(model);
            return true;
        }

        public bool StopServer() {
            m_TaskServer.TaskDispose();
            Careysoft.Dotnet.Server.MessageServer.Model.MessageBodyModel model = new Server.MessageServer.Model.MessageBodyModel();
            model.Header.TagetType = Server.MessageServer.Model.EnumClientType.Normal;
            model.Header.MessageType = Server.MessageServer.Model.EnumMessageType.Group;
            model.MessageContentType = Server.MessageServer.Model.EnumMessageContentType.Text;
            model.MessageContent = Model.EnumServerMessage.StateShutdown.ToString();
            m_MessageSocketClient.SendGroupMessage(model);
            Thread.Sleep(100);
            m_MessageSocketClient.StopConnect();
            return true;
        }

        void m_MessageSocketClient_EventRecieveMessage(object sender, EventArgs e)
        {
            Careysoft.Dotnet.Server.MessageServer.Model.MessageBodyModel model = sender as Careysoft.Dotnet.Server.MessageServer.Model.MessageBodyModel;
            Model.EnumServerMessage messageContent = (Model.EnumServerMessage)Enum.Parse(typeof(Model.EnumServerMessage), model.MessageContent);
            switch (messageContent) { 
                case Model.EnumServerMessage.QueryState:
                    if (m_TaskServer.Worked)
                    {
                        model.MessageContent = Model.EnumServerMessage.StateWorked.ToString();
                    }
                    else { 
                        model.MessageContent = Model.EnumServerMessage.StateNoWork.ToString();
                    }
                    break;
            }
            model.Header.TargetCode = model.Header.SourceCode;
            m_MessageSocketClient.SendPointMessage(model);
        }

        public Model.EventMessageHandler EventReceiveThreadMessage { get; set; }
    }
}
