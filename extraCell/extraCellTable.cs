using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
// using System.Drawing.Graphics;
using System.Drawing;

namespace extraCell
{
    class extraCellTable : DataGridView
    {
        private System.Data.DataTable _Engine;



        public System.Data.DataTable Engine
        {
            get { return _Engine; }
            set { _Engine = value; }
        }

        public extraCellTable()
            : base()
        {
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridColor = Color.BlueViolet;
            
            CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            BorderStyle = BorderStyle.Fixed3D;

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            base.OnPaint(e);

            this.Update();
            
            // e.Graphics.DrawRectangle(System.Drawing.Pens.Black, base.Cell
            Pen _pen = new Pen(Color.Yellow, 3);
            Rectangle ramka;

            

            if (CurrentCell != null)
            {

         //       Debug.Print(String.Format("Aktualna komorka: {0}{1}", CurrentCell.RowIndex, CurrentCell.ColumnIndex));


       //         Point Punkt = new Point();

                ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false);
/*
                Punkt.X = (CurrentCell.ColumnIndex +1) * RowHe ;
                Punkt.Y = (CurrentCell.RowIndex +1) * CurrentCell.Size.Height ;
                */
                e.Graphics.DrawRectangle(_pen, new Rectangle( ramka.Location , CurrentCell.Size));
            }
            Debug.Print("OnPaint");
        }
        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {

                if (e.X == this[e.ColumnIndex, e.RowIndex].ContentBounds.Right - 1 ||

                    e.Y == this[e.ColumnIndex, e.RowIndex].ContentBounds.Bottom - 1)
                {

                    this.Cursor = Cursors.Cross;

                }

                else
                {

                    this.Cursor = Cursors.Arrow;

                }

            }
            base.OnCellMouseMove(e);
        }

        public object DataSource
        {
            get { return base.DataSource; }
            //         set { base.DataSource = new ExtraCellEngine().toDataTable(); _Engine = (System.Data.DataTable)base.DataSource; }
            set { base.DataSource = value; }
        }


        void CellMouseMoveCross(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {

                if (e.X == this[e.ColumnIndex, e.RowIndex].ContentBounds.Right - 1 ||

                    e.Y == this[e.ColumnIndex, e.RowIndex].ContentBounds.Bottom - 1)
                {

                    this.Cursor = Cursors.Cross;

                }

                else
                {

                    this.Cursor = Cursors.Arrow;

                }

            }

        }



    }
}
