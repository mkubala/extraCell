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
            Regex re = new Regex("^=(?<formula>.+)", RegexOptions.IgnoreCase);
            Match m = re.Match(formula);
            if (m.Success)
            {
                String formulaString = m.Groups["formula"].Value.ToString();
                re = new Regex("^(?<function>.+)\\((?<args>.*)\\)");
                Match f = re.Match(formulaString);
                if (f.Success)
                {
                    String func = f.Groups["function"].Value.ToString();
                    Type p = System.Type.GetType("extraCell.formula.functions." + func.ToLower());
                    if (typeof(IFormula).IsAssignableFrom(p))
                    {
                        IFormula obj = (IFormula) Activator.CreateInstance(p);
                        return obj.run(f.Groups["args"].Value.ToString());
                    }
                    else
                    {
                        return "BŁĄD: nieznana funkcja";
                    }
                    
                }
                else
                {
                    re = new Regex("^\"(?<text>.*)\"$");
                    f = re.Match(formulaString);
                    if (f.Success)
                        return f.Groups["text"].Value.ToString();
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
