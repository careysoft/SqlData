using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public interface IT_D_TASK_MSTAccess
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T_D_TASK_MSTModel model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Modify(T_D_TASK_MSTModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(string id);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T_D_TASK_MSTModel Query(string id);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<T_D_TASK_MSTModel> QueryList(string swhere, string orders);

        int UpdateTaskLastDateTime(string taskId, string lastDatetime);
    }
}
