using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace extraCell.formula.functions
{
    class iloczyn : IFunction
    {
        public Object run(Object[] args)
        {
            Double res = 1d;
            foreach (Object arg in args)
                if (arg.ToString().Length > 0)
                {
                    foreach (String s in arg.ToString().Split(','))
                        res = res * Convert.ToDouble(s.Trim().Replace('.', ','));
                }
                else
                {
                    return 0d;
                }

            return res.ToString();
        }
    }
}
