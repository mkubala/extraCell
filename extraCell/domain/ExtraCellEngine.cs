using System;
using System.Data;
using System.Text;
using extraCell.formula;
using extraCell;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace extraCell.domain
{
    class ExtraCellEngine : DataTable, IEngine
    {
        private Formula formulaProc;

        public ExtraCellEngine() : base("arkusz") { initialize(); }
        public ExtraCellEngine(string name) : base(name) { initialize(); }

        private void initialize()
        {
            formulaProc = new Formula(this);
        }

        public Cell getCell(int col, int row)
        {
            try
            {
                if (!typeof(extraCell.domain.Cell).IsAssignableFrom(Rows[row][col].GetType()))
                    setCell(col, row, "");
                return (Cell)this.Rows[row][col];
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("getCell FAIL, col = " + col + ", row = " + row);
                return new Cell();
            }
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
            setCell(col, row, new Cell(formula, formulaProc.eval(formula)));
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
            //WriteXml(filename, XmlWriteMode.WriteSchema);
            WriteXml(filename, false);
        }

        public void importXML(string filename)
        {
            try
            {
                ReadXml(filename);
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Nie znaleziono pliku " + filename);
            }
            catch (FileLoadException)
            {
                throw new FileLoadException("Nie udało się załadować pliku " + filename);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("To nie jest prawidłowy dokument programu eXtraCell!");
            }
        }

        public LinkedList<Point> search(string expression)
        {
            LinkedList<Point> res = new LinkedList<Point>();
            for(int i = 0; i < Columns.Count; i++) 
            {
                for(int j = 0; j < Rows.Count; j++) 
                {
                    if (((Cell)this.Rows[j][i]).result.ToUpper().Contains(expression.ToUpper()))
                        res.AddLast(new Point(i, j));
                }
            }
            return res;
        }

        public void fill() 
        {
            while (Rows.Count <= 255)
                addRow();
            while (Columns.Count <= 255)
                addColumn();
        }

    }

}
