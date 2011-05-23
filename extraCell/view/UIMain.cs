using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using extraCell.view;
using extraCell.formula;
using extraCell.domain;

namespace extraCell
{
    public partial class UIMain : Form
    {
        private List<MDIContent> mdiContainer;
        private const String documentFilter = "ExtraCell Document (*.xcd)|*.xcd|XML document (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";

        public UIMain()
        {
            InitializeComponent();
            mdiContainer = new List<MDIContent>();
            setEditOptions(false);

//            AddTab("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        //Dodaje nowa karte i tabelke
        private void AddTab()
        {
            AddTab("");
        }

        //Dodaje nowa karte i tabelke
        private void AddTab(string filePath)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("before load");
                MDIContent mdiContent = new MDIContent(filePath);
                System.Diagnostics.Debug.WriteLine("after load");

                ImageList imageList = new ImageList();
                Stream stream = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("extraCell.gfx.close.png");
                imageList.ImageSize = new Size(16, 16);
                imageList.Images.Add(Image.FromStream(stream));

                mdiContent.extraCellTable.inputBox = formulaInputBox;
                mdiContent.tabPage.ImageIndex = 0;
                mdiContainer.Add(mdiContent);
            
                filesTab.ImageList = imageList;
                filesTab.Controls.Add(mdiContent.tabPage);

                filesTab.SelectTab(mdiContainer.Count - 1);

                setEditOptions(true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public MDIContent getCurrentDoc()
        {
            return mdiContainer[filesTab.SelectedIndex];
        }

        public Formula getFormula()
        {
            return getCurrentDoc().extraCellTable.ece.getFormula();
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = documentFilter;
            openFileDialog1.FileName = "";

            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
                AddTab(openFileDialog1.FileName);
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeTab();
        }

        private void drukujToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wyjscieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void noweOknoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            ExtraCellTable tabelka = (ExtraCellTable)filesTab.SelectedTab.Controls[0];

            for (int i = 0; i < (tabelka.SelectedCells.Count); i++)
            {
                tabelka.SelectedCells[i].Style.ForeColor = colorDialog1.Color;
            }
        }

        private void czcionkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            for (int i = 0; i < (getCurrentDoc().extraCellTable.SelectedCells.Count); i++)
                getCurrentDoc().extraCellTable.SelectedCells[i].Style.Font = fontDialog1.Font;
        }

        private void backColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog backgroundColorDialog = new ColorDialog();
            backgroundColorDialog.ShowDialog();

            for (int i = 0; i < (getCurrentDoc().extraCellTable.SelectedCells.Count); i++)
            {
                getCurrentDoc().extraCellTable.SelectedCells[i].Style.BackColor = backgroundColorDialog.Color;
                getCurrentDoc().extraCellTable.ece.getCell(0, 0).backColor = backgroundColorDialog.Color.ToArgb();
            }
        }

        private void NowyStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void ZapiszStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private bool saveFile()
        {
            saveFileDialog1.Filter = documentFilter;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    getCurrentDoc().extraCellTable.ece.exportXML(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się zapisać pliku.\n" + ex.Message, "Błąd");
                    return false;
                }
                string name = new FileInfo(saveFileDialog1.FileName).Name;
                getCurrentDoc().tabPage.Text = name;

                return true;
            }
            return false;
        }

        private void calculate()
        {
            getCurrentDoc().extraCellTable.isEditing = false;
            Point p = getCurrentDoc().extraCellTable.CurrentCellAddress;
            getCurrentDoc().extraCellTable.ece.setCell(p.X, p.Y, formulaInputBox.Text.Trim());
        }

        private void obliczButton_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void filesTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filesTab.TabCount == 0) return;
            Point p = getCurrentDoc().extraCellTable.CurrentCellAddress;
            Cell c = getCurrentDoc().extraCellTable.ece.getCell(p.X, p.Y);
            formulaInputBox.Text = c.formula;
        }

        private void filesTab_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle tabRect = filesTab.GetTabRect(filesTab.SelectedIndex);

            if (/*filesTab.SelectedIndex == currentTabNum &&*/ e.X >= tabRect.Left+4 && e.X <= tabRect.Left + 20)
            {
                getCurrentDoc().extraCellTable.isEditing = false;
                closeTab();
            }
        }

        private void closeTab() {
            if (askOnExit())
            {
                //mdiContainer.RemoveAt(filesTab.SelectedIndex);
                mdiContainer.Remove(getCurrentDoc());
                filesTab.SelectedTab.Dispose();
                if (mdiContainer.Count < 1)
                    setEditOptions(false);
            }
        }

        /* Zapytanie o wyjście i zapis + jego obsługa */
        private bool askOnExit() {
            DialogResult dialogResult = MessageBox.Show(
                "Czy na pewno chcesz zamknąć ten dokument?", 
                "Zamykanie karty", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );
            if (dialogResult.Equals(DialogResult.No))
            {
                return false;
            }
            else if (getCurrentDoc().extraCellTable.changed)
            {
                dialogResult = MessageBox.Show(
                    "Dokument " + getCurrentDoc().documentName + " nie został zapisany. Czy chcesz zapisać zmiany?", 
                    "Zapisz zmiany", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question
                );

                if (dialogResult.Equals(DialogResult.Cancel))
                    return false;
                else if (dialogResult.Equals(DialogResult.Yes) && (getCurrentDoc().documentPath == null || getCurrentDoc().documentPath.Trim().Length == 0))
                    return saveFile();
                else if (dialogResult.Equals(DialogResult.Yes))
                    getCurrentDoc().saveDocument(getCurrentDoc().documentPath);
                return true;
            }
            return true;
        }

        private void setEditOptions(bool enable)
        {
            znajdźToolStripMenuItem.Enabled = enable;
            ZapiszStripMenuItem.Enabled = enable;
            formatToolStripMenuItem.Enabled = enable;
            edycjaToolStripMenuItem.Enabled = enable;
            drukujToolStripMenuItem.Enabled = enable;
        }

        private void formulaInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
                calculate();
        }

        private void znajdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(getCurrentDoc());
            searchForm.Visible = true;
            searchForm.Activate();
        }

        private void formulaInputBox_TextChanged(object sender, EventArgs e)
        {
            getCurrentDoc().extraCellTable.isEditing = true;
            getCurrentDoc().extraCellTable.CurrentCell.Value = this.formulaInputBox.Text;
        }

        private void beginEdit(object sender, EventArgs e)
        {
            getCurrentDoc().extraCellTable.isEditing = true;
        }

        private void endEdit(object sender, EventArgs e)
        {
            getCurrentDoc().extraCellTable.isEditing = false;
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autorzy:\n- Marcin Kubala\n- Michał Urbańczyk\n- Paweł Ochalik", "O programie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
