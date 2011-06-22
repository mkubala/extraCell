using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class max : IFunction
    {
        public Object run(Object[] args)
        {

            Double max = 0;

            max = Convert.ToDouble(args[0].ToString().Trim().Replace('.', ','));

            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {
                    var akt = Convert.ToDouble(arg.ToString().Trim().Replace('.', ','));
                    if (akt > max) max = akt;
                    
                }
                else
                {
                    return "###";
                }

            return max.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca największą wartość.";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "max(2,5,100)",
                "max(2.1, 4.4, 0.99973)",
                "max(A3:D8)"
            };
        }

    }
}
