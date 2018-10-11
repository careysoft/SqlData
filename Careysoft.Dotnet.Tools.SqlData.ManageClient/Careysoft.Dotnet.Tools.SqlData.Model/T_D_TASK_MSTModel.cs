using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Tools.SqlData.Model
{
    public class T_D_TASK_MSTModel : Careysoft.Basic.Public.TableBaseModel
    {
        public T_D_TASK_MSTModel() { }
        
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
        private string m_TASKNAME;
        ///<summary>
        ///任务名
        ///</summary>
        public string TASKNAME
        {
            get
            {
                return m_TASKNAME;
            }
            set
            {
                m_TASKNAME = value;
            }
        }
        
        private int m_TASKNUMBER;
        ///<summary>
        ///需要执行次数-1 则不要求
        ///</summary>
        public int TASKNUMBER
        {
            get
            {
                return m_TASKNUMBER;
            }
            set
            {
                m_TASKNUMBER = value;
            }
        }
        private int m_TASKDONUMBER;
        ///<summary>
        ///执行次数 执行次数与要求次数相等 则不执行
        ///</summary>
        public int TASKDONUMBER
        {
            get
            {
                return m_TASKDONUMBER;
            }
            set
            {
                m_TASKDONUMBER = value;
            }
        }
        private string m_BEGINDATETIME;
        ///<summary>
        ///开始时间
        ///</summary>
        public string BEGINDATETIME
        {
            get
            {
                return m_BEGINDATETIME;
            }
            set
            {
                m_BEGINDATETIME = value;
            }
        }
        private string m_LASTDATETIME;
        ///<summary>
        ///最后一次执行时间
        ///</summary>
        public string LASTDATETIME
        {
            get
            {
                return m_LASTDATETIME;
            }
            set
            {
                m_LASTDATETIME = value;
            }
        }
        private int m_INTERVAL;
        ///<summary>
        ///间隔时间
        ///</summary>
        public int INTERVAL
        {
            get
            {
                return m_INTERVAL;
            }
            set
            {
                m_INTERVAL = value;
            }
        }
        private string m_INTERVALTYPE;
        ///<summary>
        ///间隔类型0秒 1分钟 2小时 3天 
        ///</summary>
        public string INTERVALTYPE
        {
            get
            {
                return m_INTERVALTYPE;
            }
            set
            {
                m_INTERVALTYPE = value;
            }
        }

        private string m_INTERVALADDTYPE;
        ///<summary>
        ///间隔类型0从间隔起始时间间隔 1从执行完成后间隔 
        ///</summary>
        public string INTERVALADDTYPE
        {
            get
            {
                return m_INTERVALADDTYPE;
            }
            set
            {
                m_INTERVALADDTYPE = value;
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

        private string m_TASKDISCRIBE;
        public string TASKDISCRIBE {
            get { return m_TASKDISCRIBE; }
            set { m_TASKDISCRIBE = value; }
        }

        private List<Model.T_D_TASK_SLVModel> m_SlvList = new List<T_D_TASK_SLVModel>();
        public List<Model.T_D_TASK_SLVModel> SlvList
        {
            get { return m_SlvList; }
            set { m_SlvList = value; }
        }
    }

}
