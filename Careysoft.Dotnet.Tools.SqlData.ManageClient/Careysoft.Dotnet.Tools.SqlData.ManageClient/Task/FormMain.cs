using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient.Task
{
    public partial class FormMain : CareySoft.FormObject.FObject
    {
        private Model.T_BASE_UNITTYPEModel m_GroupModel = new Model.T_BASE_UNITTYPEModel();

        private Model.T_D_TASK_MSTModel m_SelectTaskModel = new Model.T_D_TASK_MSTModel();

        private void SetValue(string taskId) {
            m_SelectTaskModel = Access.Task.GetTaskFromId(taskId);
            txt_TASKNAME.Text = m_SelectTaskModel.TASKNAME;
            txt_TASKNUMBERTYPE.SelectedIndex = m_SelectTaskModel.TASKNUMBER == -1 ? 0 : 1;
            txt_TASKNUMBER.Text = m_SelectTaskModel.TASKNUMBER.ToString();
            txt_BEGINDATE.DateTime = Convert.ToDateTime(m_SelectTaskModel.BEGINDATETIME);
            txt_BEGINTIME.Time = Convert.ToDateTime(m_SelectTaskModel.BEGINDATETIME);
            txt_INTERVAL.Text = m_SelectTaskModel.INTERVAL.ToString();
            txt_INTERVALTYPE.SelectedIndex = Careysoft.Basic.Public.BConvert.ToInt(m_SelectTaskModel.INTERVALTYPE);
            txt_INTERVALADDTYPE.SelectedIndex = Careysoft.Basic.Public.BConvert.ToInt(m_SelectTaskModel.INTERVALADDTYPE); 
            txt_SFJY_S.Checked = m_SelectTaskModel.SFJY == 1;
            txt_SFJY_F.Checked = m_SelectTaskModel.SFJY == 0;
            txt_TASKDISCRIBE.Text = m_SelectTaskModel.TASKDISCRIBE;
            gridControl1.DataSource = m_SelectTaskModel.SlvList;
            if (m_SelectTaskModel.SlvList.Count > 0)
            {
                gridControl2.DataSource = m_SelectTaskModel.SlvList[0].SlvList;
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_GroupModel = Access.UnitType.GetUnitTypeModel(m_Memo);
            List<Model.T_D_TASK_MSTModel> sjys = Access.Task.GetGroupTask(m_Memo);
            gridControl3.DataSource = sjys;
            if (sjys.Count > 0)
            {
                SetValue(sjys[0].ID);
            }
            else
            {
                Careysoft.Dev.Public.Function.EnableButton(false, Controls);
            }
        }

        private void txt_TASKNUMBERTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_TASKNUMBERTYPE.SelectedIndex == 0)
            {
                txt_TASKNUMBER.Visible = false;
                txt_TASKNUMBER.Text = "-1";
            }
            else if (txt_TASKNUMBERTYPE.SelectedIndex == 1)
            {
                txt_TASKNUMBER.Visible = true;
                txt_TASKNUMBER.Text = "1";
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormSelectSqlData f = new FormSelectSqlData();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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
                    foreach (Model.T_D_SQLDATA_SLVModel m in sqlDataModel.SLVList)
                    {
                        Model.T_S_TASK_SLV_SLVModel model2 = new Model.T_S_TASK_SLV_SLVModel();
                        model2.SQLDATASLVID = m.ID;
                        model2.SQLDATASLVVAL = m.DEFAULTVALUE;
                        model2.SQLDARASLVNAME = m.PARAMETERNAME;
                        model2.SQLDARASQLTYPE = m.PARAMETERTYPE;
                        model.SlvList.Add(model2);
                    }
                    m_SelectTaskModel.SlvList.Add(model);
                    gridControl1.DataSource = m_SelectTaskModel.SlvList.FindAll(delegate(Model.T_D_TASK_SLVModel m) { return m.SFSC == 0; });
                    //models.Add(model);
                    //gridControl1.RefreshDataSource();
                    gridView1.FocusedRowHandle = models.Count - 1;
                    gridControl2.DataSource = model.SlvList;
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model != null)
            {
                if (XtraMessageBox.Show("你确定删除该SqlData?", "消息确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    model.SFSC = 1;
                    //gridControl1.RefreshDataSource();
                    gridControl1.DataSource = m_SelectTaskModel.SlvList.FindAll(delegate(Model.T_D_TASK_SLVModel m) { return m.SFSC == 0; });
                    List<Model.T_D_TASK_SLVModel> models = gridControl1.DataSource as List<Model.T_D_TASK_SLVModel>;
                    if (models.Count > 0)
                    {
                        gridControl2.DataSource = models[0].SlvList;
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model == null)
            {
                return;
            }
            FormSelectParameter f = new FormSelectParameter(model.SQLDATAID);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Model.T_S_TASK_SLV_SLVModel model = gridView2.GetFocusedRow() as Model.T_S_TASK_SLV_SLVModel;
            if (model != null)
            {
                if (XtraMessageBox.Show("你确定删除该参数?", "消息确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    (gridControl2.DataSource as List<Model.T_S_TASK_SLV_SLVModel>).Remove(model);
                    gridControl2.RefreshDataSource();
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Model.T_D_TASK_SLVModel model = gridView1.GetFocusedRow() as Model.T_D_TASK_SLVModel;
            if (model == null)
            {
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
            if (model.TASKTYPE == "1")
            {
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
            if (model.TASKTYPE != "0")
            {
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                model.OUTPUTPATH = folderBrowserDialog1.SelectedPath;
                gridView1.SetFocusedRowCellValue("OUTPUTPATH", model.OUTPUTPATH);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_TASKNAME.Text))
            {
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
            if (Careysoft.Basic.Public.BConvert.ToInt(txt_INTERVAL.Text) <= 0)
            {
                xtraTabControl1.SelectedTabPageIndex = 0;
                XtraMessageBox.Show("间隔时间需要大于0");
                txt_INTERVAL.Focus();
                return;
            }
            List<Model.T_D_TASK_SLVModel> models = gridControl1.DataSource as List<Model.T_D_TASK_SLVModel>;
            if (models.Count == 0)
            {
                XtraMessageBox.Show("请添加SqlData");
                xtraTabControl1.SelectedTabPageIndex = 1;
                return;
            }
            foreach (Model.T_D_TASK_SLVModel model in models)
            {
                if (model.TASKTYPE == "0")
                {
                    if (String.IsNullOrEmpty(model.OUTPUTTYPE) || String.IsNullOrEmpty(model.OUTPUTPATH))
                    {
                        XtraMessageBox.Show("请添加输出路径");
                        xtraTabControl1.SelectedTabPageIndex = 1;
                        return;
                    }
                }
                else
                {
                    model.OUTPUTTYPE = "";
                    model.OUTPUTPATH = "";
                }
            }
            m_SelectTaskModel.TASKNAME = txt_TASKNAME.Text;
            m_SelectTaskModel.TASKNUMBER = Careysoft.Basic.Public.BConvert.ToInt(txt_TASKNUMBER.Text);
            m_SelectTaskModel.BEGINDATETIME = txt_BEGINDATE.DateTime.ToString("yyyy-MM-dd") + " " + txt_BEGINTIME.Time.ToString("HH:mm:ss");
            m_SelectTaskModel.LASTDATETIME = m_SelectTaskModel.BEGINDATETIME;
            m_SelectTaskModel.TASKDONUMBER = 0;
            m_SelectTaskModel.INTERVAL = Careysoft.Basic.Public.BConvert.ToInt(txt_INTERVAL.Text);
            m_SelectTaskModel.INTERVALTYPE = txt_INTERVALTYPE.SelectedIndex.ToString();
            m_SelectTaskModel.INTERVALADDTYPE = txt_INTERVALADDTYPE.SelectedIndex.ToString();
            if (txt_SFJY_F.Checked)
            {
                m_SelectTaskModel.SFJY = 0;
            }
            else {
                m_SelectTaskModel.SFJY = 1;
            }
            m_SelectTaskModel.TASKDISCRIBE = txt_TASKDISCRIBE.Text;
            if (Access.Task.TaskEdit(m_SelectTaskModel))
            {

                XtraMessageBox.Show("修改成功");
                //m_SelectTaskModel = Access.Task.GetTaskFromId(m_Memo);
                SetValue(m_SelectTaskModel.ID);
                gridView3.SetFocusedRowCellValue("TASKNAME", m_SelectTaskModel.TASKNAME);
                (gridView3.GetFocusedRow() as Model.T_D_TASK_MSTModel).SFJY = m_SelectTaskModel.SFJY;
            }
            else
            {
                XtraMessageBox.Show("修改失败");
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("是否要删除该任务?", "信息提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Access.Task.TaskDel(m_SelectTaskModel.ID))
                {
                    //SetMessageToFormain(this, e);
                    int rowHandle = gridView3.FocusedRowHandle;
                    List<Model.T_D_TASK_MSTModel> sjys = Access.Task.GetGroupTask(m_Memo);
                    gridControl3.DataSource = sjys;
                    gridView3.FocusedRowHandle = rowHandle - 1;
                    if (sjys.Count == 0)
                    {
                        Careysoft.Dev.Public.Function.EnableButton(false, Controls);
                        Careysoft.Dev.Public.Function.ClearText(Controls);
                        gridControl1.DataSource = new List<Model.T_D_TASK_SLVModel>(); 
                        gridControl2.DataSource = new List<Model.T_S_TASK_SLV_SLVModel>(); 
                    }
                }
                else
                {
                    XtraMessageBox.Show("删除失败");
                }
            }
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Model.T_D_TASK_MSTModel model = gridView3.GetFocusedRow() as Model.T_D_TASK_MSTModel;
            if (model == null)
            {
                return;
            }
            SetValue(model.ID);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView3.FocusedRowHandle;
            List<Model.T_D_TASK_MSTModel> sjys = Access.Task.GetGroupTask(m_Memo);
            gridControl3.DataSource = sjys;
            gridView3.FocusedRowHandle = rowHandle;
            if (sjys.Count > 0)
            {
                Careysoft.Dev.Public.Function.EnableButton(true, Controls);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormAddTask f = new FormAddTask(m_GroupModel.LXBM);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<Model.T_D_TASK_MSTModel> sjys = Access.Task.GetGroupTask(m_Memo);
                gridControl3.DataSource = sjys;
                if (sjys.Count == 1)
                {
                    Careysoft.Dev.Public.Function.EnableButton(true, Controls);
                }
                gridView3.FocusedRowHandle = sjys.Count - 1;
            }
        }

    }
}