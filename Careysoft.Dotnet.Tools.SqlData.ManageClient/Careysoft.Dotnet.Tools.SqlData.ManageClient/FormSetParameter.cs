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
    public partial class FormSetParameter : CareySoft.FormObject.FormShowDialogObject
    {
        private List<Model.T_D_SQLDATA_SLVModel> m_SqlParameters = new List<Model.T_D_SQLDATA_SLVModel>();
        public List<Model.T_D_SQLDATA_SLVModel> SqlParameters {
            get { return m_SqlParameters; }
        }

        public FormSetParameter()
        {
            InitializeComponent();
        }

        public FormSetParameter(string parameters)
        {
            InitializeComponent();
            gridView1.Columns.RemoveAt(3);
            gridView1.Columns.RemoveAt(1);
            string[] strSqlParameters = parameters.Split(';');
            for (int i = 0; i < strSqlParameters.Length; i++) {
                Model.T_D_SQLDATA_SLVModel model = new Model.T_D_SQLDATA_SLVModel();
                model.PARAMETERNAME = strSqlParameters[i];
                m_SqlParameters.Add(model);
            }
            gridControl1.DataSource = m_SqlParameters;
        }

        public FormSetParameter(List<Model.T_D_SQLDATA_SLVModel> models, int ftype) {
            InitializeComponent();
            gridView1.Columns.RemoveAt(3);
            gridView1.Columns.RemoveAt(1);
            gridControl1.DataSource = models;
        }

        public FormSetParameter(List<Model.T_D_SQLDATA_SLVModel> models)
        {
            InitializeComponent();
            m_SqlParameters = models;
            gridControl1.DataSource = m_SqlParameters;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}