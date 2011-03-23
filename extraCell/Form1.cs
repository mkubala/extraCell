﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace extraCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 300;
            dataGridView1.RowCount = 300;
     
            for ( int  i = 0; i < 300; i++)
            {
                dataGridView1.Columns[i].Name = (Convert.ToChar(65+i)).ToString();
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            }

            // Wylaczenie sortowania 

            foreach (DataGridViewColumn kol in this.dataGridView1.Columns)
            {
                kol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {

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



    }
}
