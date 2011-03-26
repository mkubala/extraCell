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

namespace extraCell
{
    public partial class Form1 : Form
    {
        private ExtraCellEngine ece;
        private List <TabPage> karty = new List <TabPage>();
        private List<extraCellTable> tabelki = new List<extraCellTable>();

        public Form1()
        {
            InitializeComponent();

            ece = new ExtraCellEngine();


            dataGridView1.DataSource = ece.toDataTable();

            // Wylaczenie sortowania
/*
            foreach (DataGridViewColumn kol in this.dataGridView1.Columns)
            {
                kol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            }
            */
            dataGridView1.DataSource = null;

             DataGridViewCustomColumn col = new DataGridViewCustomColumn();
            dataGridView1.Columns.Add(col);
            
          

      //      dataGridView1.DataSource = ece.toDataTable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pliki xml|*.xml|Wszystkie pliki|*.*";
            openFileDialog1.FileName = "";

            DialogResult result = openFileDialog1.ShowDialog();

            // Process open file dialog box results
            if (result == DialogResult.OK)
            {
                // Open document
                string filename = openFileDialog1.FileName;

                // Dodanie karty

                System.Windows.Forms.TabPage karta = new System.Windows.Forms.TabPage();

              
                karty.Add(karta);
                filesTab.Controls.Add(karta);

                extraCellTable tabelka = new extraCellTable();

                karta.Controls.Add(tabelka);

                tabelka.Size = new System.Drawing.Size(552, 270);
                tabelka.Location = new System.Drawing.Point(3, 3);

                tabelka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                tabelka.Dock = System.Windows.Forms.DockStyle.Fill;
                tabelka.Location = new System.Drawing.Point(3, 3);
                tabelka.RowHeadersWidth = 50;
                tabelka.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                tabelka.Size = new System.Drawing.Size(552, 270);


                tabelki.Add(tabelka);

                tabelka.DataSource = new ExtraCellEngine().toDataTable();


                dataGridView1.DataSource = ece.toDataTable();

                karta.Padding = new System.Windows.Forms.Padding(3);

                // Nazwa wyswietlana na karcie 

                karta.Text = new  FileInfo( openFileDialog1.FileName).Name;
                karta.UseVisualStyleBackColor = true;

                //Operacje po otwarciu pliku
            }

           
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            for (int i = 0; i < (dataGridView1.SelectedCells.Count); i++)
            {
                dataGridView1.SelectedCells[i].Style.ForeColor = colorDialog1.Color;
            }
        }

        private void czcionkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            for (int i = 0; i < (dataGridView1.SelectedCells.Count); i++)
            {
                dataGridView1.SelectedCells[i].Style.Font = fontDialog1.Font;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog backgroundColorDialog = new ColorDialog();

            backgroundColorDialog.ShowDialog();

            for (int i = 0; i < (dataGridView1.SelectedCells.Count); i++)
            {
                dataGridView1.SelectedCells[i].Style.BackColor = backgroundColorDialog.Color;
            }
        }

        private void NowyStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ZapiszStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("Zaznaczona komorka " + DateTime.Now.ToLongTimeString());

           DataGridViewCellStyle styl =  new DataGridViewCellStyle();

            

            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = styl;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            
        }


 


    }
}
