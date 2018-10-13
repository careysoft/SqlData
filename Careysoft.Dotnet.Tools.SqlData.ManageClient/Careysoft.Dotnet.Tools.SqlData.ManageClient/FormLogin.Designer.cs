namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labpass = new System.Windows.Forms.Label();
            this.txt_user = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pass = new DevExpress.XtraEditors.TextEdit();
            this.btn_ack = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_connectsource = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labpass
            // 
            this.labpass.AutoSize = true;
            this.labpass.BackColor = System.Drawing.Color.Transparent;
            this.labpass.Location = new System.Drawing.Point(44, 36);
            this.labpass.Name = "labpass";
            this.labpass.Size = new System.Drawing.Size(47, 14);
            this.labpass.TabIndex = 26;
            this.labpass.Text = "用户名:";
            // 
            // txt_user
            // 
            this.txt_user.EditValue = "";
            this.txt_user.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_user.Location = new System.Drawing.Point(109, 33);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(309, 21);
            this.txt_user.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(56, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "密码:";
            // 
            // txt_pass
            // 
            this.txt_pass.EditValue = "";
            this.txt_pass.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_pass.Location = new System.Drawing.Point(109, 76);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Properties.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(309, 21);
            this.txt_pass.TabIndex = 1;
            this.txt_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pass_KeyPress);
            // 
            // btn_ack
            // 
            this.btn_ack.Location = new System.Drawing.Point(109, 136);
            this.btn_ack.Name = "btn_ack";
            this.btn_ack.Size = new System.Drawing.Size(75, 23);
            this.btn_ack.TabIndex = 3;
            this.btn_ack.Text = "确认";
            this.btn_ack.Click += new System.EventHandler(this.btn_ack_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(343, 136);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_cancle.TabIndex = 4;
            this.btn_cancle.Text = "取消";
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_connectsource
            // 
            this.btn_connectsource.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline);
            this.btn_connectsource.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.btn_connectsource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_connectsource.Location = new System.Drawing.Point(109, 106);
            this.btn_connectsource.Name = "btn_connectsource";
            this.btn_connectsource.Size = new System.Drawing.Size(57, 14);
            this.btn_connectsource.TabIndex = 27;
            this.btn_connectsource.Text = "配置连接>";
            this.btn_connectsource.Click += new System.EventHandler(this.btn_connectsource_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "DevExpress Dark Style";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 193);
            this.Controls.Add(this.btn_connectsource);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labpass);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_user);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.Text = "易联数据分发系统 - 系统登录";
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labpass;
        private DevExpress.XtraEditors.TextEdit txt_user;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_pass;
        private DevExpress.XtraEditors.SimpleButton btn_ack;
        private DevExpress.XtraEditors.SimpleButton btn_cancle;
        private DevExpress.XtraEditors.LabelControl btn_connectsource;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}