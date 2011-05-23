using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace extraCell.view
{
    class ExtraCellCustomCell : DataGridViewTextBoxCell
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
            entered = true;
/*            if (helpers.Helpers.mainWindow.getCurrentDoc().extraCellTable.isEditing)
                Value = helpers.Helpers.mainWindow.getCurrentDoc().extraCellTable.ece.getCell(ColumnIndex, RowIndex).result;*/
            base.OnEnter(rowIndex, throughMouseClick);
            
        }
        
        protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            if (helpers.Helpers.mainWindow.getCurrentDoc().extraCellTable.isEditing)
                this.Value = helpers.Helpers.mainWindow.getCurrentDoc().extraCellTable.ece.getCell(e.ColumnIndex, e.RowIndex).formula;
            base.OnDoubleClick(e);
        }

        protected override void OnLeave(int rowIndex, bool throughMouseClick)
        {
            base.OnLeave(rowIndex, throughMouseClick);
            entered = false;
//            helpers.Helpers.mainWindow.getCurrentDoc().extraCellTable.ece.setCell(ColumnIndex, rowIndex, new extraCell.domain.Cell(this.Value.ToString()));
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

        /*protected override void OnClick(DataGridViewCellEventArgs e)
        {
            //DO NOTHING (disable base class event handler)
        }*/

        /*protected override void OnDoubleClick(DataGridViewCellEventArgs e)
        {
            base.OnDoubleClick(e);
        }*/

    }
}
