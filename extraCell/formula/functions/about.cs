using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.formula.functions
{
    class about : IFormula
    {
        public String run(String args)
        {
            return "by: Marcin Kubala, Michał Urbańczyk, Paweł Ochalik";
        }
    }
}
