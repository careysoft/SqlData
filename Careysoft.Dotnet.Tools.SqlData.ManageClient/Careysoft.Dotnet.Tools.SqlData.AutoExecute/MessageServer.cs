using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketEngine;
using SuperSocket.SocketBase;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute
{
    public class MessageServer
    {
        private IBootstrap m_WebSocketServer = null;
        public bool StartServer(ref string errorinfo) {
            if (m_WebSocketServer == null) {
                m_WebSocketServer = BootstrapFactory.CreateBootstrap();
            }
            if (!m_WebSocketServer.Initialize()) {
                errorinfo = "初始化失败";
                return false;
            }
            m_WebSocketServer.Stop();
            if (m_WebSocketServer.Start() == StartResult.Failed) {
                errorinfo = "启动失败";
                return false;
            }
            return true;
        }

        public bool StopServer(ref string errorinfo) {
            if (m_WebSocketServer == null)
            {
                errorinfo = "服务未创建";
                return false;
            }
            m_WebSocketServer.Stop();
            return true;
        }
    }
}
