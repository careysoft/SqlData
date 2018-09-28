using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class T_S_TASK_SLV_SLVModel
    {
        public T_S_TASK_SLV_SLVModel() { }
        public T_S_TASK_SLV_SLVModel(string _id,
                           string _sqldataslvid,
                           string _sqldataslvval,
                           string _bl1,
                           string _bl2,
                           string _bl3,
                           string _sjc)
        {
            m_ID = _id;
            m_SQLDATASLVID = _sqldataslvid;
            m_SQLDATASLVVAL = _sqldataslvval;
            m_BL1 = _bl1;
            m_BL2 = _bl2;
            m_BL3 = _bl3;
            m_SJC = _sjc;
        }
        private string m_ID;
        ///<summary>
        ///序号
        ///</summary>
        public string ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }
        private string m_TASKSLVID;
        ///<summary>
        ///taskSLV ID
        ///</summary>
        public string TASKSLVID
        {
            get
            {
                return m_TASKSLVID;
            }
            set
            {
                m_TASKSLVID = value;
            }
        }
        
        private string m_SQLDATASLVID;
        ///<summary>
        ///对应参数ID
        ///</summary>
        public string SQLDATASLVID
        {
            get
            {
                return m_SQLDATASLVID;
            }
            set
            {
                m_SQLDATASLVID = value;
            }
        }
        private string m_SQLDARASLVNAME;
        ///<summary>
        ///参数名
        ///</summary>
        public string SQLDARASLVNAME
        {
            get
            {
                return m_SQLDARASLVNAME;
            }
            set
            {
                m_SQLDARASLVNAME = value;
            }
        }
        private string m_SQLDARASQLTYPE;
        ///<summary>
        ///参数类型
        ///</summary>
        public string SQLDARASQLTYPE
        {
            get
            {
                return m_SQLDARASQLTYPE;
            }
            set
            {
                m_SQLDARASQLTYPE = value;
            }
        }
        private string m_SQLDATASLVVAL;
        ///<summary>
        ///对应参数值
        ///</summary>
        public string SQLDATASLVVAL
        {
            get
            {
                return m_SQLDATASLVVAL;
            }
            set
            {
                m_SQLDATASLVVAL = value;
            }
        }
        private string m_BL1;
        ///<summary>
        ///保留1
        ///</summary>
        public string BL1
        {
            get
            {
                return m_BL1;
            }
            set
            {
                m_BL1 = value;
            }
        }
        private string m_BL2;
        ///<summary>
        ///保留2
        ///</summary>
        public string BL2
        {
            get
            {
                return m_BL2;
            }
            set
            {
                m_BL2 = value;
            }
        }
        private string m_BL3;
        ///<summary>
        ///保留3
        ///</summary>
        public string BL3
        {
            get
            {
                return m_BL3;
            }
            set
            {
                m_BL3 = value;
            }
        }
        private string m_SJC;
        ///<summary>
        ///时间戳
        ///</summary>
        public string SJC
        {
            get
            {
                return m_SJC;
            }
            set
            {
                m_SJC = value;
            }
        }
    }
}
