using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OfficeOpenXml;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output
{
    public class OutputXlsx : Output
    {
        public override void OutputData(System.Data.DataTable dt, string outputPath, ref string errorInfo)
        {
            try
            {
                string outputFile = outputPath + ".xlsx";
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }
                    using (var excel = new ExcelPackage(new FileInfo(outputFile)))
                    {
                        string sheelname = outputFile.Substring(outputFile.LastIndexOf('\\') + 1, outputFile.LastIndexOf('.') - outputFile.LastIndexOf('\\') - 1);
                        var ws = excel.Workbook.Worksheets.Add(sheelname);
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value = Careysoft.Basic.Public.BConvert.ToString(dt.Rows[i][j]);
                            }
                        }
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            ws.Column(i + 1).AutoFit();
                        }
                        excel.Save();
                    }
                }
            }
            catch (Exception e)
            {
                errorInfo = String.Format("OutPutDataTableToXls-{0}", e.Message);

            }
        }
    }
}
