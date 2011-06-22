using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class min : IFunction
    {
        public Object run(Object[] args)
        {

            Double min = 0;

            min = Convert.ToDouble(args[0].ToString().Trim().Replace('.', ','));

            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {

                    var akt = Convert.ToDouble(arg.ToString().Trim().Replace('.', ','));
                    if (akt < min) min = akt;

                }
                else
                {
                    return "###";
                }

            return min.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca najmniejszą wartość.";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "min(2,5,100)",
                "min(2.1, 4.4, 0.99973)",
                "min(A3:D8)"
            };
        }
    }
}
