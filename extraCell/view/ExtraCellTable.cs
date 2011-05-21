using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace extraCell.view
{
    class ExtraCellTable : DataGridView
    {
        public bool changed { get; set; }
        public TextBox inputBox { get; set; }
        public extraCell.domain.IEngine ece { get; set; }

        public ExtraCellTable()
            : base()
        {
            changed = false;
            inputBox = new TextBox();

            EnableHeadersVisualStyles = true;
            ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;

            ece = new extraCell.domain.ExtraCellEngine();
            this.DataSource = ece;

            /* przeniesione z Form1.cs/AddTab() */
            this.Size = new System.Drawing.Size(552, 270);
            this.Location = new System.Drawing.Point(3, 3);
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(3, 3);
            this.RowHeadersWidth = 50;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Size = new System.Drawing.Size(552, 270);
        }

        // Numerowanie wierszy
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            Brush b = SystemBrushes.ControlText;

            if (this.RowHeadersWidth < (int)(size.Width + 5)) 
                this.RowHeadersWidth = (int)(size.Width + 5);

            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

            base.OnRowPostPaint(e);
        }

        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellEnter(e);
            inputBox.Text = ece.getCell(CurrentCellAddress.X, CurrentCellAddress.Y).formula.ToString();
        }

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
/*            ClearSelection();
            SetSelectedColumnCore(e.ColumnIndex, true);*/
            SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            base.OnPaint(e);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraCellTable));
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ExtraCellTable
            // 
            resources.ApplyResources(this, "$this");
            this.CausesValidation = false;
            this.ShowEditingIcon = false;
            this.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.ExtraCellTable_CellStateChanged);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void ExtraCellTable_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            changed = true;
            MessageBox.Show("Hello");
        }

    }
}
