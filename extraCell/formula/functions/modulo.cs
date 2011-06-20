using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class modulo : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = 0d;


            double[] x = new double[2];

            if (args.Count() == 2)
            {
                for (int i = 0; i < 2; i++)
                    x[i] = Convert.ToDouble((args[i].ToString().Trim()).Replace('.', ','));

                res = Convert.ToDouble(x[0]) %  Convert.ToDouble(x[1]);
            }
            else
            {
                return "###";
            }

            return res.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca modulo - resztę z dzielenia.";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "modulo(2, 5)",
                "modulo(2.1, 4.4)",
                "modulo(A3, D8)"
            };
        }
    }
}
