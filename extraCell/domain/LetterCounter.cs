using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* DEPRECATED!
 * Use helper class instead of it [mkubala] */

namespace extraCell
{
    class LetterCounter
    {
        private String lett;
        private int counter;

        public int Counter
        {
            get { return counter; }
        }
        private int [] counters = new int[4];

        public LetterCounter()
        {
            lett = "A";
            counter = 1;
        }
        private void ToLetter()
        {

            lett = "";
        }
        public override string ToString()
        {
            return lett;
        }
        public void Increment()
        {
            

            int quotient = 0;

            Stack <int> stos = new Stack <int>();

            counters = new int[4];

            StringBuilder sbuild = new StringBuilder(4);

            int tmp = Counter;

            while (tmp >= 26)
            {
                quotient = tmp / 26;
                stos.Push(tmp % 26);
                tmp = quotient-1;
            }
            stos.Push(tmp);

            // ilosc elementow stosu zmienia sie w czasie dzialania petli!
            int il = stos.Count();
            for (int i = 0; i < il; i++)
            {

                counters[i] = stos.Pop();
                sbuild.Append(Convert.ToChar(65 + counters[i]));
            }
            lett = sbuild.ToString();
            counter++;
        }

    }
}
