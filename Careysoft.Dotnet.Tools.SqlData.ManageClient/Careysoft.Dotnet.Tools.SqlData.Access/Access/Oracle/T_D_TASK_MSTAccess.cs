using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Tools.SqlData.Model;
using System.Data;
using System.Data.OracleClient;

namespace Careysoft.Dotnet.Tools.SqlData.Access.Access.Oracle
{
    public class T_D_TASK_MSTAccess : IT_D_TASK_MSTAccess
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
        public int Add(T_D_TASK_MSTModel model)
        {
            List<XMLDbHelper.Paramers> listParamters = new List<XMLDbHelper.Paramers>();
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DateTime sjc = af.GetDbDatetimestamp();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("INSERT INTO T_D_TASK_MST(");
            sBuilder.Append("ID,");
            sBuilder.Append("TASKNAME,");
            sBuilder.Append("TASKNUMBER,");
            sBuilder.Append("TASKDONUMBER,");
            sBuilder.Append("BEGINDATETIME,");
            sBuilder.Append("LASTDATETIME,");
            sBuilder.Append("INTERVAL,");
            sBuilder.Append("INTERVALTYPE,");
            sBuilder.Append("SFSC,");
            sBuilder.Append("SFJY,");
            sBuilder.Append("CJR,");
            sBuilder.Append("CJSJ,");
            sBuilder.Append("XGR,");
            sBuilder.Append("XGSJ,");
            sBuilder.Append("SJC,");
            sBuilder.Append("TASKDISCRIBE");
            sBuilder.Append(") VALUES(");
            sBuilder.Append(":ID,");
            sBuilder.Append(":TASKNAME,");
            sBuilder.Append(":TASKNUMBER,");
            sBuilder.Append(":TASKDONUMBER,");
            sBuilder.Append(":BEGINDATETIME,");
            sBuilder.Append(":LASTDATETIME,");
            sBuilder.Append(":INTERVAL,");
            sBuilder.Append(":INTERVALTYPE,");
            sBuilder.Append(":SFSC,");
            sBuilder.Append(":SFJY,");
            sBuilder.Append(":CJR,");
            sBuilder.Append(":CJSJ,");
            sBuilder.Append(":XGR,");
            sBuilder.Append(":XGSJ,");
            sBuilder.Append(":SJC,");
            sBuilder.Append(":TASKDISCRIBE");
            sBuilder.Append(")");
            OracleParameter[] oparams ={
             new OracleParameter(":ID",OracleType.VarChar),
             new OracleParameter(":TASKNAME",OracleType.VarChar),
             new OracleParameter(":TASKNUMBER",OracleType.Number),
             new OracleParameter(":TASKDONUMBER",OracleType.Number),
             new OracleParameter(":BEGINDATETIME",OracleType.VarChar),
             new OracleParameter(":LASTDATETIME",OracleType.VarChar),
             new OracleParameter(":INTERVAL",OracleType.Number),
             new OracleParameter(":INTERVALTYPE",OracleType.VarChar),
             new OracleParameter(":SFSC",OracleType.Number),
             new OracleParameter(":SFJY",OracleType.Number),
             new OracleParameter(":CJR",OracleType.VarChar),
             new OracleParameter(":CJSJ",OracleType.VarChar),
             new OracleParameter(":XGR",OracleType.VarChar),
             new OracleParameter(":XGSJ",OracleType.VarChar),
             new OracleParameter(":SJC",OracleType.VarChar),
             new OracleParameter(":TASKDISCRIBE",OracleType.VarChar)
           };
            oparams[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_D_TASK_MST");//model.ID;
            oparams[1].Value = model.TASKNAME;
            oparams[2].Value = model.TASKNUMBER;
            oparams[3].Value = model.TASKDONUMBER;
            oparams[4].Value = model.BEGINDATETIME;
            oparams[5].Value = model.LASTDATETIME;
            oparams[6].Value = model.INTERVAL;
            oparams[7].Value = model.INTERVALTYPE;
            oparams[8].Value = model.SFSC;
            oparams[9].Value = model.SFJY;
            oparams[10].Value = model.CJR;
            oparams[11].Value = sjc.ToString("yyyyMMddHHmmss");//model.CJSJ;
            oparams[12].Value = model.XGR;
            oparams[13].Value = model.XGSJ;
            oparams[14].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC;
            oparams[15].Value = model.TASKDISCRIBE;
            listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams));
            foreach (Model.T_D_TASK_SLVModel m in model.SlvList) {
                sBuilder.Remove(0, sBuilder.Length);
                sBuilder.Append("INSERT INTO T_D_TASK_SLV(");
                sBuilder.Append("ID,");
                sBuilder.Append("MSTID,");
                sBuilder.Append("SQLDATAID,");
                sBuilder.Append("BL1,");
                sBuilder.Append("BL2,");
                sBuilder.Append("BL3,");
                sBuilder.Append("SJC,");
                sBuilder.Append("TASKTYPE,");
                sBuilder.Append("OUTPUTTYPE,");
                sBuilder.Append("OUTPUTPATH");
                sBuilder.Append(") VALUES(");
                sBuilder.Append(":ID,");
                sBuilder.Append(":MSTID,");
                sBuilder.Append(":SQLDATAID,");
                sBuilder.Append(":BL1,");
                sBuilder.Append(":BL2,");
                sBuilder.Append(":BL3,");
                sBuilder.Append(":SJC,");
                sBuilder.Append(":TASKTYPE,");
                sBuilder.Append(":OUTPUTTYPE,");
                sBuilder.Append(":OUTPUTPATH");
                sBuilder.Append(")");
                OracleParameter[] oparams1 ={
                 new OracleParameter(":ID",OracleType.VarChar),
                 new OracleParameter(":MSTID",OracleType.VarChar),
                 new OracleParameter(":SQLDATAID",OracleType.VarChar),
                 new OracleParameter(":BL1",OracleType.VarChar),
                 new OracleParameter(":BL2",OracleType.VarChar),
                 new OracleParameter(":BL3",OracleType.VarChar),
                 new OracleParameter(":SJC",OracleType.VarChar),
                 new OracleParameter(":TASKTYPE",OracleType.VarChar),
                 new OracleParameter(":OUTPUTTYPE",OracleType.VarChar),
                 new OracleParameter(":OUTPUTPATH",OracleType.VarChar)
               };
                oparams1[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_D_TASK_SLV");//m.ID;
                oparams1[1].Value = oparams[0].Value;//m.MSTID;
                oparams1[2].Value = m.SQLDATAID;
                oparams1[3].Value = m.BL1;
                oparams1[4].Value = m.BL2;
                oparams1[5].Value = m.BL3;
                oparams1[6].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//m.SJC;
                oparams1[7].Value = m.TASKTYPE;
                oparams1[8].Value = m.OUTPUTTYPE;
                oparams1[9].Value = m.OUTPUTPATH;
                listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams1));
                foreach (Model.T_S_TASK_SLV_SLVModel mm in m.SlvList) {
                    sBuilder.Remove(0, sBuilder.Length);
                    sBuilder.Append("INSERT INTO T_S_TASK_SLV_SLV(");
                    sBuilder.Append("ID,");
                    sBuilder.Append("TASKSLVID,"); 
                    sBuilder.Append("SQLDATASLVID,");
                    sBuilder.Append("SQLDATASLVVAL,");
                    sBuilder.Append("BL1,");
                    sBuilder.Append("BL2,");
                    sBuilder.Append("BL3,");
                    sBuilder.Append("SJC,");
                    sBuilder.Append("SQLDARASLVNAME,");
                    sBuilder.Append("SQLDARASQLTYPE");
                    sBuilder.Append(") VALUES(");
                    sBuilder.Append(":ID,");
                    sBuilder.Append(":TASKSLVID,"); 
                    sBuilder.Append(":SQLDATASLVID,");
                    sBuilder.Append(":SQLDATASLVVAL,");
                    sBuilder.Append(":BL1,");
                    sBuilder.Append(":BL2,");
                    sBuilder.Append(":BL3,");
                    sBuilder.Append(":SJC,");
                    sBuilder.Append(":SQLDARASLVNAME,");
                    sBuilder.Append(":SQLDARASQLTYPE");
                    sBuilder.Append(")");
                    OracleParameter[] oparams2 ={
                     new OracleParameter(":ID",OracleType.VarChar),
                     new OracleParameter(":TASKSLVID",OracleType.VarChar),
                     new OracleParameter(":SQLDATASLVID",OracleType.VarChar),
                     new OracleParameter(":SQLDATASLVVAL",OracleType.VarChar),
                     new OracleParameter(":BL1",OracleType.VarChar),
                     new OracleParameter(":BL2",OracleType.VarChar),
                     new OracleParameter(":BL3",OracleType.VarChar),
                     new OracleParameter(":SJC",OracleType.VarChar),
                     new OracleParameter(":SQLDARASLVNAME",OracleType.VarChar),
                     new OracleParameter(":SQLDARASQLTYPE",OracleType.VarChar)
                   };
                    oparams2[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_S_TASK_SLV_SLV");//mm.ID;
                    oparams2[1].Value = oparams1[0].Value;
                    oparams2[2].Value = mm.SQLDATASLVID;
                    oparams2[3].Value = mm.SQLDATASLVVAL;
                    oparams2[4].Value = mm.BL1;
                    oparams2[5].Value = mm.BL2;
                    oparams2[6].Value = mm.BL3;
                    oparams2[7].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//mm.SJC;
                    oparams2[8].Value = mm.SQLDARASLVNAME;
                    oparams2[9].Value = mm.SQLDARASQLTYPE;
                    listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams2));
                }
            }
            int ret = af.ExecuteNonQueryTransaction(listParamters);
            return ret;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Modify(T_D_TASK_MSTModel model)
        {
            List<XMLDbHelper.Paramers> listParamters = new List<XMLDbHelper.Paramers>();
            XMLDbHelper.FactoryDbHelper af = new XMLDbHelper.FactoryDbHelper();
            DateTime sjc = af.GetDbDatetimestamp();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("UPDATE T_D_TASK_MST SET ");
            sBuilder.Append("TASKNAME=:TASKNAME,");
            sBuilder.Append("TASKNUMBER=:TASKNUMBER,");
            sBuilder.Append("TASKDONUMBER=:TASKDONUMBER,");
            sBuilder.Append("BEGINDATETIME=:BEGINDATETIME,");
            sBuilder.Append("LASTDATETIME=:LASTDATETIME,");
            sBuilder.Append("INTERVAL=:INTERVAL,");
            sBuilder.Append("INTERVALTYPE=:INTERVALTYPE,");
            sBuilder.Append("SFSC=:SFSC,");
            sBuilder.Append("SFJY=:SFJY,");
            sBuilder.Append("CJR=:CJR,");
            sBuilder.Append("CJSJ=:CJSJ,");
            sBuilder.Append("XGR=:XGR,");
            sBuilder.Append("XGSJ=:XGSJ,");
            sBuilder.Append("SJC=:SJC,");
            sBuilder.Append("TASKDISCRIBE=:TASKDISCRIBE "); 
            sBuilder.Append("WHERE ID=:ID ");
            OracleParameter[] oparams ={
             new OracleParameter(":ID",OracleType.VarChar),
             new OracleParameter(":TASKNAME",OracleType.VarChar),
             new OracleParameter(":TASKNUMBER",OracleType.Number),
             new OracleParameter(":TASKDONUMBER",OracleType.Number),
             new OracleParameter(":BEGINDATETIME",OracleType.VarChar),
             new OracleParameter(":LASTDATETIME",OracleType.VarChar),
             new OracleParameter(":INTERVAL",OracleType.Number),
             new OracleParameter(":INTERVALTYPE",OracleType.VarChar),
             new OracleParameter(":SFSC",OracleType.Number),
             new OracleParameter(":SFJY",OracleType.Number),
             new OracleParameter(":CJR",OracleType.VarChar),
             new OracleParameter(":CJSJ",OracleType.VarChar),
             new OracleParameter(":XGR",OracleType.VarChar),
             new OracleParameter(":XGSJ",OracleType.VarChar),
             new OracleParameter(":SJC",OracleType.VarChar), 
             new OracleParameter(":TASKDISCRIBE",OracleType.VarChar)
           };
            oparams[0].Value = model.ID;
            oparams[1].Value = model.TASKNAME;
            oparams[2].Value = model.TASKNUMBER;
            oparams[3].Value = model.TASKDONUMBER;
            oparams[4].Value = model.BEGINDATETIME;
            oparams[5].Value = model.LASTDATETIME;
            oparams[6].Value = model.INTERVAL;
            oparams[7].Value = model.INTERVALTYPE;
            oparams[8].Value = model.SFSC;
            oparams[9].Value = model.SFJY;
            oparams[10].Value = model.CJR;
            oparams[11].Value = model.CJSJ;
            oparams[12].Value = model.XGR;
            oparams[13].Value = sjc.ToString("yyyyMMddHHmmss");//model.XGSJ;
            oparams[14].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//model.SJC;
            oparams[15].Value = model.TASKDISCRIBE;
            listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams));
            foreach (Model.T_D_TASK_SLVModel m in model.SlvList) {
                if (String.IsNullOrEmpty(m.ID))
                {
                    if (m.SFSC == 0)
                    {
                        sBuilder.Remove(0, sBuilder.Length);
                        sBuilder.Append("INSERT INTO T_D_TASK_SLV(");
                        sBuilder.Append("ID,");
                        sBuilder.Append("MSTID,");
                        sBuilder.Append("SQLDATAID,");
                        sBuilder.Append("BL1,");
                        sBuilder.Append("BL2,");
                        sBuilder.Append("BL3,");
                        sBuilder.Append("SJC,");
                        sBuilder.Append("TASKTYPE,");
                        sBuilder.Append("OUTPUTTYPE,");
                        sBuilder.Append("OUTPUTPATH");
                        sBuilder.Append(") VALUES(");
                        sBuilder.Append(":ID,");
                        sBuilder.Append(":MSTID,");
                        sBuilder.Append(":SQLDATAID,");
                        sBuilder.Append(":BL1,");
                        sBuilder.Append(":BL2,");
                        sBuilder.Append(":BL3,");
                        sBuilder.Append(":SJC,");
                        sBuilder.Append(":TASKTYPE,");
                        sBuilder.Append(":OUTPUTTYPE,");
                        sBuilder.Append(":OUTPUTPATH");
                        sBuilder.Append(")");
                        OracleParameter[] oparams1 ={
                     new OracleParameter(":ID",OracleType.VarChar),
                     new OracleParameter(":MSTID",OracleType.VarChar),
                     new OracleParameter(":SQLDATAID",OracleType.VarChar),
                     new OracleParameter(":BL1",OracleType.VarChar),
                     new OracleParameter(":BL2",OracleType.VarChar),
                     new OracleParameter(":BL3",OracleType.VarChar),
                     new OracleParameter(":SJC",OracleType.VarChar),
                     new OracleParameter(":TASKTYPE",OracleType.VarChar),
                     new OracleParameter(":OUTPUTTYPE",OracleType.VarChar),
                     new OracleParameter(":OUTPUTPATH",OracleType.VarChar)
                   };
                        oparams1[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_D_TASK_SLV");//m.ID;
                        oparams1[1].Value = model.ID;
                        oparams1[2].Value = m.SQLDATAID;
                        oparams1[3].Value = m.BL1;
                        oparams1[4].Value = m.BL2;
                        oparams1[5].Value = m.BL3;
                        oparams1[6].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//m.SJC;
                        oparams1[7].Value = m.TASKTYPE;
                        oparams1[8].Value = m.OUTPUTTYPE;
                        oparams1[9].Value = m.OUTPUTPATH;
                        listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams1));
                        foreach (Model.T_S_TASK_SLV_SLVModel mm in m.SlvList)
                        {
                            sBuilder.Remove(0, sBuilder.Length);
                            sBuilder.Append("INSERT INTO T_S_TASK_SLV_SLV(");
                            sBuilder.Append("ID,");
                            sBuilder.Append("TASKSLVID,");
                            sBuilder.Append("SQLDATASLVID,");
                            sBuilder.Append("SQLDATASLVVAL,");
                            sBuilder.Append("BL1,");
                            sBuilder.Append("BL2,");
                            sBuilder.Append("BL3,");
                            sBuilder.Append("SJC,");
                            sBuilder.Append("SQLDARASLVNAME,");
                            sBuilder.Append("SQLDARASQLTYPE");
                            sBuilder.Append(") VALUES(");
                            sBuilder.Append(":ID,");
                            sBuilder.Append(":TASKSLVID,");
                            sBuilder.Append(":SQLDATASLVID,");
                            sBuilder.Append(":SQLDATASLVVAL,");
                            sBuilder.Append(":BL1,");
                            sBuilder.Append(":BL2,");
                            sBuilder.Append(":BL3,");
                            sBuilder.Append(":SJC,");
                            sBuilder.Append(":SQLDARASLVNAME,");
                            sBuilder.Append(":SQLDARASQLTYPE");
                            sBuilder.Append(")");
                            OracleParameter[] oparams2 ={
                         new OracleParameter(":ID",OracleType.VarChar), 
                         new OracleParameter(":TASKSLVID",OracleType.VarChar), 
                         new OracleParameter(":SQLDATASLVID",OracleType.VarChar),
                         new OracleParameter(":SQLDATASLVVAL",OracleType.VarChar),
                         new OracleParameter(":BL1",OracleType.VarChar),
                         new OracleParameter(":BL2",OracleType.VarChar),
                         new OracleParameter(":BL3",OracleType.VarChar),
                         new OracleParameter(":SJC",OracleType.VarChar),
                         new OracleParameter(":SQLDARASLVNAME",OracleType.VarChar),
                         new OracleParameter(":SQLDARASQLTYPE",OracleType.VarChar)
                       };
                            oparams2[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_S_TASK_SLV_SLV");//mm.ID;
                            oparams2[1].Value = oparams1[0].Value;
                            oparams2[2].Value = mm.SQLDATASLVID;
                            oparams2[3].Value = mm.SQLDATASLVVAL;
                            oparams2[4].Value = mm.BL1;
                            oparams2[5].Value = mm.BL2;
                            oparams2[6].Value = mm.BL3;
                            oparams2[7].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//mm.SJC;
                            oparams2[8].Value = mm.SQLDARASLVNAME;
                            oparams2[9].Value = mm.SQLDARASQLTYPE;
                            listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams2));
                        }
                    }
                }
                else {
                    if (m.SFSC == 1)
                    {
                        sBuilder.Remove(0, sBuilder.Length);
                        sBuilder.Append("DELETE FROM T_D_TASK_SLV ");
                        sBuilder.Append("WHERE ID=:ID ");
                        OracleParameter[] oparams3 ={
                         new OracleParameter(":ID",OracleType.VarChar)
                       };
                        oparams3[0].Value = m.ID;
                        listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams3));
                        
                        sBuilder.Remove(0, sBuilder.Length);
                        sBuilder.Append("DELETE FROM T_S_TASK_SLV_SLV ");
                        sBuilder.Append("WHERE TASKSLVID=:TASKSLVID ");
                        OracleParameter[] oparams4 ={
                         new OracleParameter(":TASKSLVID",OracleType.VarChar)
                       };
                        oparams4[0].Value = m.ID;
                        listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams4));
                    }
                    else {
                        sBuilder.Remove(0, sBuilder.Length);
                        sBuilder.Append("UPDATE T_D_TASK_SLV SET ");
                        sBuilder.Append("MSTID=:MSTID,");
                        sBuilder.Append("SQLDATAID=:SQLDATAID,");
                        sBuilder.Append("BL1=:BL1,");
                        sBuilder.Append("BL2=:BL2,");
                        sBuilder.Append("BL3=:BL3,");
                        sBuilder.Append("SJC=:SJC,");
                        sBuilder.Append("TASKTYPE=:TASKTYPE,");
                        sBuilder.Append("OUTPUTTYPE=:OUTPUTTYPE,");
                        sBuilder.Append("OUTPUTPATH=:OUTPUTPATH ");
                        sBuilder.Append("WHERE ID=:ID ");
                        OracleParameter[] oparams5 ={
                         new OracleParameter(":ID",OracleType.VarChar),
                         new OracleParameter(":MSTID",OracleType.VarChar),
                         new OracleParameter(":SQLDATAID",OracleType.VarChar),
                         new OracleParameter(":BL1",OracleType.VarChar),
                         new OracleParameter(":BL2",OracleType.VarChar),
                         new OracleParameter(":BL3",OracleType.VarChar),
                         new OracleParameter(":SJC",OracleType.VarChar),
                         new OracleParameter(":TASKTYPE",OracleType.VarChar),
                         new OracleParameter(":OUTPUTTYPE",OracleType.VarChar),
                         new OracleParameter(":OUTPUTPATH",OracleType.VarChar)
                       };
                        oparams5[0].Value = m.ID;
                        oparams5[1].Value = m.MSTID;
                        oparams5[2].Value = m.SQLDATAID;
                        oparams5[3].Value = m.BL1;
                        oparams5[4].Value = m.BL2;
                        oparams5[5].Value = m.BL3;
                        oparams5[6].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//m.SJC;
                        oparams5[7].Value = m.TASKTYPE;
                        oparams5[8].Value = m.OUTPUTTYPE;
                        oparams5[9].Value = m.OUTPUTPATH;
                        listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams5));

                        sBuilder.Remove(0, sBuilder.Length);
                        sBuilder.Append("DELETE FROM T_S_TASK_SLV_SLV ");
                        sBuilder.Append("WHERE TASKSLVID=:TASKSLVID ");
                        OracleParameter[] oparams6 ={
                         new OracleParameter(":TASKSLVID",OracleType.VarChar)
                       };
                        oparams6[0].Value = m.ID;
                        listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams6));

                        foreach (Model.T_S_TASK_SLV_SLVModel mm in m.SlvList)
                        {
                            sBuilder.Remove(0, sBuilder.Length);
                            sBuilder.Append("INSERT INTO T_S_TASK_SLV_SLV(");
                            sBuilder.Append("ID,");
                            sBuilder.Append("TASKSLVID,"); 
                            sBuilder.Append("SQLDATASLVID,");
                            sBuilder.Append("SQLDATASLVVAL,");
                            sBuilder.Append("BL1,");
                            sBuilder.Append("BL2,");
                            sBuilder.Append("BL3,");
                            sBuilder.Append("SJC,");
                            sBuilder.Append("SQLDARASLVNAME,");
                            sBuilder.Append("SQLDARASQLTYPE");
                            sBuilder.Append(") VALUES(");
                            sBuilder.Append(":ID,");
                            sBuilder.Append(":TASKSLVID,"); 
                            sBuilder.Append(":SQLDATASLVID,");
                            sBuilder.Append(":SQLDATASLVVAL,");
                            sBuilder.Append(":BL1,");
                            sBuilder.Append(":BL2,");
                            sBuilder.Append(":BL3,");
                            sBuilder.Append(":SJC,");
                            sBuilder.Append(":SQLDARASLVNAME,");
                            sBuilder.Append(":SQLDARASQLTYPE");
                            sBuilder.Append(")");
                            OracleParameter[] oparams7 ={
                             new OracleParameter(":ID",OracleType.VarChar),
                             new OracleParameter(":TASKSLVID",OracleType.VarChar),
                             new OracleParameter(":SQLDATASLVID",OracleType.VarChar),
                             new OracleParameter(":SQLDATASLVVAL",OracleType.VarChar),
                             new OracleParameter(":BL1",OracleType.VarChar),
                             new OracleParameter(":BL2",OracleType.VarChar),
                             new OracleParameter(":BL3",OracleType.VarChar),
                             new OracleParameter(":SJC",OracleType.VarChar),
                             new OracleParameter(":SQLDARASLVNAME",OracleType.VarChar),
                             new OracleParameter(":SQLDARASQLTYPE",OracleType.VarChar)
                           };
                            oparams7[0].Value = af.GetID(T_BASE_PUBLIC.UNITNAMEKEY, "T_S_TASK_SLV_SLV");//mm.ID;
                            oparams7[1].Value = m.ID;
                            oparams7[2].Value = mm.SQLDATASLVID;
                            oparams7[3].Value = mm.SQLDATASLVVAL;
                            oparams7[4].Value = mm.BL1;
                            oparams7[5].Value = mm.BL2;
                            oparams7[6].Value = mm.BL3;
                            oparams7[7].Value = sjc.ToString("yyyy-MM-dd HH:mm:ss.ffffff");//mm.SJC;
                            oparams7[8].Value = mm.SQLDARASLVNAME;
                            oparams7[9].Value = mm.SQLDARASQLTYPE;
                            listParamters.Add(new XMLDbHelper.Paramers(sBuilder.ToString(), oparams7));
                        }
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
            sBuilder.Append("DELETE FROM T_D_TASK_MST ");
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
        public T_D_TASK_MSTModel Query(string id)
        {
            T_D_TASK_MSTModel model = new T_D_TASK_MSTModel();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.ID,");
            sBuilder.Append("T.TASKNAME,");
            sBuilder.Append("T.TASKNUMBER,");
            sBuilder.Append("T.TASKDONUMBER,");
            sBuilder.Append("T.BEGINDATETIME,");
            sBuilder.Append("T.LASTDATETIME,");
            sBuilder.Append("T.INTERVAL,");
            sBuilder.Append("T.INTERVALTYPE,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.SFJY,");
            sBuilder.Append("T.CJR,");
            sBuilder.Append("T.CJSJ,");
            sBuilder.Append("T.XGR,");
            sBuilder.Append("T.XGSJ,");
            sBuilder.Append("T.SJC,");
            sBuilder.Append("T.TASKDISCRIBE "); 
            sBuilder.Append("FROM T_D_TASK_MST T ");
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
                model.TASKNAME = ToString(dr["TASKNAME"]);
                model.TASKNUMBER = ToInt(dr["TASKNUMBER"]);
                model.TASKDONUMBER = ToInt(dr["TASKDONUMBER"]);
                model.BEGINDATETIME = ToString(dr["BEGINDATETIME"]);
                model.LASTDATETIME = ToString(dr["LASTDATETIME"]);
                model.INTERVAL = ToInt(dr["INTERVAL"]);
                model.INTERVALTYPE = ToString(dr["INTERVALTYPE"]);
                model.SFSC = ToInt(dr["SFSC"]);
                model.SFJY = ToInt(dr["SFJY"]);
                model.CJR = ToString(dr["CJR"]);
                model.CJSJ = ToString(dr["CJSJ"]);
                model.XGR = ToString(dr["XGR"]);
                model.XGSJ = ToString(dr["XGSJ"]);
                model.SJC = ToString(dr["SJC"]);
                model.TASKDISCRIBE = ToString(dr["TASKDISCRIBE"]); 
            }
            model.SlvList = QuerySlvList(id);
            return model;
        }

        private List<Model.T_D_TASK_SLVModel> QuerySlvList(string mstid) {
            string swhere = String.Format(" T.MSTID='{0}'", mstid);
            string orders = "T.ID";
            List<T_D_TASK_SLVModel> models = new List<T_D_TASK_SLVModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.ID,");
            sBuilder.Append("T4.LXMC GROUPMC,");
            sBuilder.Append("T3.PZMC SJYMC,");
            sBuilder.Append("T2.SQLDATANAME,");
            sBuilder.Append("T2.SQLTYPE,");
            sBuilder.Append("T.MSTID,");
            sBuilder.Append("T.SQLDATAID,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3,");
            sBuilder.Append("T.SJC,");
            sBuilder.Append("T.TASKTYPE,");
            sBuilder.Append("T.OUTPUTTYPE,");
            sBuilder.Append("T.OUTPUTPATH ");
            sBuilder.Append("FROM T_D_TASK_SLV T ");
            sBuilder.Append("LEFT JOIN T_D_SQLDATA_MST T2 ON T.SQLDATAID=T2.ID ");
            sBuilder.Append("LEFT JOIN T_BASE_SJYPZ T3 ON T2.SJYID=T3.PZBM ");
            sBuilder.Append("LEFT JOIN T_BASE_UNITTYPE T4 ON T2.UNITTYPEID=T4.LXBM ");
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
                    T_D_TASK_SLVModel model = new T_D_TASK_SLVModel();
                    model.ID = ToString(dr["ID"]);
                    model.MSTID = ToString(dr["MSTID"]);
                    model.SQLDATAID = ToString(dr["SQLDATAID"]);
                    model.BL1 = ToString(dr["BL1"]);
                    model.BL2 = ToString(dr["BL2"]);
                    model.BL3 = ToString(dr["BL3"]);
                    model.SJC = ToString(dr["SJC"]);
                    model.TASKTYPE = ToString(dr["TASKTYPE"]);
                    model.OUTPUTTYPE = ToString(dr["OUTPUTTYPE"]);
                    model.OUTPUTPATH = ToString(dr["OUTPUTPATH"]);
                    model.GROUPMC = ToString(dr["GROUPMC"]);
                    model.SJYMC = ToString(dr["SJYMC"]);
                    model.SQLDATANAME = ToString(dr["SQLDATANAME"]);
                    model.SQLTYPE = ToString(dr["SQLTYPE"]);
                    model.SlvList = QuerySlvSlvList(model.ID);
                    models.Add(model);
                }
            }
            return models;
        }

        private List<T_S_TASK_SLV_SLVModel> QuerySlvSlvList(string slvid)
        {
            string swhere = String.Format(" T.TASKSLVID='{0}'", slvid);
            string orders = "T.ID";
            List<T_S_TASK_SLV_SLVModel> models = new List<T_S_TASK_SLV_SLVModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.ID,");
            sBuilder.Append("T.TASKSLVID,"); 
            sBuilder.Append("T.SQLDATASLVID,");
            sBuilder.Append("T.SQLDATASLVVAL,");
            sBuilder.Append("T.SQLDARASLVNAME,");
            sBuilder.Append("T.SQLDARASQLTYPE,");
            sBuilder.Append("T.BL1,");
            sBuilder.Append("T.BL2,");
            sBuilder.Append("T.BL3,");
            sBuilder.Append("T.SJC ");
            sBuilder.Append("FROM T_S_TASK_SLV_SLV T ");
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
                    T_S_TASK_SLV_SLVModel model = new T_S_TASK_SLV_SLVModel();
                    model.ID = ToString(dr["ID"]);
                    model.TASKSLVID = ToString(dr["TASKSLVID"]); 
                    model.SQLDATASLVID = ToString(dr["SQLDATASLVID"]);
                    model.SQLDATASLVVAL = ToString(dr["SQLDATASLVVAL"]);
                    model.SQLDARASLVNAME = ToString(dr["SQLDARASLVNAME"]);
                    model.SQLDARASQLTYPE = ToString(dr["SQLDARASQLTYPE"]);
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
        public List<T_D_TASK_MSTModel> QueryList(string swhere, string orders)
        {
            List<T_D_TASK_MSTModel> models = new List<T_D_TASK_MSTModel>();
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append("SELECT  ");
            sBuilder.Append("T.ID,");
            sBuilder.Append("T.TASKNAME,");
            sBuilder.Append("T.TASKNUMBER,");
            sBuilder.Append("T.TASKDONUMBER,");
            sBuilder.Append("T.BEGINDATETIME,");
            sBuilder.Append("T.LASTDATETIME,");
            sBuilder.Append("T.INTERVAL,");
            sBuilder.Append("T.INTERVALTYPE,");
            sBuilder.Append("T.SFSC,");
            sBuilder.Append("T.SFJY,");
            sBuilder.Append("T.CJR,");
            sBuilder.Append("T.CJSJ,");
            sBuilder.Append("T.XGR,");
            sBuilder.Append("T.XGSJ,");
            sBuilder.Append("T.SJC,");
            sBuilder.Append("T.TASKDISCRIBE ");
            sBuilder.Append("FROM T_D_TASK_MST T ");
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
                    T_D_TASK_MSTModel model = new T_D_TASK_MSTModel();
                    model.ID = ToString(dr["ID"]);
                    model.TASKNAME = ToString(dr["TASKNAME"]);
                    model.TASKNUMBER = ToInt(dr["TASKNUMBER"]);
                    model.TASKDONUMBER = ToInt(dr["TASKDONUMBER"]);
                    model.BEGINDATETIME = ToString(dr["BEGINDATETIME"]);
                    model.LASTDATETIME = ToString(dr["LASTDATETIME"]);
                    model.INTERVAL = ToInt(dr["INTERVAL"]);
                    model.INTERVALTYPE = ToString(dr["INTERVALTYPE"]);
                    model.SFSC = ToInt(dr["SFSC"]);
                    model.SFJY = ToInt(dr["SFJY"]);
                    model.CJR = ToString(dr["CJR"]);
                    model.CJSJ = ToString(dr["CJSJ"]);
                    model.XGR = ToString(dr["XGR"]);
                    model.XGSJ = ToString(dr["XGSJ"]);
                    model.SJC = ToString(dr["SJC"]);
                    model.TASKDISCRIBE = ToString(dr["TASKDISCRIBE"]);
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
