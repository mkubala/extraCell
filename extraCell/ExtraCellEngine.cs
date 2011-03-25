using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell
{
    class ExtraCellEngine
    {
        private List<Cell[]> cells;

        public ExtraCellEngine()
        {
            cells = new List<Cell[]>(20);
            for (int i = 0; i < 20; i++)
            {
                cells.Add(new Cell[20]);
                for (int j = 0; j < 20; j++)
                {
                    cells.Last()[j] = new Cell("aloha!", "test");
                }
            }

        }

        public List<Cell[]> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public DataTable toDataTable()
        {
            DataTable dt = new DataTable();
            int rowNum = 1;

            for (int i = 0; i < 20; i++)
            {
                dt.Columns.Add();
            }

            foreach(Cell[] ct in cells)
            {
                dt.Rows.Add();
                /*for(int c = 0; c < 20; c++)
                {
                    dt.Rows[rowNum][c] = ct[c].Result;
                }
                rowNum++;*/
            }
            return dt;
        }

        public Cell getCell(int col, int row)
        {
            return cells[col][row];
        }
    }

}
