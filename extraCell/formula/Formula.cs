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
    public class Formula
    {
        public IEngine ece { set; get; }

        public Formula() { }
        
        public Formula(IEngine e) 
        {
            this.ece = e;
        }
        
        public String eval(String formula)
        {
            Regex re = new Regex("^=(?<formula>.+)$");
            Match m = re.Match(formula);
            if (m.Success)
            {
                return (String)proceedFormula(m.Groups["formula"].Value.ToString());
            }
            return formula;
        }

        private Object proceedFormula(String formula)
        {
            Regex re = null;
            Match m = null;

            re = new Regex(@"^[a-zA-Z_0-9]+[\+\-\*/][a-zA-Z_0-9]+", RegexOptions.IgnorePatternWhitespace);
            m = re.Match(formula);
            if (m.Success)
                return evalAlgebra(m);

            /* Important! Order of occurrences matters! */
            re = new Regex(@"^(?<function>[a-zA-Z_]+)\((?<args>.*)\)$", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if (m.Success)
                return evalFunction(m);

            re = new Regex(@"(?<colStart>[A-Z]+)(?<rowStart>[0-9]+):(?<colEnd>[A-Z]+)(?<rowEnd>[0-9]+)", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if(m.Success)
                return evalAddrRange(m);

            re = new Regex(@"(?<col>[A-Z]+)(?<row>[0-9]+)", RegexOptions.IgnoreCase);
            m = re.Match(formula);
            if (m.Success)
                return evalAddr(m);

            re = new Regex(@"[0-9]+", RegexOptions.IgnorePatternWhitespace);
            m = re.Match(formula);
            if (m.Success)
                return formula.Trim();

            return "=" + formula;
        }

        private Object evalAlgebra(Match m)
        {
            return "Algebra coming soon"; //temporary
        }

        private Object evalFunction(Match m) {
            String func = m.Groups["function"].Value.ToString();
            Type p = System.Type.GetType("extraCell.formula.functions." + func.ToLower());

            if (typeof(extraCell.formula.IFunction).IsAssignableFrom(p))
            {
                /*LinkedList<Object> argList = new LinkedList<Object>();
                string args = m.Groups["args"].Value.ToString();

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
                        argList.AddLast(proceedFormula(tmp.ToString().TrimEnd(',')));
                        tmp = new StringBuilder();
                    }
                }*/
                try
                {
                    IFunction obj = (IFunction)Activator.CreateInstance(p);
                    return obj.run(getArgs(m).ToArray());
                }
                catch (Exception)
                {
                    return "###";
                }
            }
            else
            {
                if (func != null)
                    return "BŁĄD: nieznana funkcja " + func.ToLower();
                else
                    return "BŁĄD: brak nazwy funkcji";
            }
        }

        private Object evalAddrRange(Match m)
        {
            int colStart = helpers.Helpers.getColumnNumber(m.Groups["colStart"].Value);
            int rowStart = Convert.ToInt32(m.Groups["rowStart"].Value) - 1;
            int width = helpers.Helpers.getColumnNumber(m.Groups["colEnd"].Value) - colStart + 1;
            int height = Convert.ToInt32(m.Groups["rowEnd"].Value) - rowStart;

            StringBuilder res = new StringBuilder("");

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    res.Append(ece.getCell(colStart + i, rowStart + j).result.ToString());
                    res.Append(",");
                }
            }

            return res.ToString().TrimEnd(',');
        }

        private Object evalAddr(Match m)
        {
            int col = helpers.Helpers.getColumnNumber(m.Groups["col"].Value);
            int row = Convert.ToInt32(m.Groups["row"].Value);
            try
            {
                return ece.getCell(col, row).result.ToString();
            }
            catch (NullReferenceException)
            {
                return "###";
            }
        }

        /* this functions returning collection of arguments passed to a function */
        private LinkedList<Object> getArgs(Match m)
        {
            LinkedList<Object> argList = new LinkedList<Object>();
            string args = m.Groups["args"].Value.ToString();

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
                    if (cnt != 0) continue;
                    argList.AddLast(proceedFormula(tmp.ToString().TrimEnd(',')));
                    tmp = new StringBuilder();
                }
            }
            return argList;
        }
    }
}
