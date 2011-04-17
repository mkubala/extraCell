using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.domain
{
    interface IEngine
    {
        Cell getCell(int col, int row);
        Cell getCell(String str);
        void setCell(int col, int row, Cell value);
        void setCell(int col, int row, String formula);
        void addColumn();
        void addRow();
    }
}
