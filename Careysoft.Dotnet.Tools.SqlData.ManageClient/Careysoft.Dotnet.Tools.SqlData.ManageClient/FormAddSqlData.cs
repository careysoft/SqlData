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
    public partial class FormAddSqlData : CareySoft.FormObject.FormShowFormObject
    {
        private string m_UnitTypeId = "";

        public FormAddSqlData()
        {
            InitializeComponent();
            Width = (int)((double)Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            Height = (int)((double)Screen.PrimaryScreen.WorkingArea.Height * 0.8); 
        }

        public FormAddSqlData(string unitTypeId)
        {
            m_UnitTypeId = unitTypeId;
            InitializeComponent();
            Width = (int)((double)Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            Height = (int)((double)Screen.PrimaryScreen.WorkingArea.Height * 0.8);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txt_name.Text))
            //{
            //    XtraMessageBox.Show("配置名称不能为空");
            //    txt_name.Focus();
            //    return;
            //}
            //if (String.IsNullOrEmpty(txt_ip.Text)) {
            //    XtraMessageBox.Show("IP地址不能为空");
            //    txt_ip.Focus();
            //    return;
            //}
            //if (String.IsNullOrEmpty(txt_port.Text))
            //{
            //    XtraMessageBox.Show("端口不能为空");
            //    txt_port.Focus();
            //    return;
            //}
            //if (String.IsNullOrEmpty(txt_sjylx.Text))
            //{
            //    XtraMessageBox.Show("请选择数据源类型");
            //    txt_sjylx.Focus();
            //    return;
            //}
            //if (String.IsNullOrEmpty(txt_sid.Text))
            //{
            //    XtraMessageBox.Show("数据源不能为空");
            //    txt_sid.Focus();
            //    return;
            //}
            //if (String.IsNullOrEmpty(txt_uid.Text))
            //{
            //    XtraMessageBox.Show("用户名不能为空");
            //    txt_uid.Focus();
            //    return;
            //}
            //if (String.IsNullOrEmpty(txt_pass.Text))
            //{
            //    XtraMessageBox.Show("密码不能为空");
            //    txt_pass.Focus();
            //    return;
            //}
            //if (!Careysoft.Basic.Public.RegexMatch.IsIpAddress(txt_ip.Text))
            //{
            //    XtraMessageBox.Show("IP地址输入不正确");
            //    txt_ip.Focus();
            //    return;
            //}
            //if (!Careysoft.Basic.Public.RegexMatch.IsZZS(txt_port.Text))
            //{
            //    XtraMessageBox.Show("端口号输入不正确");
            //    txt_port.Focus();
            //    return;
            //}
            
            //Model.T_BASE_SJYPZModel model = new Model.T_BASE_SJYPZModel();
            //model.PZMC = txt_name.Text;
            //model.SJIP = txt_ip.Text;
            //model.SJPORT = txt_port.Text;
            //model.SJSID = txt_sid.Text;
            //model.SJUSERID = txt_uid.Text;
            //model.SJPASSWORD = txt_pass.Text;
            //model.BL1 = txt_sjylx.SelectedIndex.ToString();
            //if (Access.DataSource.SJYPZAdd(model))
            //{
            //    DialogResult = System.Windows.Forms.DialogResult.OK;
            //}
            //else {
            //    XtraMessageBox.Show("新增失败");
            //}
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_SJYID.Text))
            {
                XtraMessageBox.Show("数据源不能为空");
                txt_SJYID.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_SQLDATANAME.Text))
            {
                XtraMessageBox.Show("SqlData名称不能为空");
                txt_SQLDATANAME.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_SQLTYPE.Text))
            {
                XtraMessageBox.Show("SqlData类型不能为空");
                txt_SQLTYPE.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_SQL.Text))
            {
                XtraMessageBox.Show("SQL不能为空");
                txt_SQL.Focus();
                return;
            }
            string errorInfo = "";
            List<DataTable> models = Access.SqlData.GetDataSet((txt_SJYID.Tag as Model.T_BASE_SJYPZModel), txt_SQL.Text, ref errorInfo);
        }

        private void txt_SJYID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sjyid = "";
            if (txt_SJYID.Tag != null) {
                sjyid = (txt_SJYID.Tag as Model.T_BASE_SJYPZModel).PZBM;
            }
            FormSelectSJY f = new FormSelectSJY(sjyid);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txt_SJYID.Text = f.SelectModel.PZMC;
                txt_SJYID.Tag = f.SelectModel;
            }
        }
    }
}