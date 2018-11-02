using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output
{
    public abstract class Output
    {
        public abstract void OutputData(DataTable dt, string outputPath, ref string errorInfo);
    }
}
