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
    public partial class FormSelectParameter : CareySoft.FormObject.FormShowDialogObject
    {
        public Model.T_D_SQLDATA_SLVModel SelectModel { get; set; }
        public FormSelectParameter()
        {
            InitializeComponent();
        }

        public FormSelectParameter(string sqlDataId)
        {
            InitializeComponent();
            gridControl1.DataSource = Access.SqlData.GetSqlDataParameterFromSqlDataId(sqlDataId);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Model.T_D_SQLDATA_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_SQLDATA_SLVModel;
            if (model == null)
            {
                return;
            }
            SelectModel = model;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}