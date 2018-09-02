using System;
using System.Collections.Generic;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;
using System.Data;
using System.Data.OracleClient;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle
{
    public class T_BASE_SJYPZAccess : IT_BASE_SJYPZAccess
    {
        /// <summary>
        /// 转换整型
        /// </summary>
        private int ToInt(object o)
        {
            try
            {
                return Convert.ToInt32(o.ToString());
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 转换货币类型
        /// </summary>
        private decimal ToDecimal(object o)
        {
            try
            {
                return Convert.ToDecimal(o.ToString());
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 转换字符型
        /// </summary>
        private string ToString(object o)
        {
            try
            {
                return o.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 转换布尔型
        /// </summary>
        private Boolean ToBoolean(object o)
        {
            try
            {
                if (o.ToString() == "0")
                {
                    return false;
                }
                if (o.ToString() == "1")
                {
                    return true;
                }
                return Convert.ToBoolean(o.ToString());
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 转换时间型
        /// </summary>
        private DateTime ToDateTime(object o)
        {
            try
            {
                if (o == null || o == DBNull.Value)
                {
                    return Convert.ToDateTime("0000-00-00");
                }
                return Convert.ToDateTime(o);
            }
            catch
            {
                return Convert.ToDateTime("0000-00-00");
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T_BASE_SJYPZModel model)
        {
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();

            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("INSERT INTO T_BASE_SJYPZ(");
            sBuilder.Append("PZBM,");
            sBuilder.Append("PZMC,");
            sBuilder.Append("SJIP,");
            sBuilder.Append("SJPORT,");
            sBuilder.Append("SJSID,");
            sBuilder.Append("SJUSERID,");
            sBuilder.Append("SJPASSWORD,");
            sBuilder.Append("SFSC,");
            sBuilder.Append("BL1,");
            sBuilder.Append("BL2,");
            sBuilder.Append("BL3");
            sBuilder.Append(") VALUES(");
            sBuilder.Append(":PZBM,");
            sBuilder.Append(":PZMC,");
            sBuilder.Append(":SJIP,");
            sBuilder.Append(":SJPORT,");
            sBuilder.Append(":SJSID,");
            sBuilder.Append(":SJUSERID,");
            sBuilder.Append(":SJPASSWORD,");
            sBuilder.Append(":SFSC,");
            sBuilder.Append(":BL1,");
            sBuilder.Append(":BL2,");
            sBuilder.Append(":BL3");
            sBuilder.Append(")");
            OracleParameter[] oparams ={
         new OracleParameter(":PZBM",OracleType.VarChar),
         new OracleParameter(":PZMC",OracleType.VarChar),
         new OracleParameter(":SJIP",OracleType.VarChar),
         new OracleParameter(":SJPORT",OracleType.VarChar),
         new OracleParameter(":SJSID",OracleType.VarChar),
         new OracleParameter(":SJUSERID",OracleType.VarChar),
         new OracleParameter(":SJPASSWORD",OracleType.VarChar),
         new OracleParameter(":SFSC",OracleType.Number),
         new OracleParameter(":BL1",OracleType.VarChar),
         new OracleParameter(":BL2",OracleType.VarChar),
         new OracleParameter(":BL3",OracleType.VarChar)
       };
            oparams[0].Value = af.GetID("ELANESJY", "T_BASE_SJYPZ");//model.PZBM;
            oparams[1].Value = model.PZMC;
            oparams[2].Value = model.SJIP;
            oparams[3].Value = model.SJPORT;
            oparams[4].Value = model.SJSID;
            oparams[5].Value = model.SJUSERID;
            oparams[6].Value = model.SJPASSWORD;
            oparams[7].Value = model.SFSC;
            oparams[8].Value = model.BL1;
            oparams[9].Value = model.BL2;
            oparams[10].Value = model.BL3;
            
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_BASE_SJYPZModel model)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("UPDATE T_BASE_SJYPZ SET ");
            sBuilder.Append("PZMC=:PZMC,");
            sBuilder.Append("SJIP=:SJIP,");
            sBuilder.Append("SJPORT=:SJPORT,");
            sBuilder.Append("SJSID=:SJSID,");
            sBuilder.Append("SJUSERID=:SJUSERID,");
            sBuilder.Append("SJPASSWORD=:SJPASSWORD,");
            sBuilder.Append("SFSC=:SFSC,");
            sBuilder.Append("BL1=:BL1,");
            sBuilder.Append("BL2=:BL2,");
            sBuilder.Append("BL3=:BL3 ");
            sBuilder.Append("WHERE PZBM=:PZBM ");
            OracleParameter[] oparams ={
         new OracleParameter(":PZBM",OracleType.VarChar),
         new OracleParameter(":PZMC",OracleType.VarChar),
         new OracleParameter(":SJIP",OracleType.VarChar),
         new OracleParameter(":SJPORT",OracleType.VarChar),
         new OracleParameter(":SJSID",OracleType.VarChar),
         new OracleParameter(":SJUSERID",OracleType.VarChar),
         new OracleParameter(":SJPASSWORD",OracleType.VarChar),
         new OracleParameter(":SFSC",OracleType.Number),
         new OracleParameter(":BL1",OracleType.VarChar),
         new OracleParameter(":BL2",OracleType.VarChar),
         new OracleParameter(":BL3",OracleType.VarChar)
       };
            oparams[0].Value = model.PZBM;
            oparams[1].Value = model.PZMC;
            oparams[2].Value = model.SJIP;
            oparams[3].Value = model.SJPORT;
            oparams[4].Value = model.SJSID;
            oparams[5].Value = model.SJUSERID;
            oparams[6].Value = model.SJPASSWORD;
            oparams[7].Value = model.SFSC;
            oparams[8].Value = model.BL1;
            oparams[9].Value = model.BL2;
            oparams[10].Value = model.BL3;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pzbm"></param>
        /// <returns></returns>
        public int Delete(string pzbm)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("DELETE FROM T_BASE_SJYPZ ");
            sBuilder.Append("WHERE PZBM=:PZBM ");
            OracleParameter[] oparams ={
         new OracleParameter(":PZBM",OracleType.VarChar)
       };
            oparams[0].Value = pzbm;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pzbm"></param>
        /// <returns></returns>
        public T_BASE_SJYPZModel Query(string pzbm)
        {
            T_BASE_SJYPZModel model = new T_BASE_SJYPZModel();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.PZBM,");
            sBuilder.Append("T.PZMC,");
            sBuilder.Append("T.SJIP,");
            sBuilder.Append("T.SJPORT,");
            sBuilder.Append("T.SJSID,");
            sBuilder.Append("T.SJUSERID,");
            sBuilder.Append("T.SJPASSWORD,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3 ");
            sBuilder.Append("FROM T_BASE_SJYPZ  T ");
            sBuilder.Append("WHERE T.PZBM=:PZBM ");
            OracleParameter[] oparams ={
         new OracleParameter(":PZBM",OracleType.VarChar)
       };
            oparams[0].Value = pzbm;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DataSet ds = af.Query(sBuilder.ToString(), oparams);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                model.PZBM = ToString(dr["PZBM"]);
                model.PZMC = ToString(dr["PZMC"]);
                model.SJIP = ToString(dr["SJIP"]);
                model.SJPORT = ToString(dr["SJPORT"]);
                model.SJSID = ToString(dr["SJSID"]);
                model.SJUSERID = ToString(dr["SJUSERID"]);
                model.SJPASSWORD = ToString(dr["SJPASSWORD"]);
                model.SFSC = ToInt(dr["SFSC"]);
                model.BL1 = ToString(dr["BL1"]);
                model.BL2 = ToString(dr["BL2"]);
                model.BL3 = ToString(dr["BL3"]);
            }
            return model;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T_BASE_SJYPZModel> QueryList(string swhere, string orders)
        {
            List<T_BASE_SJYPZModel> models = new List<T_BASE_SJYPZModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.PZBM,");
            sBuilder.Append("T.PZMC,");
            sBuilder.Append("T.SJIP,");
            sBuilder.Append("T.SJPORT,");
            sBuilder.Append("T.SJSID,");
            sBuilder.Append("T.SJUSERID,");
            sBuilder.Append("T.SJPASSWORD,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3 ");
            sBuilder.Append("FROM T_BASE_SJYPZ  T ");
            if (!String.IsNullOrEmpty(swhere))
            {
                sBuilder.Append(String.Format("WHERE {0} ", swhere));
            }
            if (!String.IsNullOrEmpty(orders))
            {
                sBuilder.Append(String.Format("ORDER BY {0} ", orders));
            }
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DataSet ds = af.Query(sBuilder.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    T_BASE_SJYPZModel model = new T_BASE_SJYPZModel();
                    model.PZBM = ToString(dr["PZBM"]);
                    model.PZMC = ToString(dr["PZMC"]);
                    model.SJIP = ToString(dr["SJIP"]);
                    model.SJPORT = ToString(dr["SJPORT"]);
                    model.SJSID = ToString(dr["SJSID"]);
                    model.SJUSERID = ToString(dr["SJUSERID"]);
                    model.SJPASSWORD = ToString(dr["SJPASSWORD"]);
                    model.SFSC = ToInt(dr["SFSC"]);
                    model.BL1 = ToString(dr["BL1"]);
                    model.BL2 = ToString(dr["BL2"]);
                    model.BL3 = ToString(dr["BL3"]);
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
