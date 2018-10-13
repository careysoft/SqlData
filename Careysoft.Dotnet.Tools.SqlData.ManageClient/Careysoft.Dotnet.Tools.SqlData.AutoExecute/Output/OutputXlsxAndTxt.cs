using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output
{
    public class OutputXlsxAndTxt : Output
    {
        public override void OutputData(System.Data.DataTable dt, string outputPath, ref string errorInfo)
        {
            var oxls = new OutputXlsx();
            string outputPath1 = outputPath + ".xlsx";
            oxls.OutputData(dt, outputPath1, ref errorInfo);

            var otxt = new OutputTxt();
            string outputPath2 = outputPath + ".txt";
            otxt.OutputData(dt, outputPath2, ref errorInfo);
        }
    }
}
