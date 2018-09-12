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
    public partial class FormSelectSJY : CareySoft.FormObject.FormShowDialogObject
    {
        public Model.T_BASE_SJYPZModel SelectModel { get; set; }
        public FormSelectSJY()
        {
            InitializeComponent();
            gridControl1.DataSource = Access.DataSource.GetAllSJYPZ();
        }

        public FormSelectSJY(string sjyid)
        {
            InitializeComponent();
            gridControl1.DataSource = Access.DataSource.GetAllSJYPZ();
            if (!String.IsNullOrEmpty(sjyid))
            {
                int rowHandle = 0;
                List<Model.T_BASE_SJYPZModel> models = gridControl1.DataSource as List<Model.T_BASE_SJYPZModel>;
                for (rowHandle = 0; rowHandle < models.Count; rowHandle++)
                {
                    if (models[rowHandle].PZBM == sjyid)
                    {
                        break;
                    }
                }
                gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Model.T_BASE_SJYPZModel model = gridView1.GetFocusedRow() as Model.T_BASE_SJYPZModel;
            if (model == null)
            {
                return;
            }
            SelectModel = model;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}