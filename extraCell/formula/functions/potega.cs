using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class potega : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = 0d;


            double[] x = new double[2];

            if (args.Count() == 2)
            {
                for (int i = 0; i < 2; i++)
                    x[i] = Convert.ToDouble((args[i].ToString().Trim()).Replace('.', ','));

                res = Math.Pow(Convert.ToDouble(x[0]), Convert.ToDouble(x[1]));
            }
            else
            {
                return "###";
            }

            return res.ToString();
        }


        public string getHelp()
        {
            return "Funkcja przyjmuje 2 argumenty i zwraca wartość potęgi. Pierwszy argument stanowi podstawę, kolejny - wykładnik";
        }

        public string[] getExamples()
        {
            return new string[] { 
                "potega(2,2)",
                "potega(3,2)",
            };
        }
    }
}
