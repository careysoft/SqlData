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
            //List<Model.T_BASE_UNITModel> units = Access.Unit.GetAllUnitModel();
            //foreach (Model.T_BASE_UNITTYPEModel m in unittypes)
            //{
            //    NavBarGroup nb = new NavBarGroup(m.LXMC);
            //    List<Model.T_BASE_UNITModel> ulist = units.FindAll(delegate(Model.T_BASE_UNITModel mm) { return mm.UNITTYPE == m.LXBM; });
            //    foreach (Model.T_BASE_UNITModel mm in ulist)
            //    {
            //        NavBarItem ni = new NavBarItem(mm.UNITNAME);
            //        NavBarItemTag nbt = new NavBarItemTag(mm.UNITNAME, "Elane.Jgzb.DPS.V2.ManageSystem.Unit.FormMain", "Elane.Jgzb.DPS.V2.ManageSystem.Unit.dll", mm.ID);
            //        ni.Tag = nbt;
            //        ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
            //        navBarControl1.Items.Add(ni);
            //        NavBarItemLink nil = new NavBarItemLink(ni);
            //        if (mm.SFSC == 1)
            //        {
            //            nil.Item.Appearance.ForeColor = Color.DarkGray;
            //        }
            //        if (mm.UNITNAME.IndexOf("(") > 0)
            //        {
            //            nil.Item.Appearance.ForeColor = Color.FromArgb(255, 128, 128);
            //        }
            //        nb.ItemLinks.Add(nil);
            //    }
            //    nb.Expanded = true;
            //    navBarControl1.Groups.Add(nb);
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
            //FormAddUnit f = new FormAddUnit();
            //if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            //    LoadNav();
            //}
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
    }
}