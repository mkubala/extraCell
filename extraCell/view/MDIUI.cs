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

        public MDIUI()
        {
            InitializeComponent();
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
                wyjdzMenuItem
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
            if (ActiveMdiChild != null && !ActiveMdiChild.IsDisposed)
            {
                activeDocument = ((DocumentForm)ActiveMdiChild);
                formulaInput.Text = activeDocument.extraCellTable.CurrentCell.Value.ToString();
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

        private void MDIUI_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void formulaInput_TextChanged(object sender, EventArgs e)
        {
            /*activeDocument.extraCellTable.isEditing = true;
            activeDocument.extraCellTable.CurrentCell.Value = formulaInput.Text;*/
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
    }
}
