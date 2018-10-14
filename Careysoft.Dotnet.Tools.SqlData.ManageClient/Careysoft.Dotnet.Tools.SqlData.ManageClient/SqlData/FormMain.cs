using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient.SqlData
{
    public partial class FormMain : CareySoft.FormObject.FObject
    {
        private Model.T_BASE_UNITTYPEModel m_GroupModel = new Model.T_BASE_UNITTYPEModel();

        private Model.T_D_SQLDATA_MSTModel m_SelectSqlDataModel = new Model.T_D_SQLDATA_MSTModel();

        /// <summary>
        /// 设置对话框值
        /// </summary>
        /// <param name="sjypm"></param>
        private void SetValue(string id)
        {
            m_SelectSqlDataModel = Access.SqlData.GetSqlDataModel(id);
            Model.T_BASE_SJYPZModel sjy = Access.DataSource.GetSJYPZFromBM(m_SelectSqlDataModel.SJYID);
            txt_SJYID.Text = sjy.PZMC;
            txt_SJYID.Tag = sjy;
            txt_SQLDATANAME.Text = m_SelectSqlDataModel.SQLDATANAME;
            txt_SQLDATADISCRIBE.Text = m_SelectSqlDataModel.SQLDATADISCRIBE;
            txt_SQLTYPE.SelectedIndex = Careysoft.Basic.Public.BConvert.ToInt(m_SelectSqlDataModel.SQLTYPE);
            if (m_SelectSqlDataModel.SFJY == 0)
            {
                txt_SFJY_S.Checked = false;
                txt_SFJY_F.Checked = true; 
            }
            else
            {
                txt_SFJY_S.Checked = true;
                txt_SFJY_F.Checked = false; 
            }
            txt_SQL.Text = m_SelectSqlDataModel.SQL;
            xtraTabControl1.TabPages.Clear();
        }

        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            string id = m_Memo;
            m_GroupModel = Access.UnitType.GetUnitTypeModel(m_Memo);
            List<Model.T_D_SQLDATA_MSTModel> sqlDatas = Access.SqlData.GetSqlDataListFromGroupId(m_Memo);
            gridControl1.DataSource = sqlDatas;
            if (sqlDatas.Count > 0)
            {
                SetValue(sqlDatas[0].ID);
            }
            else {
                Careysoft.Dev.Public.Function.EnableButton(false, Controls);
            }
            base.OnLoad(e);
        }

        private void btn_test_Click(object sender, EventArgs e)
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
            string sql = txt_SQL.Text.ToUpper();
            Regex re = new Regex(@"&\w*");
            MatchCollection matchs = re.Matches(sql);
            string parameters = "";
            for (int i = 0; i < matchs.Count; i++)
            {
                if ((String.Format("{0};", parameters)).IndexOf(String.Format(";{0};", matchs[i].Value)) < 0)
                {
                    parameters += ";" + matchs[i].Value;
                }
            }
            if (!String.IsNullOrEmpty(parameters))
            {
                parameters = parameters.Substring(1);
                string[] parameterArray = parameters.Split(';');
                List<Model.T_D_SQLDATA_SLVModel> parameterList = new List<Model.T_D_SQLDATA_SLVModel>();
                for (int i = 0; i < parameterArray.Length; i++)
                {
                    Model.T_D_SQLDATA_SLVModel parameterModel = m_SelectSqlDataModel.SLVList.Find(delegate(Model.T_D_SQLDATA_SLVModel m) { return m.PARAMETERNAME == parameterArray[i]; });
                    if (parameterModel != null)
                    {
                        parameterList.Add(parameterModel);
                    }
                    else {
                        parameterModel = new Model.T_D_SQLDATA_SLVModel();
                        parameterModel.PARAMETERNAME = parameterArray[i];
                        parameterList.Add(parameterModel);
                    }

                }
                FormSetParameter f = new FormSetParameter(parameterList, 0);
                if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                List<Model.T_D_SQLDATA_SLVModel> models = f.SqlParameters;
                foreach (Model.T_D_SQLDATA_SLVModel model in models)
                {
                    if (model.DEFAULTVALUE.IndexOf("FUN:") == 0)
                    {
                        //参数如果为'FUN:XX' 格式，那么就替换原有'&parameter' 如果没有，则替换&parameter
                        sql = sql.Replace(String.Format("'{0}'", model.PARAMETERNAME), model.DEFAULTVALUE.Substring(4));
                    }
                    sql = sql.Replace(String.Format("{0}", model.PARAMETERNAME), model.DEFAULTVALUE);
                }
            }
            if (XtraMessageBox.Show("是否查看SQL?", "信息提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                Careysoft.Dev.Public.FormShowMemo fMemo = new Dev.Public.FormShowMemo("SQL", sql);
                fMemo.ShowDialog();
            }
            xtraTabControl1.TabPages.Clear();
            if (txt_SQLTYPE.SelectedIndex == 0)
            {
                string errorInfo = "";
                List<DataTable> models = Access.SqlData.GetDataSet((txt_SJYID.Tag as Model.T_BASE_SJYPZModel), sql, ref errorInfo);
                foreach (DataTable dt in models)
                {
                    DevExpress.XtraTab.XtraTabPage xTab = xtraTabControl1.TabPages.Add();
                    xTab.Text = " 查询结果 ";
                    SqlData.UserControlTableGrid uTabGrid = new SqlData.UserControlTableGrid(dt);
                    uTabGrid.Dock = DockStyle.Fill;
                    xTab.Controls.Add(uTabGrid);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
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
            Model.T_D_SQLDATA_MSTModel model = m_SelectSqlDataModel;
            string sql = txt_SQL.Text.ToUpper();
            Regex re = new Regex(@"&\w*");
            MatchCollection matchs = re.Matches(sql);
            string parameters = "";
            for (int i = 0; i < matchs.Count; i++)
            {
                parameters += ";" + matchs[i].Value;
            }
            if (!String.IsNullOrEmpty(parameters))
            {
                parameters = parameters.Substring(1);
                //m_SqlDataModel.SLVList.RemoveAll(delegate(Model.T_D_SQLDATA_SLVModel m) { return ("," + parameters + ",").IndexOf(",&" + m.PARAMETERNAME + ",") < 0; });
                List<Model.T_D_SQLDATA_SLVModel> delSlvList = m_SelectSqlDataModel.SLVList.FindAll(delegate(Model.T_D_SQLDATA_SLVModel m) { return (";" + parameters + ";").IndexOf(";" + m.PARAMETERNAME + ";") < 0; });
                foreach (Model.T_D_SQLDATA_SLVModel m in delSlvList) {
                    m.SFSC = 1;
                }
                string[] arraySqlParameters = parameters.Split(';');
                for (int i = 0; i < arraySqlParameters.Length; i++)
                {
                    Model.T_D_SQLDATA_SLVModel modelSlv = m_SelectSqlDataModel.SLVList.Find(delegate(Model.T_D_SQLDATA_SLVModel m) { return m.PARAMETERNAME == arraySqlParameters[i]; });
                    if (modelSlv == null)
                    {
                        modelSlv = new Model.T_D_SQLDATA_SLVModel();
                        modelSlv.PARAMETERNAME = arraySqlParameters[i];
                        modelSlv.PARAMETERTYPE = "STRING";
                        model.SLVList.Add(modelSlv);
                    }
                }
                FormSetParameter f = new FormSetParameter(model.SLVList.FindAll(delegate(Model.T_D_SQLDATA_SLVModel m) { return m.SFSC == 0; }));
                if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
            }
            else {
                foreach (Model.T_D_SQLDATA_SLVModel m in m_SelectSqlDataModel.SLVList)
                {
                    m.SFSC = 1;
                }
            }
            model.SJYID = (txt_SJYID.Tag as Model.T_BASE_SJYPZModel).PZBM;
            model.SQLDATANAME = txt_SQLDATANAME.Text;
            model.SQLTYPE = txt_SQLTYPE.SelectedIndex.ToString();
            model.SQLDATADISCRIBE = txt_SQLDATADISCRIBE.Text;
            model.SQL = sql;
            if (txt_SFJY_S.Checked)
            {
                model.SFJY = 1;
            }
            else
            {
                model.SFJY = 0;
            }
            if (Access.SqlData.SqlDataEdit(model))
            {
                XtraMessageBox.Show("修改成功");
                gridView1.SetFocusedRowCellValue("SQLDATANAME", model.SQLDATANAME);
                SetValue(model.ID);
                (gridView1.GetFocusedRow() as Model.T_D_SQLDATA_MSTModel).SFJY = m_SelectSqlDataModel.SFJY;
            }
            else
            {
                XtraMessageBox.Show("修改失败");
            }
        }

        private void txt_SJYID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sjyid = "";
            if (txt_SJYID.Tag != null)
            {
                sjyid = (txt_SJYID.Tag as Model.T_BASE_SJYPZModel).PZBM;
            }
            FormSelectSJY f = new FormSelectSJY(sjyid);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_SJYID.Text = f.SelectModel.PZMC;
                txt_SJYID.Tag = f.SelectModel;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("是否要删除该SqlData?", "信息提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Access.SqlData.SqlDataDel(m_SelectSqlDataModel.ID))
                {
                    //SetMessageToFormain(this, e);
                    int rowHandle = gridView1.FocusedRowHandle;
                    List<Model.T_D_SQLDATA_MSTModel> sjys = Access.SqlData.GetSqlDataListFromGroupId(m_Memo);
                    gridControl1.DataSource = sjys;
                    gridView1.FocusedRowHandle = rowHandle - 1;
                    if (sjys.Count == 0)
                    {
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
            Model.T_D_SQLDATA_MSTModel model = gridView1.GetFocusedRow() as Model.T_D_SQLDATA_MSTModel;
            if (model == null)
            {
                return;
            }
            SetValue(model.ID);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            List<Model.T_D_SQLDATA_MSTModel> sjys = Access.SqlData.GetSqlDataListFromGroupId(m_Memo);
            gridControl1.DataSource = sjys;
            gridView1.FocusedRowHandle = rowHandle;
            if (sjys.Count > 0)
            {
                Careysoft.Dev.Public.Function.EnableButton(true, Controls);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAddSqlData f = new FormAddSqlData(m_GroupModel.LXBM);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<Model.T_D_SQLDATA_MSTModel> sjys = Access.SqlData.GetSqlDataListFromGroupId(m_Memo);
                gridControl1.DataSource = sjys;
                if (sjys.Count == 1)
                {
                    Careysoft.Dev.Public.Function.EnableButton(true, Controls);
                }
                gridView1.FocusedRowHandle = sjys.Count - 1;
            }
        }
    }
}