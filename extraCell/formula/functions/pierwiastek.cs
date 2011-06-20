using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class pierwiastek : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = 0d;


            double x = new double();

            if (args.Count() == 1)
            {

                x = Convert.ToDouble((args[0].ToString().Trim()).Replace('.', ','));

                res = Math.Sqrt(Convert.ToDouble(x));
            }
            else
            {
                return "###";
            }

            return res.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca wartość pierwiastka kwadratowego.";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "pierwiastek(9)"
            };
        }
    }
}
