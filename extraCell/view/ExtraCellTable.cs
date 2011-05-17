using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace extraCell.view
{
    class extraCellTable : DataGridView
    {
        private System.Data.DataTable _Engine;
        private bool CellEntered = false;

        public extraCell.domain.IEngine ece { get; set; }

        private bool ColumnClicked = false, RowClicked = false;

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
            //ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridColor = Color.Coral;
            //AutoGenerateColumns = false;
            this.AllowUserToAddRows = false;

            EnableHeadersVisualStyles = true;
            ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;

            //        RowHeadersVisible = true;

            //   DataTable dt = new DataTable();
       //     LetterCounter lettcount = new LetterCounter();

            //     dt.Columns.Add();

            // AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

/*            for (int i = 0; i < 50; i++)
            {
                DataGridViewTextBoxCustomCellColumn c = new DataGridViewTextBoxCustomCellColumn();
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                c.Width = 45;
                //  c.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                //getColumnName

                //c.HeaderText = lettcount.ToString();
                c.HeaderText = helpers.Helpers.getColumnName(i+1);
                this.Columns.Add(c);
                this.Rows.Add(1);


                // Nie dziala!
                //     this.Rows.Add(1);

                //      this.Rows[i].HeaderCell.Value = i;

                //       c.DataGridView.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //      c.DataGridView.Rows[i].HeaderCell.Style.BackColor = Color.Azure;

              //  lettcount.Increment();
                //  dt.Rows.Add(" ");
            }
            */

            /* hwast debug START */
            ece = new extraCell.domain.ExtraCellEngine();
            extraCell.formula.Formula.ece = ece;
            this.DataSource = ece;
            
            ece.addRow();
            ece.addRow();
            ece.addRow();
            ece.addRow();

            ece.addColumn();

            ece.setCell(0, 1, "3");
            ece.setCell(0, 2, "9");
            ece.setCell(0, 3, "3");
            
            ece.setCell(0, 0, "=suma(2,suma(1,suma(0.5,0.5)),8, suma(A2:A4,2))");
            
            ece.exportXML("test.xml");
            // powyższe linijki lub
            //ece.importXML("..\\Release\\jaha.xcd");
            //ece.exportXML("test.xml");

            /* hwast debug FINISH */

            /*
            for (int i = 0; i < 255; i++)
            {
                this.Rows.Add(1);
                this.Rows[i].HeaderCell.Value = i;
            }
            */
            ////DebugPrint("Ilosc wierszy: " + this.Rows.Count.ToString());

        }

        /*
        protected  override  void OnCellFormatting( DataGridViewCellFormattingEventArgs e)
        {
            this.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            this.Rows[e.RowIndex].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.Rows[e.RowIndex].HeaderCell.Style.BackColor = Color.Azure;
        }
        */
        /*
         * Zrodlo : http://www.danielsoper.com/programming/DataGridViewNumberedRows.aspx
         */

        // Numerowanie wierszy
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        { //this method overrides the DataGridView's RowPostPaint event 
            //in order to automatically draw numbers on the row header cells
            //and to automatically adjust the width of the column containing
            //the row header cells so that it can accommodate the new row
            //numbers,

            //store a string representation of the row number in 'strRowNumber'
            string strRowNumber = (e.RowIndex + 1).ToString();

            //prepend leading zeros to the string if necessary to improve
            //appearance. For example, if there are ten rows in the grid,
            //row seven will be numbered as "07" instead of "7". Similarly, if 
            //there are 100 rows in the grid, row seven will be numbered as "007".
            //    while (strRowNumber.Length < this.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            //determine the display size of the row number string using
            //the DataGridView's current font.
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            //adjust the width of the column that contains the row header cells 
            //if necessary
            if (this.RowHeadersWidth < (int)(size.Width + 5)) this.RowHeadersWidth = (int)(size.Width + 5);

            //this brush will be used to draw the row number string on the
            //row header cell using the system's current ControlText color
            Brush b = SystemBrushes.ControlText;

            //draw the row number string on the current row header cell using
            //the brush defined above and the DataGridView's default font
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

            //call the base object's OnRowPostPaint method
            base.OnRowPostPaint(e);
        } //end OnRowPostPaint method



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
                if (entered)
                {
                    Rectangle newRect = new Rectangle(cellBounds.X + 1,
                cellBounds.Y + 1, cellBounds.Width - 3,
                cellBounds.Height - 3);
                    Pen _Pen = new Pen(Color.Black);
                    _Pen.Width = 2;
                    graphics.DrawRectangle(_Pen, newRect);

                    /*
                    
                    _Pen.Width = 2;
                    _Pen.Color = Color.White;
                    graphics.DrawRectangle(_Pen, new Rectangle(cellBounds.X + cellBounds.Width - 6, cellBounds.Y + cellBounds.Height - 6, 15, 15));
               
                    
                    _Pen.Width = 5;
                    _Pen.Color = Color.Black;
                    graphics.DrawRectangle(_Pen, new Rectangle(cellBounds.X + cellBounds.Width - 5, cellBounds.Y + cellBounds.Height - 5, 15, 15));
                     */
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
            ////DebugPrint(DateTime.Now.ToLongTimeString() + "OnCellPainting");


            /* System.IO.Stream imageStream = this.GetType().Assembly.GetManifestResourceStream("Controls.002-folder_add.png"); checkBox1.Image = Image.FromStream(imageStream);
            * */


            if (SelectedCells.Count == 1 && e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                Rows[e.RowIndex].HeaderCell.Style.BackColor = Color.Red;
                ////DebugPrint("SelectedCells.Count == 1 && e.ColumnIndex != -1 && e.RowIndex != -1)");
            }



            if (e.ColumnIndex == -1)
            {
                System.IO.Stream imageStream = this.GetType().Assembly.GetManifestResourceStream("extraCell.gfx.background3.png");
                Image image = Image.FromStream(imageStream);

                ImageAttributes attr = new ImageAttributes();
                attr.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Tile);
                e.Graphics.DrawImage(image, e.CellBounds, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attr);
                e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background));
                e.Handled = true;

                ////DebugPrint(this.ToString() + " if (e.ColumnIndex == -1))");

            }
            else if (this.SelectedColumns.Count > 0 && this.SelectedColumns.Contains(this.Columns[e.ColumnIndex]))
            {
                //         e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);
                //           e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.CellBounds);
                System.IO.Stream imageStream = this.GetType().Assembly.GetManifestResourceStream("extraCell.gfx.background4.png");
                Image image = Image.FromStream(imageStream);

                ImageAttributes attr = new ImageAttributes();

                attr.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Tile);
                e.Graphics.DrawImage(image, e.CellBounds, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attr);

                e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~(DataGridViewPaintParts.Background | DataGridViewPaintParts.SelectionBackground)));
                e.Handled = true;

                ////DebugPrint(this.ToString() + " this.SelectedRows.Count > 0 && this.SelectedRows.Contains(this.Rows[e.RowIndex])");
            }


            if (e.RowIndex == -1)
            {
                System.IO.Stream imageStream = this.GetType().Assembly.GetManifestResourceStream("extraCell.gfx.background.png");
                Image image = Image.FromStream(imageStream);

                ImageAttributes attr = new ImageAttributes();
                attr.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Tile);
                e.Graphics.DrawImage(image, e.CellBounds, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attr);
                e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.Background));
                e.Handled = true;

                ////DebugPrint(this.ToString() + " if (e.RowIndex == -1)");
            }
            else if (this.SelectedRows.Count > 0 && this.SelectedRows.Contains(this.Rows[e.RowIndex]))
            {
                //         e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);
                //           e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.CellBounds);
                System.IO.Stream imageStream = this.GetType().Assembly.GetManifestResourceStream("extraCell.gfx.background2.png");
                Image image = Image.FromStream(imageStream);

                ImageAttributes attr = new ImageAttributes();

                attr.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Tile);
                e.Graphics.DrawImage(image, e.CellBounds, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attr);

                e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~(DataGridViewPaintParts.Background | DataGridViewPaintParts.SelectionBackground)));
                e.Handled = true;

                ////DebugPrint(this.ToString() + " this.SelectedRows.Count > 0 && this.SelectedRows.Contains(this.Rows[e.RowIndex])");
            }
        }

        //ColumnClicked, RowClicked 


        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {

            SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        protected override void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {

            SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
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

                    ////DebugPrint(String.Format("Komorka nr: {0} {1}{2}", i, x, y));
                    cell.Value = String.Format("Komorka nr: {0} {1}{2}", i, x, y);



                    //       WspKom.Add(new Point(cell.RowIndex, cell.ColumnIndex));
                }
                this[LeftUpper.X, LeftUpper.Y].Value = ("Komorka LeftUpper");
                this[RightLower.X, RightLower.Y].Value = ("Komorka RightLower");

                //    Invalidate(false);



                ////DebugPrint(String.Format("Aktualna komorka: {0}{1}", CurrentCell.RowIndex, CurrentCell.ColumnIndex));


                //         Point Punkt = new Point();

                ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false);
                /*
                                Punkt.X = (CurrentCell.ColumnIndex +1) * RowHe ;
                                Punkt.Y = (CurrentCell.RowIndex +1) * CurrentCell.Size.Height ;
                                */

                e.Graphics.DrawRectangle(_pen, new Rectangle(ramka.Location, CurrentCell.Size));

            }
            //DebugPrint(DateTime.Now.ToLongTimeString() + " OnPaint extraCellTable_Paint");

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

                    ////DebugPrint(String.Format("Komorka nr: {0} {1}{2}", i, x, y));
                    cell.Value = String.Format("Komorka nr: {0} {1}{2}", i, x, y);



                    //       WspKom.Add(new Point(cell.RowIndex, cell.ColumnIndex));
                }
                this[LeftUpper.X, LeftUpper.Y].Value = ("Komorka LeftUpper");
                this[RightLower.X, RightLower.Y].Value = ("Komorka RightLower");

                //    Invalidate(false);



                ////DebugPrint(String.Format("Aktualna komorka: {0}{1}", CurrentCell.RowIndex, CurrentCell.ColumnIndex));


                //         Point Punkt = new Point();

                ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false);
                /*
                                Punkt.X = (CurrentCell.ColumnIndex +1) * RowHe ;
                                Punkt.Y = (CurrentCell.RowIndex +1) * CurrentCell.Size.Height ;
                                */

                e.Graphics.DrawRectangle(_pen, new Rectangle(ramka.Location, CurrentCell.Size));

            }
            //DebugPrint(DateTime.Now.ToLongTimeString() + " OnPaint extraCellTable_Paint");

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
