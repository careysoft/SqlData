using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    public partial class FormAddSqlData : CareySoft.FormObject.FormShowFormObject
    {
        private string m_UnitTypeId = "";

        public FormAddSqlData()
        {
            InitializeComponent();
            Width = (int)((double)Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            Height = (int)((double)Screen.PrimaryScreen.WorkingArea.Height * 0.8); 
        }

        public FormAddSqlData(string unitTypeId)
        {
            m_UnitTypeId = unitTypeId;
            InitializeComponent();
            Width = (int)((double)Screen.PrimaryScreen.WorkingArea.Width * 0.8);
            Height = (int)((double)Screen.PrimaryScreen.WorkingArea.Height * 0.8);
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
            Model.T_D_SQLDATA_MSTModel model = new Model.T_D_SQLDATA_MSTModel();
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
                string[] arraySqlParameters = parameters.Split(';');
                for (int i = 0; i < arraySqlParameters.Length; i++) {
                    Model.T_D_SQLDATA_SLVModel modelSlv = new Model.T_D_SQLDATA_SLVModel();
                    modelSlv.PARAMETERNAME = arraySqlParameters[i];
                    modelSlv.PARAMETERTYPE = "STRING";
                    model.SLVList.Add(modelSlv);
                }
                FormSetParameter f = new FormSetParameter(model.SLVList);
                if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK) {
                    return;
                }
            }
            model.UNITTYPEID = m_UnitTypeId;
            model.SJYID = (txt_SJYID.Tag as Model.T_BASE_SJYPZModel).PZBM;
            model.SQLDATANAME = txt_SQLDATANAME.Text;
            model.SQLTYPE = txt_SQLTYPE.SelectedIndex.ToString();
            model.SQLDATADISCRIBE = txt_SQLDATADISCRIBE.Text;
            model.SQL = sql;
            if (txt_SFJY_S.Checked)
            {
                model.SFJY = 1;
            }
            else {
                model.SFJY = 0;
            }
            if (Access.SqlData.SqlDataAdd(model))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("新增失败");
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
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
            for (int i = 0; i < matchs.Count; i++) {
                if ((String.Format("{0};", parameters)).IndexOf(String.Format(";{0};", matchs[i].Value)) < 0)
                {
                    parameters += ";" + matchs[i].Value;
                }
            }
            if (!String.IsNullOrEmpty(parameters)) {
                parameters = parameters.Substring(1);
                FormSetParameter f = new FormSetParameter(parameters);
                if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK) {
                    return;
                }
                List<Model.T_D_SQLDATA_SLVModel> models = f.SqlParameters;
                foreach (Model.T_D_SQLDATA_SLVModel model in models) {
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
                foreach (DataTable dt in models) {
                    DevExpress.XtraTab.XtraTabPage xTab = xtraTabControl1.TabPages.Add();
                    xTab.Text = " 查询结果 ";
                    SqlData.UserControlTableGrid uTabGrid = new SqlData.UserControlTableGrid(dt);
                    uTabGrid.Dock = DockStyle.Fill;
                    xTab.Controls.Add(uTabGrid);
                }
            }
        }

        private void txt_SJYID_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sjyid = "";
            if (txt_SJYID.Tag != null) {
                sjyid = (txt_SJYID.Tag as Model.T_BASE_SJYPZModel).PZBM;
            }
            FormSelectSJY f = new FormSelectSJY(sjyid);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txt_SJYID.Text = f.SelectModel.PZMC;
                txt_SJYID.Tag = f.SelectModel;
            }
        }
    }
}