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

            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {
                    
                    String [] sp = arg.ToString().Split(',');

                    max = Convert.ToDouble(sp[0].Trim().Replace('.', ','));

                    for (int i=1;i< sp.Count();i++)
                    {
                        var akt = Convert.ToDouble(sp[i].Trim().Replace('.', ','));
                        max = (akt > max) ? akt : max;
                    }
                }
                else
                {
                    return "###";
                }

            return max.ToString();
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
