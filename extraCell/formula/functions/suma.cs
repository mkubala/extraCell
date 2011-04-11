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
                        res += Convert.ToDouble(s.Trim());
                }
                else
                {
                    return "###";
                }

            return res.ToString();
        }
    }
}
