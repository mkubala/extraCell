using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using extraCell.helpers;

namespace extraCell.view
{
    public partial class DocumentForm : Form
    {
        internal string documentPath { get; set;}
        internal string documentName { get; set; }
        private static int documentsCount;
        public ExtraCellTable extraCellTable { get; set; }

        public DocumentForm(MDIUI parent)
        {
            Initialize(parent, "");
        }

        public DocumentForm(MDIUI parent, string filePath)
        {
            Initialize(parent, filePath);
        }

        private void Initialize(MDIUI p, string filePath)
        {
            InitializeComponent();
            MdiParent = p;

            extraCellTable = new ExtraCellTable();

            documentsCount++;
            ((MDIUI)MdiParent).activeDocument = this;

            extraCellTable.ece.fill();
            Controls.Add(extraCellTable);

            documentPath = "";
            documentName = "Niezapisany(" + documentsCount + ")";
            
            this.Text = documentName;
        }

        public void loadDocument(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                extraCellTable.ece.importXML(path);
                documentPath = path;
                documentName = fileInfo.Name;
            }
        }

        private bool saveFileAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = MDIUI.documentFilter;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string name = new System.IO.FileInfo(saveFileDialog.FileName).Name;
                Text = name;
                return saveFile(saveFileDialog.FileName);
            }
            return false;
        }

        internal bool saveFile()
        {
            if (documentPath.Length > 0 && new System.IO.FileInfo(documentPath).Exists)
                return saveFile(documentPath);
            else
                return saveFileAs();
        }

        private bool saveFile(string path)
        {
            return extraCellTable.ece.exportXML(path);
        }

        /* Zapytanie o wyjście row zapis + jego obsługa */
        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult;
            if (extraCellTable.ece.isModified)
            {
                dialogResult = MessageBox.Show(
                    "Dokument " + documentName + " został zmieniony, ale nie został zapisany.\nZapisać teraz?",
                    "Zamykanie dokumentu",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button3
                );

                if (dialogResult.Equals(DialogResult.Cancel))
                    e.Cancel = true;
                else if (dialogResult.Equals(DialogResult.Yes) && (documentPath == null || documentPath.Trim().Length == 0))
                    e.Cancel = !saveFileAs();
                else if (dialogResult.Equals(DialogResult.Yes))
                    e.Cancel = !saveFile(documentPath);
            }
        }

        private void DocumentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            documentsCount--;
            if (documentsCount <= 0)
                ((MDIUI)MdiParent).setEditOptions(false);
        }

        private void DocumentForm_Activated(object sender, EventArgs e)
        {
            SearchForm searchForm = ((MDIUI)MdiParent).searchForm;
            if (!searchForm.IsDisposed)
                searchForm.Activate();
        }

    }
}
