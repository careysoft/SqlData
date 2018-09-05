using System;
using System.Collections.Generic;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public class FactoryT_BASE_UNITTYPEAccess
    {
        private string clsname = "Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle.T_BASE_UNITTYPEAccess";
        private IT_BASE_UNITTYPEAccess access;
        public FactoryT_BASE_UNITTYPEAccess()
        {
            access = null;
            Type t = Type.GetType(clsname);
            access = (IT_BASE_UNITTYPEAccess)Activator.CreateInstance(t);
        }

        public FactoryT_BASE_UNITTYPEAccess(string typestring)
        {
            access = null;
            Type t = Type.GetType(typestring);
            access = (IT_BASE_UNITTYPEAccess)Activator.CreateInstance(t);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T_BASE_UNITTYPEModel model)
        {
            return access.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_BASE_UNITTYPEModel model)
        {
            return access.Modify(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lxbm"></param>
        /// <returns></returns>
        public int Delete(string lxbm)
        {
            return access.Delete(lxbm);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="lxbm"></param>
        /// <returns></returns>
        public T_BASE_UNITTYPEModel Query(string lxbm)
        {
            return access.Query(lxbm);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T_BASE_UNITTYPEModel> QueryList(string swhere, string orders)
        {
            return access.QueryList(swhere, orders);
        }
    }

}
