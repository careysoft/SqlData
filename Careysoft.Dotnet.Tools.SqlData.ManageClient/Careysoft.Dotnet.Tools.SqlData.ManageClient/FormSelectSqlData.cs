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
    public partial class FormSelectSqlData : CareySoft.FormObject.FormShowDialogObject
    {
        private Model.T_D_SQLDATA_MSTModel m_SelectSqlData = new Model.T_D_SQLDATA_MSTModel();
        public Model.T_D_SQLDATA_MSTModel SelectSqlData {
            get { return m_SelectSqlData; }
            set { m_SelectSqlData = value; }
        }

        public FormSelectSqlData()
        {
            InitializeComponent();
            List<Model.T_BASE_UNITTYPEModel> models = Access.UnitType.GetSqlDataUnitType();
            foreach (Model.T_BASE_UNITTYPEModel model in models) {
                txt_GROUP.Properties.Items.Add(model);
            }
        }

        private void txt_GROUP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_GROUP.SelectedItem == null) {
                return;
            }
            Model.T_BASE_UNITTYPEModel model = txt_GROUP.SelectedItem as Model.T_BASE_UNITTYPEModel;
            gridControl1.DataSource = Access.SqlData.GetSqlDataListFromGroupId(model.LXBM).FindAll(delegate(Model.T_D_SQLDATA_MSTModel m) { return m.SFJY == 0; });
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Model.T_D_SQLDATA_MSTModel model = gridView1.GetFocusedRow() as Model.T_D_SQLDATA_MSTModel;
            if (model == null) {
                return;
            }
            m_SelectSqlData = model;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}