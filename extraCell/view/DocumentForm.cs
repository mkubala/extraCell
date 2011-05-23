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
        private string documentPath;
        private string documentName;
        private static int documentsCount;
        private MDIUI parent;
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
            parent = p;
            InitializeComponent();

            Helpers.debug("before set inputbox");
            extraCellTable = new ExtraCellTable();
            extraCellTable.inputBox = parent.formulaInput;

            Helpers.debug("after set inputbox");

            documentsCount++;
            
            string path = filePath.Trim();
            
            if (path != null && path.Length > 0)
            {
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Exists)
                {
                    Helpers.debug("before import");
                    extraCellTable.ece.importXML(path);
                    Helpers.debug("after import");
                    documentPath = path;
                    documentName = fileInfo.Name;
                }
            }
            else
            {
                documentPath = "";
                documentName = "Niezapisany(" + documentsCount + ")";
            }
            
            this.Text = documentName;

            Helpers.debug("before fill");
            extraCellTable.ece.fill();
            Helpers.debug("after fill");
            extraCellTable.changed = false;
            extraCellTable.Focus();
            Controls.Add(extraCellTable);
        }

        public extraCell.formula.Formula getFormula()
        {
            return extraCellTable.ece.formulaProc;
        }
    }
}
