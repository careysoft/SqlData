using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.IO;
using OfficeOpenXml;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute
{
    public class TaskThread
    {
        public EventMessageHandler EventThreadMessage;

        private void ThreadSendMessage(string code, string procedureName, string message) {
            if (EventThreadMessage != null) {
                EventThreadMessage(new EventMessageModel(code, procedureName, message));
            }
        }

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
                ThreadSendMessage("error", "StartTask", errorinfo);
                return false;
            }
            if (m_ThreadMain != null) {
                errorinfo = "任务正在执行";
                ThreadSendMessage("error", "StartTask", errorinfo);
                return false;
            }
            //EventThreadMessage("start", null);
            ThreadSendMessage("start", "StartTask", m_TaskModel.TASKNAME);
            m_Running = true;
            m_ThreadMain = new Thread(TaskProcess);
            m_ThreadMain.Start();
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
            ThreadSendMessage("stop", "StopTaskForce", m_TaskModel.TASKNAME);
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
            ThreadSendMessage("stop", "StopTaskForce", m_TaskModel.TASKNAME);
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
                    ThreadSendMessage("info", "TaskProcess", String.Format("{0}:{1}", m_TaskModel.TASKNAME, "开始执行"));
                    m_Doing = true;
                    TaskDo();
                    if (m_TaskModel.INTERVALADDTYPE == "1")
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
                    ThreadSendMessage("info", "TaskProcess", String.Format("{0}:{1}", m_TaskModel.TASKNAME, "执行结束"));
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
                            sql = sql.Replace(String.Format("'{0}'", m.SQLDARASLVNAME), m.SQLDATASLVVAL.Substring(4));
                            break;
                        default:
                            sql = sql.Replace(m.SQLDARASLVNAME, m.SQLDATASLVVAL);
                            break;
                    }
                }
                Model.T_BASE_SJYPZModel sjyModel = Access.DataSource.GetSJYPZFromBM(model.SJYBM);
                if (String.IsNullOrEmpty(sjyModel.PZBM))
                {
                    ThreadSendMessage("error", "SqlDataDo", String.Format("{0}:未找到数据源", m_TaskModel.TASKNAME));
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
                            string outPutPath = model.OUTPUTPATH[model.OUTPUTPATH.Length - 1] == '\\' ? model.OUTPUTPATH : model.OUTPUTPATH+"\\";
                            string fileName = outPutPath + model.SQLDATANAME;
                            var output = Output.OutputCreater.CreateOutput(model.OUTPUTTYPE);
                            output.OutputData(dt, fileName, ref errorinfo);
                            if (!String.IsNullOrEmpty(errorinfo)) {
                                ThreadSendMessage("error", "SqlDataDo", String.Format("{0}:{1}", m_TaskModel.TASKNAME, errorinfo));
                            }
                        }
                    }
                }
            }
            catch (Exception e) {
                ThreadSendMessage("error", "SqlDataDo", String.Format("{0}:{1}", m_TaskModel.TASKNAME, e.Message));
            }
        }
    }
}
