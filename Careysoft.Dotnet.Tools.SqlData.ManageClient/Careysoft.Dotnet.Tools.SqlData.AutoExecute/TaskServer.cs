using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace Careysoft.Dotnet.Tools.SqlData.AutoExecute
{
    public class TaskServer
    {
        public Model.EventMessageHandler EventRecieveThreadMessage;

        private ConcurrentBag<TaskThread> m_TaskThreadList = new ConcurrentBag<TaskThread>();

        public TaskServer()
        { 
            
        }

        public bool TaskInit() {
            List<Model.T_D_TASK_MSTModel> taskList = Access.Task.GetAllTask().FindAll(delegate(Model.T_D_TASK_MSTModel m) { return m.SFJY == 0; });
            foreach (Model.T_D_TASK_MSTModel task in taskList) {
                TaskThread taskThread = new TaskThread(task.ID);
                string errorinfo = "";
                taskThread.EventThreadMessage += new Model.EventMessageHandler(EventReciveThreadMessage);
                taskThread.StartTask(ref errorinfo);
                m_TaskThreadList.Add(taskThread);
            }
            return true;
        }
        private void EventReciveThreadMessage(Model.EventMessageModel model)
        {
            if (EventRecieveThreadMessage != null) {
                EventRecieveThreadMessage(model);
            }
        }
        public bool TaskDispose() {
            while (!m_TaskThreadList.IsEmpty) {
                TaskThread task = null;
                m_TaskThreadList.TryTake(out task);
                if (task != null) {
                    string errorinfo = "";
                    task.StopTaskForce(ref errorinfo);
                }
            }
            return true;
        }

        public bool StartTask(string taskId, ref string errorinfo) {
            TaskThread taskThread = m_TaskThreadList.Single(t => t.TaskModel.ID == taskId);
            if (taskThread == null)
            {
                taskThread = new TaskThread(taskId);
                taskThread.StartTask(ref errorinfo);
                m_TaskThreadList.Add(taskThread);
                return true;
            }
            return taskThread.StartTask(ref errorinfo);
        }

        public bool StartTaskForce(string taskId, ref string errorinfo)
        {
            TaskThread taskThread = m_TaskThreadList.Single(t => t.TaskModel.ID == taskId);
            if (taskThread == null)
            {
                taskThread = new TaskThread(taskId);
                taskThread.StartTask(ref errorinfo);
                m_TaskThreadList.Add(taskThread);
                return true;
            }
            taskThread.StopTaskForce(ref errorinfo);
            return taskThread.StartTask(ref errorinfo);
        }

        public bool StopTask(string taskId, ref string errorinfo) {
            TaskThread taskThread = m_TaskThreadList.Single(t => t.TaskModel.ID == taskId);
            if (taskThread == null)
            {
                errorinfo = "该任务不存在";
                return false;
            }
            return taskThread.StopTask(ref errorinfo);
        }

        public bool StopTaskForce(string taskId, ref string errorinfo)
        {
            TaskThread taskThread = m_TaskThreadList.Single(t => t.TaskModel.ID == taskId);
            if (taskThread == null)
            {
                errorinfo = "该任务不存在";
                return false;
            }
            return taskThread.StopTaskForce(ref errorinfo);
        }
    }
}
