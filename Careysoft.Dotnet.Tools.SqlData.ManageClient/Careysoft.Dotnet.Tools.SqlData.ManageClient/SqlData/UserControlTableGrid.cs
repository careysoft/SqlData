using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Careysoft.Dotnet.Tools.SqlData.ManageClient.SqlData
{
    public partial class UserControlTableGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public UserControlTableGrid()
        {
            InitializeComponent();
        }

        public UserControlTableGrid(DataTable dt)
        {
            InitializeComponent();
            for (int i = 0; i < dt.Columns.Count; i++) {
                DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
                column.Caption = dt.Columns[i].Caption;
                column.FieldName = dt.Columns[i].Caption;
                column.Visible = true;
                column.VisibleIndex = i;
                gridView1.Columns.Add(column);
                column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            gridControl1.DataSource = dt;
        }
    }
}
