﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class T_D_SQLDATA_SLVModel
    {
        public T_D_SQLDATA_SLVModel() { }
        public T_D_SQLDATA_SLVModel(string _id,
                           string _mstid,
                           string _PARAMETERNAME,
                           string _parametertype,
                           string _parameterdisc,
                           string _defaultvalue,
                           string _bl1,
                           string _bl2,
                           string _bl3,
                           string _sjc)
        {
            m_ID = _id;
            m_MSTID = _mstid;
            m_PARAMETERNAME = _PARAMETERNAME;
            m_PARAMETERTYPE = _parametertype;
            m_PARAMETERDISC = _parameterdisc;
            m_DEFAULTVALUE = _defaultvalue;
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
        private string m_PARAMETERNAME;
        ///<summary>
        ///参数名
        ///</summary>
        public string PARAMETERNAME
        {
            get
            {
                return m_PARAMETERNAME;
            }
            set
            {
                m_PARAMETERNAME = value;
            }
        }
        private string m_PARAMETERTYPE;
        ///<summary>
        ///参数类型
        ///</summary>
        public string PARAMETERTYPE
        {
            get
            {
                return m_PARAMETERTYPE;
            }
            set
            {
                m_PARAMETERTYPE = value;
            }
        }
        private string m_PARAMETERDISC;
        ///<summary>
        ///参数说明
        ///</summary>
        public string PARAMETERDISC
        {
            get
            {
                return m_PARAMETERDISC;
            }
            set
            {
                m_PARAMETERDISC = value;
            }
        }
        private string m_DEFAULTVALUE;
        ///<summary>
        ///默认值
        ///</summary>
        public string DEFAULTVALUE
        {
            get
            {
                return m_DEFAULTVALUE;
            }
            set
            {
                m_DEFAULTVALUE = value;
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

        private int m_SFSC;
        /// <summary>
        /// 是否删除
        /// </summary>
        public int SFSC {
            get { return m_SFSC; }
            set { m_SFSC = value; }
        }
    }
}
