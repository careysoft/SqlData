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
            List<Model.T_BASE_UNITTYPEModel> models = Access.UnitType.GetSJYPZUnitType();
            foreach (Model.T_BASE_UNITTYPEModel model in models)
            {
                txt_GROUP.Properties.Items.Add(model);
            }
        }

        public FormSelectSJY(string sjyid)
        {
            InitializeComponent();
            Model.T_BASE_SJYPZModel sjy = Access.DataSource.GetSJYPZFromBM(sjyid);
            List<Model.T_BASE_UNITTYPEModel> models = Access.UnitType.GetSJYPZUnitType();
            int selectIndex = -1;
            for (int i = 0; i < models.Count; i++)
            {
                txt_GROUP.Properties.Items.Add(models[i]);
                if (models[i].LXBM == sjy.BL2) //BL2为数据源分组
                {
                    selectIndex = i;
                }
            }
            txt_GROUP.SelectedIndex = selectIndex;
            if (selectIndex != -1) {
                Model.T_BASE_UNITTYPEModel model = txt_GROUP.SelectedItem as Model.T_BASE_UNITTYPEModel;
                List<Model.T_BASE_SJYPZModel> sjys = Access.DataSource.GetSJYPZFromGroupId(model.LXBM);
                int rowHandle = 0;
                for (rowHandle = 0; rowHandle < sjys.Count; rowHandle++)
                {
                    if (sjys[rowHandle].PZBM == sjyid)
                    {
                        break;
                    }
                }
                gridControl1.DataSource = sjys;
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

        private void txt_GROUP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_GROUP.SelectedItem == null)
            {
                return;
            }
            Model.T_BASE_UNITTYPEModel model = txt_GROUP.SelectedItem as Model.T_BASE_UNITTYPEModel;
            gridControl1.DataSource = Access.DataSource.GetSJYPZFromGroupId(model.LXBM);
        }
    }
}