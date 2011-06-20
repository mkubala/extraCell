using System;
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
        private ContextMenuStrip cellContextMenu;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;

        private MDIUI mainForm { get; set; }

        internal bool isInitialized { get; set; }

        public bool isEditing { get; set; }
        public /*ToolStrip*/TextBox inputBox { get; set; }
        public ToolStripTextBox addressBox { get; set; }
        public extraCell.domain.ExtraCellEngine ece { get; set; }

        public ExtraCellTable()
            : base()
        {
            isInitialized = false;
            mainForm = (MDIUI) Application.OpenForms[0];
            addressBox = mainForm.addressInput;
            inputBox = mainForm.formulaInput.TextBox;
            isEditing = false;

            EnableHeadersVisualStyles = true;

            ece = new extraCell.domain.ExtraCellEngine();
            this.DataSource = ece;

            this.Size = new System.Drawing.Size(552, 270);
            this.Location = new System.Drawing.Point(3, 3);
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(3, 3);
            this.RowHeadersWidth = 50;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Size = new System.Drawing.Size(552, 270);

            InitializeComponent();
            DoubleBuffered = true;
        }

        // Numerowanie wierszy
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            Brush b;
            
            //kolor numeru wiersza - trzeba dopracowac bo warunekcos nie bangla..
            if (SelectedRows.Contains(Rows[e.RowIndex]))
                b = SystemBrushes.ActiveCaptionText;
            else
                b = SystemBrushes.ControlText;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cellContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cellContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cellContextMenu
            // 
            this.cellContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.cellContextMenu.Name = "cellContextMenu";
            this.cellContextMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // ExtraCellTable
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CausesValidation = false;
            this.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.ContextMenuStrip = this.cellContextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowEditingIcon = false;
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtraCellTable_CellClick);
            this.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtraCellTable_CellEnter);
            this.SelectionChanged += new System.EventHandler(this.ExtraCellTable_SelectionChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExtraCellTable_KeyPress);
            this.cellContextMenu.ResumeLayout(false);
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

                if (colStart == colEnd && rowStart == rowEnd)
                {
                    selectCell(colStart, rowStart);
                    addressBox.Text = m.Groups["colStart"].Value + m.Groups["rowStart"].Value;
                    return;
                }

                if(colStart >= colEnd && rowStart >= rowEnd) {
                    addressBox.Text = m.Groups["colEnd"].Value + m.Groups["rowEnd"].Value + ":" + m.Groups["colStart"].Value + m.Groups["rowStart"].Value;
                    int tmp = colEnd;
                    colEnd = colStart;
                    colStart = tmp;
                    tmp = rowEnd;
                    rowEnd = rowStart + 1;
                    rowStart = tmp - 1;
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
            if (isInitialized)
            {
                inputBox.Text = ece.getCell(CurrentCellAddress.X, CurrentCellAddress.Y).formula;
//                addressBox.Text = ece.getColumnName(CurrentCellAddress.X + 1) + (CurrentCellAddress.Y + 1).ToString();
                updateAddresBox();

                if (isInitialized && CurrentCell != null && CurrentCell.Style != null)
                {
                    if (CurrentCell.Style.Font != null)
                    {
                        mainForm.boldButton.Checked = (CurrentCell.Style.Font.Bold) ? true : false;
                        mainForm.italicButton.Checked = (CurrentCell.Style.Font.Italic) ? true : false;
                        mainForm.underlineButton.Checked = (CurrentCell.Style.Font.Underline) ? true : false;
                    }

                    mainForm.alignCenterButton.Checked = (CurrentCell.Style.Alignment == DataGridViewContentAlignment.MiddleCenter) ? true : false;
                    mainForm.alignLeftButton.Checked = (CurrentCell.Style.Alignment == DataGridViewContentAlignment.MiddleLeft) ? true : false;
                    mainForm.alignRightButton.Checked = (CurrentCell.Style.Alignment == DataGridViewContentAlignment.MiddleRight) ? true : false;
                }
            }
        }

        private void ExtraCellTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nie działa tak jakbym sobie tego zyczyl...
            /*if (e.ColumnIndex == 0 || e.RowIndex == 0)
            {
                this.ContextMenuStrip = null;
            }
            else
            {
                this.ContextMenuStrip = cellContextMenu;
            }*/
        }

        private void ExtraCellTable_SelectionChanged(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                Color selectedHeadersBackColor = System.Drawing.SystemColors.ActiveCaption;
                Color selectedHeadersForeColor = System.Drawing.SystemColors.ActiveCaptionText;

                foreach (DataGridViewColumn col in Columns)
                {
                    col.HeaderCell.Style.BackColor = Color.Empty;
                    col.HeaderCell.Style.ForeColor = Color.Empty;
                }

                foreach (DataGridViewRow row in Rows)
                {
                    row.HeaderCell.Style.BackColor = Color.Empty;
                    row.HeaderCell.Style.ForeColor = Color.Empty;
                }

                foreach (DataGridViewCell cell in SelectedCells)
                {
                    this.Columns[cell.ColumnIndex].HeaderCell.Style.BackColor = selectedHeadersBackColor;
                    this.Columns[cell.ColumnIndex].HeaderCell.Style.ForeColor = selectedHeadersForeColor;

                    this.Rows[cell.RowIndex].HeaderCell.Style.BackColor = selectedHeadersBackColor;
                    this.Rows[cell.RowIndex].HeaderCell.Style.ForeColor = selectedHeadersForeColor;
                }
            }
        }

        private void updateAddresBox() {
            if (SelectedCells.Count > 1)
            {
                int last = SelectedCells.Count - 1;
                addressBox.Text = ece.getColumnName(SelectedCells[last].ColumnIndex + 1)
                                + (SelectedCells[last].RowIndex + 1).ToString()
                                + ":"
                                + ece.getColumnName(SelectedCells[0].ColumnIndex + 1)
                                + (SelectedCells[0].RowIndex + 1).ToString();
            }
            else
            {
                addressBox.Text = ece.getColumnName(SelectedCells[0].ColumnIndex + 1)
                                + (SelectedCells[0].RowIndex + 1).ToString();
            }
        }
    }
}
