using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace extraCell
{
    class CustomDataGridViewCell : DataGridViewTextBoxCell
    {
        private System.Windows.Forms.DataGridViewAdvancedBorderStyle _style;

        public CustomDataGridViewCell()
            : base()
        {
            _style = new DataGridViewAdvancedBorderStyle();
            
            _style.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            _style.Top = DataGridViewAdvancedCellBorderStyle.InsetDouble;
            _style.Left =  DataGridViewAdvancedCellBorderStyle.InsetDouble;
            _style.Right = DataGridViewAdvancedCellBorderStyle.InsetDouble;
        }

        public DataGridViewAdvancedBorderStyle AdvancedBorderStyle
        {
            get { return _style; }
            set
            {
                _style.Bottom = value.Bottom;
                _style.Top = value.Top;
                _style.Left = value.Left;
                _style.Right = value.Right;
            }
        }

        protected override void PaintBorder(Graphics graphics, Rectangle clipBounds, Rectangle bounds, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            base.PaintBorder(graphics, clipBounds, bounds, cellStyle, _style);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, _style, paintParts);
        }

    }


    public class DataGridViewCustomColumn: DataGridViewColumn
    {
        public DataGridViewCustomColumn()
        {
            CustomDataGridViewCell templ = new CustomDataGridViewCell();
            this.CellTemplate = new CustomDataGridViewCell();
        }
    }
}
