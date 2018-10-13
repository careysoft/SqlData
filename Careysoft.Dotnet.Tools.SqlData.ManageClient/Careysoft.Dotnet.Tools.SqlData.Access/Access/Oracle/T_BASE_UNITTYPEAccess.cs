using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Careysoft.Dotnet.Tools.SqlData.Model;
using System.Data.OracleClient;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle
{
    public class T_BASE_UNITTYPEAccess : IT_BASE_UNITTYPEAccess
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
        public int Add(T_BASE_UNITTYPEModel model)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("INSERT INTO T_BASE_UNITTYPE(");
            sBuilder.Append("LXBM,");
            sBuilder.Append("LXMC,");
            sBuilder.Append("FLXBM,"); 
            sBuilder.Append("SFSC,");
            sBuilder.Append("BL1,");
            sBuilder.Append("BL2,");
            sBuilder.Append("BL3,");
            sBuilder.Append("CJR,");
            sBuilder.Append("CJSJ,");
            sBuilder.Append("XGR,");
            sBuilder.Append("XGSJ,");
            sBuilder.Append("SJC");
            sBuilder.Append(") VALUES(");
            sBuilder.Append(":LXBM,");
            sBuilder.Append(":LXMC,");
            sBuilder.Append(":FLXBM,"); 
            sBuilder.Append(":SFSC,");
            sBuilder.Append(":BL1,");
            sBuilder.Append(":BL2,");
            sBuilder.Append(":BL3,");
            sBuilder.Append(":CJR,");
            sBuilder.Append(":CJSJ,");
            sBuilder.Append(":XGR,");
            sBuilder.Append(":XGSJ,");
            sBuilder.Append(":SJC");
            sBuilder.Append(")");
            OracleParameter[] oparams ={
             new OracleParameter(":LXBM",OracleType.VarChar),
             new OracleParameter(":LXMC",OracleType.VarChar),
             new OracleParameter(":SFSC",OracleType.Number),
             new OracleParameter(":BL1",OracleType.VarChar),
             new OracleParameter(":BL2",OracleType.VarChar),
             new OracleParameter(":BL3",OracleType.VarChar),
             new OracleParameter(":CJR",OracleType.VarChar),
             new OracleParameter(":CJSJ",OracleType.VarChar),
             new OracleParameter(":XGR",OracleType.VarChar),
             new OracleParameter(":XGSJ",OracleType.VarChar),
             new OracleParameter(":SJC",OracleType.VarChar), 
             new OracleParameter(":FLXBM",OracleType.VarChar)
           };
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DateTime sjc = af.GetDbDatetimestamp();
            oparams[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_BASE_UNITTYPE");//model.LXBM;
            oparams[1].Value = model.LXMC;
            oparams[2].Value = model.SFSC;
            oparams[3].Value = model.BL1;
            oparams[4].Value = model.BL2;
            oparams[5].Value = model.BL3;
            oparams[6].Value = model.CJR;
            oparams[7].Value = sjc.ToString("yyyyMMddHHmmss");// model.CJSJ;
            oparams[8].Value = model.XGR;
            oparams[9].Value = model.XGSJ;
            oparams[10].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC; 
            oparams[11].Value = model.FLXBM;//model.SJC; 
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_BASE_UNITTYPEModel model)
        {
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DateTime sjc = af.GetDbDatetimestamp();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("UPDATE T_BASE_UNITTYPE SET ");
            sBuilder.Append("LXMC=:LXMC,");
            sBuilder.Append("FLXBM=:FLXBM,"); 
            sBuilder.Append("SFSC=:SFSC,");
            sBuilder.Append("BL1=:BL1,");
            sBuilder.Append("BL2=:BL2,");
            sBuilder.Append("BL3=:BL3,");
            sBuilder.Append("CJR=:CJR,");
            sBuilder.Append("CJSJ=:CJSJ,");
            sBuilder.Append("XGR=:XGR,");
            sBuilder.Append("XGSJ=:XGSJ,");
            sBuilder.Append("SJC=:SJC ");
            sBuilder.Append("WHERE LXBM=:LXBM ");
            OracleParameter[] oparams ={
             new OracleParameter(":LXBM",OracleType.VarChar),
             new OracleParameter(":LXMC",OracleType.VarChar),
             new OracleParameter(":SFSC",OracleType.Number),
             new OracleParameter(":BL1",OracleType.VarChar),
             new OracleParameter(":BL2",OracleType.VarChar),
             new OracleParameter(":BL3",OracleType.VarChar),
             new OracleParameter(":CJR",OracleType.VarChar),
             new OracleParameter(":CJSJ",OracleType.VarChar),
             new OracleParameter(":XGR",OracleType.VarChar),
             new OracleParameter(":XGSJ",OracleType.VarChar),
             new OracleParameter(":SJC",OracleType.VarChar), 
             new OracleParameter(":FLXBM",OracleType.VarChar)
           };
            oparams[0].Value = model.LXBM;
            oparams[1].Value = model.LXMC;
            oparams[2].Value = model.SFSC;
            oparams[3].Value = model.BL1;
            oparams[4].Value = model.BL2;
            oparams[5].Value = model.BL3;
            oparams[6].Value = model.CJR;
            oparams[7].Value = model.CJSJ;
            oparams[8].Value = model.XGR;
            oparams[9].Value = sjc.ToString("yyyyMMddHHmmss");//model.XGSJ;
            oparams[10].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC 
            oparams[11].Value = model.FLXBM;//model.SJC; 
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lxbm"></param>
        /// <returns></returns>
        public int Delete(string lxbm)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("DELETE FROM T_BASE_UNITTYPE ");
            sBuilder.Append("WHERE LXBM=:LXBM ");
            OracleParameter[] oparams ={
         new OracleParameter(":LXBM",OracleType.VarChar)
       };
            oparams[0].Value = lxbm;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="lxbm"></param>
        /// <returns></returns>
        public T_BASE_UNITTYPEModel Query(string lxbm)
        {
            T_BASE_UNITTYPEModel model = new T_BASE_UNITTYPEModel();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.LXBM,");
            sBuilder.Append("T.FLXBM,"); 
            sBuilder.Append("T.LXMC,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3,");
            sBuilder.Append("T.CJR,");
            sBuilder.Append("T.CJSJ,");
            sBuilder.Append("T.XGR,");
            sBuilder.Append("T.XGSJ,");
            sBuilder.Append("T.SJC ");
            sBuilder.Append("FROM T_BASE_UNITTYPE T ");
            sBuilder.Append("WHERE T.LXBM=:LXBM ");
            OracleParameter[] oparams ={
             new OracleParameter(":LXBM",OracleType.VarChar)
           };
            oparams[0].Value = lxbm;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DataSet ds = af.Query(sBuilder.ToString(), oparams);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                model.LXBM = ToString(dr["LXBM"]);
                model.FLXBM = ToString(dr["FLXBM"]); 
                model.LXMC = ToString(dr["LXMC"]);
                model.SFSC = ToInt(dr["SFSC"]);
                model.BL1 = ToString(dr["BL1"]);
                model.BL2 = ToString(dr["BL2"]);
                model.BL3 = ToString(dr["BL3"]);
                model.CJR = ToString(dr["CJR"]);
                model.CJSJ = ToString(dr["CJSJ"]);
                model.XGR = ToString(dr["XGR"]);
                model.XGSJ = ToString(dr["XGSJ"]);
                model.SJC = ToString(dr["SJC"]);
            }
            return model;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T_BASE_UNITTYPEModel> QueryList(string swhere, string orders)
        {
            List<T_BASE_UNITTYPEModel> models = new List<T_BASE_UNITTYPEModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.LXBM,");
            sBuilder.Append("T.FLXBM,"); 
            sBuilder.Append("T.LXMC,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3,");
            sBuilder.Append("T.CJR,");
            sBuilder.Append("T.CJSJ,");
            sBuilder.Append("T.XGR,");
            sBuilder.Append("T.XGSJ,");
            sBuilder.Append("T.SJC ");
            sBuilder.Append("FROM T_BASE_UNITTYPE T ");
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
                    T_BASE_UNITTYPEModel model = new T_BASE_UNITTYPEModel();
                    model.LXBM = ToString(dr["LXBM"]);
                    model.FLXBM = ToString(dr["FLXBM"]); 
                    model.LXMC = ToString(dr["LXMC"]);
                    model.SFSC = ToInt(dr["SFSC"]);
                    model.BL1 = ToString(dr["BL1"]);
                    model.BL2 = ToString(dr["BL2"]);
                    model.BL3 = ToString(dr["BL3"]);
                    model.CJR = ToString(dr["CJR"]);
                    model.CJSJ = ToString(dr["CJSJ"]);
                    model.XGR = ToString(dr["XGR"]);
                    model.XGSJ = ToString(dr["XGSJ"]);
                    model.SJC = ToString(dr["SJC"]);
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
