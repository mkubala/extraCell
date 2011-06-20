using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows;

namespace extraCell.view
{
    public partial class MDIUI : Form
    {
        internal static String documentFilter = "ExtraCell Document (*.xcd)|*.xcd|XML document (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";
        public DocumentForm activeDocument {get; set; }
        internal SearchForm searchForm;
        private DostepneFunkcje dostepneFunkcje;

        public MDIUI()
        {
            InitializeComponent();
            searchForm = new SearchForm(this);
            dostepneFunkcje = new DostepneFunkcje();
            setEditOptions(false);
        }

        private void calculate()
        {
            activeDocument.extraCellTable.isEditing = false;
            Point p = activeDocument.extraCellTable.CurrentCellAddress;
            activeDocument.extraCellTable.ece.setCell(p.X, p.Y, formulaInput.Text.Trim());
        }

        internal void setEditOptions(bool enabled)
        {
            foreach (ToolStripItem comp in mainMenu.Items)
                comp.Enabled = enabled;

            foreach (ToolStripItem comp in formulaTools.Items)
                comp.Enabled = enabled;

            foreach (ToolStripItem comp in editTools.Items)
                comp.Enabled = enabled;

            foreach (ToolStripItem comp in new ToolStripItem[] { 
                /* komponenty, które mająbyć zawsze aktywne */
                nowyButton, 
                otworzButton,
                otworzMenuItem,
                plikToolStripMenuItem,
                pomocToolStripMenuItem,
                oProgramieToolStripMenuItem,
                nowyMenuItem,
                wyjdzMenuItem,
                dostepneFunkcjeMenuItem
            })
                comp.Enabled = true;
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newDocumentForm(null);
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = documentFilter;
            openFileDialog.FileName = "";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
                newDocumentForm(openFileDialog.FileName);
        }

        private void newDocumentForm(string path)
        {
            DocumentForm documentForm = new DocumentForm(this);
            documentForm.Show();
            if(path != null)
                documentForm.loadDocument(path);

            documentForm.extraCellTable.isInitialized = true;

            documentForm.extraCellTable.selectCell(1, 1);
            documentForm.extraCellTable.selectCell(0, 0);
        }

        private void formulaInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                calculate();
                activeDocument.Focus();
            }
        }

        private void MDIUI_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild.GetType().IsAssignableFrom(typeof(DocumentForm))) 
            {
                if (ActiveMdiChild != null && !ActiveMdiChild.IsDisposed)
                {
                    activeDocument = ((DocumentForm)ActiveMdiChild);
                    DataGridViewCell cell = activeDocument.extraCellTable.CurrentCell;
                    formulaInput.Text = activeDocument.extraCellTable.ece.getCell(cell.ColumnIndex, cell.RowIndex).formula;
                    setEditOptions(true);
                }
                else
                {
                    setEditOptions(false);
                    activeDocument = null;
                    addressInput.Text = "";
                    formulaInput.Text = "";
                }
            }
        }

        private void zapiszJakoMenuItem_Click(object sender, EventArgs e)
        {
            activeDocument.saveFile();
        }

        private void addressInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                activeDocument.extraCellTable.readAddress();
            }
        }

        private void tloButton_Click(object sender, EventArgs e)
        {
            ColorDialog backgroundColorDialog = new ColorDialog();
            backgroundColorDialog.ShowDialog();

            for (int i = 0; i < (activeDocument.extraCellTable.SelectedCells.Count); i++)
            {
                activeDocument.extraCellTable.SelectedCells[i].Style.BackColor = backgroundColorDialog.Color;
            }
        }

        private void kolorButton_Click(object sender, EventArgs e)
        {
            ColorDialog foregroundColorDialog = new ColorDialog();
            foregroundColorDialog.ShowDialog();

            for (int i = 0; i < (activeDocument.extraCellTable.SelectedCells.Count); i++)
            {
                activeDocument.extraCellTable.SelectedCells[i].Style.ForeColor = foregroundColorDialog.Color;
            }
        }

        private void czcionkaButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();

            for (int i = 0; i < (activeDocument.extraCellTable.SelectedCells.Count); i++)
                activeDocument.extraCellTable.SelectedCells[i].Style.Font = fontDialog.Font;
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeDocument.saveFile();
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeDocument.Close();
        }

        private void alignCenterButton_Click(object sender, EventArgs e)
        {
            activeDocument.extraCellTable.CurrentCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void zapiszWszystkopMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DocumentForm doc in MdiChildren)
                doc.saveFile();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            setFontStyle(FontStyle.Bold, boldButton);
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            setFontStyle(FontStyle.Italic, italicButton);
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            setFontStyle(FontStyle.Underline, underlineButton);
        }

        private void setFontStyle(FontStyle fs, ToolStripButton button)
        {
            FontStyle fontStyle;
            button.Checked = !button.Checked;
            foreach(DataGridViewCell cell in activeDocument.extraCellTable.SelectedCells)
            {
                if (cell.Style.Font == null) 
                    cell.Style.Font = DefaultFont;
                
                fontStyle = cell.Style.Font.Style;
                
                if (button.Checked)
                    fontStyle |= fs;
                else
                    fontStyle ^= fs;

                cell.Style.Font = new Font(cell.Style.Font, fontStyle);
            }
        }

        private void setCellAlign(DataGridViewContentAlignment ca , ToolStripButton button)
        {
            alignCenterButton.Checked = false;
            alignLeftButton.Checked = false;
            alignRightButton.Checked = false;

            button.Checked = true;
            
            foreach (DataGridViewCell cell in activeDocument.extraCellTable.SelectedCells)
            {
                cell.Style.Alignment = ca;
            }
        }

        private void alignLeftButton_Click(object sender, EventArgs e)
        {
            setCellAlign(DataGridViewContentAlignment.MiddleLeft, alignLeftButton);
        }

        private void alignCenterButton_Click_1(object sender, EventArgs e)
        {
            setCellAlign(DataGridViewContentAlignment.MiddleCenter, alignCenterButton);
        }

        private void alignRightButton_Click(object sender, EventArgs e)
        {
            setCellAlign(DataGridViewContentAlignment.MiddleRight, alignRightButton);
        }

        private void znajdzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchForm.Activate();
            searchForm.Show();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtraCellTable ect = activeDocument.extraCellTable;
            if (ect.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    int x = ect.CurrentCell.ColumnIndex;
                    int y = ect.CurrentCell.RowIndex;

                    char[] lineDelim = { '\r', '\n' },
                            colDelim = { '\t' };

                    string[] rows = ((string)Clipboard.GetDataObject().GetData(DataFormats.Text)).Split(lineDelim, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < rows.Length; i++)
                    {
                        string[] cols = rows[i].Split(colDelim);
                        for (int j = 0; j < cols.Length; j++)
                        {
                            ect.Rows[y + i].Cells[x + j].Value = cols[j];
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtraCellTable ect = activeDocument.extraCellTable;
            try
            {
                Clipboard.SetDataObject(ect.GetClipboardContent().GetData(DataFormats.Text));
            }
            catch (Exception) { }
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtraCellTable ect = activeDocument.extraCellTable;
            try
            {
                Clipboard.SetDataObject(ect.GetClipboardContent().GetData(DataFormats.Text));
                foreach (DataGridViewCell cell in ect.SelectedCells)
                    cell.Value = "";
            }
            catch (Exception) { }
        }

        private void dostepneFunkcjeMenuItem_Click(object sender, EventArgs e)
        {
            dostepneFunkcje.Activate();
            if (dostepneFunkcje.IsDisposed)
                dostepneFunkcje = new DostepneFunkcje();
            dostepneFunkcje.Show();
        }
    }
}
