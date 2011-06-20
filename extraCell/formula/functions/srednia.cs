using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class srednia : IFunction
    {
        int count = 0;
        public Object run(Object[] args)
        {
            Double res = 0d;
            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {
                    foreach (String s in arg.ToString().Split(','))
                    {
                        res += Convert.ToDouble(s.Trim().Replace('.', ','));
                        count++;
                    }
                }
                else
                {
                    return "###";
                }

            return (res / count).ToString();
        }


        public string getHelp()
        {
            return "Funkcja zwraca średnia arytmetyczna wartości w zadanym zbiorze.";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "srednia(2, 3.3, 50, 12)"
            };
        }
    }
}
