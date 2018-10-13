using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Careysoft.Dotnet.Tools.SqlData.Access
{
    public class DataSource
    {
        public static List<Model.T_BASE_SJYPZModel> GetAllSJYPZ()
        {
            string where = "T.SFSC=0";
            string order = "T.BL1,T.PZBM";
            Access.FactoryT_BASE_SJYPZAccess af = new Access.FactoryT_BASE_SJYPZAccess();
            return af.QueryList(where, order);
        }

        public static List<Model.T_BASE_SJYPZModel> GetSJYPZFromGroupId(string groupId)
        {
            string where = "T.BL2='" + groupId + "' AND T.SFSC=0";
            string order = "T.BL1,T.PZBM";
            Access.FactoryT_BASE_SJYPZAccess af = new Access.FactoryT_BASE_SJYPZAccess();
            return af.QueryList(where, order);
        }

        public static Model.T_BASE_SJYPZModel GetSJYPZFromBM(string bm)
        {
            Access.FactoryT_BASE_SJYPZAccess af = new Access.FactoryT_BASE_SJYPZAccess();
            Model.T_BASE_SJYPZModel model = af.Query(bm);
            return model;
        }

        public static bool SJYPZAdd(Model.T_BASE_SJYPZModel model)
        {
            Access.FactoryT_BASE_SJYPZAccess af = new Access.FactoryT_BASE_SJYPZAccess();
            int ret = af.Add(model);
            return ret > 0;
        }

        public static bool SJYPZEdit(Model.T_BASE_SJYPZModel model)
        {
            Access.FactoryT_BASE_SJYPZAccess af = new Access.FactoryT_BASE_SJYPZAccess();
            int ret = af.Modify(model);
            return ret > 0;
        }

        public static bool SJYPDel(string bm) {
            Model.T_BASE_SJYPZModel model = GetSJYPZFromBM(bm);
            model.SFSC = 1;
            return SJYPZEdit(model);
        }

        public static bool SJYConnected(string ip, string port, string sid, string uid, string pass)
        {
            string m_ConnectStringModel = "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SID={2})));USER ID={3};PASSWORD ={4}";
            string connectstring = String.Format(m_ConnectStringModel, ip, port, sid, uid, pass);
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper(XMLDbHelper.DbHelperType.ORACLE, connectstring, true);
            return af.Connected();
        }
        //新增了一个数据源type 用于区分sid 和 service_name
        public static bool SJYConnected(string ip, string port, string sidtype, string sid, string uid, string pass)
        {
            string[] m_ConnectStringModel = { 
                                                "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SID={2})));USER ID={3};PASSWORD ={4}", 
                                                "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SERVICE_NAME={2})));USER ID={3};PASSWORD ={4}" 
                                            };
            string connectstring = String.Format(m_ConnectStringModel[Convert.ToInt32(sidtype)], ip, port, sid, uid, pass);
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper(XMLDbHelper.DbHelperType.ORACLE, connectstring, true);
            return af.Connected();
        }

        public static DateTime GetDBDatetime(string ip, string port, string sidtype, string sid, string uid, string pass)
        {
            string[] m_ConnectStringModel = { 
                                                "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SID={2})));USER ID={3};PASSWORD ={4}", 
                                                "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SERVICE_NAME={2})));USER ID={3};PASSWORD ={4}" 
                                            };
            string connectstring = String.Format(m_ConnectStringModel[Convert.ToInt32(sidtype)], ip, port, sid, uid, pass);
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper(XMLDbHelper.DbHelperType.ORACLE, connectstring, true);
            return af.GetDbDatetimestamp();
        }

        public static string GetDBZFJ(string ip, string port, string sidtype, string sid, string uid, string pass)
        {
            string[] m_ConnectStringModel = { 
                                                "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SID={2})));USER ID={3};PASSWORD ={4}", 
                                                "DATA SOURCE =(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})) (CONNECT_DATA=(SERVICE_NAME={2})));USER ID={3};PASSWORD ={4}" 
                                            };
            string connectstring = String.Format(m_ConnectStringModel[Convert.ToInt32(sidtype)], ip, port, sid, uid, pass);
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper(XMLDbHelper.DbHelperType.ORACLE, connectstring, true);
            DataSet ds = af.GetNlsDatabaseParameters();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow[] drs = ds.Tables[0].Select("PARAMETER='NLS_CHARACTERSET'");
                if (drs.Length == 1)
                {
                    try
                    {
                        return drs[0]["VALUE"].ToString();
                    }
                    catch { }
                }
            }
            return "";
        }
    }
}
