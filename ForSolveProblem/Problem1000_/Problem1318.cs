using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForSolveProblem
{
    public class Problem1318 : IProblem
    {
        public void RunProblem()
        {
            var temp = MinFlips(2, 6, 5);
            if (temp != 3) throw new Exception();

            temp = MinFlips(4, 2, 7);
            if (temp != 1) throw new Exception();

            temp = MinFlips(1, 2, 3);
            if (temp != 0) throw new Exception();
        }

        public int MinFlips(int a, int b, int c)
        {
            var forReturn = 0;

            var aArray = Convert.ToString(a, 2).ToCharArray();
            aArray = aArray.Reverse().ToArray();

            var bArray = Convert.ToString(b, 2).ToCharArray();
            bArray = bArray.Reverse().ToArray();

            var cArray = Convert.ToString(c, 2).ToCharArray();
            cArray = cArray.Reverse().ToArray();

            var numArray = new int[] { aArray.Length, bArray.Length, cArray.Length };
            var maxLength = numArray.Max();

            for (int i = 0; i < maxLength; i++)
            {
                var aNum = '0';
                if (i < aArray.Length)
                    aNum = aArray[i];

                var bNum = '0';
                if (i < bArray.Length)
                    bNum = bArray[i];

                var cNum = '0';
                if (i < cArray.Length)
                    cNum = cArray[i];

                if (cNum == '0')
                {
                    if (aNum == '1')
                        forReturn++;

                    if (bNum == '1')
                        forReturn++;
                }
                else
                {
                    if (aNum == '0' && bNum == '0')
                        forReturn += 1;
                }
            }

            return forReturn;
        }
    }
}
