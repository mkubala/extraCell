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
