using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access
{
    public class FactoryT_D_SQLDATA_MSTAccess
    {
        private string clsname = "Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle.T_D_SQLDATA_MSTAccess";
        private IT_D_SQLDATA_MSTAccess access;
        public FactoryT_D_SQLDATA_MSTAccess()
        {
            access = null;
            Type t = Type.GetType(clsname);
            access = (IT_D_SQLDATA_MSTAccess)Activator.CreateInstance(t);
        }

        public FactoryT_D_SQLDATA_MSTAccess(string typestring)
        {
            access = null;
            Type t = Type.GetType(typestring);
            access = (IT_D_SQLDATA_MSTAccess)Activator.CreateInstance(t);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T_D_SQLDATA_MSTModel model)
        {
            return access.Add(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_D_SQLDATA_MSTModel model)
        {
            return access.Modify(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            return access.Delete(id);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_D_SQLDATA_MSTModel Query(string id)
        {
            return access.Query(id);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T_D_SQLDATA_MSTModel> QueryList(string swhere, string orders)
        {
            return access.QueryList(swhere, orders);
        }
    }
}
