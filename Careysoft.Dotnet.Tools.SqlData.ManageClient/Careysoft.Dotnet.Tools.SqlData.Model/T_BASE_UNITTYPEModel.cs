using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model 
{
    public class T_BASE_UNITTYPEModel : Careysoft.Basic.Public.TableBaseModel
    {
        public override string ToString()
        {
            return m_LXMC;
        }
        public T_BASE_UNITTYPEModel() { }
        public T_BASE_UNITTYPEModel(string _lxbm,
                           string _lxmc,
                           int _sfsc,
                           string _bl1,
                           string _bl2,
                           string _bl3)
        {
            m_LXBM = _lxbm;
            m_LXMC = _lxmc;
            m_SFSC = _sfsc;
            m_BL1 = _bl1;
            m_BL2 = _bl2;
            m_BL3 = _bl3;
        }
        private string m_LXBM;
        ///<summary>
        ///类型编码
        ///</summary>
        public string LXBM
        {
            get
            {
                return m_LXBM;
            }
            set
            {
                m_LXBM = value;
            }
        }
        private string m_LXMC;
        ///<summary>
        ///类型名称
        ///</summary>
        public string LXMC
        {
            get
            {
                return m_LXMC;
            }
            set
            {
                m_LXMC = value;
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
    }
}
