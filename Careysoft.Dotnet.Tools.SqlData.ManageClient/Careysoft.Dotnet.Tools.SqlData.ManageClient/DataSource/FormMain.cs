using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient.DataSource
{
    public partial class FormMain : CareySoft.FormObject.FObject
    {
        private Model.T_BASE_UNITTYPEModel m_GroupModel = new Model.T_BASE_UNITTYPEModel();
        private Model.T_BASE_SJYPZModel m_SelectSJYModel = new Model.T_BASE_SJYPZModel();

        /// <summary>
        /// 设置对话框值
        /// </summary>
        /// <param name="sjypm"></param>
        private void SetValue(string sjypm) {
            m_SelectSJYModel = Access.DataSource.GetSJYPZFromBM(sjypm);
            txt_name.Text = m_SelectSJYModel.PZMC;
            txt_ip.Text = m_SelectSJYModel.SJIP;
            txt_port.Text = m_SelectSJYModel.SJPORT;
            txt_sid.Text = m_SelectSJYModel.SJSID;
            txt_uid.Text = m_SelectSJYModel.SJUSERID;
            txt_pass.Text = m_SelectSJYModel.SJPASSWORD;
            txt_sjylx.SelectedIndex = Convert.ToInt32(m_SelectSJYModel.BL1);
        }

        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            m_GroupModel = Access.UnitType.GetUnitTypeModel(m_Memo);
            List<Model.T_BASE_SJYPZModel> sjys = Access.DataSource.GetSJYPZFromGroupId(m_Memo);
            gridControl1.DataSource = sjys;
            if (sjys.Count > 0)
            {
                SetValue(sjys[0].PZBM);
            }
            else {
                Careysoft.Dev.Public.Function.EnableButton(false, Controls);
            }
            base.OnLoad(e);
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            FormPass f = new FormPass();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_pass.Text = f.PASSWORD;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_name.Text))
            {
                XtraMessageBox.Show("配置名称不能为空");
                txt_name.Focus();
                return;
            }
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
            m_SelectSJYModel.PZMC = txt_name.Text;
            m_SelectSJYModel.SJIP = txt_ip.Text;
            m_SelectSJYModel.SJPORT = txt_port.Text;
            m_SelectSJYModel.SJSID = txt_sid.Text;
            m_SelectSJYModel.SJUSERID = txt_uid.Text;
            m_SelectSJYModel.SJPASSWORD = txt_pass.Text;
            m_SelectSJYModel.BL1 = txt_sjylx.SelectedIndex.ToString();
            if (Access.DataSource.SJYPZEdit(m_SelectSJYModel))
            {
                XtraMessageBox.Show("修改成功");
                gridView1.SetFocusedRowCellValue("PZMC", m_SelectSJYModel.PZMC);
            }
            else
            {
                XtraMessageBox.Show("修改失败");
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

            if (Access.DataSource.SJYConnected(txt_ip.Text, txt_port.Text, txt_sjylx.SelectedIndex.ToString(), txt_sid.Text, txt_uid.Text, Careysoft.Basic.Public.DES.Decrypt(txt_pass.Text, "EPad@)!!")))
            {
                XtraMessageBox.Show("连接成功");
            }
            else
            {
                XtraMessageBox.Show("连接失败");
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("是否要删除该数据源?", "信息提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                if (Access.DataSource.SJYPDel(m_SelectSJYModel.PZBM))
                {
                    //SetMessageToFormain(this, e);
                    int rowHandle = gridView1.FocusedRowHandle;
                    List<Model.T_BASE_SJYPZModel> sjys = Access.DataSource.GetSJYPZFromGroupId(m_Memo);
                    gridControl1.DataSource = sjys;
                    gridView1.FocusedRowHandle = rowHandle - 1;
                    if (sjys.Count == 0) {
                        Careysoft.Dev.Public.Function.EnableButton(false, Controls);
                        Careysoft.Dev.Public.Function.ClearText(Controls);
                    }
                }
                else {
                    XtraMessageBox.Show("删除失败");
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Model.T_BASE_SJYPZModel model = gridView1.GetFocusedRow() as Model.T_BASE_SJYPZModel;
            if (model == null) {
                return;
            }
            SetValue(model.PZBM);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddDataSource f = new FormAddDataSource(m_GroupModel.LXBM);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                List<Model.T_BASE_SJYPZModel> sjys = Access.DataSource.GetSJYPZFromGroupId(m_Memo);
                gridControl1.DataSource = sjys;
                if (sjys.Count == 1) {
                    Careysoft.Dev.Public.Function.EnableButton(true, Controls);
                }
                gridView1.FocusedRowHandle = sjys.Count - 1;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            List<Model.T_BASE_SJYPZModel> sjys = Access.DataSource.GetSJYPZFromGroupId(m_Memo);
            gridControl1.DataSource = sjys;
            gridView1.FocusedRowHandle = rowHandle;
            if (sjys.Count > 0) {
                Careysoft.Dev.Public.Function.EnableButton(true, Controls);
            }
        }
    }
}