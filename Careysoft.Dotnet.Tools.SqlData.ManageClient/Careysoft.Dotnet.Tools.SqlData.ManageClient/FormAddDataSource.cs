using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    public partial class FormAddDataSource : CareySoft.FormObject.FormShowDialogObject
    {
        private string m_SjyGroup = "";
        public FormAddDataSource()
        {
            InitializeComponent();
        }

        public FormAddDataSource(string sjyGroup)
        {
            m_SjyGroup = sjyGroup;
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_name.Text))
            {
                XtraMessageBox.Show("配置名称不能为空");
                txt_name.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_ip.Text)) {
                XtraMessageBox.Show("IP地址不能为空");
                txt_ip.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_port.Text))
            {
                XtraMessageBox.Show("端口不能为空");
                txt_port.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_sjylx.Text))
            {
                XtraMessageBox.Show("请选择数据源类型");
                txt_sjylx.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_sid.Text))
            {
                XtraMessageBox.Show("数据源不能为空");
                txt_sid.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_uid.Text))
            {
                XtraMessageBox.Show("用户名不能为空");
                txt_uid.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_pass.Text))
            {
                XtraMessageBox.Show("密码不能为空");
                txt_pass.Focus();
                return;
            }
            if (!Careysoft.Basic.Public.RegexMatch.IsIpAddress(txt_ip.Text))
            {
                XtraMessageBox.Show("IP地址输入不正确");
                txt_ip.Focus();
                return;
            }
            if (!Careysoft.Basic.Public.RegexMatch.IsZZS(txt_port.Text))
            {
                XtraMessageBox.Show("端口号输入不正确");
                txt_port.Focus();
                return;
            }
            
            Model.T_BASE_SJYPZModel model = new Model.T_BASE_SJYPZModel();
            model.PZMC = txt_name.Text;
            model.SJIP = txt_ip.Text;
            model.SJPORT = txt_port.Text;
            model.SJSID = txt_sid.Text;
            model.SJUSERID = txt_uid.Text;
            model.SJPASSWORD = txt_pass.Text;
            model.BL1 = txt_sjylx.SelectedIndex.ToString();
            model.BL2 = m_SjyGroup;
            if (Access.DataSource.SJYPZAdd(model))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else {
                XtraMessageBox.Show("新增失败");
            }
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            FormPass f = new FormPass();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_pass.Text = f.PASSWORD;
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_ip.Text))
            {
                XtraMessageBox.Show("IP地址不能为空");
                txt_ip.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_port.Text))
            {
                XtraMessageBox.Show("端口不能为空");
                txt_port.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_sid.Text))
            {
                XtraMessageBox.Show("数据源不能为空");
                txt_sid.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_sjylx.Text))
            {
                XtraMessageBox.Show("请选择数据源类型");
                txt_sjylx.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_uid.Text))
            {
                XtraMessageBox.Show("用户名不能为空");
                txt_uid.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_pass.Text))
            {
                XtraMessageBox.Show("密码不能为空");
                txt_pass.Focus();
                return;
            }
            if (!Careysoft.Basic.Public.RegexMatch.IsIpAddress(txt_ip.Text))
            {
                XtraMessageBox.Show("IP地址输入不正确");
                txt_ip.Focus();
                return;
            }
            if (!Careysoft.Basic.Public.RegexMatch.IsZZS(txt_port.Text))
            {
                XtraMessageBox.Show("端口号输入不正确");
                txt_port.Focus();
                return;
            }
            if (Access.DataSource.SJYConnected(txt_ip.Text, txt_port.Text, txt_sjylx.SelectedIndex.ToString(), txt_sid.Text, txt_uid.Text, Careysoft.Basic.Public.DES.Decrypt(txt_pass.Text, "EPad@)!!")))
            {
                XtraMessageBox.Show("连接成功");
            }
            else {
                XtraMessageBox.Show("连接失败");
            }
        }
    }
}