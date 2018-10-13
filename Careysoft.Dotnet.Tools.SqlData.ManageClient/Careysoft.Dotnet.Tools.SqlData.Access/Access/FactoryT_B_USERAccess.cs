using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public class FactoryT_B_USERAccess
    {
        private string clsname = "Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle.T_B_USERAccess";
        private IT_B_USERAccess access;
        public FactoryT_B_USERAccess()
        {
            access = null;
            Type t = Type.GetType(clsname);
            access = (IT_B_USERAccess)Activator.CreateInstance(t);
        }

        public FactoryT_B_USERAccess(string typestring)
        {
            access = null;
            Type t = Type.GetType(typestring);
            access = (IT_B_USERAccess)Activator.CreateInstance(t);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T_B_USERModel model)
        {
            return access.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_B_USERModel model)
        {
            return access.Modify(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int Delete(string username)
        {
            return access.Delete(username);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public T_B_USERModel Query(string username)
        {
            return access.Query(username);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T_B_USERModel> QueryList(string swhere, string orders)
        {
            return access.QueryList(swhere, orders);
        }
    }

}
