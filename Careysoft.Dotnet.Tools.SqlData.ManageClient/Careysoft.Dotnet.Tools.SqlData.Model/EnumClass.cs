using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public enum EnumServerMessage { 
        QueryState,
        StateWorked,
        StateNoWork,
        StateShutdown,
        StartServer,
        StopServer
    }
}
