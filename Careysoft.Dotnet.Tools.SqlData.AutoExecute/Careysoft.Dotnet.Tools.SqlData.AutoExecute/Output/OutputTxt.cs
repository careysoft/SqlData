using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute.Output
{
    public class OutputTxt : Output
    {
        public override void OutputData(System.Data.DataTable dt, string outputPath, ref string errorInfo)
        {
            try
            {
                string outputFile = outputPath + ".txt";
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }
                    FileStream fileStream = null;
                    try
                    {
                        fileStream = File.Create(outputFile);
                    }
                    finally
                    {
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                    StringBuilder sBuilder = new StringBuilder();
                    string rowString = "";
                    //for (int j = 0; j < dt.Columns.Count; j++)
                    //{
                    //    if (j == 0)
                    //    {
                    //        rowString += Careysoft.Basic.Public.BConvert.ToString(dt.Columns[j].ColumnName);
                    //    }
                    //    else
                    //    {
                    //        rowString += "\t" + Careysoft.Basic.Public.BConvert.ToString(dt.Columns[j].ColumnName);
                    //    }
                    //}
                    //sBuilder.AppendLine(rowString);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rowString = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (j == 0)
                            {
                                rowString += Careysoft.Basic.Public.BConvert.ToString(dt.Rows[i][j]);
                            }
                            else
                            {
                                rowString += "\t" + Careysoft.Basic.Public.BConvert.ToString(dt.Rows[i][j]);
                            }
                        }
                        sBuilder.AppendLine(rowString);
                    }
                    using (StreamWriter sw = new StreamWriter(outputFile, true, Encoding.Unicode))
                    {
                        sw.Write(sBuilder.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                errorInfo = String.Format("OutPutDataTableToTxt-{0}", e.Message);
            }
        }
    }
}
