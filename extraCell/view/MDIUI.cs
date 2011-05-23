using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace extraCell.view
{
    public partial class MDIUI : Form
    {
        private const String documentFilter = "ExtraCell Document (*.xcd)|*.xcd|XML document (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";
        private DocumentForm activeDocument;

        public MDIUI()
        {
            InitializeComponent();
        }

        private void calculate()
        {
            activeDocument.extraCellTable.isEditing = false;
            Point p = activeDocument.extraCellTable.CurrentCellAddress;
            activeDocument.extraCellTable.ece.setCell(p.X, p.Y, formulaInput.Text.Trim());
        }

        private bool saveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = documentFilter;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    activeDocument.extraCellTable.ece.exportXML(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się zapisać pliku.\n" + ex.Message, "Błąd");
                    return false;
                }
                string name = new System.IO.FileInfo(saveFileDialog.FileName).Name;
                activeDocument.Text = name;

                return true;
            }
            return false;
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

        private void formulaTools_Resize(object sender, EventArgs e)
        {
            formulaInput.Width = formulaTools.Width - (addressInput.Width + formulaLabel.Width);
        }

        private void formulaInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                calculate();
                activeDocument.Focus();
            }
        }

        private void formulaInput_TextChanged(object sender, EventArgs e)
        {
            /*activeDocument.extraCellTable.isEditing = true;
            activeDocument.extraCellTable.CurrentCell.Value = formulaInput.Text;*/
        }

        private void MDIUI_MdiChildActivate(object sender, EventArgs e)
        {
            this.activeDocument = ((DocumentForm)ActiveMdiChild);
            formulaInput.Text = activeDocument.extraCellTable.CurrentCell.Value.ToString();
        }

        private void zapiszJakoMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }
    }
}
