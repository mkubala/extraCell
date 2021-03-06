﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class suma : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = 0d;
            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {
                    foreach (String s in arg.ToString().Split(','))
                        res += Convert.ToDouble(s.Trim().Replace('.',','));
                }
                else
                {
                    return "###";
                }

            return res.ToString();
        }

        public string getHelp()
        {
            return "Funkcja zwraca największą wartość.";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "suma(2,3)",
                "suma(A3:F13)",
                "suma(0.0000010, 4.42, 423.65, 22.1)"
            };
        }
    }
}
