using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;

using extraCell.domain;

namespace extraCell.formula
{
    class Formula
    {
        public static ExtraCellEngine ece { set; get; }
        
        //czy ten kod komuś w ogóle jest potrzebny?
        /*public bool isValidate()
        {
            return false;
        }

        public bool isEvaluate()
        {
            return false;
        }*/

        public static String eval(String formula)
        {
            Debug.Print("EVAL");
            Regex re = new Regex("^=(?<formula>.+)");
            Match m = re.Match(formula);
            if (m.Success)
            {
                return (String)proceedFormula(m.Groups["formula"].Value.ToString());
            }
            else
            {
                return formula;
            }
            return formula;
        }

        private static Object proceedFormula(String formula)
        {
            Regex re = null;
            Match m = null;

            re = new Regex("^(?<function>[A-Z_]+)\\((?<args>.*)\\)$", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if (m.Success)
                return evalFunction(m);

            re = new Regex("(?<colStart>[A-Z]+)(?<rowStart>[0-9]+):(?<colEnd>[A-Z]+)(?<rowEnd>[0-9]+)", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if(m.Success)
                return evalAddrRange(m);

            re = new Regex("(?<col>[A-Z]+)(?<row>[0-9]+)", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if (m.Success)
                return evalAddr(m);

            return "Nie znaleziono wzorca dla " + formula;
        }

        private static Object evalFunction(Match m) {
            String func = m.Groups["function"].Value.ToString();
            Type p = System.Type.GetType("extraCell.formula.functions." + func.ToLower());

            if (typeof(extraCell.formula.IFunction).IsAssignableFrom(p))
            {
                LinkedList<Object> argList = new LinkedList<Object>();
                string args = m.Groups["args"].Value.ToString();

                if (args.Length > 0)
                    foreach (String arg in args.Split(','))
                        argList.AddLast(proceedFormula(arg.Trim()));

                IFunction obj = (IFunction)Activator.CreateInstance(p);
                return obj.run(argList.ToArray());
            }
            else
            {
                if (func != null)
                    return "BŁĄD: nieznana funkcja " + func.ToLower();
                else
                    return "BŁĄD: brak nazwy funkcji";
            }
        }

        private static Object evalAddrRange(Match m)
        {
            int colStart = helpers.Helpers.getColumnNumber(m.Groups["colStart"].Value);
            int rowStart = Convert.ToInt32(m.Groups["rowStart"].Value);
            int width = helpers.Helpers.getColumnNumber(m.Groups["colEnd"].Value) - colStart + 1;
            int height = Convert.ToInt32(m.Groups["rowEnd"].Value) - rowStart + 1;

            Debug.Print("width: " + width + ", height: " + height);

            StringBuilder res = new StringBuilder("");

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    res.Append(ece.getCell(colStart + i, rowStart + j).result.ToString());
                    res.Append(",");
                }
            }

            Debug.Print(res.ToString().TrimEnd(','));

            return res.ToString().TrimEnd(',');
        }

        private static Object evalAddr(Match m)
        {
            int col = helpers.Helpers.getColumnNumber(m.Groups["col"].Value);
            int row = Convert.ToInt32(m.Groups["row"].Value);
            return ece.getCell(col, row).result.ToString();
        }

    }
}
