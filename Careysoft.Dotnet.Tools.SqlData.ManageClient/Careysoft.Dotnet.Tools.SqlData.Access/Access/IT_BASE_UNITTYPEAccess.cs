using System;
using System.Collections.Generic;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public interface IT_BASE_UNITTYPEAccess
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(T_BASE_UNITTYPEModel model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Modify(T_BASE_UNITTYPEModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lxbm"></param>
        /// <returns></returns>
        int Delete(string lxbm);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="lxbm"></param>
        /// <returns></returns>
        T_BASE_UNITTYPEModel Query(string lxbm);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<T_BASE_UNITTYPEModel> QueryList(string swhere, string orders);
    }

}
