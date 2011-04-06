using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace extraCell.formula
{
    class Formula
    {
        public bool Validate()
        {
            return false;
        }

        public bool Evaluate()
        {
            return false;
        }

        public static String eval(String formula)
        {
            Regex re = new Regex("^=(?<formula>.+)");
            Match m = re.Match(formula.ToUpper());
            if (m.Success)
            {
                re = new Regex("^(?<function>.+)\\((?<args>.*)\\)");
                Match f = re.Match(m.Groups["formula"].Value.ToString());
                if (f.Success)
                {
                    String func = f.Groups["function"].Value.ToString();
                    return "użyto " + func;
                }
                else
                {
                    //sprawdzanie czy to nie operacje arytmetyczne, odwolania do komorek, czy lancuchy (np. ''="cześć!"'' )
                }
            }
            else
            {
                return formula;
            }
            return formula;
        }

    }
}
