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
    public partial class Form1 : Form
    {
        private IEngine ece;
        private List <TabPage> karty = new List <TabPage>();
        private List<extraCellTable> tabelki = new List<extraCellTable>();
//         private void AddTab(string title);
        //Licznik nowych plikow 
        private byte NewCount = 1;

        private const String documentFilter = "ExtraCell Document (*.xcd)|*.xcd|XML document (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";


        public Form1()
        {
            InitializeComponent();
            // Wylaczenie sortowania
/*
            foreach (DataGridViewColumn kol in this.dataGridView1.Columns)
            {
                kol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            }
            */
      //      dataGridView1.DataSource = null;

            
         

      //      dataGridView1.DataSource = ece.toDataTable();
            /***************************************************************
             * Sztuczne dodanie karty */
//            AddTab("Artificial");
            /***************************************************************
            * Sztuczne dodanie karty - KONIEC*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        //Dodaje nowa karte i tabelke
        private void AddTab(string title)
        {
            AddTab(title, "");
        }

        //Dodaje nowa karte i tabelke
        private void AddTab(string title, string filePath)
        {
            System.Windows.Forms.TabPage karta = new System.Windows.Forms.TabPage();

            extraCellTable tabelka = new extraCellTable();
            tabelka.ece = new ExtraCellEngine("tabelka");
            
            if(filePath.Trim().Length > 0)
                tabelka.ece.importXML(filePath);

            tabelka.DataSource = tabelka.ece;

            karta.Controls.Add(tabelka);


            tabelka.Size = new System.Drawing.Size(552, 270);
            tabelka.Location = new System.Drawing.Point(3, 3);

            tabelka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tabelka.Dock = System.Windows.Forms.DockStyle.Fill;
            tabelka.Location = new System.Drawing.Point(3, 3);
            tabelka.RowHeadersWidth = 50;
            tabelka.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            tabelka.Size = new System.Drawing.Size(552, 270);

            //  tabelka.DataSource = new ExtraCellEngine().toDataTable();

            karta.Padding = new System.Windows.Forms.Padding(3);

            // Nazwa wyswietlana na karcie 

            karta.Text = title;
            karta.UseVisualStyleBackColor = true;

            tabelki.Add(tabelka);
            karty.Add(karta);
            filesTab.Controls.Add(karta);
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = documentFilter;
            openFileDialog1.FileName = "";

            DialogResult result = openFileDialog1.ShowDialog();

            // Process open file dialog box results
            if (result == DialogResult.OK)
            {
                // Nazwa wyswietlana na karcie 
                // Skraca do nazwy pliku - zamiast pelnej sciezki
                AddTab(new FileInfo(openFileDialog1.FileName).Name, openFileDialog1.FileName);
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

            extraCellTable tabelka = (extraCellTable)filesTab.SelectedTab.Controls[0];

            for (int i = 0; i < (tabelka.SelectedCells.Count); i++)
            {
                tabelka.SelectedCells[i].Style.ForeColor = colorDialog1.Color;
            }
        }

        private void czcionkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();

            extraCellTable tabelka = (extraCellTable)filesTab.SelectedTab.Controls[0];

      //      Debug.Print(this.ToString()+ " nazwa aktywnej zakladki: " + filesTab.SelectedTab.Text);

            for (int i = 0; i < (tabelka.SelectedCells.Count); i++)
            {
                tabelka.SelectedCells[i].Style.Font = fontDialog1.Font;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog backgroundColorDialog = new ColorDialog();

            backgroundColorDialog.ShowDialog();

            extraCellTable tabelka = (extraCellTable)filesTab.SelectedTab.Controls[0];

            for (int i = 0; i < (tabelka.SelectedCells.Count); i++)
            {
                tabelka.SelectedCells[i].Style.BackColor = backgroundColorDialog.Color;
            }
        }

        private void NowyStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab("Niezapisany"+NewCount.ToString());
            NewCount++;
        }

        private void ZapiszStripMenuItem_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.Filter = documentFilter;
            saveFileDialog1.RestoreDirectory = true;

            // Process open file dialog box results
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tabelki[filesTab.SelectedIndex].ece.exportXML(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie udało się zapisać pliku.\n" + ex.Message, "Błąd");
                    return;
                }
                MessageBox.Show("Plik " + new FileInfo(saveFileDialog1.FileName).Name + " został pomyślnie zapisany.", "Sukces");

                //Operacje po zapisaniu pliku
                //Debug.WriteLine("Zapisano plik jako " + saveFileDialog1.FileName + "(zakladka nr " + filesTab.SelectedIndex + ")");
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("Zaznaczona komorka " + DateTime.Now.ToLongTimeString());
        }



        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Przeciąganie");
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            Debug.Print(DateTime.Now.ToShortDateString() + " zmiana");
        }



 


    }
}
