using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Access
{
    public class Task
    {
        public static bool TaskAdd(Model.T_D_TASK_MSTModel model)
        {
            Access.FactoryT_D_TASK_MSTAccess af = new Access.FactoryT_D_TASK_MSTAccess();
            int ret = af.Add(model);
            return ret > 0;
        }

        public static bool TaskEdit(Model.T_D_TASK_MSTModel model)
        {
            Access.FactoryT_D_TASK_MSTAccess af = new Access.FactoryT_D_TASK_MSTAccess();
            int ret = af.Modify(model);
            return ret > 0;
        }

        public static bool TaskDel(string taskId) {
            Access.FactoryT_D_TASK_MSTAccess af = new Access.FactoryT_D_TASK_MSTAccess();
            Model.T_D_TASK_MSTModel model = af.Query(taskId);
            model.SFSC = 1;
            return af.Modify(model) > 0;
        }

        public static List<Model.T_D_TASK_MSTModel> GetAllTask() {
            List<Model.T_D_TASK_MSTModel> models = new List<Model.T_D_TASK_MSTModel>();
            Access.FactoryT_D_TASK_MSTAccess af = new Access.FactoryT_D_TASK_MSTAccess();
            models = af.QueryList("T.SFSC=0", "T.ID");
            return models;
        }

        public static Model.T_D_TASK_MSTModel GetTaskFromId(string taskId) {
            Model.T_D_TASK_MSTModel model = new Model.T_D_TASK_MSTModel();
            Access.FactoryT_D_TASK_MSTAccess af = new Access.FactoryT_D_TASK_MSTAccess();
            model = af.Query(taskId);
            return model;
        }

        public static bool UpdateLastDateTime(string taskId, string lastDatetime) {
            Access.FactoryT_D_TASK_MSTAccess af = new Access.FactoryT_D_TASK_MSTAccess();
            return af.UpdateTaskLastDateTime(taskId, lastDatetime) > 0;
        }
    }
}
