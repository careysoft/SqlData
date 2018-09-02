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
    public partial class FormPass : CareySoft.FormObject.FormShowDialogObject
    {
        public string PASSWORD {
            get {
                return Careysoft.Basic.Public.DES.Encrypt(txt_pass.Text, "EPad@)!!");
            }
        }

        public FormPass()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_pass.Text)) {
                XtraMessageBox.Show("密码不能为空");
                txt_pass.Focus();
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}