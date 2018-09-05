namespace Careysoft.Dotnet.Tools.SqlData.ManageClient.DataSource
{
    partial class FormMain
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
            this.txt_sid = new DevExpress.XtraEditors.TextEdit();
            this.txt_port = new DevExpress.XtraEditors.TextEdit();
            this.txt_pass = new DevExpress.XtraEditors.TextEdit();
            this.txt_uid = new DevExpress.XtraEditors.TextEdit();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.txt_ip = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_pass = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_connect = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_sjylx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_del = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_uid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sjylx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_sid
            // 
            this.txt_sid.Location = new System.Drawing.Point(102, 81);
            this.txt_sid.Name = "txt_sid";
            this.txt_sid.Size = new System.Drawing.Size(151, 21);
            this.txt_sid.TabIndex = 15;
            // 
            // txt_port
            // 
            this.txt_port.EditValue = "1521";
            this.txt_port.Location = new System.Drawing.Point(339, 43);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(151, 21);
            this.txt_port.TabIndex = 14;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(581, 81);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Properties.ReadOnly = true;
            this.txt_pass.Size = new System.Drawing.Size(151, 21);
            this.txt_pass.TabIndex = 17;
            // 
            // txt_uid
            // 
            this.txt_uid.Location = new System.Drawing.Point(339, 81);
            this.txt_uid.Name = "txt_uid";
            this.txt_uid.Size = new System.Drawing.Size(151, 21);
            this.txt_uid.TabIndex = 16;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(102, 12);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(630, 21);
            this.txt_name.TabIndex = 6;
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(102, 43);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(151, 21);
            this.txt_ip.TabIndex = 13;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(541, 84);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "密码";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(287, 84);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "用户名";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(287, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "端口号";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(26, 15);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "数据源名称";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(50, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "数据源";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "数据源IP地址";
            // 
            // btn_pass
            // 
            this.btn_pass.Location = new System.Drawing.Point(752, 79);
            this.btn_pass.Name = "btn_pass";
            this.btn_pass.Size = new System.Drawing.Size(69, 23);
            this.btn_pass.TabIndex = 18;
            this.btn_pass.Text = "设置密码";
            this.btn_pass.Click += new System.EventHandler(this.btn_pass_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(102, 119);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(151, 23);
            this.btn_save.TabIndex = 19;
            this.btn_save.Text = "保存";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline);
            this.btn_connect.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_connect.Location = new System.Drawing.Point(266, 124);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(57, 14);
            this.btn_connect.TabIndex = 20;
            this.btn_connect.Text = "测试连接>";
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(505, 46);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 21;
            this.labelControl7.Text = "数据源类型";
            // 
            // txt_sjylx
            // 
            this.txt_sjylx.Location = new System.Drawing.Point(581, 43);
            this.txt_sjylx.Name = "txt_sjylx";
            this.txt_sjylx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_sjylx.Properties.Items.AddRange(new object[] {
            "SID",
            "SERVICE_NAME"});
            this.txt_sjylx.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txt_sjylx.Size = new System.Drawing.Size(151, 21);
            this.txt_sjylx.TabIndex = 22;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(102, 160);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(151, 23);
            this.btn_del.TabIndex = 23;
            this.btn_del.Text = "删除";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 359);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.txt_sjylx);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_pass);
            this.Controls.Add(this.txt_sid);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_uid);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.txt_sid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_uid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sjylx.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_sid;
        private DevExpress.XtraEditors.TextEdit txt_port;
        private DevExpress.XtraEditors.TextEdit txt_pass;
        private DevExpress.XtraEditors.TextEdit txt_uid;
        private DevExpress.XtraEditors.TextEdit txt_name;
        private DevExpress.XtraEditors.TextEdit txt_ip;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_pass;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.LabelControl btn_connect;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit txt_sjylx;
        private DevExpress.XtraEditors.SimpleButton btn_del;
    }
}