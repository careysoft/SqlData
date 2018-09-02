namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    partial class FormPass
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
            this.txt_pass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(83, 44);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Properties.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(151, 21);
            this.txt_pass.TabIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(43, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "密码";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(83, 82);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(69, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "保存";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FormPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 144);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.labelControl5);
            this.Name = "FormPass";
            this.Text = "密码设置";
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_pass;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_save;
    }
}