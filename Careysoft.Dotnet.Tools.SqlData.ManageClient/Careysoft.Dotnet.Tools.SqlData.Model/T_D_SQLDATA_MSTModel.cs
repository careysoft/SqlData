using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class T_D_SQLDATA_MSTModel : Careysoft.Basic.Public.TableBaseModel
    {
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
        private string m_SJYID;
        ///<summary>
        ///数据源ID
        ///</summary>
        public string SJYID
        {
            get
            {
                return m_SJYID;
            }
            set
            {
                m_SJYID = value;
            }
        }

        /// <summary>
        /// 数据源名称
        /// </summary>
        public string SJYMC { get; set; }

        private string m_SQLDATANAME;
        ///<summary>
        ///名称
        ///</summary>
        public string SQLDATANAME
        {
            get
            {
                return m_SQLDATANAME;
            }
            set
            {
                m_SQLDATANAME = value;
            }
        }
        private string m_SQLDATADISCRIBE;
        ///<summary>
        ///描述
        ///</summary>
        public string SQLDATADISCRIBE
        {
            get
            {
                return m_SQLDATADISCRIBE;
            }
            set
            {
                m_SQLDATADISCRIBE = value;
            }
        }
        private string m_SQL;
        ///<summary>
        ///SQL
        ///</summary>
        public string SQL
        {
            get
            {
                return m_SQL;
            }
            set
            {
                m_SQL = value;
            }
        }
        private string m_SQLTYPE;
        ///<summary>
        ///SQL类型0查询类 1执行类
        ///</summary>
        public string SQLTYPE
        {
            get
            {
                return m_SQLTYPE;
            }
            set
            {
                m_SQLTYPE = value;
            }
        }

        private int m_SFSC;
        ///<summary>
        ///是否删除0否1是
        ///</summary>
        public int SFSC
        {
            get
            {
                return m_SFSC;
            }
            set
            {
                m_SFSC = value;
            }
        }

        private int m_SFJY;
        ///<summary>
        ///是否禁用0否1是
        ///</summary>
        public int SFJY
        {
            get
            {
                return m_SFJY;
            }
            set
            {
                m_SFJY = value;
            }
        }

        private string m_UNITTYPEID;
        /// <summary>
        /// 所在分组
        /// </summary>
        public string UNITTYPEID {
            get { return m_UNITTYPEID; }
            set { m_UNITTYPEID = value; }
        }

        public string UNITTYPENAME { get; set; }

        private List<T_D_SQLDATA_SLVModel> m_SLVList = new List<T_D_SQLDATA_SLVModel>();
        public List<T_D_SQLDATA_SLVModel> SLVList {
            get { return m_SLVList; }
            set { m_SLVList = value; }
        }
    }
}
