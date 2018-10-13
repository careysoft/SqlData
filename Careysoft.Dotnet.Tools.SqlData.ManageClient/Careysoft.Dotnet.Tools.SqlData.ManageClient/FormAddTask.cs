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
    public partial class FormAddTask : CareySoft.FormObject.FormShowDialogObject
    {
        public FormAddTask()
        {
            InitializeComponent();
            txt_BEGINDATE.DateTime = DateTime.Now;
            txt_BEGINTIME.Time = DateTime.Now;
            gridControl1.DataSource = new List<Model.T_D_TASK_SLVModel>();
            gridControl2.DataSource = new List<Model.T_S_TASK_SLV_SLVModel>();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_TASKNAME.Text)) {
                xtraTabControl1.SelectedTabPageIndex = 0;
                XtraMessageBox.Show("任务名称不能为空");
                txt_TASKNAME.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txt_INTERVAL.Text))
            {
                xtraTabControl1.SelectedTabPageIndex = 0;
                XtraMessageBox.Show("间隔时间不能为空");
                txt_INTERVAL.Focus();
                return;
            }
            if (Careysoft.Basic.Public.BConvert.ToInt(txt_INTERVAL.Text) <= 0) {
                xtraTabControl1.SelectedTabPageIndex = 0;
                XtraMessageBox.Show("间隔时间需要大于0");
                txt_INTERVAL.Focus();
                return;
            }
            List<Model.T_D_TASK_SLVModel> models = gridControl1.DataSource as List<Model.T_D_TASK_SLVModel>;
            if (models.Count == 0) {
                XtraMessageBox.Show("请添加SqlData");
                xtraTabControl1.SelectedTabPageIndex = 1;
                return;
            }
            foreach (Model.T_D_TASK_SLVModel model in models) {
                if (model.TASKTYPE == "0")
                {
                    if (String.IsNullOrEmpty(model.OUTPUTTYPE) || String.IsNullOrEmpty(model.OUTPUTPATH))
                    {
                        XtraMessageBox.Show("请添加输出路径");
                        xtraTabControl1.SelectedTabPageIndex = 1;
                        return;
                    }
                }
                else {
                    model.OUTPUTTYPE = "";
                    model.OUTPUTPATH = "";
                }
            }
            Model.T_D_TASK_MSTModel modelMst = new Model.T_D_TASK_MSTModel();
            modelMst.TASKNAME = txt_TASKNAME.Text;
            modelMst.TASKNUMBER = Careysoft.Basic.Public.BConvert.ToInt(txt_TASKNUMBER.Text);
            modelMst.BEGINDATETIME = txt_BEGINDATE.DateTime.ToString("yyyy-MM-dd") + " " + txt_BEGINTIME.Time.ToString("HH:mm:ss");
            modelMst.LASTDATETIME = modelMst.BEGINDATETIME;
            modelMst.INTERVAL = Careysoft.Basic.Public.BConvert.ToInt(txt_INTERVAL.Text);
            modelMst.INTERVALTYPE = txt_INTERVALTYPE.SelectedIndex.ToString();
            modelMst.INTERVALADDTYPE = txt_INTERVALADDTYPE.SelectedIndex.ToString();
            if (txt_SFJY_F.Checked) {
                modelMst.SFJY = 0;
            }
            else
            {
                modelMst.SFJY = 1;
            }
            modelMst.TASKDISCRIBE = txt_TASKDISCRIBE.Text;
            modelMst.SlvList = models;
            if (Access.Task.TaskAdd(modelMst))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else {
                XtraMessageBox.Show("新增失败");
            }
        }

        private void txt_TASKNUMBERTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_TASKNUMBERTYPE.SelectedIndex == 0) {
                txt_TASKNUMBER.Visible = false;
                txt_TASKNUMBER.Text = "-1";
            }
            else if (txt_TASKNUMBERTYPE.SelectedIndex == 1) {
                txt_TASKNUMBER.Visible = true;
                txt_TASKNUMBER.Text = "1";
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormSelectSqlData f = new FormSelectSqlData();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                List<Model.T_D_TASK_SLVModel> models = gridControl1.DataSource as List<Model.T_D_TASK_SLVModel>;
                if (models.Find(delegate(Model.T_D_TASK_SLVModel m) { return m.SQLDATAID == f.SelectSqlData.ID; }) == null)
                {
                    Model.T_D_TASK_SLVModel model = new Model.T_D_TASK_SLVModel();
                    Model.T_D_SQLDATA_MSTModel sqlDataModel = Access.SqlData.GetSqlDataModel(f.SelectSqlData.ID);
                    model.SQLDATAID = sqlDataModel.ID;
                    model.SQLDATANAME = sqlDataModel.SQLDATANAME;
                    model.SQLTYPE = sqlDataModel.SQLTYPE;
                    model.SJYMC = sqlDataModel.SJYMC;
                    model.GROUPMC = sqlDataModel.UNITTYPENAME;
                    model.TASKTYPE = "0";
                    model.OUTPUTTYPE = "0";
                    foreach(Model.T_D_SQLDATA_SLVModel m in sqlDataModel.SLVList){
                        Model.T_S_TASK_SLV_SLVModel model2 = new Model.T_S_TASK_SLV_SLVModel();
                        model2.SQLDATASLVID = m.ID;
                        model2.SQLDATASLVVAL = m.DEFAULTVALUE;
                        model2.SQLDARASLVNAME = m.PARAMETERNAME;
                        model2.SQLDARASQLTYPE = m.PARAMETERTYPE;
                        model.SlvList.Add(model2);
                    }
                    models.Add(model);
                    gridControl1.RefreshDataSource();
                    gridView1.FocusedRowHandle = models.Count - 1;
                    gridControl2.DataSource = model.SlvList;
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Model.T_S_TASK_SLV_SLVModel model = gridView2.GetFocusedRow() as Model.T_S_TASK_SLV_SLVModel;
            if (model != null) {
                if (XtraMessageBox.Show("你确定删除该参数?", "消息确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                    (gridControl2.DataSource as List<Model.T_S_TASK_SLV_SLVModel>).Remove(model);
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model == null) {
                return;
            }
            FormSelectParameter f = new FormSelectParameter(model.SQLDATAID);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                List<Model.T_S_TASK_SLV_SLVModel> models = gridControl2.DataSource as List<Model.T_S_TASK_SLV_SLVModel>;
                if (models.Find(delegate(Model.T_S_TASK_SLV_SLVModel m) { return m.SQLDATASLVID == f.SelectModel.ID; }) == null)
                {
                    Model.T_S_TASK_SLV_SLVModel model2 = new Model.T_S_TASK_SLV_SLVModel();
                    model2.SQLDATASLVID = f.SelectModel.ID;
                    model2.SQLDARASLVNAME = f.SelectModel.PARAMETERNAME;
                    model2.SQLDARASQLTYPE = f.SelectModel.PARAMETERTYPE;
                    model2.SQLDATASLVVAL = f.SelectModel.DEFAULTVALUE;
                    models.Add(model2);
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model == null) {
                return;
            }
            gridControl2.DataSource = model.SlvList;
            gridControl2.RefreshDataSource();
        }

        private void repositoryItemImageComboBox2_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model == null)
            {
                return;
            }
            if (e.NewValue.ToString() == "1")
            {
                model.OUTPUTTYPE = "";
                model.OUTPUTPATH = "";
                gridView1.SetFocusedRowCellValue("OUTPUTTYPE", "");
                gridView1.SetFocusedRowCellValue("OUTPUTPATH", "");
            }
            else
            {
                if (String.IsNullOrEmpty(model.OUTPUTTYPE))
                {
                    model.OUTPUTTYPE = "0";
                    gridView1.SetFocusedRowCellValue("OUTPUTTYPE", "0");
                }
            }
        }

        private void repositoryItemImageComboBox5_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model == null)
            {
                return;
            }
            if (model.TASKTYPE == "1") {
                e.Cancel = true;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model == null)
            {
                return;
            }
            if (model.TASKTYPE != "0") {
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                model.OUTPUTPATH = folderBrowserDialog1.SelectedPath;
                gridView1.SetFocusedRowCellValue("OUTPUTPATH", model.OUTPUTPATH);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model != null)
            {
                if (XtraMessageBox.Show("你确定删除该SqlData?", "消息确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<Model.T_D_TASK_SLVModel> models = gridControl1.DataSource as List<Model.T_D_TASK_SLVModel>;
                    models.Remove(model);
                    gridControl1.RefreshDataSource();
                    if (models.Count > 0) {
                        gridControl2.DataSource = models[0].SlvList;
                    }
                }
            }
        }
    }
}