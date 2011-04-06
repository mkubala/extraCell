using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using extraCell.formula;

namespace extraCell.domain
{
    class ExtraCellEngine : DataTable
    {
        public ExtraCellEngine()
        {
            for(int i = 0; i < 65; i++)
                addColumn();
            
            addRow();
            addRow();
            
            // przykladowe dane (akurat testowałem translacje alfanumeryczna na indeksy)
            setCell(0, 0, helpers.Helpers.getColumnNumber("A").ToString());
            setCell(1, 0, helpers.Helpers.getColumnNumber("B").ToString());
            setCell(2, 0, helpers.Helpers.getColumnNumber("C").ToString());
            setCell(3, 0, "=\"Witaj Świecie!\"");
            setCell(4, 0, "=argtest(Lipa, Świerk, Brzoza)");

            String alphaCol = "AB";
            int intCol = helpers.Helpers.getColumnNumber(alphaCol);
            setCell(intCol, 0, new Cell("", intCol));

            setCell(5, 0, getCell(alphaCol+"0"));

            setCell(6, 0, "=about()");
            setCell(7, 0, "=\"Hello World\"");

        }

        public Cell getCell(int col, int row)
        {
            return (Cell)this.Rows[row][col];
        }

        public Cell getCell(String str)
        {
            int[] coords = helpers.Helpers.getCoords(str);
            return getCell(coords[0], coords[1]);
        }

        public void setCell(int col, int row, Cell value)
        {
            this.Rows[row][col] = value;
        }

        public void setCell(int col, int row, String formula)
        {
            setCell(col, row, new Cell(formula, Formula.eval(formula)));
        }

        public void addColumn()
        {
            this.Columns.Add(helpers.Helpers.getColumnName(Columns.Count+1), System.Type.GetType("extraCell.domain.Cell"));
        }

        public void addRow()
        {
            DataRow dr = NewRow();
            
            this.Rows.Add(dr);
        }
     
    }

}
