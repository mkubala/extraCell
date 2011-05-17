using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using extraCell.formula;
using extraCell;
using System.Diagnostics;

namespace extraCell.domain
{
    class ExtraCellEngine : DataTable, IEngine
    {
        public ExtraCellEngine() : base("arkusz") {}
        public ExtraCellEngine(string name) : base(name)
        {
            /* Debug by hwast */
            /*addColumn();
            addRow();
            addRow();
            addRow();
            setCell(0, 0, "1");
            setCell(0, 1, "9");
            setCell(0, 2, "3");
            extraCell.formula.Formula.ece = this;

            Debug.Print(extraCell.formula.Formula.eval("=print(suma(suma(A0:A2),A0))"));*/
            /* debug by hwast koniec */

            /*for(int i = 0; i < 65; i++)
                addColumn();
            
            addRow();
            addRow();
            
            // przykladowe dane (akurat testowałem translacje alfanumeryczna na indeksy)
            setCell(0, 0, new Cell("formula", helpers.Helpers.getColumnNumber("A").ToString()));
            setCell(1, 0, new Cell("formula", helpers.Helpers.getColumnNumber("B").ToString()));
            setCell(2, 0, new Cell("formula", helpers.Helpers.getColumnNumber("C").ToString()));
            setCell(4, 0, new Cell("formula", helpers.Helpers.getColumnNumber("e").ToString()));

            String alphaCol = "AB";
            int intCol = helpers.Helpers.getColumnNumber(alphaCol);
            setCell(intCol, 0, new Cell("formula", intCol));

            setCell(5, 0, getCell(alphaCol+"0"));

            setCell(6, 0, "=about(marian)");
            extraCell.formula.Formula.ece = this;
            System.Diagnostics.Debug.Print(extraCell.formula.Formula.eval("=\"test\""));
            */
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

        public void exportXML(string filename)
        {
            this.WriteXml(filename, XmlWriteMode.WriteSchema, true);
        }

        public void importXML(string filename)
        {
            this.ReadXml(filename);
        }
    }

}
