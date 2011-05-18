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
    class ExtraCellTable : DataGridView
    {
//        private System.Data.DataTable _Engine;
//        private bool CellEntered = false;
        public bool changed { get; set; }
        public TextBox inputBox { get; set; }

        public extraCell.domain.IEngine ece { get; set; }

        private bool ColumnClicked = false, RowClicked = false;

        //[BrowsableAttribute(false)]
        public DataGridViewSelectedCellCollection LastSelectedCells;
        public Point LastCellAddress;


        public ExtraCellTable()
            : base()
        {
            changed = false;
            inputBox = new TextBox();
            //ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            // RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
//            GridColor = Color.Coral;
            this.AllowUserToAddRows = false;

            EnableHeadersVisualStyles = true;
            ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;

            ece = new extraCell.domain.ExtraCellEngine();
            this.DataSource = ece;

            /* przeniesione z Form1.cs/AddTab() */
            this.Size = new System.Drawing.Size(552, 270);
            this.Location = new System.Drawing.Point(3, 3);
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(3, 3);
            this.RowHeadersWidth = 50;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Size = new System.Drawing.Size(552, 270);

            /*for (int i = 0; i < 255; i++)
            {
                ece.addColumn();
                ece.addRow();
            }*/
        }


        /*
         * Zrodlo : http://www.danielsoper.com/programming/DataGridViewNumberedRows.aspx
         */
        // Numerowanie wierszy
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            Brush b = SystemBrushes.ControlText;

            if (this.RowHeadersWidth < (int)(size.Width + 5)) 
                this.RowHeadersWidth = (int)(size.Width + 5);

            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

            base.OnRowPostPaint(e);
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

            //this.InvalidateCell(e.ColumnIndex, e.RowIndex);

            inputBox.Text = ece.getCell(CurrentCellAddress.X, CurrentCellAddress.Y).formula.ToString();

            return;

/*            PaintEventHandler t = new PaintEventHandler(extraCellTable_Paint);
            if (!CellEntered)
            {

                Paint += t;
                CellEntered = true;
            }*/

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
            // rzuca wyjątkami :(
            //SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        protected override void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            // rzuca wyjątkami :(
            //SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        void extraCellTable_Paint(object sender, PaintEventArgs e)
        {
            return;
/*
            Pen _pen = new Pen(Color.Black, 3);
            Rectangle ramka;

            // Wspolrzedne punktow
            Point LeftUpper = new Point(int.MaxValue, int.MaxValue);
            Point RightLower = new Point(0, 0);

            //TODO
            //  return;

            if (LastSelectedCells == null) LastSelectedCells = SelectedCells;

            if (LastCellAddress == null) LastCellAddress = CurrentCellAddress;

            if (CurrentCell != null && true */ /* ( LastCellAddress.X != CurrentCellAddress.X || LastCellAddress.Y != CurrentCellAddress.Y ) *//*)
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

                ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false); */
                /*
                                Punkt.X = (CurrentCell.ColumnIndex +1) * RowHe ;
                                Punkt.Y = (CurrentCell.RowIndex +1) * CurrentCell.Size.Height ;
                                */
            /*
                e.Graphics.DrawRectangle(_pen, new Rectangle(ramka.Location, CurrentCell.Size));

            }
            //DebugPrint(DateTime.Now.ToLongTimeString() + " OnPaint extraCellTable_Paint");

            // Paint -= new PaintEventHandler(extraCellTable_Paint);
            */
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            base.OnPaint(e);

            return;
            /*
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

                ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false);*/
                /*
                                Punkt.X = (CurrentCell.ColumnIndex +1) * RowHe ;
                                Punkt.Y = (CurrentCell.RowIndex +1) * CurrentCell.Size.Height ;
                                */
            /*
                e.Graphics.DrawRectangle(_pen, new Rectangle(ramka.Location, CurrentCell.Size));

            }
            //DebugPrint(DateTime.Now.ToLongTimeString() + " OnPaint extraCellTable_Paint");

            e.Graphics.Flush();

            ramka = GetCellDisplayRectangle(CurrentCell.ColumnIndex, CurrentCell.RowIndex, false);
            e.Graphics.DrawRectangle(_pen, new Rectangle(ramka.Location, CurrentCell.Size));*/
        }

        /*protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
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
        }*/

        /*void CellMouseMoveCross(object sender, DataGridViewCellMouseEventArgs e)
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

        }*/

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraCellTable));
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ExtraCellTable
            // 
            resources.ApplyResources(this, "$this");
            this.CausesValidation = false;
            this.ShowEditingIcon = false;
            this.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.ExtraCellTable_CellStateChanged);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void ExtraCellTable_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            changed = true;
        }

    }
}
