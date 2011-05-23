﻿using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;

using extraCell.domain;

namespace extraCell.view
{
    public class ExtraCellTable : DataGridView
    {
        public bool changed { get; set; }
        public bool isEditing { get; set; }
        public ToolStripTextBox inputBox { get; set; }
        public extraCell.domain.ExtraCellEngine ece { get; set; }

        public ExtraCellTable()
            : base()
        {
            changed = false;
            inputBox = new ToolStripTextBox();
            isEditing = false;

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

            InitializeComponent();
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

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            base.OnColumnHeaderMouseClick(e);
        }

        protected override void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            base.OnRowHeaderMouseClick(e);
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
            this.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtraCellTable_CellEnter);
            this.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.ExtraCellTable_CellStateChanged);
            this.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtraCellTable_CellValueChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExtraCellTable_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void ExtraCellTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isEditing && (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete))
                CurrentRow.Cells[CurrentCellAddress.X].Value = "";
        }

        private void ExtraCellTable_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            changed = true;
            //if(isEditing)
                //inputBox.Text = CurrentCell.Value.ToString();
        }

        protected override void OnCellStateChanged(DataGridViewCellStateChangedEventArgs e)
        {
            if(isEditing)
                inputBox.Text = CurrentCell.Value.ToString();
            base.OnCellStateChanged(e);
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //e.Column.CellTemplate = new ExtraCellCustomCell();
            base.OnColumnAdded(e);
        }

        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            isEditing = true;
            Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.ece.getCell(e.ColumnIndex, e.RowIndex).formula;
            base.OnCellBeginEdit(e);
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            isEditing = false;
            this.ece.getCell(e.ColumnIndex, e.RowIndex).result = ece.formulaProc.eval(Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            base.OnCellEndEdit(e);
        }

        private void ExtraCellTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //inputBox.Text = CurrentCell.Value.ToString();
        }

        private void ExtraCellTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            inputBox.Text = ece.getCell(CurrentCellAddress.X, CurrentCellAddress.Y).formula;
        }
        
    }
}
