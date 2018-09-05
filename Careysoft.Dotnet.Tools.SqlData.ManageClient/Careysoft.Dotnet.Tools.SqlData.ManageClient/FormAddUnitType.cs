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
    public partial class FormAddUnitType : CareySoft.FormObject.FormShowDialogObject
    {
        private Model.T_BASE_UNITTYPEModel m_UnitType = new Model.T_BASE_UNITTYPEModel();

        public FormAddUnitType()
        {
            InitializeComponent();
        }

        public FormAddUnitType(string id)
        {
            InitializeComponent();
            m_UnitType = Access.UnitType.GetUnitTypeModel(id);
            Text = "编辑分组";
            txt_lxmc.Text = m_UnitType.LXMC;
            txt_bl1.Text = m_UnitType.BL1;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_lxmc.Text))
            {
                XtraMessageBox.Show("分组名称不能为空");
                txt_lxmc.Focus();
                return;
            }
            if (!Careysoft.Basic.Public.RegexMatch.IsZZS(txt_bl1.Text))
            {
                XtraMessageBox.Show("排序号不正确");
                txt_bl1.Focus();
                return;
            }
            if (Text == "新增分组")
            {
                m_UnitType = new Model.T_BASE_UNITTYPEModel();
                m_UnitType.LXMC = txt_lxmc.Text;
                m_UnitType.BL1 = txt_bl1.Text;
                if (Access.UnitType.UnitTypeAdd(m_UnitType))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("新增失败");
                }
            }
            else {
                m_UnitType.LXMC = txt_lxmc.Text;
                m_UnitType.BL1 = txt_bl1.Text;
                if (Access.UnitType.UnitTypeEdit(m_UnitType))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("编辑失败");
                }
            }
            
        }
    }
}