namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    partial class FormAddDataSource
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ip = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_uid = new DevExpress.XtraEditors.TextEdit();
            this.txt_port = new DevExpress.XtraEditors.TextEdit();
            this.txt_sid = new DevExpress.XtraEditors.TextEdit();
            this.txt_pass = new DevExpress.XtraEditors.TextEdit();
            this.btn_pass = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txt_name = new DevExpress.XtraEditors.TextEdit();
            this.btn_connect = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txt_sjylx = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_uid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sjylx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "数据源IP地址";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(118, 51);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(151, 21);
            this.txt_ip.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(301, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "端口号";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(298, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "数据源";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(66, 126);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "用户名";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(313, 126);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "密码";
            // 
            // txt_uid
            // 
            this.txt_uid.Location = new System.Drawing.Point(118, 123);
            this.txt_uid.Name = "txt_uid";
            this.txt_uid.Size = new System.Drawing.Size(151, 21);
            this.txt_uid.TabIndex = 5;
            // 
            // txt_port
            // 
            this.txt_port.EditValue = "1521";
            this.txt_port.Location = new System.Drawing.Point(353, 51);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(151, 21);
            this.txt_port.TabIndex = 2;
            // 
            // txt_sid
            // 
            this.txt_sid.Location = new System.Drawing.Point(353, 83);
            this.txt_sid.Name = "txt_sid";
            this.txt_sid.Size = new System.Drawing.Size(151, 21);
            this.txt_sid.TabIndex = 4;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(353, 123);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Properties.ReadOnly = true;
            this.txt_pass.Size = new System.Drawing.Size(151, 21);
            this.txt_pass.TabIndex = 6;
            // 
            // btn_pass
            // 
            this.btn_pass.Location = new System.Drawing.Point(521, 122);
            this.btn_pass.Name = "btn_pass";
            this.btn_pass.Size = new System.Drawing.Size(69, 23);
            this.btn_pass.TabIndex = 6;
            this.btn_pass.Text = "设置密码";
            this.btn_pass.Click += new System.EventHandler(this.btn_pass_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(118, 167);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(69, 23);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "保存";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(42, 22);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "数据源名称";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(118, 19);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(386, 21);
            this.txt_name.TabIndex = 0;
            // 
            // btn_connect
            // 
            this.btn_connect.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline);
            this.btn_connect.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.btn_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_connect.Location = new System.Drawing.Point(212, 171);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(57, 14);
            this.btn_connect.TabIndex = 8;
            this.btn_connect.Text = "测试连接>";
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(42, 90);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(60, 14);
            this.labelControl16.TabIndex = 14;
            this.labelControl16.Text = "数据源类型";
            // 
            // txt_sjylx
            // 
            this.txt_sjylx.Location = new System.Drawing.Point(118, 87);
            this.txt_sjylx.Name = "txt_sjylx";
            this.txt_sjylx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_sjylx.Properties.Items.AddRange(new object[] {
            "SID",
            "SERVICE_NAME"});
            this.txt_sjylx.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txt_sjylx.Size = new System.Drawing.Size(151, 21);
            this.txt_sjylx.TabIndex = 3;
            // 
            // FormAddDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 228);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.txt_sjylx);
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
            this.Name = "FormAddDataSource";
            this.Text = "新增数据源";
            ((System.ComponentModel.ISupportInitialize)(this.txt_ip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_uid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sjylx.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_ip;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_uid;
        private DevExpress.XtraEditors.TextEdit txt_port;
        private DevExpress.XtraEditors.TextEdit txt_sid;
        private DevExpress.XtraEditors.TextEdit txt_pass;
        private DevExpress.XtraEditors.SimpleButton btn_pass;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txt_name;
        private DevExpress.XtraEditors.LabelControl btn_connect;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.ComboBoxEdit txt_sjylx;
    }
}