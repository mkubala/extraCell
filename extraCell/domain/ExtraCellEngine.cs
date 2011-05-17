using System;
using System.Data;
using System.Text;
using extraCell.formula;
using extraCell;
using System.IO;
//using System.Diagnostics;

namespace extraCell.domain
{
    class ExtraCellEngine : DataTable, IEngine
    {
        public ExtraCellEngine() : base("arkusz") {}
        public ExtraCellEngine(string name) : base(name) {}

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
            System.Diagnostics.Debug.WriteLine(" -------------------> IN exportXML <------------------");
            this.WriteXml(filename, XmlWriteMode.WriteSchema);
        }

        public void importXML(string filename)
        {
            System.Diagnostics.Debug.WriteLine(" -------------------> IN importXML <------------------");
            try
            {
                //this.ReadXmlSchema(filename);
                this.ReadXml(filename);
            }
            catch (FileNotFoundException e)
            {
                throw new Exception("Nie znaleziono pliku " + filename);
            }
            catch (FileLoadException e)
            {
                throw new FileLoadException("Nie udało się załadować pliku " + filename);
            }
            finally
            {
                foreach(DataRow row in this.Rows) {
                    foreach (DataColumn column in this.Columns)
                    {
                        System.Diagnostics.Debug.Write("\t" + row[column]);
                    }
                    System.Diagnostics.Debug.WriteLine("");
                }
            }
        }

    }

}
