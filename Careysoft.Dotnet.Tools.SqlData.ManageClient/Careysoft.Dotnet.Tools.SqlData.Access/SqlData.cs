using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Careysoft.Dotnet.Tools.SqlData.Access
{
    public class SqlData
    {
        private readonly static string[] m_ConnectStringModel = {
                                                    "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SID={2})));USER ID={3};PASSWORD ={4}", 
                                                    "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SERVICE_NAME={2})));USER ID={3};PASSWORD ={4}", 
                                                };

        public static List<DataTable> GetDataSet(Model.T_BASE_SJYPZModel sjy, string sql, ref string errorinfo) {
            List<DataTable> models = new List<DataTable>();
            string connectstring = String.Format(m_ConnectStringModel[Convert.ToInt32(sjy.BL1)], sjy.SJIP, sjy.SJPORT, sjy.SJSID, sjy.SJUSERID, Careysoft.Basic.Public.DES.Decrypt(sjy.SJPASSWORD, "EPad@)!!"));
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper(XMLDbHelper.DbHelperType.ORACLE, connectstring, true);
            if (!af.Connected())
            {
                errorinfo = "目标数据无法连接!";
                return models;
            }
            string[] sqlArray = sql.Split(';');
            for (int i = 0; i < sqlArray.Length; i++) {
                DataSet ds = af.Query(sqlArray[i]);
                if (ds != null && ds.Tables.Count > 0)
                {
                    models.Add(ds.Tables[0]);
                }
            }
            return models;
        }
    }
}
