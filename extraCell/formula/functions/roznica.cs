using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class roznica : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = Convert.ToDouble(args[0].ToString().Trim().Replace('.', ','));

           for (int i=1;i<args.Count();i++)
           {
                if (args[i].ToString().Length > 0)
                {
                    //   foreach (String s in arg.ToString().Split(','))
                    //res -= Convert.ToDouble(s.Trim().Replace('.', ','));

                    var akt = Convert.ToDouble(args[i].ToString().Trim().Replace('.', ','));

                    res -= akt;
                }
           
                
                else
                {
                    return "###";
                }
        }
            return res.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca wynik odejmowania.";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "roznica(10, 2)",
                "roznica(2.1, 4.4, 0.99973)",
                "roznica(200,2,7,8,34,6,3)"
            };
        }
    }
}
