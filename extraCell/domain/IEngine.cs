using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace extraCell.domain
{
    public interface IEngine
    {
        formula.Formula getFormula();
        Cell getCell(int col, int row);
        Cell getCell(String str);
        void setCell(int col, int row, Cell value);
        void setCell(int col, int row, String formula);
        void addColumn();
        void addRow();

        void exportXML(string filename);
        void importXML(string filename);
        void fill();

        LinkedList<int[]> search(string query, RegexOptions options);
    }
}
