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

            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {
                    
                    String [] sp = arg.ToString().Split(',');

                    min = Convert.ToDouble(sp[0].Trim().Replace('.', ','));

                    for (int i=1;i< sp.Count();i++)
                    {
                        var akt = Convert.ToDouble(sp[i].Trim().Replace('.', ','));
                        min = (akt < min) ? akt : min;
                    }
                }
                else
                {
                    return "###";
                }

            return min.ToString();
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
