using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.formula.functions
{
    class print : IFunction
    {
        public Object run(Object[] args)
        {
            return "Print() = " + args[0].ToString();
        }
    }
}
