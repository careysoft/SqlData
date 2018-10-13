using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    public partial class FormLogin : CareySoft.FormObject.FormShowDialogObject
    {
        #region 私有函数
        [DllImport("RegCom.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetDeviceMachineCode(out uint codelen, out IntPtr machinecode);
        /// <summary>
        /// 得到机器码
        /// </summary>
        /// <returns></returns>
        private string GetMachinecode()
        {
            try
            {
                uint codelen = 0;
                IntPtr machinecode = IntPtr.Zero;
                GetDeviceMachineCode(out codelen, out machinecode);
                string _machinecode = ""; //本机注册码
                if (machinecode != IntPtr.Zero)
                {
                    byte[] retStr = new byte[codelen];
                    Marshal.Copy(machinecode, retStr, 0, (int)codelen);
                    System.Text.Encoding encoding = System.Text.Encoding.ASCII;
                    _machinecode = encoding.GetString(retStr);
                    Marshal.FreeHGlobal(machinecode);
                }
                return _machinecode;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        private bool m_Logined;
        public bool Logined
        {
            get { return m_Logined; }
            set { m_Logined = value; }
        }

        private string m_Unitid; //服务器动态key
        public string Unitid
        {
            get { return m_Unitid; }
        }

        private string m_UserPost; //服务器动态key
        public string UserPost
        {
            get { return m_UserPost; }
        }

        public string Username
        {
            get { return txt_user.Text; }
        }

        public string Password
        {
            get { return txt_pass.Text; }
        }

        public FormLogin()
        {
            InitializeComponent();
            CareySoft.FormObject.SRFSet.SetControl(Controls);
            txt_user.Focus();
        }

        private void btn_ack_Click(object sender, EventArgs e)
        {
            string username = txt_user.Text;
            string password = txt_pass.Text;
            if (String.IsNullOrEmpty(username)) {
                XtraMessageBox.Show("用户名不能为空");
                txt_user.Focus();
                return;
            }
            if (String.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("密码不能为空");
                txt_pass.Focus();
                return;
            }
            if (Access.User.Login(username, password))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("登录失败");
                txt_pass.Focus();
                txt_pass.SelectAll();
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btn_ack_Click(sender, e);
            }
        }

        private void btn_connectsource_Click(object sender, EventArgs e)
        {
            Access.ConnectDB.GetDBSetWindow();
        }
    }
}