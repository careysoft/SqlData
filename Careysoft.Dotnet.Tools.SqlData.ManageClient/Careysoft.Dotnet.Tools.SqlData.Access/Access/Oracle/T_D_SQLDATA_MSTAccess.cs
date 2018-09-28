using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;
using System.Data;
using System.Data.OracleClient;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle
{
    public class T_D_SQLDATA_MSTAccess : IT_D_SQLDATA_MSTAccess
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
        public int Add(T_D_SQLDATA_MSTModel model)
       {
           List<XMLDbHelper.Paramers> listParamters = new List<XMLDbHelper.Paramers>();
           XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
           DateTime sjc = af.GetDbDatetimestamp();
           StringBuilder sBuilder = new StringBuilder();
           sBuilder.Append("INSERT INTO T_D_SQLDATA_MST(");
           sBuilder.Append("ID,");
           sBuilder.Append("SJYID,");
           sBuilder.Append("SQLDATANAME,");
           sBuilder.Append("SQLDATADISCRIBE,");
           sBuilder.Append("SQL,");
           sBuilder.Append("SQLTYPE,");
           sBuilder.Append("CJR,");
           sBuilder.Append("CJSJ,");
           sBuilder.Append("XGR,");
           sBuilder.Append("XGSJ,");
           sBuilder.Append("SJC,");
           sBuilder.Append("SFSC,");
           sBuilder.Append("SFJY,");
           sBuilder.Append("UNITTYPEID");
           sBuilder.Append(") VALUES(");
           sBuilder.Append(":ID,");
           sBuilder.Append(":SJYID,");
           sBuilder.Append(":SQLDATANAME,");
           sBuilder.Append(":SQLDATADISCRIBE,");
           sBuilder.Append(":SQL,");
           sBuilder.Append(":SQLTYPE,");
           sBuilder.Append(":CJR,");
           sBuilder.Append(":CJSJ,");
           sBuilder.Append(":XGR,");
           sBuilder.Append(":XGSJ,");
           sBuilder.Append(":SJC,");
           sBuilder.Append(":SFSC,");
           sBuilder.Append(":SFJY,");
           sBuilder.Append(":UNITTYPEID");
           sBuilder.Append(")");
           OracleParameter[] oparams ={
             new OracleParameter(":ID",OracleType.VarChar),
             new OracleParameter(":SJYID",OracleType.VarChar),
             new OracleParameter(":SQLDATANAME",OracleType.VarChar),
             new OracleParameter(":SQLDATADISCRIBE",OracleType.VarChar),
             new OracleParameter(":SQL",OracleType.Clob),
             new OracleParameter(":SQLTYPE",OracleType.VarChar),
             new OracleParameter(":CJR",OracleType.VarChar),
             new OracleParameter(":CJSJ",OracleType.VarChar),
             new OracleParameter(":XGR",OracleType.VarChar),
             new OracleParameter(":XGSJ",OracleType.VarChar),
             new OracleParameter(":SJC",OracleType.VarChar), 
             new OracleParameter(":SFSC",OracleType.Number), 
             new OracleParameter(":SFJY",OracleType.Number), 
             new OracleParameter(":UNITTYPEID",OracleType.VarChar)
           };
           oparams[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_D_SQLDATA_MST");//model.ID;
           oparams[1].Value = model.SJYID;
           oparams[2].Value = model.SQLDATANAME;
           oparams[3].Value = model.SQLDATADISCRIBE;
           oparams[4].Value = model.SQL;
           oparams[5].Value = model.SQLTYPE;
           oparams[6].Value = model.CJR;
           oparams[7].Value = sjc.ToString("yyyyMMddHHmmss");//model.CJSJ;
           oparams[8].Value = model.XGR;
           oparams[9].Value = model.XGSJ;
           oparams[10].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC;
           oparams[11].Value = model.SFSC;
           oparams[12].Value = model.SFJY;
           oparams[13].Value = model.UNITTYPEID; 
           listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams));
           foreach (T_D_SQLDATA_SLVModel m in model.SLVList) {
               sBuilder.Remove(0, sBuilder.Length);
               sBuilder.Append("INSERT INTO T_D_SQLDATA_SLV(");
               sBuilder.Append("ID,");
               sBuilder.Append("MSTID,");
               sBuilder.Append("PARAMETERNAME,");
               sBuilder.Append("PARAMETERTYPE,");
               sBuilder.Append("PARAMETERDISC,");
               sBuilder.Append("DEFAULTVALUE,");
               sBuilder.Append("BL1,");
               sBuilder.Append("BL2,");
               sBuilder.Append("BL3,");
               sBuilder.Append("SJC");
               sBuilder.Append(") VALUES(");
               sBuilder.Append(":ID,");
               sBuilder.Append(":MSTID,");
               sBuilder.Append(":PARAMETERNAME,");
               sBuilder.Append(":PARAMETERTYPE,");
               sBuilder.Append(":PARAMETERDISC,");
               sBuilder.Append(":DEFAULTVALUE,");
               sBuilder.Append(":BL1,");
               sBuilder.Append(":BL2,");
               sBuilder.Append(":BL3,");
               sBuilder.Append(":SJC");
               sBuilder.Append(")");
               OracleParameter[] oparams1 ={
                 new OracleParameter(":ID",OracleType.VarChar),
                 new OracleParameter(":MSTID",OracleType.VarChar),
                 new OracleParameter(":PARAMETERNAME",OracleType.VarChar),
                 new OracleParameter(":PARAMETERTYPE",OracleType.VarChar),
                 new OracleParameter(":PARAMETERDISC",OracleType.VarChar),
                 new OracleParameter(":DEFAULTVALUE",OracleType.VarChar),
                 new OracleParameter(":BL1",OracleType.VarChar),
                 new OracleParameter(":BL2",OracleType.VarChar),
                 new OracleParameter(":BL3",OracleType.VarChar),
                 new OracleParameter(":SJC",OracleType.VarChar)
               };
               oparams1[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_D_SQLDATA_MST");//model.ID;
               oparams1[1].Value = oparams[0].Value;//model.MSTID;
               oparams1[2].Value = m.PARAMETERNAME;//model.PARAMETERNAME;
               oparams1[3].Value = m.PARAMETERTYPE;//model.PARAMETERTYPE;
               oparams1[4].Value = m.PARAMETERDISC;//model.PARAMETERDISC;
               oparams1[5].Value = m.DEFAULTVALUE;//model.DEFAULTVALUE;
               oparams1[6].Value = m.BL1;//model.BL1;
               oparams1[7].Value = m.BL2;//model.BL2;
               oparams1[8].Value = m.BL3;//model.BL3;
               oparams1[9].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC;
               listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams1));
           }
           int ret = af.ExecuteNonQueryTransactionNoZero(listParamters);
           return ret;
       }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_D_SQLDATA_MSTModel model)
        {
           List<XMLDbHelper.Paramers> listParamters = new List<XMLDbHelper.Paramers>();
           XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
           DateTime sjc = af.GetDbDatetimestamp();
           StringBuilder sBuilder = new StringBuilder();
           sBuilder.Append("UPDATE T_D_SQLDATA_MST SET ");
           sBuilder.Append("SJYID=:SJYID,");
           sBuilder.Append("SQLDATANAME=:SQLDATANAME,");
           sBuilder.Append("SQLDATADISCRIBE=:SQLDATADISCRIBE,");
           sBuilder.Append("SQL=:SQL,");
           sBuilder.Append("SQLTYPE=:SQLTYPE,");
           sBuilder.Append("CJR=:CJR,");
           sBuilder.Append("CJSJ=:CJSJ,");
           sBuilder.Append("XGR=:XGR,");
           sBuilder.Append("XGSJ=:XGSJ,");
           sBuilder.Append("SJC=:SJC,");
           sBuilder.Append("SFSC=:SFSC,");
           sBuilder.Append("SFJY=:SFJY,");
           sBuilder.Append("UNITTYPEID=:UNITTYPEID ");  
           sBuilder.Append("WHERE ID=:ID ");
           OracleParameter[] oparams ={
             new OracleParameter(":ID",OracleType.VarChar),
             new OracleParameter(":SJYID",OracleType.VarChar),
             new OracleParameter(":SQLDATANAME",OracleType.VarChar),
             new OracleParameter(":SQLDATADISCRIBE",OracleType.VarChar),
             new OracleParameter(":SQL",OracleType.Clob),
             new OracleParameter(":SQLTYPE",OracleType.VarChar),
             new OracleParameter(":CJR",OracleType.VarChar),
             new OracleParameter(":CJSJ",OracleType.VarChar),
             new OracleParameter(":XGR",OracleType.VarChar),
             new OracleParameter(":XGSJ",OracleType.VarChar),
             new OracleParameter(":SJC",OracleType.VarChar), 
             new OracleParameter(":SFSC",OracleType.Number), 
             new OracleParameter(":SFJY",OracleType.Number), 
             new OracleParameter(":UNITTYPEID",OracleType.VarChar)
           };
           oparams[0].Value = model.ID;
           oparams[1].Value = model.SJYID;
           oparams[2].Value = model.SQLDATANAME;
           oparams[3].Value = model.SQLDATADISCRIBE;
           oparams[4].Value = model.SQL;
           oparams[5].Value = model.SQLTYPE;
           oparams[6].Value = model.CJR;
           oparams[7].Value = model.CJSJ;
           oparams[8].Value = model.XGR;
           oparams[9].Value = sjc.ToString("yyyyMMddHHmmss");//model.XGSJ;
           oparams[10].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC;
           oparams[11].Value = model.SFSC;
           oparams[12].Value = model.SFJY;
           oparams[13].Value = model.UNITTYPEID; 
           listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams));

           foreach (T_D_SQLDATA_SLVModel m in model.SLVList)
           {
               if (String.IsNullOrEmpty(m.ID))
               {
                   sBuilder.Remove(0, sBuilder.Length);
                   sBuilder.Append("INSERT INTO T_D_SQLDATA_SLV(");
                   sBuilder.Append("ID,");
                   sBuilder.Append("MSTID,");
                   sBuilder.Append("PARAMETERNAME,");
                   sBuilder.Append("PARAMETERTYPE,");
                   sBuilder.Append("PARAMETERDISC,");
                   sBuilder.Append("DEFAULTVALUE,");
                   sBuilder.Append("BL1,");
                   sBuilder.Append("BL2,");
                   sBuilder.Append("BL3,");
                   sBuilder.Append("SJC");
                   sBuilder.Append(") VALUES(");
                   sBuilder.Append(":ID,");
                   sBuilder.Append(":MSTID,");
                   sBuilder.Append(":PARAMETERNAME,");
                   sBuilder.Append(":PARAMETERTYPE,");
                   sBuilder.Append(":PARAMETERDISC,");
                   sBuilder.Append(":DEFAULTVALUE,");
                   sBuilder.Append(":BL1,");
                   sBuilder.Append(":BL2,");
                   sBuilder.Append(":BL3,");
                   sBuilder.Append(":SJC");
                   sBuilder.Append(")");
                   OracleParameter[] oparams1 ={
                     new OracleParameter(":ID",OracleType.VarChar),
                     new OracleParameter(":MSTID",OracleType.VarChar),
                     new OracleParameter(":PARAMETERNAME",OracleType.VarChar),
                     new OracleParameter(":PARAMETERTYPE",OracleType.VarChar),
                     new OracleParameter(":PARAMETERDISC",OracleType.VarChar),
                     new OracleParameter(":DEFAULTVALUE",OracleType.VarChar),
                     new OracleParameter(":BL1",OracleType.VarChar),
                     new OracleParameter(":BL2",OracleType.VarChar),
                     new OracleParameter(":BL3",OracleType.VarChar),
                     new OracleParameter(":SJC",OracleType.VarChar)
                   };
                   oparams1[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_D_SQLDATA_MST");//model.ID;
                   oparams1[1].Value = oparams[0].Value;//model.MSTID;
                   oparams1[2].Value = m.PARAMETERNAME;//model.PARAMETERNAME;
                   oparams1[3].Value = m.PARAMETERTYPE;//model.PARAMETERTYPE;
                   oparams1[4].Value = m.PARAMETERDISC;//model.PARAMETERDISC;
                   oparams1[5].Value = m.DEFAULTVALUE;//model.DEFAULTVALUE;
                   oparams1[6].Value = m.BL1;//model.BL1;
                   oparams1[7].Value = m.BL2;//model.BL2;
                   oparams1[8].Value = m.BL3;//model.BL3;
                   oparams1[9].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC;
                   listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams1));
               }
               else {
                   if (m.SFSC == 1)
                   {
                       sBuilder.Remove(0, sBuilder.Length);
                       sBuilder.Append("DELETE FROM T_D_SQLDATA_SLV WHERE ID=:ID");
                       OracleParameter[] oparams2 ={
                         new OracleParameter(":ID",OracleType.VarChar)
                       };
                       oparams2[0].Value = m.ID;
                       listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams2));
                   }
                   else {
                       sBuilder.Remove(0, sBuilder.Length);
                       sBuilder.Append("UPDATE T_D_SQLDATA_SLV SET ");
                       sBuilder.Append("MSTID=:MSTID,");
                       sBuilder.Append("PARAMETERNAME=:PARAMETERNAME,");
                       sBuilder.Append("PARAMETERTYPE=:PARAMETERTYPE,");
                       sBuilder.Append("PARAMETERDISC=:PARAMETERDISC,");
                       sBuilder.Append("DEFAULTVALUE=:DEFAULTVALUE,");
                       sBuilder.Append("BL1=:BL1,");
                       sBuilder.Append("BL2=:BL2,");
                       sBuilder.Append("BL3=:BL3,");
                       sBuilder.Append("SJC=:SJC ");
                       sBuilder.Append("WHERE ID=:ID ");
                       OracleParameter[] oparams3 ={
                         new OracleParameter(":ID",OracleType.VarChar),
                         new OracleParameter(":MSTID",OracleType.VarChar),
                         new OracleParameter(":PARAMETERNAME",OracleType.VarChar),
                         new OracleParameter(":PARAMETERTYPE",OracleType.VarChar),
                         new OracleParameter(":PARAMETERDISC",OracleType.VarChar),
                         new OracleParameter(":DEFAULTVALUE",OracleType.VarChar),
                         new OracleParameter(":BL1",OracleType.VarChar),
                         new OracleParameter(":BL2",OracleType.VarChar),
                         new OracleParameter(":BL3",OracleType.VarChar),
                         new OracleParameter(":SJC",OracleType.VarChar)
                       };
                       oparams3[0].Value = m.ID;
                       oparams3[1].Value = m.MSTID;
                       oparams3[2].Value = m.PARAMETERNAME;
                       oparams3[3].Value = m.PARAMETERTYPE;
                       oparams3[4].Value = m.PARAMETERDISC;
                       oparams3[5].Value = m.DEFAULTVALUE;
                       oparams3[6].Value = m.BL1;
                       oparams3[7].Value = m.BL2;
                       oparams3[8].Value = m.BL3;
                       oparams3[9].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//m.SJC;
                       listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams3));
                   }
               }
           }
           int ret = af.ExecuteNonQueryTransaction(listParamters);
           return ret;
       }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("DELETE FROM T_D_SQLDATA_MST ");
            sBuilder.Append("WHERE ID=:ID ");
            OracleParameter[] oparams ={
         new OracleParameter(":ID",OracleType.VarChar)
       };
            oparams[0].Value = id;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            int ret = af.ExecuteNonQuery(sBuilder.ToString(), oparams);
            return ret;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_D_SQLDATA_MSTModel Query(string id)
        {
            T_D_SQLDATA_MSTModel model = new T_D_SQLDATA_MSTModel();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.ID,");
            sBuilder.Append("T.SJYID,");
            sBuilder.Append("T2.PZMC SJYMC,");
            sBuilder.Append("T.SQLDATANAME,");
            sBuilder.Append("T.SQLDATADISCRIBE,");
            sBuilder.Append("T.SQL,");
            sBuilder.Append("T.SQLTYPE,");
            sBuilder.Append("T.CJR,");
            sBuilder.Append("T.CJSJ,");
            sBuilder.Append("T.XGR,");
            sBuilder.Append("T.XGSJ,");
            sBuilder.Append("T.SJC,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.SFJY,");
            sBuilder.Append("T.UNITTYPEID,");
            sBuilder.Append("T3.LXMC UNITTYPENAME ");
            sBuilder.Append("FROM T_D_SQLDATA_MST T ");
            sBuilder.Append("LEFT JOIN T_BASE_SJYPZ T2 ON T.SJYID=T2.PZBM ");
            sBuilder.Append("LEFT JOIN T_BASE_UNITTYPE T3 ON T.UNITTYPEID=T3.LXBM ");
            sBuilder.Append("WHERE T.ID=:ID ");
            OracleParameter[] oparams ={
             new OracleParameter(":ID",OracleType.VarChar)
           };
            oparams[0].Value = id;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DataSet ds = af.Query(sBuilder.ToString(), oparams);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                model.ID = ToString(dr["ID"]);
                model.SJYID = ToString(dr["SJYID"]);
                model.SQLDATANAME = ToString(dr["SQLDATANAME"]);
                model.SQLDATADISCRIBE = ToString(dr["SQLDATADISCRIBE"]);
                model.SQL = ToString(dr["SQL"]);
                model.SQLTYPE = ToString(dr["SQLTYPE"]);
                model.CJR = ToString(dr["CJR"]);
                model.CJSJ = ToString(dr["CJSJ"]);
                model.XGR = ToString(dr["XGR"]);
                model.XGSJ = ToString(dr["XGSJ"]);
                model.SJC = ToString(dr["SJC"]);
                model.SFSC = ToInt(dr["SFSC"]);
                model.SFJY = ToInt(dr["SFJY"]);
                model.UNITTYPEID = ToString(dr["UNITTYPEID"]);
                model.SJYMC = ToString(dr["SJYMC"]);
                model.UNITTYPENAME = ToString(dr["UNITTYPENAME"]);
                model.SLVList = QuerySlvList(id);
            }
            return model;
        }

        public List<T_D_SQLDATA_SLVModel> QuerySlvList(string mstid)
        {

            List<T_D_SQLDATA_SLVModel> models = new List<T_D_SQLDATA_SLVModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.ID,");
            sBuilder.Append("T.MSTID,");
            sBuilder.Append("T.PARAMETERNAME,");
            sBuilder.Append("T.PARAMETERTYPE,");
            sBuilder.Append("T.PARAMETERDISC,");
            sBuilder.Append("T.DEFAULTVALUE,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3,");
            sBuilder.Append("T.SJC ");
            sBuilder.Append("FROM T_D_SQLDATA_SLV T ");
            sBuilder.Append("WHERE T.MSTID=:MSTID ");
            OracleParameter[] oparams ={
             new OracleParameter(":MSTID",OracleType.VarChar)
           };
            oparams[0].Value = mstid;
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DataSet ds = af.Query(sBuilder.ToString(), oparams);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    T_D_SQLDATA_SLVModel model = new T_D_SQLDATA_SLVModel();
                    model.ID = ToString(dr["ID"]);
                    model.MSTID = ToString(dr["MSTID"]);
                    model.PARAMETERNAME = ToString(dr["PARAMETERNAME"]);
                    model.PARAMETERTYPE = ToString(dr["PARAMETERTYPE"]);
                    model.PARAMETERDISC = ToString(dr["PARAMETERDISC"]);
                    model.DEFAULTVALUE = ToString(dr["DEFAULTVALUE"]);
                    model.BL1 = ToString(dr["BL1"]);
                    model.BL2 = ToString(dr["BL2"]);
                    model.BL3 = ToString(dr["BL3"]);
                    model.SJC = ToString(dr["SJC"]);
                    models.Add(model);
                }
            }
            return models;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T_D_SQLDATA_MSTModel> QueryList(string swhere, string orders)
        {
            List<T_D_SQLDATA_MSTModel> models = new List<T_D_SQLDATA_MSTModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.ID,");
            sBuilder.Append("T.SJYID,");
            sBuilder.Append("T2.PZMC SJYMC,");
            sBuilder.Append("T.SQLDATANAME,");
            sBuilder.Append("T.SQLDATADISCRIBE,");
            sBuilder.Append("T.SQL,");
            sBuilder.Append("T.SQLTYPE,");
            sBuilder.Append("T.CJR,");
            sBuilder.Append("T.CJSJ,");
            sBuilder.Append("T.XGR,");
            sBuilder.Append("T.XGSJ,");
            sBuilder.Append("T.SJC,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.SFJY,");
            sBuilder.Append("T.UNITTYPEID,");
            sBuilder.Append("T3.LXMC UNITTYPENAME ");
            sBuilder.Append("FROM T_D_SQLDATA_MST T ");
            sBuilder.Append("LEFT JOIN T_BASE_SJYPZ T2 ON T.SJYID=T2.PZBM ");
            sBuilder.Append("LEFT JOIN T_BASE_UNITTYPE T3 ON T.UNITTYPEID=T3.LXBM ");
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
                    T_D_SQLDATA_MSTModel model = new T_D_SQLDATA_MSTModel();
                    model.ID = ToString(dr["ID"]);
                    model.SJYID = ToString(dr["SJYID"]);
                    model.SQLDATANAME = ToString(dr["SQLDATANAME"]);
                    model.SQLDATADISCRIBE = ToString(dr["SQLDATADISCRIBE"]);
                    model.SQL = ToString(dr["SQL"]);
                    model.SQLTYPE = ToString(dr["SQLTYPE"]);
                    model.CJR = ToString(dr["CJR"]);
                    model.CJSJ = ToString(dr["CJSJ"]);
                    model.XGR = ToString(dr["XGR"]);
                    model.XGSJ = ToString(dr["XGSJ"]);
                    model.SJC = ToString(dr["SJC"]);
                    model.SFSC = ToInt(dr["SFSC"]);
                    model.SFJY = ToInt(dr["SFJY"]);
                    model.UNITTYPEID = ToString(dr["UNITTYPEID"]);
                    model.SJYMC = ToString(dr["SJYMC"]);
                    model.UNITTYPENAME = ToString(dr["UNITTYPENAME"]);
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
