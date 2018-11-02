using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output
{
    public class OutputCreater
    {
        private static Dictionary<string, string> m_DictOutputType = new Dictionary<string, string>();
        public OutputCreater() {

        }

        public static Output CreateOutput(string outputType) {
            if (m_DictOutputType.Count == 0) {
                m_DictOutputType.Add("0", "Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output.OutputTxt");
                m_DictOutputType.Add("1", "Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output.OutputXlsx");
                m_DictOutputType.Add("2", "Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output.OutputXlsxAndTxt"); 
            }
            Type t = Type.GetType(m_DictOutputType[outputType]);
            var output = (Output)Activator.CreateInstance(t);
            return output;
        }
    }
}
