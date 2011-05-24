﻿using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using extraCell.domain;
using extraCell.helpers;

namespace extraCell.view
{
    public class ExtraCellTable : DataGridView
    {
        public bool isEditing { get; set; }
        public /*ToolStrip*/TextBox inputBox { get; set; }
        public ToolStripTextBox addressBox { get; set; }
        public extraCell.domain.ExtraCellEngine ece { get; set; }

        public ExtraCellTable()
            : base()
        {
//            inputBox = new ToolStripTextBox();
            addressBox = new ToolStripTextBox();
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
            this.CellStyleContentChanged += new System.Windows.Forms.DataGridViewCellStyleContentChangedEventHandler(this.ExtraCellTable_CellStyleContentChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExtraCellTable_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        public void selectCell(int col, int row)
        {
            CurrentCell = Rows[row].Cells[col];
        }

        public void readAddress()
        {
            Regex re = new Regex(@"(?<colStart>[A-Z]+)(?<rowStart>[0-9]+):(?<colEnd>[A-Z]+)(?<rowEnd>[0-9]+)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            Match m = re.Match(addressBox.Text);
            if (m.Success)
            {
                int colStart = ece.getColumnNumber(m.Groups["colStart"].Value);
                int rowStart = Convert.ToInt32(m.Groups["rowStart"].Value) - 1;
                
                int colEnd = ece.getColumnNumber(m.Groups["colEnd"].Value);
                int rowEnd = Convert.ToInt32(m.Groups["rowEnd"].Value);
                
                if(colStart > colEnd && rowStart > rowEnd) {
                    int tmp = colEnd;
                    colEnd = colStart;
                    colStart = tmp;
                    tmp = rowEnd;
                    rowEnd = rowStart;
                    rowStart = tmp;
                }

                int width = colEnd - colStart + 1;
                int height = rowEnd - rowStart;

                foreach (DataGridViewCell cell in SelectedCells)
                    cell.Selected = false;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        try
                        {
                            Rows[rowStart + j].Cells[colStart + i].Selected = true;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            selectCell(CurrentCellAddress.X, CurrentCellAddress.Y);
                            return;
                        }
                    }
                }
                return;
            }

            re = new Regex(@"(?<col>[A-Z]+)(?<row>[0-9]+)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            m = re.Match(addressBox.Text);
            if (m.Success)
            {
                int col = ece.getColumnNumber(m.Groups["col"].Value);
                int row = Convert.ToInt32(m.Groups["row"].Value);
                try
                {
                    selectCell(col, row - 1);
                }
                catch (NullReferenceException)
                {
                    addressBox.Text = ece.getColumnName(CurrentCellAddress.X + 1) + CurrentCellAddress.Y.ToString();
                }
                return;
            }
        }

        private void ExtraCellTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isEditing && (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete))
                CurrentRow.Cells[CurrentCellAddress.X].Value = "";
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            e.Column.CellTemplate = new ExtraCellCustomCell();
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
            this.ece.getCell(e.ColumnIndex, e.RowIndex).result = ece.eval(Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            base.OnCellEndEdit(e);
        }

        private void ExtraCellTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            inputBox.Text = ece.getCell(CurrentCellAddress.X, CurrentCellAddress.Y).formula;
            addressBox.Text = ece.getColumnName(CurrentCellAddress.X+1)+(CurrentCellAddress.Y+1).ToString();
        }

        private void ExtraCellTable_CellStyleContentChanged(object sender, DataGridViewCellStyleContentChangedEventArgs e)
        {
        }

    }
}
