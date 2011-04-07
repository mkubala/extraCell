using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

namespace extraCell.formula
{
    class Formula
    {
        public bool isValidate()
        {
            return false;
        }

        public bool isEvaluate()
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
                    Type p = System.Type.GetType("extraCell.formula.functions." + func.ToLower());
                    if (typeof(extraCell.formula.IFormula).IsAssignableFrom(p))
                    {
                        IFormula obj = (IFormula) Activator.CreateInstance(p);
                        MethodInfo methodInfo = p.GetMethod("run");
                        return (String)methodInfo.Invoke(obj, new Object[] { f.Groups["args"].Value.ToString() });
                    }
                    else
                    {
                        return "BŁĄD: nieznana funkcja";
                    }
                    
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
