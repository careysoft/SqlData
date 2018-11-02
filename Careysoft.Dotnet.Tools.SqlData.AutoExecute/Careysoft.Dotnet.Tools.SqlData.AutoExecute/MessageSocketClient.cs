using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;
using Careysoft.Dotnet.Server.MessageServer.Model;
using System.Threading;
using System.Configuration;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute
{
    public class MessageSocketClient
    {
        public event EventHandler EventRecieveMessage;

        private WebSocket4Net.WebSocket m_WebSocketClient = null;
        private string m_Ip = "";
        private string m_Port = "";
        //private bool m_Logined = false;
        private string m_PrivateKey = "";
        private Thread m_HeartThread = null;
        private bool m_Running = false;
        private Thread m_ConnectThread = null;

        public MessageSocketClient(string ip, string port) {
            m_Ip = ip;
            m_Port = port;
        }

        /// <summary>
        /// 不停连接
        /// </summary>
        public void StartConnect() {
            m_Running = true;
            m_ConnectThread = new Thread(StartConnectWithoutStop);
            m_ConnectThread.Start();
        }

        public void StartConnectWithoutStop() {
            while (m_Running) {
                if (m_WebSocketClient == null)
                {
                    Connect();
                }
                else {
                    if (m_WebSocketClient.State == WebSocketState.Closed) {
                        Connect();
                    }
                }
                Thread.Sleep(60000);
            }    
        }

        public void StopConnect() {
            m_Running = false;
            if (m_ConnectThread != null) {
                m_ConnectThread.Abort();
                m_ConnectThread = null;
            }
            Close();
        }

        public void Connect()
        {
            if (m_WebSocketClient != null)
            {
                Close();
            }
            m_WebSocketClient = new WebSocket4Net.WebSocket(string.Format("ws://{0}:{1}/websocket", m_Ip, m_Port), "basic", WebSocketVersion.Rfc6455);
            m_WebSocketClient.Opened += new EventHandler(m_WebSocketClient_Opened);
            m_WebSocketClient.Closed += new EventHandler(m_WebSocketClient_Closed);
            m_WebSocketClient.MessageReceived += new EventHandler<MessageReceivedEventArgs>(m_WebSocketClient_MessageReceived);
            m_WebSocketClient.Open();
        }

        void m_WebSocketClient_Opened(object sender, EventArgs e)
        {

        }

        void m_WebSocketClient_Closed(object sender, EventArgs e)
        {
            StopHeartBeat();
        }

        void m_WebSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageModel model = new MessageModel(e.Message);
            switch (model.Command)
            {
                case EnumCommand.AuthQuestion:
                    m_WebSocketClient.Send(EnumCommand.AuthUser + " " + ConfigurationManager.AppSettings["ClientCode"] + "$aaa");
                    break;
                case EnumCommand.AuthAccept:
                    //m_Logined = true;
                    m_PrivateKey = Careysoft.Basic.Public.DES.Decrypt(model.Body, DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
                    StartHeartBeat();
                    break;
                case EnumCommand.MessagePoint:
                    string body = model.Body;
                    body = Careysoft.Basic.Public.DES.Decrypt(body, m_PrivateKey);
                    MessageBodyModel msgModel = Careysoft.Basic.Public.ObjectSerializer.Xml16ToInstances<MessageBodyModel>(body);
                    DoMessagePoint(msgModel);
                    //发送
                    break;
            }
        }

        public void SendPointMessage(MessageBodyModel msgModel) {
            if (m_WebSocketClient != null && m_WebSocketClient.State == WebSocketState.Open)
            {
                string sendMessage = "";
                msgModel.Header.SourceCode = ConfigurationManager.AppSettings["ClientCode"];
                sendMessage = Careysoft.Basic.Public.ObjectSerializer.InstancesToXML<MessageBodyModel>(msgModel);
                sendMessage = Careysoft.Basic.Public.DES.Encrypt(sendMessage, m_PrivateKey);
                MessageModel model = new MessageModel(EnumCommand.MessagePoint, sendMessage);
                m_WebSocketClient.Send(model.ToString());
            }
        }

        public void SendGroupMessage(MessageBodyModel msgModel)
        {
            if (m_WebSocketClient != null && m_WebSocketClient.State == WebSocketState.Open)
            {
                string sendMessage = "";
                msgModel.Header.SourceCode = ConfigurationManager.AppSettings["ClientCode"];
                sendMessage = Careysoft.Basic.Public.ObjectSerializer.InstancesToXML<MessageBodyModel>(msgModel);
                sendMessage = Careysoft.Basic.Public.DES.Encrypt(sendMessage, m_PrivateKey);
                MessageModel model = new MessageModel(EnumCommand.MessageGroup, sendMessage);
                m_WebSocketClient.Send(model.ToString());
            }
        }

        private void DoMessagePoint(MessageBodyModel msgModel)
        {
            //string sendMessage = "";
            //Model.EnumServerMessage messageContent = (Model.EnumServerMessage)Enum.Parse(typeof(Model.EnumServerMessage), msgModel.MessageContent);
            //switch (messageContent) { 
            //    case Model.EnumServerMessage.Hello:
            //        string codeTemp = msgModel.Header.TargetCode;
            //        msgModel.Header.TargetCode = msgModel.Header.SourceCode;
            //        msgModel.Header.SourceCode = codeTemp;
            //        sendMessage = Careysoft.Basic.Public.ObjectSerializer.InstancesToXML<MessageBodyModel>(msgModel);
            //        sendMessage = Careysoft.Basic.Public.DES.Encrypt(sendMessage, m_PrivateKey);
            //        break;
            //}
            //MessageModel model = new MessageModel(EnumCommand.MessagePoint, sendMessage);
            //m_WebSocketClient.Send(model.ToString());
            EventRecieveMessage(msgModel, null);
        }

        public void Close()
        {
            m_WebSocketClient.Close();
            m_WebSocketClient = null;
        }

        public void StartHeartBeat() {
            m_HeartThread = new Thread(SendHeartBeat);
            m_HeartThread.Start();
        }

        public void SendHeartBeat() {
            string message = EnumCommand.Status.ToString();
            while (true)
            {
                if (m_WebSocketClient!=null && m_WebSocketClient.State == WebSocketState.Open)
                {
                    m_WebSocketClient.Send(message);
                }
                Thread.Sleep(30000);
            }
        }

        public void StopHeartBeat() {
            if (m_HeartThread != null) {
                m_HeartThread.Abort();
                m_HeartThread = null;
            }
        }
    }
}
