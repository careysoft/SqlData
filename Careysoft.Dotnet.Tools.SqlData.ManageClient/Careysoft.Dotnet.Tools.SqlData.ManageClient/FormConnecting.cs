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
    public partial class FormConnecting : CareySoft.FormObject.FormShowDialogObject
    {
        private int m_ConnectSec = 0;

        public FormConnecting()
        {
            InitializeComponent();
        }

        public FormConnecting(int sec) {
            InitializeComponent();
            m_ConnectSec = sec;
            labelControl1.Text = "服务器连接中......" + m_ConnectSec + " 秒";
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelControl1.Text = "服务器连接中......" + m_ConnectSec + " 秒";
            if (m_ConnectSec == 0)
            {
                labelControl1.Text = "服务器连接失败";
                timer1.Enabled = false;
                return;
            }
            m_ConnectSec--;
        }
    }
}