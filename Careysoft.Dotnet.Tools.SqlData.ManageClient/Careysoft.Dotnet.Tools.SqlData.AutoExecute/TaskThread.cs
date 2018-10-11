using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute
{
    public class TaskThread
    {
        public event EventHandler EventThreadMessage;

        public TaskThread(string taskId) {
            m_TaskModel = Access.Task.GetTaskFromId(taskId);
        }

        private bool m_Running = false;
        public bool Running {
            get { return m_Running; }
            set { m_Running = value; }
        }

        private bool m_Doing = false;
        public bool Doing {
            get { return m_Doing; }
            set { m_Doing = value; }
        }

        private Thread m_ThreadMain = null;
        public Thread ThreadMain
        {
            get { return m_ThreadMain; }
            set { m_ThreadMain = value; }
        }

        private Model.T_D_TASK_MSTModel m_TaskModel = new Model.T_D_TASK_MSTModel();
        public Model.T_D_TASK_MSTModel TaskModel {
            get { return m_TaskModel; }
            set { m_TaskModel = value; }
        }

        public bool StartTask(ref string errorinfo) {
            if (String.IsNullOrEmpty(m_TaskModel.ID))
            {
                errorinfo = "没有找到任务";
                return false;
            }
            if (m_ThreadMain != null) {
                errorinfo = "任务正在执行";
                return false;
            }
            EventThreadMessage("start", null);
            m_Running = true;
            m_ThreadMain = new Thread(TaskProcess);
            return true;
        }
        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="errorinfo"></param>
        /// <returns></returns>
        public bool StopTask(ref string errorinfo) {
            if (m_Doing) {
                errorinfo = "任务还在运行中";
                return false;
            }
            m_Running = false;
            Thread.Sleep(1000);
            m_ThreadMain.Abort();
            m_ThreadMain = null;
            EventThreadMessage("stop", null);
            return true;
        }
        /// <summary>
        /// 强制停止
        /// </summary>
        /// <param name="errorinfo"></param>
        /// <returns></returns>
        public bool StopTaskForce(ref string errorinfo)
        {
            m_Running = false;
            m_Doing = false;
            m_ThreadMain.Abort();
            m_ThreadMain = null;
            EventThreadMessage("stop", null);
            return true;
        }

        private void TaskProcess() {
            //EventThreadMessage("start", null);
            while (m_Running)
            {
                DateTime now = DateTime.Now;
                TimeSpan timeSpan = now - Convert.ToDateTime(m_TaskModel.LASTDATETIME);
                bool startTask = false;
                switch (m_TaskModel.INTERVALTYPE) { 
                    case "0":
                        startTask = timeSpan.TotalSeconds > m_TaskModel.INTERVAL;
                        break;
                    case "1":
                        startTask = timeSpan.TotalMinutes > m_TaskModel.INTERVAL;
                        break;
                    case "2":
                        startTask = timeSpan.TotalHours > m_TaskModel.INTERVAL;
                        break;
                    case "3":
                        startTask = timeSpan.TotalDays > m_TaskModel.INTERVAL;
                        break;
                }
                if (startTask) { //判断是否有执行次数限制 
                    if (m_TaskModel.TASKNUMBER != -1 && m_TaskModel.TASKDONUMBER >= m_TaskModel.TASKNUMBER) {
                        startTask = false;
                    }
                }
                if (startTask) {
                    m_Doing = true;
                    TaskDo();
                    if (m_TaskModel.INTERVALADDTYPE == "0")
                    {
                        m_TaskModel.LASTDATETIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else {
                        DateTime lastDatetime = Convert.ToDateTime(m_TaskModel.LASTDATETIME);
                        DateTime lastDatetime2 = Convert.ToDateTime(m_TaskModel.LASTDATETIME); 
                        DateTime now2 = DateTime.Now;
                        while (now2 > lastDatetime)
                        {
                            lastDatetime2 = lastDatetime;
                            switch (m_TaskModel.INTERVALTYPE)
                            {
                                case "0":
                                    lastDatetime = lastDatetime.AddSeconds(m_TaskModel.INTERVAL);
                                    break;
                                case "1":
                                    lastDatetime = lastDatetime.AddMinutes(m_TaskModel.INTERVAL);
                                    break;
                                case "2":
                                    lastDatetime = lastDatetime.AddHours(m_TaskModel.INTERVAL);
                                    break;
                                case "3":
                                    lastDatetime = lastDatetime.AddDays(m_TaskModel.INTERVAL);
                                    break;
                            }
                        }
                        m_TaskModel.LASTDATETIME = lastDatetime2.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    Access.Task.UpdateLastDateTime(m_TaskModel.ID, m_TaskModel.LASTDATETIME);
                    m_Doing = false;
                }
                Thread.Sleep(500);
            }
            //EventThreadMessage("stop", null);
        }

        private void TaskDo() {
            foreach (Model.T_D_TASK_SLVModel model in m_TaskModel.SlvList) {
                SqlDataDo(model);        
            }
        }

        private void SqlDataDo(Model.T_D_TASK_SLVModel model) {
            try
            {
                string sql = model.SQL;
                foreach (Model.T_S_TASK_SLV_SLVModel m in model.SlvList)
                {
                    switch (m.SQLDATASLVVAL.Substring(0, 4))
                    {
                        case "FUN:":
                            sql = sql.Replace(String.Format("'{0},", m.SQLDARASLVNAME), m.SQLDATASLVVAL.Substring(4));
                            break;
                        default:
                            sql = sql.Replace(m.SQLDARASLVNAME, m.SQLDATASLVVAL);
                            break;
                    }
                }
                Model.T_BASE_SJYPZModel sjyModel = Access.DataSource.GetSJYPZFromBM(model.SJYBM);
                if (String.IsNullOrEmpty(sjyModel.PZBM))
                {
                    EventThreadMessage(String.Format("error:{0}", "未找到数据源"), null);
                    return;
                }
                string errorinfo = "";
                if (model.SQLTYPE == "0")
                {
                    //查询类
                    List<DataTable> dataTables = Access.SqlData.GetDataSet(sjyModel, sql, ref errorinfo);
                    if (model.TASKTYPE == "0")
                    {
                        //输出类
                        foreach (DataTable dt in dataTables)
                        {
                            string fileName = model.OUTPUTPATH + model.SQLDATANAME;
                            switch (model.OUTPUTTYPE)
                            {
                                case "0":
                                    OutPutDataTableToTxt(dt, fileName + ".txt");
                                    break;
                                case "1":
                                    OutPutDataTableToExcel(dt, fileName + ".xlsx");
                                    break;
                                case "2":
                                    OutPutDataTableToTxt(dt, fileName + ".txt");
                                    OutPutDataTableToExcel(dt, fileName + ".xlsx");
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception e) {
                EventThreadMessage(String.Format("error:{0}", e.Message), null);
            }
        }

        private void OutPutDataTableToExcel(DataTable dt, string file) {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        using (var excel = new ExcelPackage(new FileInfo(file)))
                        {
                            string sheelname = file.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - file.LastIndexOf('\\') - 1);
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
            }
            catch (Exception e) {
                EventThreadMessage(String.Format("error:{0}", e.Message), null);
            }
        }

        private void OutPutDataTableToTxt(DataTable dt, string file) {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        FileStream fileStream = null;
                        try
                        {
                            fileStream = File.Create(file);
                        }
                        finally
                        {
                            fileStream.Close();
                            fileStream.Dispose();
                        }
                        StringBuilder sBuilder = new StringBuilder();
                        string rowString = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (j == 0)
                            {
                                rowString += Careysoft.Basic.Public.BConvert.ToString(dt.Columns[j].ColumnName);
                            }
                            else
                            {
                                rowString += "\t" + Careysoft.Basic.Public.BConvert.ToString(dt.Columns[j].ColumnName);
                            }
                            sBuilder.AppendLine(rowString);
                        }
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
                        }
                        using (StreamWriter sw = new StreamWriter(file, true, Encoding.Unicode))
                        {
                            sw.Write(sBuilder.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                EventThreadMessage(String.Format("error:{0}", e.Message), null);
            }
        }
    }
}
