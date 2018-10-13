using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class EventMessageModel {
        public EventMessageModel(string code, string procedureName, string message) {
            Code = code;
            ProcedureName = procedureName;
            Message = message;
            CreateDatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public string Code { get; set; }
        public string ProcedureName { get; set; }
        public string Message { get; set; }
        public string CreateDatetime { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", Code, ProcedureName, Message, CreateDatetime);
        }
    }

    public delegate void EventMessageHandler(EventMessageModel emModel);
}
