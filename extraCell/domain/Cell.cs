using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using extraCell.helpers;
using System.Collections.Generic;

namespace extraCell.domain
{
    [TypeConverter(typeof(CellClassConverter))]
    public class Cell
    {
        public String formula { get; set; }
        public String result { get; set; }

        public Cell() { }

        public Cell(string value)
        {
            this.formula = value;
            this.result = ((extraCell.view.MDIUI)Application.OpenForms[0]).activeDocument.extraCellTable.ece.eval(value);
        }

        public Cell(String formula, String result)
        {
            this.formula = formula;
            this.result = result;
        }

        public Cell(String formula, int result)
        {
            this.formula = formula;
            this.result = result.ToString();
        }

        public Cell(String formula, double result)
        {
            this.formula = formula;
            this.result = result.ToString();
        }

        /*
         * funkcja toString odpowiada za przekazanie danych komórki do wyswietlenia w widoku tabeli
         */
        public override string ToString()
        {
            return this.result;
        }

    }
}
