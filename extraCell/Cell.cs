using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell
{
    class Cell
    {
        private String formula;
        private String result;

        public Cell() { }
        public Cell(String formula, String result)
        {
            this.formula = formula;
            this.result = result;
        }

        public String Formula
        {
            get { return formula; }
            set { formula = value; }
        }

        public String Result
        {
            get { return result; }
            set { result = value; }
        }

    }
}
