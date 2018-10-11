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
        private Model.T_D_SQLDATA_MSTModel m_SqlDataModel = new Model.T_D_SQLDATA_MSTModel();

        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            string id = m_Memo;
            m_SqlDataModel = Access.SqlData.GetSqlDataModel(id);
            Model.T_BASE_SJYPZModel sjy = Access.DataSource.GetSJYPZFromBM(m_SqlDataModel.SJYID);
            txt_SJYID.Text = sjy.PZMC;
            txt_SJYID.Tag = sjy;
            txt_SQLDATANAME.Text = m_SqlDataModel.SQLDATANAME;
            txt_SQLDATADISCRIBE.Text = m_SqlDataModel.SQLDATADISCRIBE;
            txt_SQLTYPE.SelectedIndex = Careysoft.Basic.Public.BConvert.ToInt(m_SqlDataModel.SQLTYPE);
            if (m_SqlDataModel.SFJY == 0)
            {
                txt_SFJY_S.Checked = false;
            }
            else {
                txt_SFJY_S.Checked = true;
            }
            txt_SQL.Text = m_SqlDataModel.SQL;
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
                    Model.T_D_SQLDATA_SLVModel parameterModel = m_SqlDataModel.SLVList.Find(delegate(Model.T_D_SQLDATA_SLVModel m) { return m.PARAMETERNAME == parameterArray[i]; });
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
            Model.T_D_SQLDATA_MSTModel model = m_SqlDataModel;
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
                List<Model.T_D_SQLDATA_SLVModel> delSlvList = m_SqlDataModel.SLVList.FindAll(delegate(Model.T_D_SQLDATA_SLVModel m) { return (";" + parameters + ";").IndexOf(";" + m.PARAMETERNAME + ";") < 0; });
                foreach (Model.T_D_SQLDATA_SLVModel m in delSlvList) {
                    m.SFSC = 1;
                }
                string[] arraySqlParameters = parameters.Split(';');
                for (int i = 0; i < arraySqlParameters.Length; i++)
                {
                    Model.T_D_SQLDATA_SLVModel modelSlv = m_SqlDataModel.SLVList.Find(delegate(Model.T_D_SQLDATA_SLVModel m) { return m.PARAMETERNAME == arraySqlParameters[i]; });
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
                foreach (Model.T_D_SQLDATA_SLVModel m in m_SqlDataModel.SLVList)
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
                SetMessageToFormain(null, null);
                m_SqlDataModel = Access.SqlData.GetSqlDataModel(m_Memo);
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
                if (Access.SqlData.SqlDataDel(m_Memo))
                {
                    SetMessageToFormain(this, e);
                }
                else {
                    XtraMessageBox.Show("删除失败");
                }
            }
        }
    }
}