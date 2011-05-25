using System;
using System.Data;
using System.Text;
using extraCell.formula;
using extraCell;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;

namespace extraCell.domain
{
    public class ExtraCellEngine : DataTable, IEngine
    {
        public ExtraCellEngine() : base("arkusz") { initialize(); }
        public ExtraCellEngine(string name) : base(name) { initialize(); }
        public Boolean isModified { get; set; }

        private void initialize() { isModified = false; }

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
            int[] coords = getCoords(str);
            return getCell(coords[0], coords[1]);
        }

        public void setCell(int col, int row, Cell value)
        {
            isModified = true;
            this.Rows[row][col] = value;
        }

        public void setCell(int col, int row, String formula)
        {
            setCell(col, row, new Cell(formula, eval(formula)));
        }

        public void addColumn()
        {
            this.Columns.Add(getColumnName(Columns.Count+1), System.Type.GetType("extraCell.domain.Cell"));
        }

        public void addRow()
        {
            DataRow dr = NewRow();
            this.Rows.Add(dr);
        }

        public int getColumnNumber(String str)
        {
            int len = str.Length, pos = 0, num = 0;

            foreach (char ch in str.ToUpper())
                num += (Convert.ToInt32(ch) - 65) * (pos++ * 26 + 1);

            return num;
        }

        public String getColumnName(int num)
        {
            int div = num, mod;
            string res = String.Empty;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                res = Convert.ToChar(65 + mod).ToString() + res;
                div = (int)((div - mod) / 26);
            }

            return res;
        }

        public int[] getCoords(String exp)
        {
            Regex re = new Regex("(?<col>[A-Z]+)(?<row>[0-9]+)");
            Match m = re.Match(exp.ToUpper());

            if (m.Success)
                return new int[] { getColumnNumber(m.Groups["col"].Value), Convert.ToInt32(m.Groups["row"].Value) - 1 };
            else
                throw new Exception("nie znaleziono wspołrzędnych");
        }

        public bool exportXML(string filename)
        {
            try
            {
                /*WriteXml(filename, XmlWriteMode.WriteSchema);*/
                Cell cell;
                System.Windows.Forms.DataGridViewCell viewCell;
                extraCell.view.ExtraCellTable ect = ((extraCell.view.MDIUI)System.Windows.Forms.Application.OpenForms[0]).activeDocument.extraCellTable;

                using (XmlWriter writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("eXtraCellDocument");

                    for (int row = 0; row < Rows.Count; row++)
                    {
                        if (ect.Rows[row].Height != 22)
                        {
                            writer.WriteStartElement("row");
                                writer.WriteAttributeString("id", row.ToString());
                                writer.WriteAttributeString("height", ect.Rows[row].Height.ToString());
                            writer.WriteEndElement();
                        }
                    }

                    for (int col = 0; col < Columns.Count; col++)
                    {
                        if (ect.Columns[col].Width != 100)
                        {
                            writer.WriteStartElement("col");
                                writer.WriteAttributeString("id", col.ToString());
                                writer.WriteAttributeString("width", ect.Columns[col].Width.ToString());
                            writer.WriteEndElement();
                        }
                    }

                    for (int row = 0; row < Rows.Count; row++)
                    {
                        for (int col = 0; col < Columns.Count; col++)
                        {
                            cell = getCell(col, row, false);
                            if (cell != null && cell.result != null && cell.result.Trim().Length != 0)
                            {
                                viewCell = ect.Rows[row].Cells[col];
                                
                                writer.WriteStartElement("cell");
                                    writer.WriteAttributeString("col", col.ToString());
                                    writer.WriteAttributeString("row", row.ToString());
                                    writer.WriteAttributeString("formula", cell.formula);
                                    writer.WriteAttributeString("result", cell.result);

                                    writer.WriteStartElement("style");
                                        writer.WriteAttributeString("bgcolor", viewCell.Style.BackColor.ToArgb().ToString());
                                        writer.WriteAttributeString("fgcolor", viewCell.Style.ForeColor.ToArgb().ToString());
                                        writer.WriteAttributeString("format", viewCell.Style.Format);
                                        writer.WriteAttributeString("align", viewCell.Style.Alignment.ToString());

                                        if (viewCell.Style.Font != null)
                                        {
                                            writer.WriteStartElement("font");
                                                writer.WriteAttributeString("family", viewCell.Style.Font.FontFamily.Name);
                                                writer.WriteAttributeString("bold", viewCell.Style.Font.Bold.ToString());
                                                writer.WriteAttributeString("italic", viewCell.Style.Font.Italic.ToString());
                                                writer.WriteAttributeString("underline", viewCell.Style.Font.Underline.ToString());
                                                writer.WriteAttributeString("strikeout", viewCell.Style.Font.Strikeout.ToString());
                                                writer.WriteAttributeString("size", viewCell.Style.Font.Size.ToString());
                                                writer.WriteAttributeString("gdicharset", viewCell.Style.Font.GdiCharSet.ToString());
                                                writer.WriteAttributeString("unit", viewCell.Style.Font.Unit.ToString());
                                            writer.WriteEndElement();
                                        }

                                    writer.WriteEndElement();

                                writer.WriteEndElement();
                            }
                        }
                    }
                    
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                isModified = false;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Nie udało się zapisać pliku.", "Błąd");
                return false;
            }
            return true;
        }

        public void importXML(string filename)
        {
            /*try
            {*/
                int col = 0;
                int row = 0;
                extraCell.view.ExtraCellTable ect = ((extraCell.view.MDIUI)System.Windows.Forms.Application.OpenForms[0]).activeDocument.extraCellTable;
                System.Windows.Forms.DataGridViewCell viewCell = ect.Rows[0].Cells[0];

                using (XmlReader reader = XmlReader.Create(filename))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "col":
                                    ect.Columns[Convert.ToInt32(reader["id"])].Width = Convert.ToInt32(reader["width"]);
                                    System.Diagnostics.Debug.WriteLine("set col width");
                                    break;
                                case "row":
                                    ect.Rows[Convert.ToInt32(reader["id"])].Height = Convert.ToInt32(reader["height"]);
                                    System.Diagnostics.Debug.WriteLine("set row height, " + Convert.ToInt32(reader["height"]));
                                    break;
                                case "cell":
                                    col = Convert.ToInt32(reader["col"]);
                                    row = Convert.ToInt32(reader["row"]);
                                    setCell(col, row, new Cell(reader["formula"], reader["result"]));
                                    viewCell = ect.Rows[row].Cells[col];
                                    break;
                                case "style":
                                    viewCell.Style.Format = reader["format"];
                                    viewCell.Style.BackColor = Color.FromArgb(Convert.ToInt32(reader["bgcolor"]));
                                    viewCell.Style.ForeColor = Color.FromArgb(Convert.ToInt32(reader["fgcolor"]));
                                    viewCell.Style.Alignment = (DataGridViewContentAlignment) Enum.Parse(typeof(DataGridViewContentAlignment), reader["align"]);
                                    break;
                                case "font":
                                    FontStyle fs = new FontStyle();

                                    if(Convert.ToBoolean(reader["bold"]))
                                        fs = fs|FontStyle.Bold;
                                    if(Convert.ToBoolean(reader["italic"]))
                                        fs = fs|FontStyle.Italic;
                                    if(Convert.ToBoolean(reader["regular"]))
                                        fs = fs|FontStyle.Regular;
                                    if(Convert.ToBoolean(reader["strikeout"]))
                                        fs = fs|FontStyle.Strikeout;
                                    if(Convert.ToBoolean(reader["underline"]))
                                        fs = fs|FontStyle.Underline;

                                    viewCell.Style.Font = new Font(
                                        reader["family"], 
                                        (float)Convert.ToDouble(reader["size"]), 
                                        fs, 
                                        (GraphicsUnit) Enum.Parse(typeof(GraphicsUnit), reader["unit"]),
                                        Convert.ToByte(reader["gdicharset"])
                                    );
                                    break;
                            }
                        }
                    }
                }
            /*}
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
            }*/
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


        /*** FORMUŁY ***/
        public String eval(String formula)
        {
            Regex re = new Regex("^=(?<formula>.+)$");
            Match m = re.Match(formula);
            if (m.Success)
            {
                return (String)proceedFormula(m.Groups["formula"].Value.ToString());
            }
            return formula;
        }

        private Object proceedFormula(String formula)
        {
            Regex re = null;
            Match m = null;

            re = new Regex(@"^[a-zA-Z_0-9]+[\+\-\*/][a-zA-Z_0-9]+", RegexOptions.IgnorePatternWhitespace);
            m = re.Match(formula);
            if (m.Success)
                return evalAlgebra(m);

            /* Important! Order of occurrences matters! */
            re = new Regex(@"^(?<function>[a-zA-Z_]+)\((?<args>.*)\)$", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if (m.Success)
                return evalFunction(m);

            re = new Regex(@"(?<colStart>[A-Z]+)(?<rowStart>[0-9]+):(?<colEnd>[A-Z]+)(?<rowEnd>[0-9]+)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            m = re.Match(formula);
            if (m.Success)
                return evalAddrRange(m);

            re = new Regex(@"(?<col>[A-Z]+)(?<row>[0-9]+)", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if (m.Success)
                return evalAddr(m);

            re = new Regex(@"[0-9]+", RegexOptions.IgnorePatternWhitespace);
            m = re.Match(formula);
            if (m.Success)
                return formula.Trim();

            return "=" + formula;
        }

        private Object evalAlgebra(Match m)
        {
            return "Algebra coming soon"; //temporary
        }

        private Object evalFunction(Match m)
        {
            String func = m.Groups["function"].Value.ToString();
            Type p = System.Type.GetType("extraCell.formula.functions." + func.ToLower());

            if (typeof(extraCell.formula.IFunction).IsAssignableFrom(p))
            {
                try
                {
                    LinkedList<object> linkedArgs = getArgs(m);
                    object[] arrayArgs = new object[linkedArgs.Count];
                    linkedArgs.CopyTo(arrayArgs, 0);
                    IFunction obj = (IFunction)Activator.CreateInstance(p);
                    return obj.run(arrayArgs);
                }
                catch (Exception)
                {
                    return "###";
                }
            }
            else
            {
                if (func != null)
                    return "BŁĄD: nieznana funkcja " + func.ToLower();
                else
                    return "BŁĄD: brak nazwy funkcji";
            }
        }

        private Object evalAddrRange(Match m)
        {
            int colStart = getColumnNumber(m.Groups["colStart"].Value);
            int rowStart = Convert.ToInt32(m.Groups["rowStart"].Value) - 1;
            int width = getColumnNumber(m.Groups["colEnd"].Value) - colStart + 1;
            int height = Convert.ToInt32(m.Groups["rowEnd"].Value) - rowStart;

            StringBuilder res = new StringBuilder("");

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    res.Append(getCell(colStart + i, rowStart + j).result.ToString());
                    res.Append(",");
                }
            }

            return res.ToString().TrimEnd(',');
        }

        private Object evalAddr(Match m)
        {
            int col = getColumnNumber(m.Groups["col"].Value);
            int row = Convert.ToInt32(m.Groups["row"].Value) - 1;
            try
            {
                return getCell(col, row).result.ToString();
            }
            catch (NullReferenceException)
            {
                return "###";
            }
        }

        /* this functions returning collection of arguments passed to a function */
        private LinkedList<Object> getArgs(Match m)
        {
            LinkedList<Object> argList = new LinkedList<Object>();
            string args = m.Groups["args"].Value.ToString();

            StringBuilder tmp = new StringBuilder();
            int cnt = 0;
            if (args.Length > 0)
            {
                Regex regOpen = new Regex(@"\(", RegexOptions.Compiled);
                Regex regClose = new Regex(@"\)", RegexOptions.Compiled);
                foreach (string arg in args.Split(','))
                {
                    cnt += regOpen.Matches(arg).Count;
                    cnt -= regClose.Matches(arg).Count;
                    tmp.Append(arg.Trim());
                    tmp.Append(',');
                    if (cnt != 0) continue;
                    argList.AddLast(proceedFormula(tmp.ToString().TrimEnd(',')));
                    tmp = new StringBuilder();
                }
            }
            return argList;
        }

    }

}
