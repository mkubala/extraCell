using System;
using System.Data;
using System.Text;
using extraCell.formula;
using extraCell;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using extraCell.helpers;
using System.Text.RegularExpressions;

namespace extraCell.domain
{
    public class ExtraCellEngine : DataTable, IEngine
    {
        public Formula formulaProc {set; get; }

        public ExtraCellEngine() : base("arkusz") { initialize(); }
        public ExtraCellEngine(string name) : base(name) { initialize(); }

        private void initialize()
        {
            formulaProc = new Formula(this);
        }

        public Cell getCell(int col, int row)
        {
            return getCell(col, row, true);
        }

        public Cell getCell(int col, int row, bool create)
        {
            try
            {
                if (create && !typeof(extraCell.domain.Cell).IsAssignableFrom(Rows[row][col].GetType()))
                    setCell(col, row, "");
                else if (!create && !typeof(extraCell.domain.Cell).IsAssignableFrom(Rows[row][col].GetType()))
                    return null;
                return (Cell)this.Rows[row][col];
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.GetType().FullName + ": " + e.Message + "getCell FAIL, col = " + col + ", row = " + row);
                return new Cell();
            }
        }

        public Cell getCell(String str)
        {
            int[] coords = Helpers.getCoords(str);
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
            this.Columns.Add(Helpers.getColumnName(Columns.Count+1), System.Type.GetType("extraCell.domain.Cell"));
        }

        public void addRow()
        {
            DataRow dr = NewRow();
            this.Rows.Add(dr);
        }

        public void exportXML(string filename)
        {
            WriteXml(filename, XmlWriteMode.WriteSchema);
            //WriteXml(filename, false);
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

        public void fill() 
        {
            while (Rows.Count <= 255)
                addRow();
            while (Columns.Count <= 255)
                addColumn();
        }

        public LinkedList<int[]> search(string query, RegexOptions options)
        {
            LinkedList<int[]> res = new LinkedList<int[]>();

            Regex reg = new Regex(query, options);
            Match m;
            Cell cell;

            for(int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Columns.Count; j++)
                {
                    cell = getCell(j, i, false);
                    if (cell != null && cell.result != null && cell.result.Trim().Length != 0)
                    {
                        m = reg.Match(cell.result);
                        if (m.Success)
                        {
                            res.AddLast(new int[] { i, j });
                        }
                    }
                }
            }

            return res;
        }

    }

}
