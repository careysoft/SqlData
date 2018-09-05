namespace Careysoft.Dotnet.Tools.SqlData.ManageClient
{
    partial class FormAddUnitType
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
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txt_lxmc = new DevExpress.XtraEditors.TextEdit();
            this.txt_bl1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_lxmc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_bl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(118, 104);
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
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "分组名称";
            // 
            // txt_lxmc
            // 
            this.txt_lxmc.Location = new System.Drawing.Point(118, 19);
            this.txt_lxmc.Name = "txt_lxmc";
            this.txt_lxmc.Size = new System.Drawing.Size(386, 21);
            this.txt_lxmc.TabIndex = 0;
            // 
            // txt_bl1
            // 
            this.txt_bl1.EditValue = "0";
            this.txt_bl1.Location = new System.Drawing.Point(118, 56);
            this.txt_bl1.Name = "txt_bl1";
            this.txt_bl1.Size = new System.Drawing.Size(151, 21);
            this.txt_bl1.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(54, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "排序号";
            // 
            // FormAddUnitType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 181);
            this.Controls.Add(this.txt_bl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_lxmc);
            this.Controls.Add(this.labelControl6);
            this.Name = "FormAddUnitType";
            this.Text = "新增分组";
            ((System.ComponentModel.ISupportInitialize)(this.txt_lxmc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_bl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txt_lxmc;
        private DevExpress.XtraEditors.TextEdit txt_bl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}