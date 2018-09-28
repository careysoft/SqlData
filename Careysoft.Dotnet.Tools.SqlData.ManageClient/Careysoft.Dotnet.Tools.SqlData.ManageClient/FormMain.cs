using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System.Reflection;
using CareySoft.FormObject;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        struct NavBarItemTag
        {
            public string AssemblyName;
            public string AssemblyDll;
            public string ItemText;
            public string Memo;
            public NavBarItemTag(string text, string name, string dll, string memo)
            {
                ItemText = text;
                AssemblyName = name;
                AssemblyDll = dll;
                Memo = memo;
            }
        }

        private int m_ConnectDBFailTime = 0;

        private DevExpress.XtraNavBar.ViewInfo.NavBarHintInfo m_MouseMovingControlObject = null; //鼠标正在哪个控件

        private DevExpress.XtraNavBar.ViewInfo.NavBarHintInfo m_MouseSelectControlObject = null;

        public FormMain()
        {
            InitializeComponent();
        }
        
        private void LoadNav() {
            navBarControl1.Groups.Clear();
            //List<Model.T_BASE_UNITTYPEModel> unittypes = Access.Unit.GetAllUnitTypeModel();
            //if (unittypes.Count == 0)
            //{
            //    if (m_ConnectDBFailTime == 3) {
            //        timer1.Enabled = false;
            //    }
            //    m_ConnectDBFailTime++;
            //}
            //else {
            //    if (!timer1.Enabled) {
            //        timer1.Enabled = true;
            //    }
            //    m_ConnectDBFailTime = 0;
            //}
            
            NavBarGroup nb2 = new NavBarGroup("数据源");
            List<Model.T_BASE_SJYPZModel> sjys = Access.DataSource.GetAllSJYPZ();
            foreach (Model.T_BASE_SJYPZModel mm in sjys)
            {
                NavBarItem ni = new NavBarItem(mm.PZMC);
                NavBarItemTag nbt = new NavBarItemTag(mm.PZMC, "Careysoft.Dotnet.Tools.SqlData.ManageClient.DataSource.FormMain", "Careysoft.Dotnet.Tools.SqlData.ManageClient.exe", mm.PZBM);
                ni.Tag = nbt;
                ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
                navBarControl1.Items.Add(ni);
                NavBarItemLink nil = new NavBarItemLink(ni);
                nb2.ItemLinks.Add(nil);
            }
            nb2.Expanded = true;
            navBarControl1.Groups.Add(nb2);

            NavBarGroup nb3 = new NavBarGroup("任务组");
            List<Model.T_D_TASK_MSTModel> tasks = Access.Task.GetAllTask();
            foreach (Model.T_D_TASK_MSTModel mm in tasks) {
                NavBarItem ni = new NavBarItem(mm.TASKNAME);
                NavBarItemTag nbt = new NavBarItemTag(mm.TASKNAME, "Careysoft.Dotnet.Tools.SqlData.ManageClient.Task.FormMain", "Careysoft.Dotnet.Tools.SqlData.ManageClient.exe", mm.ID);
                ni.Tag = nbt;
                ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
                navBarControl1.Items.Add(ni);
                NavBarItemLink nil = new NavBarItemLink(ni);
                nb3.ItemLinks.Add(nil);
            }
            nb3.Expanded = true;
            navBarControl1.Groups.Add(nb3);

            List<Model.T_BASE_UNITTYPEModel> unittypes = Access.UnitType.GetUnitTypeList();
            List<Model.T_D_SQLDATA_MSTModel> sqlDatas = Access.SqlData.GetAllSqlDataList();
            foreach (Model.T_BASE_UNITTYPEModel m in unittypes)
            {
                NavBarGroup nb = new NavBarGroup(m.LXMC);
                nb.Tag = m.LXBM;
                List<Model.T_D_SQLDATA_MSTModel> slist = sqlDatas.FindAll(delegate(Model.T_D_SQLDATA_MSTModel mm) { return mm.UNITTYPEID == m.LXBM; });
                foreach (Model.T_D_SQLDATA_MSTModel mm in slist)
                {
                    NavBarItem ni = new NavBarItem(mm.SQLDATANAME);
                    NavBarItemTag nbt = new NavBarItemTag(mm.SQLDATANAME, "Careysoft.Dotnet.Tools.SqlData.ManageClient.SqlData.FormMain", "Careysoft.Dotnet.Tools.SqlData.ManageClient.exe", mm.ID);
                    ni.Tag = nbt;
                    ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
                    navBarControl1.Items.Add(ni);
                    NavBarItemLink nil = new NavBarItemLink(ni);
                    if (mm.SFJY == 1)
                    {
                        nil.Item.Appearance.ForeColor = Color.DarkGray;
                    }
                    if (mm.SQLDATANAME.IndexOf("(") > 0)
                    {
                        nil.Item.Appearance.ForeColor = Color.FromArgb(255, 128, 128);
                    }
                    nb.ItemLinks.Add(nil);
                }
                nb.Expanded = true;
                navBarControl1.Groups.Add(nb);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            navBarControl1.Width = 250;
            LoadNav();
            timer1.Enabled = true;
        }

        /// <summary>
        /// 查找子窗体
        /// </summary>
        /// <param name="formtext"></param>
        /// <returns></returns>
        private bool FindForm(string formtag)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Tag.ToString() == formtag)
                {
                    f.Activate();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 点击NavBarItem显示窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowForm(object sender, NavBarLinkEventArgs e)
        {
            NavBarItem item = sender as NavBarItem;
            NavBarItemTag t = (NavBarItemTag)item.Tag;
            if (String.IsNullOrEmpty(t.AssemblyDll) || String.IsNullOrEmpty(t.AssemblyName))
            {
                return;
            }

            if (!FindForm(t.Memo))
            {
                try
                {
                    string assemblyName = t.AssemblyName; //"OrderList.FormOrderList";
                    Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + t.AssemblyDll);//需要使用绝对目录
                    Type type = assembly.GetType(assemblyName);
                    object obj = Activator.CreateInstance(type);
                    FObject f = (FObject)obj;
                    f.Text = t.ItemText;
                    f.EventSendMessageToFormMain += new EventHandler(f_EventSendMessageToFormMain);
                    f.Memo = t.Memo;
                    f.Tag = t.Memo;//Tag;
                    f.MdiParent = this;
                    f.ShowMessage();
                    f.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void f_EventSendMessageToFormMain(object sender, EventArgs e)
        {
            LoadNav();
            if (sender != null)
            {
                string formTag = (sender as CareySoft.FormObject.FObject).Tag.ToString();
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Tag.ToString() == formTag)
                    {
                        f.Close();
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            LoadNav();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAddDataSource f = new FormAddDataSource();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadNav();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddUnitType f = new FormAddUnitType();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadNav();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            if (XtraMessageBox.Show("您确认要退出Sql Data?", "信息提示", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes) {
                timer1.Enabled = true;
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNav();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem1_1.Enabled = false;
            toolStripMenuItem1_2.Enabled = false;
            toolStripMenuItem1_3.Enabled = false; 
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem4.Enabled = false;
            toolStripMenuItem5.Enabled = false;
            m_MouseSelectControlObject = m_MouseMovingControlObject;
            if (m_MouseMovingControlObject == null) {
                toolStripMenuItem1.Enabled = true;
                toolStripMenuItem1_1.Enabled = true;
            }
            else if (m_MouseMovingControlObject.ObjectType.ToString().ToUpper() == "GROUP") {
                DevExpress.XtraNavBar.NavBarGroup group = m_MouseMovingControlObject.HintObject as DevExpress.XtraNavBar.NavBarGroup;
                if (group.Caption == "数据源")
                {
                    toolStripMenuItem2.Enabled = true;
                }
                else if (group.Caption == "任务组")
                {
                    toolStripMenuItem5.Enabled = true;
                }
                else
                {
                    toolStripMenuItem4.Enabled = true;
                    toolStripMenuItem1.Enabled = true;
                    toolStripMenuItem1_2.Enabled = true;
                    toolStripMenuItem1_3.Enabled = true;
                }
            }
        }

        private void navBarControl1_GetHint(object sender, NavBarGetHintEventArgs e)
        {
            m_MouseMovingControlObject = e.HintInfo;
        }

        private void navBarControl1_MouseLeave(object sender, EventArgs e)
        {
            m_MouseMovingControlObject = null;
        }

        private void toolStripMenuItem1_3_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("你确定要删除该分组", "信息提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                DevExpress.XtraNavBar.NavBarGroup group = m_MouseSelectControlObject.HintObject as DevExpress.XtraNavBar.NavBarGroup;
                string id = group.Tag.ToString();
                if (Access.UnitType.UnitTypeDel(id)) {
                    LoadNav();
                }
            }
        }

        private void toolStripMenuItem1_2_Click(object sender, EventArgs e)
        {
            DevExpress.XtraNavBar.NavBarGroup group = m_MouseSelectControlObject.HintObject as DevExpress.XtraNavBar.NavBarGroup;
            string id = group.Tag.ToString();
            FormAddUnitType f = new FormAddUnitType(id);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                LoadNav();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DevExpress.XtraNavBar.NavBarGroup group = m_MouseSelectControlObject.HintObject as DevExpress.XtraNavBar.NavBarGroup;
            string id = group.Tag.ToString();
            FormAddSqlData f = new FormAddSqlData(id);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                LoadNav();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormAddTask f = new FormAddTask();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                LoadNav();
            }
        }
    }
}