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

        private void setEditOptions(bool enabled)
        {
            oknaToolStripMenuItem.Enabled = enabled;
            zapiszJakoMenuItem.Enabled = enabled;
            zapiszToolStripMenuItem.Enabled = enabled;
            zamknijToolStripMenuItem.Enabled = enabled;
            edycjaToolStripMenuItem.Enabled = enabled;
            szukajToolStripMenuItem.Enabled = enabled;
            saveToolStripButton.Enabled = enabled;
            printToolStripButton.Enabled = enabled;
            cutToolStripButton.Enabled = enabled;
            copyToolStripButton.Enabled = enabled;
            pasteToolStripButton.Enabled = enabled;
            tloButton.Enabled = enabled;
            kolorButton.Enabled = enabled;
            czcionkaButton.Enabled = enabled;
            addressInput.Enabled = enabled;
            formulaInput.Enabled = enabled;
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentForm documentForm = new DocumentForm(this);
            documentForm.MdiParent = this;
            documentForm.Show();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = documentFilter;
            openFileDialog.FileName = "";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                DocumentForm documentForm = new DocumentForm(this, openFileDialog.FileName);
                documentForm.MdiParent = this;
                documentForm.Show();
            }
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

    }
}
