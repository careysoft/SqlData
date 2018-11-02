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
using WebSocket4Net;
using System.Configuration;
using Careysoft.Dotnet.Server.MessageServer.Model;
using System.Threading;

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
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            navBarControl1.Width = 250;
            InitFormClass();
            InitSubMenu();
            LoadNav();
            ConnectAutoServer();
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
            if (XtraMessageBox.Show("您确认要退出Sql Data?", "信息提示", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes) {
                CloseAutoServer();
                e.Cancel = true;
            }
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

        #region 连接自动处理服务
        private WebSocket4Net.WebSocket m_WebSocketClient = null;

        private string m_PrivateKey = "";

        private bool m_AutoServerConnected = false;

        private Thread m_TimerThread = null;

        private int m_ConnectingCount = 5;

        private bool m_Checked = true;

        private void ConnectAutoServer()
        {
            m_WebSocketClient = new WebSocket4Net.WebSocket(string.Format("ws://{0}:{1}/websocket", ConfigurationManager.AppSettings["MessageIpAddr"], ConfigurationManager.AppSettings["MessagePort"]), "basic", WebSocketVersion.Rfc6455);
            m_WebSocketClient.MessageReceived += new EventHandler<MessageReceivedEventArgs>(m_WebSocketClient_MessageReceived);
            m_WebSocketClient.Closed += new EventHandler(m_WebSocketClient_Closed);
            m_WebSocketClient.Open();
            Thread.Sleep(1000);
            if (m_WebSocketClient.State != WebSocketState.Open)
            {
                lab_connection.Caption = "未能连接到消息服务器";
                lab_connection.Appearance.ForeColor = Color.Tomato;
            }
        }


        private void CloseAutoServer() {
            m_WebSocketClient.Close();
            if (m_TimerThread != null)
            {
                m_TimerThread.Abort();
                m_TimerThread = null;
            }
        }

        void m_WebSocketClient_Closed(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    lab_connection.Appearance.ForeColor = Color.Coral;
                    lab_connection.Caption = "未能连接到消息服务器";
                    m_Checked = false;
                });
            }
        }

        void m_WebSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageModel model = new MessageModel(e.Message);
            switch (model.Command)
            {
                case EnumCommand.AuthQuestion:
                    m_WebSocketClient.Send(EnumCommand.AuthUser + " " + ConfigurationManager.AppSettings["ClientCode"] + "$aaa");
                    break;
                case EnumCommand.AuthAccept:
                    m_PrivateKey = Careysoft.Basic.Public.DES.Decrypt(model.Body, DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
                    StartTmmerCheck();
                    break;
                case EnumCommand.MessagePoint:
                    string body = model.Body;
                    body = Careysoft.Basic.Public.DES.Decrypt(body, m_PrivateKey);
                    MessageBodyModel msgModel = Careysoft.Basic.Public.ObjectSerializer.Xml16ToInstances<MessageBodyModel>(body);
                    DoMessagePoint(msgModel);
                    //发送
                    break;
            }
        }

        private void DoMessagePoint(MessageBodyModel msgModel)
        {
            Model.EnumServerMessage messageContent = (Model.EnumServerMessage)Enum.Parse(typeof(Model.EnumServerMessage), msgModel.MessageContent);
            m_AutoServerConnected = true;
            switch (messageContent)
            {
                case Model.EnumServerMessage.StateWorked:
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                lab_connection.Appearance.ForeColor = Color.LightGreen;
                                lab_connection.Caption = "自动服务状态:正常运行";
                                m_Checked = false;
                            });
                        }
                    }
                    break;
                case Model.EnumServerMessage.StateNoWork:
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                lab_connection.Appearance.ForeColor = Color.Coral;
                                lab_connection.Caption = "自动服务状态:服务停止";
                                m_Checked = false;
                            });
                        }
                    }
                    break;
                case Model.EnumServerMessage.StateShutdown:
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                lab_connection.Appearance.ForeColor = Color.Coral;
                                lab_connection.Caption = "自动服务状态:服务停止";
                                m_Checked = false;
                            });
                        }
                    }
                    break;
            }
        }

        private void StartTmmerCheck()
        {
            m_Checked = true;
            m_AutoServerConnected = false;
            m_TimerThread = new Thread(TimmerCheck);
            m_TimerThread.Start();
        }

        private void TimmerCheck()
        {
            while (m_Checked)
            {
                if (!m_AutoServerConnected)
                {
                    MessageBodyModel bodyModel = new MessageBodyModel();
                    bodyModel.Header.TargetCode = ConfigurationManager.AppSettings["AutoExecuteClientCode"];
                    bodyModel.Header.SourceCode = ConfigurationManager.AppSettings["ClientCode"];
                    bodyModel.Header.MessageType = EnumMessageType.Point;
                    bodyModel.Header.TagetType = EnumClientType.Normal;
                    bodyModel.MessageContentType = EnumMessageContentType.Text;
                    bodyModel.MessageContent = Model.EnumServerMessage.QueryState.ToString();
                    string sendMessage = Careysoft.Basic.Public.ObjectSerializer.InstancesToXML<MessageBodyModel>(bodyModel);
                    sendMessage = Careysoft.Basic.Public.DES.Encrypt(sendMessage, m_PrivateKey);
                    MessageModel model2 = new MessageModel(EnumCommand.MessagePoint, sendMessage);
                    m_WebSocketClient.Send(model2.ToString());
                    m_ConnectingCount--;
                    if (m_ConnectingCount == 0)
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                lab_connection.Appearance.ForeColor = Color.Tomato;
                                lab_connection.Caption = "自动服务状态:服务停止";
                                m_Checked = false;
                            });
                        }
                    }
                }
                Thread.Sleep(2000);
            }
        }
        #endregion
    }
}