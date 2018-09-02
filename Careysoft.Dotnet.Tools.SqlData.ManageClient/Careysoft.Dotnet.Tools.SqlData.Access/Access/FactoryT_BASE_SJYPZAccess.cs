using System;
using System.Collections.Generic;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public class FactoryT_BASE_SJYPZAccess
    {
        private string clsname = "Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle.T_BASE_SJYPZAccess";
        private IT_BASE_SJYPZAccess access;
        public FactoryT_BASE_SJYPZAccess()
        {
            access = null;
            Type t = Type.GetType(clsname);
            access = (IT_BASE_SJYPZAccess)Activator.CreateInstance(t);
        }

        public FactoryT_BASE_SJYPZAccess(string typestring)
        {
            access = null;
            Type t = Type.GetType(typestring);
            access = (IT_BASE_SJYPZAccess)Activator.CreateInstance(t);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T_BASE_SJYPZModel model)
        {
            return access.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_BASE_SJYPZModel model)
        {
            return access.Modify(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pzbm"></param>
        /// <returns></returns>
        public int Delete(string pzbm)
        {
            return access.Delete(pzbm);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pzbm"></param>
        /// <returns></returns>
        public T_BASE_SJYPZModel Query(string pzbm)
        {
            return access.Query(pzbm);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T_BASE_SJYPZModel> QueryList(string swhere, string orders)
        {
            return access.QueryList(swhere, orders);
        }
    }

}
