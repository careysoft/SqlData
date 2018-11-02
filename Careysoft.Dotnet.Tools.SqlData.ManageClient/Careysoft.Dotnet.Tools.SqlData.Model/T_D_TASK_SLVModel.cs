using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class T_D_TASK_SLVModel
    {
        public T_D_TASK_SLVModel() { }
        public T_D_TASK_SLVModel(string _id,
                           string _mstid,
                           string _sqldataid,
                           string _bl1,
                           string _bl2,
                           string _bl3,
                           string _sjc)
        {
            m_ID = _id;
            m_MSTID = _mstid;
            m_SQLDATAID = _sqldataid;
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
        private string m_MSTID;
        ///<summary>
        ///主ID
        ///</summary>
        public string MSTID
        {
            get
            {
                return m_MSTID;
            }
            set
            {
                m_MSTID = value;
            }
        }
        private string m_SQLDATAID;
        ///<summary>
        ///SQLDATA ID
        ///</summary>
        public string SQLDATAID
        {
            get
            {
                return m_SQLDATAID;
            }
            set
            {
                m_SQLDATAID = value;
            }
        }
        /// <summary>
        /// SQLDATA名称
        /// </summary>
        public string SQLDATANAME { get; set; }
        /// <summary>
        /// SQLDATA类型
        /// </summary>
        public string SQLTYPE { get; set; }
        /// <summary>
        /// 数据源名称
        /// </summary>
        public string SJYMC { get; set; }
        /// <summary>
        /// 数据源编码
        /// </summary>
        public string SJYBM { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GROUPMC { get; set; }
        /// <summary>
        /// 对应SQL
        /// </summary>
        public string SQL { get; set; }

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

        private int m_SFSC;
        /// <summary>
        /// 是否删除
        /// </summary>
        public int SFSC
        {
            get { return m_SFSC; }
            set { m_SFSC = value; }
        }

        private string m_TASKTYPE;
        ///<summary>
        ///任务类型0输入类(对应查询类) 1执行类
        ///</summary>
        public string TASKTYPE
        {
            get
            {
                return m_TASKTYPE;
            }
            set
            {
                m_TASKTYPE = value;
            }
        }

        private string m_OUTPUTTYPE;
        ///<summary>
        ///数据类型 0 TXT输出 1EXCEL输出 2TXT EXCEL同时输出
        ///</summary>
        public string OUTPUTTYPE
        {
            get
            {
                return m_OUTPUTTYPE;
            }
            set
            {
                m_OUTPUTTYPE = value;
            }
        }
        private string m_OUTPUTPATH;
        ///<summary>
        ///输出路径
        ///</summary>
        public string OUTPUTPATH
        {
            get
            {
                return m_OUTPUTPATH;
            }
            set
            {
                m_OUTPUTPATH = value;
            }
        }

        /// <summary>
        /// SQLData是否禁用
        /// </summary>
        public int SQLDATASFJY { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int SQLDATASFSC { get; set; }

        private List<Model.T_S_TASK_SLV_SLVModel> m_SlvList = new List<T_S_TASK_SLV_SLVModel>();
        public List<Model.T_S_TASK_SLV_SLVModel> SlvList {
            get { return m_SlvList; }
            set { m_SlvList = value; }
        }
    }
}
