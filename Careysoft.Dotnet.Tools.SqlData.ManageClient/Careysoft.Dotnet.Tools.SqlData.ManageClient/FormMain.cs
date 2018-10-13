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
        class NavBarItemTag
        {
            public string AssemblyName;
            public string AssemblyDll;
            public string ItemText;
            public string Memo;
            public object Tag;
            public NavBarItemTag(string text, string name, string dll, string memo)
            {
                ItemText = text;
                AssemblyName = name;
                AssemblyDll = dll;
                Memo = memo;
                Tag = null;
            }

            public NavBarItemTag(string text, string name, string dll, string memo, object tag)
            {
                ItemText = text;
                AssemblyName = name;
                AssemblyDll = dll;
                Memo = memo;
                Tag = tag;
            }
        }

        private Dictionary<string, string> m_DicFromClass = new Dictionary<string, string>();

        private int m_ConnectDBFailTime = 0;

        private DevExpress.XtraNavBar.ViewInfo.NavBarHintInfo m_MouseMovingControlObject = null; //鼠标正在哪个控件

        private DevExpress.XtraNavBar.ViewInfo.NavBarHintInfo m_MouseSelectControlObject = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Event_SubItemClick(object sender, EventArgs e)
        {
            string tag = (sender as ToolStripMenuItem).Tag.ToString();
            if (tag == "REFRESH") {
                LoadNav(); //刷新
                return;
            }
            if (m_MouseSelectControlObject != null) {
                Model.T_BASE_UNITTYPEModel selectModel = new Model.T_BASE_UNITTYPEModel();
                if (m_MouseSelectControlObject.ObjectType.ToString().ToUpper() == "GROUP")
                {
                    var hitMenu = m_MouseSelectControlObject.HintObject as NavBarGroup;
                    selectModel = hitMenu.Tag as Model.T_BASE_UNITTYPEModel;
                }
                else if (m_MouseSelectControlObject.ObjectType.ToString().ToUpper() == "LINK")
                {
                    var hitMenu = m_MouseSelectControlObject.HintObject as NavBarItemLink;
                    selectModel = (hitMenu.Item.Tag as NavBarItemTag).Tag as Model.T_BASE_UNITTYPEModel;
                }
                if (String.IsNullOrEmpty(selectModel.LXBM)) {
                    return;
                }
                if (tag.Split('_').Length == 2)
                {
                    switch (tag.Split('_')[1])
                    {
                        case "0": //add
                            {
                                FormAddUnitType f = new FormAddUnitType();
                                f.FLXBM = selectModel.LXBM;
                                f.FL = tag.Split('_')[0];
                                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    LoadNav();
                                }
                                break;
                            }
                        case "1": //edit
                            {
                                FormAddUnitType f = new FormAddUnitType(selectModel.LXBM);
                                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    LoadNav();
                                    foreach (Form f2 in this.MdiChildren)
                                    {
                                        if (f2.Tag.ToString() == selectModel.LXBM)
                                        {
                                            f2.Text = f.LXMC;
                                        }
                                    }
                                }
                                break;
                            }
                        case "2": //del
                            {
                                if (XtraMessageBox.Show("您确认要删除'"+selectModel.LXMC+"'?", "信息提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                                    if (Access.UnitType.UnitTypeDel(selectModel.LXBM)) {
                                        LoadNav();
                                        foreach (Form f2 in this.MdiChildren)
                                        {
                                            if (f2.Tag.ToString() == selectModel.LXBM)
                                            {
                                                f2.Close();
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
        }

        private void InitFormClass() {
            m_DicFromClass.Add("SJPZ", "Careysoft.Dotnet.Tools.SqlData.ManageClient.DataSource.FormMain");
            m_DicFromClass.Add("DSWR", "Careysoft.Dotnet.Tools.SqlData.ManageClient.Task.FormMain");
            m_DicFromClass.Add("CXZX", "");
            m_DicFromClass.Add("SQLS", "Careysoft.Dotnet.Tools.SqlData.ManageClient.SqlData.FormMain"); 
        }

        private void InitSubMenu() {
            var groups = Access.UnitType.GetUnitTypeList();
            string[] subItemArray = {"新增(&A)","修改(&E)","删除(&D)" };
            foreach (var group in groups) {
                ToolStripMenuItem item = new ToolStripMenuItem(group.LXMC + "管理(&" + group.BL2.Substring(0, 1) + ")");
                item.Tag = group.BL2;
                for (int i = 0; i < subItemArray.Length; i++) {
                    ToolStripMenuItem subItem = new ToolStripMenuItem(subItemArray[i], null, Event_SubItemClick);
                    subItem.Tag = group.BL2 + "_" + i.ToString();
                    item.DropDownItems.Add(subItem);
                }
                contextMenuStrip1.Items.Add(item);
            }
            ToolStripSeparator split = new ToolStripSeparator();
            contextMenuStrip1.Items.Add(split);
            ToolStripMenuItem itemRefresh = new ToolStripMenuItem("刷新(&R)",null, Event_SubItemClick);
            itemRefresh.Tag = "REFRESH";
            contextMenuStrip1.Items.Add(itemRefresh);
        }

        private void LoadNav() {
            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            foreach (NavBarGroup nbg in navBarControl1.Groups) {
                dict.Add(nbg.Caption, nbg.Expanded);
            }
            navBarControl1.Groups.Clear();
            var groups = Access.UnitType.GetUnitTypeList();
            foreach (var group in groups) {
                NavBarGroup navGroup = new NavBarGroup(group.LXMC);
                navGroup.Tag = group;
                var subGroups = Access.UnitType.GetUnitTypeList(group.LXBM);
                foreach (var subGroup in subGroups) {
                    NavBarItem ni = new NavBarItem(subGroup.LXMC);
                    NavBarItemTag nbt = new NavBarItemTag(subGroup.LXMC, m_DicFromClass[group.BL2], "Careysoft.Dotnet.Tools.SqlData.ManageClient.exe", subGroup.LXBM, subGroup);
                    ni.Tag = nbt;
                    ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
                    navBarControl1.Items.Add(ni);
                    NavBarItemLink nil = new NavBarItemLink(ni);
                    navGroup.ItemLinks.Add(nil);
                }
                navGroup.Expanded = dict.ContainsKey(group.LXMC) ? dict[group.LXMC] : true; ;
                navBarControl1.Groups.Add(navGroup);
            }
            
            //NavBarGroup nb2 = new NavBarGroup("数据源");
            //List<Model.T_BASE_SJYPZModel> sjys = Access.DataSource.GetAllSJYPZ();
            //foreach (Model.T_BASE_SJYPZModel mm in sjys)
            //{
            //    NavBarItem ni = new NavBarItem(mm.PZMC);
            //    NavBarItemTag nbt = new NavBarItemTag(mm.PZMC, "Careysoft.Dotnet.Tools.SqlData.ManageClient.DataSource.FormMain", "Careysoft.Dotnet.Tools.SqlData.ManageClient.exe", mm.PZBM);
            //    ni.Tag = nbt;
            //    ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
            //    navBarControl1.Items.Add(ni);
            //    NavBarItemLink nil = new NavBarItemLink(ni);
            //    nb2.ItemLinks.Add(nil);
            //}
            //nb2.Expanded = dict.ContainsKey("数据源") ? dict["数据源"] : true;//true;
            //navBarControl1.Groups.Add(nb2);

            //NavBarGroup nb3 = new NavBarGroup("任务组");
            //List<Model.T_D_TASK_MSTModel> tasks = Access.Task.GetAllTask();
            //foreach (Model.T_D_TASK_MSTModel mm in tasks) {
            //    NavBarItem ni = new NavBarItem(mm.TASKNAME);
            //    NavBarItemTag nbt = new NavBarItemTag(mm.TASKNAME, "Careysoft.Dotnet.Tools.SqlData.ManageClient.Task.FormMain", "Careysoft.Dotnet.Tools.SqlData.ManageClient.exe", mm.ID);
            //    ni.Tag = nbt;
            //    ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
            //    navBarControl1.Items.Add(ni);
            //    NavBarItemLink nil = new NavBarItemLink(ni);
            //    nb3.ItemLinks.Add(nil);
            //}
            //nb3.Expanded = dict.ContainsKey("任务组") ? dict["任务组"] : true;
            //navBarControl1.Groups.Add(nb3);

            //List<Model.T_BASE_UNITTYPEModel> unittypes = Access.UnitType.GetUnitTypeList();
            //List<Model.T_D_SQLDATA_MSTModel> sqlDatas = Access.SqlData.GetAllSqlDataList();
            //foreach (Model.T_BASE_UNITTYPEModel m in unittypes)
            //{
            //    NavBarGroup nb = new NavBarGroup(m.LXMC);
            //    nb.Tag = m.LXBM;
            //    List<Model.T_D_SQLDATA_MSTModel> slist = sqlDatas.FindAll(delegate(Model.T_D_SQLDATA_MSTModel mm) { return mm.UNITTYPEID == m.LXBM; });
            //    foreach (Model.T_D_SQLDATA_MSTModel mm in slist)
            //    {
            //        NavBarItem ni = new NavBarItem(mm.SQLDATANAME);
            //        NavBarItemTag nbt = new NavBarItemTag(mm.SQLDATANAME, "Careysoft.Dotnet.Tools.SqlData.ManageClient.SqlData.FormMain", "Careysoft.Dotnet.Tools.SqlData.ManageClient.exe", mm.ID);
            //        ni.Tag = nbt;
            //        ni.LinkClicked += new NavBarLinkEventHandler(ShowForm);
            //        navBarControl1.Items.Add(ni);
            //        NavBarItemLink nil = new NavBarItemLink(ni);
            //        if (mm.SFJY == 1)
            //        {
            //            nil.Item.Appearance.ForeColor = Color.DarkGray;
            //        }
            //        if (mm.SQLDATANAME.IndexOf("(") > 0)
            //        {
            //            nil.Item.Appearance.ForeColor = Color.FromArgb(255, 128, 128);
            //        }
            //        nb.ItemLinks.Add(nil);
            //    }
            //    nb.Expanded = dict.ContainsKey(m.LXMC) ? dict[m.LXMC] : true; ;
            //    navBarControl1.Groups.Add(nb);
            //}
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            navBarControl1.Width = 250;
            InitFormClass();
            InitSubMenu();
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
            //LoadNav();
        }

        /// <summary>
        /// 递归让所有子菜单enable
        /// </summary>
        /// <param name="menuItems"></param>
        private void EnableItemRecursion(ToolStripItemCollection menuItems, bool enableVal) {
            foreach (var menu in menuItems) {
                if (menu.GetType().ToString().IndexOf("ToolStripMenuItem") >= 0)
                {
                    (menu as ToolStripMenuItem).Enabled = enableVal;
                    EnableItemRecursion((menu as ToolStripMenuItem).DropDownItems, enableVal);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            EnableItemRecursion(contextMenuStrip1.Items, false);
            contextMenuStrip1.Items[contextMenuStrip1.Items.Count - 1].Enabled = true;
            m_MouseSelectControlObject = m_MouseMovingControlObject;
            if (m_MouseMovingControlObject != null) {
                if (m_MouseMovingControlObject.ObjectType.ToString().ToUpper() == "GROUP") {
                    var hitMenu = m_MouseMovingControlObject.HintObject as NavBarGroup;
                    string tag=(hitMenu.Tag as Model.T_BASE_UNITTYPEModel).BL2;
                    foreach (var menu in contextMenuStrip1.Items)
                    {
                        if (menu.GetType().ToString().IndexOf("ToolStripMenuItem") >= 0 && (menu as ToolStripMenuItem).Tag.ToString() == tag)
                        {
                            (menu as ToolStripMenuItem).Enabled = true;
                            (menu as ToolStripMenuItem).DropDownItems[0].Enabled = true;
                        }
                    }
                }
                else if (m_MouseMovingControlObject.ObjectType.ToString().ToUpper() == "LINK") {
                    var hitMenu = m_MouseMovingControlObject.HintObject as NavBarItemLink;
                    string tag = ((hitMenu.Item.Tag as NavBarItemTag).Tag as Model.T_BASE_UNITTYPEModel).BL2;
                    foreach (var menu in contextMenuStrip1.Items)
                    {
                        if (menu.GetType().ToString().IndexOf("ToolStripMenuItem") >= 0 && (menu as ToolStripMenuItem).Tag.ToString() == tag)
                        {
                            (menu as ToolStripMenuItem).Enabled = true;
                            (menu as ToolStripMenuItem).DropDownItems[1].Enabled = true;
                            (menu as ToolStripMenuItem).DropDownItems[2].Enabled = true; 
                        }
                    }
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

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string errorInfo = Careysoft.Basic.Public.Log.GetTodayErrorInfo(Encoding.UTF8);
            Careysoft.Dev.Public.FormShowMemo f = new Dev.Public.FormShowMemo("错误日志", errorInfo);
            f.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            LoadNav();
        }
    }
}