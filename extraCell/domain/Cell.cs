using System;

namespace extraCell.domain
{
    public class Cell
    {
        public String formula { get; set; }

        public String result { get; set; }

        public Cell() { }

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
            //return extraCell.formula.Formula.eval(this.formula);
            return this.result;
        }

    }
}
