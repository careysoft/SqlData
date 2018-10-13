using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class T_B_USERModel
    {
        public T_B_USERModel() { }
        public T_B_USERModel(string _username,
                           string _password,
                           string _xm,
                           string _usertype,
                           int _sfjy,
                           string _bl1,
                           string _bl2,
                           string _bl3)
        {
            m_USERNAME = _username;
            m_PASSWORD = _password;
            m_XM = _xm;
            m_USERTYPE = _usertype;
            m_SFJY = _sfjy;
            m_BL1 = _bl1;
            m_BL2 = _bl2;
            m_BL3 = _bl3;
        }
        private string m_USERNAME;
        ///<summary>
        ///用户名
        ///</summary>
        public string USERNAME
        {
            get
            {
                return m_USERNAME;
            }
            set
            {
                m_USERNAME = value;
            }
        }
        private string m_PASSWORD;
        ///<summary>
        ///密码
        ///</summary>
        public string PASSWORD
        {
            get
            {
                return m_PASSWORD;
            }
            set
            {
                m_PASSWORD = value;
            }
        }
        private string m_XM;
        ///<summary>
        ///姓名
        ///</summary>
        public string XM
        {
            get
            {
                return m_XM;
            }
            set
            {
                m_XM = value;
            }
        }
        private string m_USERTYPE;
        ///<summary>
        ///用户类型
        ///</summary>
        public string USERTYPE
        {
            get
            {
                return m_USERTYPE;
            }
            set
            {
                m_USERTYPE = value;
            }
        }
        private int m_SFJY;
        ///<summary>
        ///是否禁用0否 1禁用
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
        ///保留2
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
