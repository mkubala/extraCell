using System;
using System.Windows.Forms;
using System.Diagnostics;
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
        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellEnter(e);

            Paint += new PaintEventHandler(extraCellTable_Paint);

        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            Debug.Print(DateTime.Now.ToLongTimeString() + "OnCellPainting");
        }

        void extraCellTable_Paint(object sender, PaintEventArgs e)
        {
            Pen _pen = new Pen(Color.Black, 3);
            Rectangle ramka;

            // Wspolrzedne punktow
            Point LeftUpper = new Point(int.MaxValue, int.MaxValue);
            Point RightLower = new Point(0, 0);

            if (CurrentCell != null)
            {
                int i = 0;

                foreach (DataGridViewCell cell in this.SelectedCells)
                {

                    i++;
                    int x = cell.ColumnIndex;
                    int y = cell.RowIndex;

                    if (x <= LeftUpper.X && y <= LeftUpper.Y)
                    {
                        LeftUpper.X = x;
                        LeftUpper.Y = y;
                    }
                    if (x >= RightLower.X && y >= RightLower.Y)
                    {
                        RightLower.X = x;
                        RightLower.Y = y;
                    }

                    Debug.Print(String.Format("Komorka nr: {0} {1}{2}", i, x, y));
                    cell.Value = String.Format("Komorka nr: {0} {1}{2}", i, x, y);



                    //       WspKom.Add(new Point(cell.RowIndex, cell.ColumnIndex));
                }
                this[LeftUpper.X, LeftUpper.Y].Value = ("Komorka LeftUpper");
                this[RightLower.X, RightLower.Y].Value = ("Komorka RightLower");

                //    Invalidate(false);



                Debug.Print(String.Format("Aktualna komorka: {0}{1}", CurrentCell.RowIndex, CurrentCell.ColumnIndex));


                //         Point Punkt = new Point();

                ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false);
                /*
                                Punkt.X = (CurrentCell.ColumnIndex +1) * RowHe ;
                                Punkt.Y = (CurrentCell.RowIndex +1) * CurrentCell.Size.Height ;
                                */

                e.Graphics.DrawRectangle(_pen, new Rectangle(ramka.Location, CurrentCell.Size));

            }
            Debug.Print("OnPaint");
        
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            base.OnPaint(e);

            // e.Graphics.DrawRectangle(System.Drawing.Pens.Black, base.Cell
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
