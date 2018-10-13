using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public interface IT_B_USERAccess
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T_B_USERModel model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Modify(T_B_USERModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int Delete(string username);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        T_B_USERModel Query(string username);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<T_B_USERModel> QueryList(string swhere, string orders);
    }

}
