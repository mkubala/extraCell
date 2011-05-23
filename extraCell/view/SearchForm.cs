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
        private MDIContent mdiContent;

        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(MDIContent mdiContent)
        {
            this.mdiContent = mdiContent;
            InitializeComponent();
        }

        private void szukajButton_Click(object sender, EventArgs e)
        {
            RegexOptions options;
            if (!wielkoscZnakowCheck.Checked) options = RegexOptions.IgnoreCase;
            if(caleWyrazyCheck.Checked) options = options | RegexOptions.ExplicitCapture;

            LinkedList<int[]> res = mdiContent.extraCellTable.ece.search(searchQueryInputBox.Text.ToString(), options);
            if (res.Count > 0)
            {
                setResultOptions(true);
                mdiContent.extraCellTable.CurrentCell = mdiContent.extraCellTable.Rows[res.First.Value[1]].Cells[res.First.Value[0]];
            }
            else
            {
                setResultOptions(false);
                MessageBox.Show("Nie znaleziono żadnych komórek");
            }
               
        }

        private void setResultOptions(Boolean enabled)
        {

        }

        private void poprzedniButton_Click(object sender, EventArgs e)
        {

        }

        private void nastepnyButton_Click(object sender, EventArgs e)
        {

        }

    }
}
