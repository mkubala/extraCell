using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.formula.functions
{
    class concat : IFunction {
        public Object run(Object[] args)
        {
            StringBuilder res = new StringBuilder();
            System.Diagnostics.Debug.WriteLine("args = " + args.ToString());
            foreach (Object arg in args)
            {
                System.Diagnostics.Debug.WriteLine("arg = " + arg.ToString());
                res.Append(arg);
            }
            return res.ToString();
        }
    }
}
