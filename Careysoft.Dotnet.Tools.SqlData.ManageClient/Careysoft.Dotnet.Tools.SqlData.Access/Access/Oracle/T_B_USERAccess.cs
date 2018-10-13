using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Careysoft.Dotnet.Tools.SqlData.Model;
using System.Data.OracleClient;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle
{
    public class T_B_USERAccess : IT_B_USERAccess
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
        public int Add(T_B_USERModel model)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("INSERT INTO T_B_USER(");
            sBuilder.Append("USERNAME,");
            sBuilder.Append("PASSWORD,");
            sBuilder.Append("XM,");
            sBuilder.Append("USERTYPE,");
            sBuilder.Append("SFJY,");
            sBuilder.Append("BL1,");
            sBuilder.Append("BL2,");
            sBuilder.Append("BL3");
            sBuilder.Append(") VALUES(");
            sBuilder.Append(":USERNAME,");
            sBuilder.Append(":PASSWORD,");
            sBuilder.Append(":XM,");
            sBuilder.Append(":USERTYPE,");
            sBuilder.Append(":SFJY,");
            sBuilder.Append(":BL1,");
            sBuilder.Append(":BL2,");
            sBuilder.Append(":BL3");
            sBuilder.Append(")");
            OracleParameter[] oparams ={
         new OracleParameter(":USERNAME",OracleType.VarChar),
         new OracleParameter(":PASSWORD",OracleType.VarChar),
         new OracleParameter(":XM",OracleType.VarChar),
         new OracleParameter(":USERTYPE",OracleType.VarChar),
         new OracleParameter(":SFJY",OracleType.Number),
         new OracleParameter(":BL1",OracleType.VarChar),
         new OracleParameter(":BL2",OracleType.VarChar),
         new OracleParameter(":BL3",OracleType.VarChar)
       };
            oparams[0].Value = model.USERNAME;
            oparams[1].Value = model.PASSWORD;
            oparams[2].Value = model.XM;
            oparams[3].Value = model.USERTYPE;
            oparams[4].Value = model.SFJY;
            oparams[5].Value = model.BL1;
            oparams[6].Value = model.BL2;
            oparams[7].Value = model.BL3;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_B_USERModel model)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("UPDATE T_B_USER SET ");
            sBuilder.Append("PASSWORD=:PASSWORD,");
            sBuilder.Append("XM=:XM,");
            sBuilder.Append("USERTYPE=:USERTYPE,");
            sBuilder.Append("SFJY=:SFJY,");
            sBuilder.Append("BL1=:BL1,");
            sBuilder.Append("BL2=:BL2,");
            sBuilder.Append("BL3=:BL3 ");
            sBuilder.Append("WHERE USERNAME=:USERNAME ");
            OracleParameter[] oparams ={
         new OracleParameter(":USERNAME",OracleType.VarChar),
         new OracleParameter(":PASSWORD",OracleType.VarChar),
         new OracleParameter(":XM",OracleType.VarChar),
         new OracleParameter(":USERTYPE",OracleType.VarChar),
         new OracleParameter(":SFJY",OracleType.Number),
         new OracleParameter(":BL1",OracleType.VarChar),
         new OracleParameter(":BL2",OracleType.VarChar),
         new OracleParameter(":BL3",OracleType.VarChar)
       };
            oparams[0].Value = model.USERNAME;
            oparams[1].Value = model.PASSWORD;
            oparams[2].Value = model.XM;
            oparams[3].Value = model.USERTYPE;
            oparams[4].Value = model.SFJY;
            oparams[5].Value = model.BL1;
            oparams[6].Value = model.BL2;
            oparams[7].Value = model.BL3;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int Delete(string username)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("DELETE FROM T_B_USER ");
            sBuilder.Append("WHERE USERNAME=:USERNAME ");
            OracleParameter[] oparams ={
         new OracleParameter(":USERNAME",OracleType.VarChar)
       };
            oparams[0].Value = username;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public T_B_USERModel Query(string username)
        {
            T_B_USERModel model = new T_B_USERModel();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.USERNAME,");
            sBuilder.Append("T.PASSWORD,");
            sBuilder.Append("T.XM,");
            sBuilder.Append("T.USERTYPE,");
            sBuilder.Append("T.SFJY,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3 ");
            sBuilder.Append("FROM T_B_USER T ");
            sBuilder.Append("WHERE T.USERNAME=:USERNAME ");
            OracleParameter[] oparams ={
         new OracleParameter(":USERNAME",OracleType.VarChar)
       };
            oparams[0].Value = username;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DataSet ds = af.Query(sBuilder.ToString(), oparams);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                model.USERNAME = ToString(dr["USERNAME"]);
                model.PASSWORD = ToString(dr["PASSWORD"]);
                model.XM = ToString(dr["XM"]);
                model.USERTYPE = ToString(dr["USERTYPE"]);
                model.SFJY = ToInt(dr["SFJY"]);
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
        public List<T_B_USERModel> QueryList(string swhere, string orders)
        {
            List<T_B_USERModel> models = new List<T_B_USERModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.USERNAME,");
            sBuilder.Append("T.PASSWORD,");
            sBuilder.Append("T.XM,");
            sBuilder.Append("T.USERTYPE,");
            sBuilder.Append("T.SFJY,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3 ");
            sBuilder.Append("FROM T_B_USER T ");
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
                    T_B_USERModel model = new T_B_USERModel();
                    model.USERNAME = ToString(dr["USERNAME"]);
                    model.PASSWORD = ToString(dr["PASSWORD"]);
                    model.XM = ToString(dr["XM"]);
                    model.USERTYPE = ToString(dr["USERTYPE"]);
                    model.SFJY = ToInt(dr["SFJY"]);
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
