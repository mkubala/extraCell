using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.formula.functions
{
    class konkatenacja : IFunction {
        public Object run(Object[] args)
        {
            StringBuilder res = new StringBuilder();
            foreach (Object arg in args)
            {
                res.Append(arg.ToString());
            }
            return res.ToString();
        }

        public string getHelp()
        {
            return "Funkcja dokonuje konkatenacji ciągów (łączy argumenty w jeden napis).";
        }
        
        public string[] getExamples()
        {
            return new string[] { 
                "konkatenacja(\"Ala\"+\" ma \"+\"kota\")",
                "konkatenacja(A1:B3)",
                "konkatenacja(3, \"d\")"
            };
        }

    }
}
