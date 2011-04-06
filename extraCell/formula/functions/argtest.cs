using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.formula.functions
{
    class argtest : IFormula
    {
        public String run(String arg)
        {
            return "Arg = " + arg;
        }
    }
}
