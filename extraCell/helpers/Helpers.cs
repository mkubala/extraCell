using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace extraCell.helpers
{
    class Helpers
    {
        public static int getColumnNumber(String str)
        {
            int len = str.Length, pos = 0 , num = 0;

            foreach (char ch in str.ToUpper())
                num += (Convert.ToInt32(ch)-65) * (pos++ * 26 + 1);

            return num;
        }

        public static String getColumnName(int num)
        {
            int div = num, mod;
            string res = String.Empty;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                res = Convert.ToChar(65 + mod).ToString() + res;
                div = (int)((div - mod) / 26);
            }

            return res;
        }

        public static int[] getCoords(String exp)
        {
            Regex re = new Regex("(?<col>[A-Z]+)(?<row>[0-9]+)");
            Match m = re.Match(exp.ToUpper());

            if (m.Success)
            {
                return new int[]{ getColumnNumber(m.Groups["col"].Value), Convert.ToInt32(m.Groups["row"].Value) };
            }
            else
            {
                //obsluga bledu tutej
                return new int[] { -1, -1 };
            }
        }
    }
}
