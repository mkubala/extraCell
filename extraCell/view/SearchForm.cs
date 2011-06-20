using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace extraCell.view
{
    public partial class SearchForm : Form
    {
        internal ExtraCellTable extraCellTable { get; set; }
        private LinkedList<int[]> res;
        private int currentIndex = 0;

        public SearchForm(MDIUI p)
        {
            MdiParent = p;
            InitializeComponent();
        }

        private void szukaj()
        {
            if (searchQueryInputBox.Text.Trim().Length == 0)
            {
                setResultOptions(false);
                MessageBox.Show("Nie podano wzorca wyszukiwania");
                return;
            }

            extraCellTable = ((MDIUI)MdiParent).activeDocument.extraCellTable;
            RegexOptions options = RegexOptions.Compiled;// = RegexOptions.None;

            if (!wielkoscZnakowCheck.Checked)
                options |= RegexOptions.IgnoreCase;

            if (caleWyrazyCheck.Checked)
                options |= RegexOptions.ExplicitCapture;

            System.Diagnostics.Debug.WriteLine(options);

            res = extraCellTable.ece.search(searchQueryInputBox.Text.ToString(), options);
            if (res.Count > 0)
            {
                setResultOptions(true);
                selectCell();
            }
            else
            {
                setResultOptions(false);
                MessageBox.Show("Nie znaleziono żadnych komórek");
            }
        }

        private void szukajButton_Click(object sender, EventArgs e)
        {
            szukaj();               
        }

        private void selectCell()
        {
            int col = (int) res.ElementAt<int[]>(currentIndex).GetValue(1);
            int row = (int) res.ElementAt<int[]>(currentIndex).GetValue(0);
            extraCellTable.CurrentCell = extraCellTable.Rows[row].Cells[col];
        }

        private void setResultOptions(Boolean enabled)
        {
            nastepnyButton.Enabled = enabled;
            poprzedniButton.Enabled = enabled;
        }

        private void poprzedniButton_Click(object sender, EventArgs e)
        {
            if (currentIndex == 0) currentIndex = res.Count - 1;
            else currentIndex--;
            selectCell();
        }

        private void nastepnyButton_Click(object sender, EventArgs e)
        {
            if (currentIndex == res.Count - 1) currentIndex = 0;
            else currentIndex++;
            selectCell();
        }

        private void searchQueryInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                szukaj();
        }
        
    }
}
