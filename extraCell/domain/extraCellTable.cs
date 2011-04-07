using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;

namespace extraCell.domain
{
    class extraCellTable : DataGridView
    {
        private System.Data.DataTable _Engine;
        private bool CellEntered = false;

        //[BrowsableAttribute(false)]
        public DataGridViewSelectedCellCollection LastSelectedCells;
        public Point LastCellAddress;

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

            DataTable dt = new DataTable();
            LetterCounter lettcount = new LetterCounter();

            dt.Columns.Add();

            for (int i = 0; i < 255; i++)
            {
                DataGridViewTextBoxCustomCellColumn c = new DataGridViewTextBoxCustomCellColumn();
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.Width = 45;

                c.HeaderText = lettcount.ToString();
                this.Columns.Add(c);
                lettcount.Increment();
                dt.Rows.Add(" ");
            }

          //  this.DataSource = dt;

           

            for (int i = 0; i < 255; i++)
            {
                this.Rows.Add();
                this.Rows[i].HeaderCell.Value = i;
            }

            Debug.Print("Ilosc wierszy: " + this.Rows.Count.ToString());
           
        }

        /**************************************************************************/
        /**************************************************************************/

        public class DataGridViewTextBoxCustomCell : DataGridViewTextBoxCell
        {
            private bool entered;

            protected override void Paint(
                Graphics graphics,
                Rectangle clipBounds,
                Rectangle cellBounds,
                int rowIndex,
                DataGridViewElementStates cellState,
                object value,
                object formattedValue,
                string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
            {
                // Call the base class method to paint the default cell appearance.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                    value, formattedValue, errorText, cellStyle,
                    advancedBorderStyle, paintParts);

                // Retrieve the client location of the mouse pointer.
                Point cursorPosition =
                    this.DataGridView.PointToClient(Cursor.Position);

                // If the mouse pointer is over the current cell, draw a custom border.
                //if (cellBounds.Contains(cursorPosition))
                    if ( entered )
                {
                    Rectangle newRect = new Rectangle(cellBounds.X +1 ,
                cellBounds.Y +1 , cellBounds.Width -3,
                cellBounds.Height -3 );
                    Pen _Pen = new Pen(Color.Black);
                    _Pen.Width = 2;
                    graphics.DrawRectangle(_Pen, newRect);
                    _Pen.Width = 2;
                    _Pen.Color = Color.White;
                    graphics.DrawRectangle(_Pen, new Rectangle(cellBounds.X + cellBounds.Width - 6, cellBounds.Y + cellBounds.Height - 6, 15, 15));
                    _Pen.Width = 5;
                    _Pen.Color = Color.Black;
                        graphics.DrawRectangle(_Pen, new Rectangle(cellBounds.X + cellBounds.Width -5 ,cellBounds.Y + cellBounds.Height -5, 15, 15) );
                 //   entered = false;
                }
            }

            protected override void OnEnter(int rowIndex, bool throughMouseClick)
            {
                base.OnEnter(rowIndex, throughMouseClick);
                       entered = true;
            }

            protected override void OnLeave(int rowIndex, bool throughMouseClick)
            {
                base.OnLeave(rowIndex, throughMouseClick);
                entered = false;
                this.DataGridView.InvalidateCell(this);
            }

            // Force the cell to repaint itself when the mouse pointer enters it.
            protected override void OnMouseEnter(int rowIndex)
            {
                this.DataGridView.InvalidateCell(this);
            }

            // Force the cell to repaint itself when the mouse pointer leaves it.
            protected override void OnMouseLeave(int rowIndex)
            {
                this.DataGridView.InvalidateCell(this);
            }

        }

        public class DataGridViewTextBoxCustomCellColumn : DataGridViewColumn
        {
            public DataGridViewTextBoxCustomCellColumn()
            {
                this.CellTemplate = new DataGridViewTextBoxCustomCell();
            }
        }


        /**************************************************************************/
        /**************************************************************************/


        protected override void OnCellEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellEnter(e);
            //   this.InvalidateCell(e.ColumnIndex, e.RowIndex);


              return;

            PaintEventHandler t = new PaintEventHandler(extraCellTable_Paint);
            if (!CellEntered)
            {

                Paint += t;
                CellEntered = true;
            }

        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            Debug.Print(DateTime.Now.ToLongTimeString() + "OnCellPainting");
        }

        void extraCellTable_Paint(object sender, PaintEventArgs e)
        {
            return;

            Pen _pen = new Pen(Color.Black, 3);
            Rectangle ramka;

            // Wspolrzedne punktow
            Point LeftUpper = new Point(int.MaxValue, int.MaxValue);
            Point RightLower = new Point(0, 0);

            //TODO
            //  return;

            if (LastSelectedCells == null) LastSelectedCells = SelectedCells;

            if (LastCellAddress == null) LastCellAddress = CurrentCellAddress;

            if (CurrentCell != null && true  /* ( LastCellAddress.X != CurrentCellAddress.X || LastCellAddress.Y != CurrentCellAddress.Y ) */)
            {
                LastCellAddress = CurrentCellAddress;
                int i = 0;

                LastSelectedCells = SelectedCells;
                //if ( this.SelectedCells != LastSelectedCells)
                //    throw new SystemException("Even");


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
            Debug.Print(DateTime.Now.ToLongTimeString() + " OnPaint extraCellTable_Paint");

            // Paint -= new PaintEventHandler(extraCellTable_Paint);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            base.OnPaint(e);

            return;

            // e.Graphics.DrawRectangle(System.Drawing.Pens.Black, base.Cell
            Pen _pen = new Pen(Color.Black, 3);
            Rectangle ramka;

            // Wspolrzedne punktow
            Point LeftUpper = new Point(int.MaxValue, int.MaxValue);
            Point RightLower = new Point(0, 0);

            //TODO

            if (LastSelectedCells == null) LastSelectedCells = SelectedCells;

            if (LastCellAddress == null) LastCellAddress = CurrentCellAddress;

            if (CurrentCell != null && (LastCellAddress.X != CurrentCellAddress.X || LastCellAddress.Y != CurrentCellAddress.Y))
            {
                LastCellAddress = CurrentCellAddress;
                int i = 0;

                LastSelectedCells = SelectedCells;
                //if ( this.SelectedCells != LastSelectedCells)
                //    throw new SystemException("Even");


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
            Debug.Print(DateTime.Now.ToLongTimeString() + " OnPaint extraCellTable_Paint");

            e.Graphics.Flush();

            ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false);
            e.Graphics.DrawRectangle(_pen, new Rectangle(ramka.Location, CurrentCell.Size));
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
