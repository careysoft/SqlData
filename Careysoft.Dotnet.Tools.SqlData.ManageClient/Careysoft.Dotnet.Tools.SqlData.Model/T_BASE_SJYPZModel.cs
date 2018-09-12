using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class T_BASE_SJYPZModel : Careysoft.Basic.Public.TableBaseModel
    {
        public T_BASE_SJYPZModel() { }
        public T_BASE_SJYPZModel(string _pzbm,
                           string _pzmc,
                           string _sjip,
                           string _sjport,
                           string _sjsid,
                           string _sjuserid,
                           string _sjpassword,
                           int _sfsc,
                           string _bl1,
                           string _bl2,
                           string _bl3)
        {
            m_PZBM = _pzbm;
            m_PZMC = _pzmc;
            m_SJIP = _sjip;
            m_SJPORT = _sjport;
            m_SJSID = _sjsid;
            m_SJUSERID = _sjuserid;
            m_SJPASSWORD = _sjpassword;
            m_SFSC = _sfsc;
            m_BL1 = _bl1;
            m_BL2 = _bl2;
            m_BL3 = _bl3;
        }
        private string m_PZBM;
        ///<summary>
        ///配置编码
        ///</summary>
        public string PZBM
        {
            get
            {
                return m_PZBM;
            }
            set
            {
                m_PZBM = value;
            }
        }
        private string m_PZMC;
        ///<summary>
        ///配置名称
        ///</summary>
        public string PZMC
        {
            get
            {
                return m_PZMC;
            }
            set
            {
                m_PZMC = value;
            }
        }
        private string m_SJIP;
        ///<summary>
        ///数据IP
        ///</summary>
        public string SJIP
        {
            get
            {
                return m_SJIP;
            }
            set
            {
                m_SJIP = value;
            }
        }
        private string m_SJPORT;
        ///<summary>
        ///数据端口
        ///</summary>
        public string SJPORT
        {
            get
            {
                return m_SJPORT;
            }
            set
            {
                m_SJPORT = value;
            }
        }
        private string m_SJSID;
        ///<summary>
        ///SID
        ///</summary>
        public string SJSID
        {
            get
            {
                return m_SJSID;
            }
            set
            {
                m_SJSID = value;
            }
        }
        private string m_SJUSERID;
        ///<summary>
        ///数据用户名
        ///</summary>
        public string SJUSERID
        {
            get
            {
                return m_SJUSERID;
            }
            set
            {
                m_SJUSERID = value;
            }
        }
        private string m_SJPASSWORD;
        ///<summary>
        ///数据用户密码
        ///</summary>
        public string SJPASSWORD
        {
            get
            {
                return m_SJPASSWORD;
            }
            set
            {
                m_SJPASSWORD = value;
            }
        }
        private int m_SFSC;
        ///<summary>
        ///是否删除0否 1是
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
        private string m_BL1;
        ///<summary>
        ///保留1 数据源类型 0SID 1SERVICE_NAME
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
    }
}
