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
        public static IEngine ece { set; get; }
        
        public static String eval(String formula)
        {
            Debug.Print("EVAL");
            Regex re = new Regex("^=(?<formula>.+)$");
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

            /* Important! Order of occurrences matters! */
            re = new Regex("^(?<function>[a-zA-Z_]+)\\((?<args>.*)\\)$", RegexOptions.IgnoreCase);
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

            re = new Regex("[0-9]+", RegexOptions.IgnorePatternWhitespace);
            m = re.Match(formula);
            if (m.Success)
                return formula.Trim();

            return "Nie znaleziono wzorca dla " + formula;
        }

        private static Object evalFunction(Match m) {
            String func = m.Groups["function"].Value.ToString();
            Type p = System.Type.GetType("extraCell.formula.functions." + func.ToLower());

            if (typeof(extraCell.formula.IFunction).IsAssignableFrom(p))
            {
                LinkedList<Object> argList = new LinkedList<Object>();
                string args = m.Groups["args"].Value.ToString();

                System.Diagnostics.Debug.WriteLine("Formula.evalFunction args = " + args);

                StringBuilder tmp = new StringBuilder();
                int cnt = 0;
                if (args.Length > 0)
                {
                    Regex regOpen = new Regex(@"\(", RegexOptions.Compiled);
                    Regex regClose = new Regex(@"\)", RegexOptions.Compiled);
                    foreach (string arg in args.Split(','))
                    {
                        cnt += regOpen.Matches(arg).Count;
                        cnt -= regClose.Matches(arg).Count;
                        tmp.Append(arg.Trim());
                        tmp.Append(',');
                        if(cnt != 0) continue;
                        System.Diagnostics.Debug.WriteLine("proceed formula args = " + tmp.ToString().TrimEnd(','));
                        argList.AddLast(proceedFormula(tmp.ToString().TrimEnd(',')));
                        tmp = new StringBuilder();
                    }
                }
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
            int rowStart = Convert.ToInt32(m.Groups["rowStart"].Value) - 1;
            int width = helpers.Helpers.getColumnNumber(m.Groups["colEnd"].Value) - colStart + 1;
            int height = Convert.ToInt32(m.Groups["rowEnd"].Value) - rowStart;

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
