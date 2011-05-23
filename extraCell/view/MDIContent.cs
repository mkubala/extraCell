using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using extraCell.domain;

namespace extraCell.view
{
    public class MDIContent
    {
        private static int documentsCount;
        public string documentPath { set; get; }
        public string documentName { set; get; }
        public ExtraCellTable extraCellTable { set; get; }
        public TabPage tabPage { set; get; }
        public int currentRow { get; set; }
        public int currentCol { get; set; }

        public MDIContent() {
            documentsCount++;
            Initialize(null);
        }

        public MDIContent(string path)
        {
            documentsCount++;
            Initialize(path);
        }

        private void Initialize(string path)
        {
            extraCellTable = new ExtraCellTable();

            tabPage = new TabPage(documentName);
            tabPage.Padding = new Padding(3);
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Controls.Add(extraCellTable);
            tabPage.ImageIndex = 0;

            loadDocument(path);

            System.Diagnostics.Debug.WriteLine("before fill");
            extraCellTable.ece.fill();
            System.Diagnostics.Debug.WriteLine("after fill");

            extraCellTable.Focus();
        }

        public int getDocumentsCount()
        {
            return documentsCount;
        }

        private void loadDocument(string filePath) {
            string path = filePath.Trim();
            if(path != null && path.Length > 0)
            {
                FileInfo fileInfo = new FileInfo(path);
            
                if (fileInfo.Exists)
                {
                    System.Diagnostics.Debug.WriteLine("before importXML");
                    extraCellTable.ece.importXML(path);
                    documentPath = path;
                    documentName = fileInfo.Name;
                    tabPage.Text = documentName;
                }
            }
            else
            {
                documentPath = "";
                documentName = "Niezapisany(" + documentsCount + ")";

                tabPage.Text = documentName;
            }
        }

        public void saveDocument(string filePath)
        {
            /*DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = System.Drawing.Color.BlanchedAlmond;
            extraCellTable.Rows[0].Cells[0].Style = style;*/
            extraCellTable.ece.exportXML(filePath.Trim());
            extraCellTable.changed = false;
        }
    }
}
