using System;
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
            string[] arr = args[0].ToString().Split(',');
            if (arr.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                    arr[i] = arr[i].Trim().Replace('.', ',');
                res = Convert.ToDouble(arr[0]) / Convert.ToDouble(arr[1]);
            }
            else
            {
                return "###";
            }

            return res.ToString();
        }
    }
}
