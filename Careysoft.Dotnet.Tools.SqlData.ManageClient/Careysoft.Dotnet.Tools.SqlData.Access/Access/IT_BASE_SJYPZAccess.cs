using System;
using System.Collections.Generic;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public interface IT_BASE_SJYPZAccess
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T_BASE_SJYPZModel model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Modify(T_BASE_SJYPZModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pzbm"></param>
        /// <returns></returns>
        int Delete(string pzbm);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pzbm"></param>
        /// <returns></returns>
        T_BASE_SJYPZModel Query(string pzbm);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<T_BASE_SJYPZModel> QueryList(string swhere, string orders);
    }

}
