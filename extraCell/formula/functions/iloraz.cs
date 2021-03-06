﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class iloraz : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = 0d;


            double[] x = new double[2];

            if (args.Count() == 2)
            {
                for (int i = 0; i < 2; i++)
                    x[i] = Convert.ToDouble((args[i].ToString().Trim()).Replace('.', ','));

                res = (Convert.ToDouble(x[0]) /  Convert.ToDouble(x[1]));
            }
            else
            {
                return "###";
            }

            return res.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca wynik dzielenia pierwszego argumentu przez drugi";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "iloraz(9,3)",
                "iloraz(A2, B2)",
                "iloraz(4.2, 2.1)"
            };
        }

    }
}
